using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Setup
{
    public class UserData
    {
        public static IEnumerable<object[]> Username =>
            new List<object[]>
            {
                new object[] { Helper.GsUser }
            };

        public static IEnumerable<object[]> UserId=>
            new List<object[]>
            {
                new object[] { Helper.GsUserId.ToString() }
            };
    }
}
