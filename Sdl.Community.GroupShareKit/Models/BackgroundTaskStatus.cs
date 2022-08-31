namespace Sdl.Community.GroupShareKit.Models
{
    public enum BackgroundTaskStatus
    {
        Unknown = 0,
        Queued = 1,
        InProgress = 2,
        Canceled = 4,
        Failed = 8,
        Done = 16
    }
}
