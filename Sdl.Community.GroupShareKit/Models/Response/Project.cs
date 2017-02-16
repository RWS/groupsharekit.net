using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Project
    {
        public int Count { get; set; }
        public List<ProjectDetails> Items { get; set; }
    }
}
