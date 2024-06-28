﻿using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplate
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
