using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Http
{
    internal class SimpleJsonSerializer : IJsonSerializer
    {

        public string Serialize(object item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}