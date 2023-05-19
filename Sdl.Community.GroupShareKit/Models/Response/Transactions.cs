using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Transactions
    {
        /// <summary>
        /// Gets or sets transaction id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets time
        /// </summary>
        public DateTime? DateTime { get; set; }
        /// <summary>
        /// Gets or sets user name
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets transaction details
        /// </summary>
        public TransactionsDetails Details { get; set; }
    }
}
