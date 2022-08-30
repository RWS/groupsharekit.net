using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class BackgroundTask
    {
        public Guid Id { get; set; }
        public bool IsGsTask { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? OwnerId { get; set; }
        public string Owner { get; set; }
        public Guid? ReferenceId { get; set; }
        public string Reference { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public string ResultDetails { get; set; }
    }
}
