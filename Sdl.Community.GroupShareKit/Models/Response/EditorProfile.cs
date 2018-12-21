using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class EditorProfile
    {
	    public string ProfileId { get; set; }
	    public string Name { get; set; }
	    public List<Feature> Features { get; set; }
    }
}
