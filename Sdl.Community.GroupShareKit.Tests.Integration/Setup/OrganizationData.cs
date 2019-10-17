using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Setup
{
    public class OrganizationData
    {
        public static IEnumerable<object[]> Organization =>
            new List<object[]>
            {
                new object[] { Helper.Organization }
            };

        public static IEnumerable<object[]> OrganizationId =>
            new List<object[]>
            {
                new object[] { Helper.OrganizationId.ToString() }
            };
        public static IEnumerable<object[]> OrganizationTag =>
            new List<object[]>
            {
                new object[] { Helper.OrganizationTag}
            };
    }
}
