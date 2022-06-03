using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Http
{
    internal class SimpleJsonSerializer : IJsonSerializer
    {

        public string Serialize(object item)
        {

            return JsonConvert.SerializeObject(item, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}