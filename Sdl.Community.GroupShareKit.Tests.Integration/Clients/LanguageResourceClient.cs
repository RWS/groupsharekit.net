using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class LanguageResourceClient
    {
        [Theory]
        [InlineData("04786029-aee1-4c07-8bbf-3a6be063fb86")]
        public async Task GetLanguageResourcesForTemplate(string templateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var resources = await groupShareClient.LanguageResource.GetLanguageResourcesForTemplate(templateId);

            Assert.True(resources.Count>0);
        }

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b")]
        public async Task CreateLanguageResourceForTemplate(string templateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var request = new Test
            {
                LanguageResourceId = "163b1ac5-6bbf-4b65-bc65-1db93ebab328",
                CultureName = "ro-ro",
                Type = "Variables",
                Data = "77u/YW5kcmVhDQo=",

            };

            var id = await groupShareClient.LanguageResource.CreateLanguageResourceForTemplate(templateId, request);

            Assert.True(id!=string.Empty);

            //var resources = await groupShareClient.LanguageResource.GetLanguageResourcesForTemplate(id);

            //Assert.True(resources.Count>0);
        }
    }
}
