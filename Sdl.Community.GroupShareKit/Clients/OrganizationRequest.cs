namespace Sdl.Community.GroupShareKit.Clients
{
    public class OrganizationRequest:RequestParameters
    {
        public OrganizationRequest(bool flatten)
        {
            Flatten = flatten;
        }        

        /// <summary>
        /// Get or sets if the response is a flatten list
        /// </summary>
        /// <value>
        /// True if the list is going to be flatten
        /// </value>
        public bool Flatten { get; set; }
    }
}