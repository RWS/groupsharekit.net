using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
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

        [Theory]
        [InlineData("Tm from kit2")]
        public async Task CreateTm(string tmName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var tmRequest = new CreateTmRequest
            {
                TranslationMemoryId = Guid.NewGuid().ToString(),
                Name = tmName,
                LanguageDirections = new List<LanguageDirection>
                {
                    new LanguageDirection
                    {
                        LanguageDirectionId = Guid.NewGuid().ToString(),
                        Source = "en-us",
                        Target = "de-de",
                        LastReIndexSize = null,
                        LastReIndexDate = null,
                        LastRecomputeDate = null,
                        LastRecomputeSize = null
                    }
                },
                FieldTemplateId = "ec6acfc3-e166-486f-9823-3220499dc95b",
                LanguageResourceTemplateId = "78df3807-06ac-438e-b2c8-5e233df1a6a2",
                Recognizers = "RecognizeAll",
                FuzzyIndexes = "SourceWordBased,TargetWordBased",
                Location = "/SDL Community Developers",
                WordCountFlags = "DefaultFlags",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                FuzzyIndexTuningSettings = new FuzzyIndexTuningSettings
                {
                    MinScoreIncrease = 20,
                    MinSearchVectorLengthSourceCharIndex = 5,
                    MinSearchVectorLengthSourceWordIndex = 3,
                    MinSearchVectorLengthTargetCharIndex = 5,
                    MinSearchVectorLengthTargetWordIndex = 3

                },            
                ContainerId = "bb9c7d71-a7b5-46ba-9f42-47ffd41b80f7"
                

            };

            var tmId = await groupShareClient.TranslationMemories.Create(tmRequest);

            Assert.True(tmId!=string.Empty);
        }

        [Fact]
        public async Task DeleteTm()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            await groupShareClient.TranslationMemories.Delete("b7c6c496-b2ac-4615-919a-e1cec538ac83");
        }

        [Theory]
        [InlineData("95114373-f19a-4885-94a5-12d1a8c7ccb3")]
        public async Task UpdateTm(string tmId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var tm = await groupShareClient.TranslationMemories.GetTmById(tmId);

            tm.Name = "Updated tm";

            await groupShareClient.TranslationMemories.Update(tmId, tm);

            var updatedTm = await groupShareClient.TranslationMemories.GetTmById(tmId);

            Assert.Equal(updatedTm.Name, "Updated tm");

        }

        [Fact]
        public async Task GetTmServiceHealth()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var health = await groupShareClient.TranslationMemories.Health();

            Assert.Equal(health.Status,"UP");
        }
    }
}
