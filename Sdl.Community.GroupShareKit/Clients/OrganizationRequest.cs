namespace Sdl.Community.GroupShareKit.Clients
{
    public class OrganizationRequest:RequestParameters
    {
        public OrganizationRequest(bool flatten, string tag="")
        {
            Flatten = flatten;
            Tag = tag;
        }        

        /// <summary>
        /// Get or sets if the response is a flatten list
        /// </summary>
        /// <value>
        /// True if the list is going to be flatten
        /// </value>
        public bool Flatten { get; set; }
        public string Tag { get; set; }
    }
}