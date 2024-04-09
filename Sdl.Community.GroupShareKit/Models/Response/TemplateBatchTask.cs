using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TemplateBatchTask
    {
        [JsonProperty("taskTemplateIdField")]
        public string BatchTaskName { get; set; }
    }
}
