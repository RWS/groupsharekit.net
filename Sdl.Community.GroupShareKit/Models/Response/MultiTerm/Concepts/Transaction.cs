using System;
using System.Text.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Concepts
{
    public class Transaction
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DateTime { get; set; }

        public string Username { get; set; }

        public TransactionDetails Details { get; set; }
    }

    public class TransactionDetails
    {
        public string User { get; set; }

        public string Type { get; set; }
    }
}
