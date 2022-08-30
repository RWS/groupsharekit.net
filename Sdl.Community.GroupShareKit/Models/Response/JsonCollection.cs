namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class JsonCollection<T>
    {
        public int Count { get; set; }
        public T[] Items { get; set; }
    }
}
