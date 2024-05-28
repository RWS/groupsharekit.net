using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// Base class for classes which represent query string parameters to certain API endpoints.
    /// </summary>
    public abstract class RequestParameters
    {
        private static readonly ConcurrentDictionary<Type, List<PropertyParameter>> PropertiesMap =
            new ConcurrentDictionary<Type, List<PropertyParameter>>();

        /// <summary>
        /// Converts the derived object into a dictionary that can be used to supply query string parameters.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, string> ToParametersDictionary()
        {
            var map = PropertiesMap.GetOrAdd(GetType(), GetPropertyParametersForType);
            return (from property in map
                    let value = property.GetValue(this)
                    let key = property.Key
                    where value != null
                    select new { key, value }).ToDictionary(kvp => kvp.key, kvp => kvp.value);
        }

        private static List<PropertyParameter> GetPropertyParametersForType(Type type)
        {
            return GetAllProperties(type)
                .Where(p => p.Name != "DebuggerDisplay")
                .Select(p => new PropertyParameter(p))
                .ToList();
        }

        private static IEnumerable<PropertyInfo> GetAllProperties(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            var properties = typeInfo.DeclaredProperties;

            var baseType = typeInfo.BaseType;

            return baseType == null ? properties : properties.Concat(GetAllProperties(baseType));
        }

        private static Func<PropertyInfo, object, string> GetValueFunc(Type propertyType)
        {
            if (typeof(IEnumerable<string>).IsAssignableFrom(propertyType))
            {
                return (prop, value) =>
                {
                    var list = ((IEnumerable<string>)value).ToArray();
                    return !list.Any() ? null : string.Join(",", list);
                };
            }

            if (IsTypeOfDateTimeOffset(propertyType))
            {
                return (prop, value) => ((DateTimeOffset?)value)?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }

            if (typeof(bool).IsAssignableFrom(propertyType))
            {
                return (prop, value) => value?.ToString().ToLowerInvariant();
            }

            if (typeof(IJsonRequest).IsAssignableFrom(propertyType))
            {
                return (prop, value) =>
                {
                    var name = prop.Name;
                    var json = string.Empty;

                    if (HasFilterOptions(name, value))
                    {
                        json = ((FilterOptions)value).Stringify();
                    }

                    if (!name.Equals("Sort", StringComparison.OrdinalIgnoreCase))
                    {
                        return json;
                    }

                    return value is SortParameters sortParameters ? sortParameters.Stringify() : json;
                };
            }

            return (prop, value) => value?.ToString();
        }

        private static bool IsTypeOfDateTimeOffset(Type propertyType)
        {
            return propertyType == typeof(DateTimeOffset) || propertyType == typeof(DateTimeOffset?);
        }

        private static bool HasFilterOptions(string name, object value)
        {
            return name.Equals("Filter", StringComparison.OrdinalIgnoreCase) && value is FilterOptions;
        }

        private class PropertyParameter
        {
            private readonly Func<PropertyInfo, object, string> _valueFunc;
            private readonly PropertyInfo _property;
            public PropertyParameter(PropertyInfo property)
            {
                _property = property;
                Key = property.Name.ToLowerInvariant();
                _valueFunc = GetValueFunc(property.PropertyType);
            }

            public string Key { get; }

            public string GetValue(object instance)
            {
                return _valueFunc(_property, _property.GetValue(instance, null));
            }
        }
    }
}
