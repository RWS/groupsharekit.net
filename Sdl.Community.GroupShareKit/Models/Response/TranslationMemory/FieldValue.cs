﻿using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FieldValue
    {
        /// <summary>
        /// Gets or sets field name
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Get or sets a list of values for a field
        /// </summary>
        public List<string> Values { get; set; }
    }
}
