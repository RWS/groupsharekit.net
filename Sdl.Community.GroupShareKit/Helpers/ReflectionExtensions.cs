using System;
using System.Reflection;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public static class ReflectionExtensions
    {
        public static bool IsAssignableFrom(this Type type, Type otherType)
        {
            return type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
        }
    }
}
