using System;
namespace Sdl.Community.GroupShareKit.Clients
{
    public class ReferenceProject
    {
        /// <summary>
        /// Gets or sets the project Id
        /// </summary>
        public Guid? ReferenceProjectId { get; set; }

        /// <summary>
        /// Gets or sets the flag to lock segments if perfect match applied
        /// </summary>
        public bool IsLocked { get; set; }
    }
}
