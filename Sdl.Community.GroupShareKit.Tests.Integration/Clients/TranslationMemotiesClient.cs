using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemotiesClient
    {
        [Fact]
        public async Task GetTms()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var tmsResponse = await groupShareClient.TranslationMemories.GetTms();

            Assert.True(tmsResponse.Items.Count>0);
        }

        [Theory]
        [InlineData("28d2843b-e038-4fa7-a5ff-bb91bd12f5a8")]
        public async Task GetTmById(string tmId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var tm = await groupShareClient.TranslationMemories.GetTmById(tmId);

            Assert.Equal(tm.Name,"Test");
        }

        [Theory]
        [InlineData("28d2843b-e038-4fa7-a5ff-bb91bd12f5a8", "2f7669f3-91a7-4c10-a689-16428b995b18")]
        public async Task GetLanguageDirectionForTm(string tmId,string languageDirectionId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var languageDirection =
                await groupShareClient.TranslationMemories.GetLanguageDirectionForTm(tmId, languageDirectionId);

            Assert.Equal(languageDirection.LanguageDirectionId,languageDirectionId);
        }

        [Theory]
        [InlineData("38d57978-0fc2-4b95-8f84-f8ca60975a10")]
        public async Task GetTmsNumberByLanguageResourceTemplateId(string id)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var tmNumber = await groupShareClient.TranslationMemories.GetTmsNumberByLanguageResourceTemplateId(id);

            Assert.True(tmNumber>0);
        }

        [Theory]
        [InlineData("e669d7d2-8ea6-4c4b-8a72-ecd7e40cf097")]
        public async Task GetTmsNumberByFieldTemplateId(string id)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var tmNumber = await groupShareClient.TranslationMemories.GetTmsNumberByFieldTemplateId(id);

            Assert.True(tmNumber > 0);
        }
    }
}
