using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;
using File = System.IO.File;
using System.IO.Compression;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoriesClientTest
    {
        [Fact]
        public async Task GetTms()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var tmsResponse = await groupShareClient.TranslationMemories.GetTms();

            Assert.True(tmsResponse.Items.Count>0);
        }


        [Fact]
        public async Task GetTmById()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var tmId = await CreateTm("NewTm");
            var tm = await groupShareClient.TranslationMemories.GetTmById(tmId);

            Assert.Equal(tm.Name, "NewTm");
            await DeleteTm(tmId);

        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638", "6e9c3b55-1cec-4439-96c6-7e3c1af590d1")]
        public async Task GetLanguageDirectionForTm(string tmId,string languageDirectionId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageDirection =
                await groupShareClient.TranslationMemories.GetLanguageDirectionForTm(tmId, languageDirectionId);

            Assert.Equal(languageDirection.LanguageDirectionId,languageDirectionId);
        }

        [Fact]
        public async Task ExportTm()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageParam = new LanguageParameters("en-us", "ro-ro");

            var requestExportRequest = new ExportRequest();

            var tm = await groupShareClient.TranslationMemories.ExportTm("b5e457e0-fe37-47cc-8ba5-4dccdcb10d78", requestExportRequest, languageParam);
           
           Assert.True(tm.Length > 0);

        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task GetTmsNumberByLanguageResourceTemplateId(string id)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var tmNumber = await groupShareClient.TranslationMemories.GetTmsNumberByLanguageResourceTemplateId(id);

            Assert.Equal(tmNumber,0);
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task GetTmsNumberByFieldTemplateId(string id)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var tmNumber = await groupShareClient.TranslationMemories.GetTmsNumberByFieldTemplateId(id);

            Assert.Equal(tmNumber , 0);
        }


        public async Task<string> CreateTm(string tmName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
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
                ContainerId = "ee2871af-a5a5-46ca-9b05-0f216744e8fe"


            };

            var tmId = await groupShareClient.TranslationMemories.CreateTm(tmRequest);

            Assert.True(tmId!=string.Empty);
            return tmId;
        }

        
        public async Task DeleteTm(string tmId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            await groupShareClient.TranslationMemories.DeleteTm(tmId);
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task UpdateTm(string tmId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var tm = await groupShareClient.TranslationMemories.GetTmById(tmId);

            tm.Description = "Updated tm";

            await groupShareClient.TranslationMemories.Update(tmId, tm);

            var updatedTm = await groupShareClient.TranslationMemories.GetTmById(tmId);

            Assert.Equal(updatedTm.Description, "Updated tm");

        }

        [Fact]
        public async Task GetTmServiceHealth()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var health = await groupShareClient.TranslationMemories.Health();

            Assert.Equal(health.Status,"UP");
        }

 

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task GetTusForTm(string tmId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var translationUnitRequest = new TranslationUnitDetailsRequest("de-de", "ro-ro", 0,50);

            var tus = await groupShareClient.TranslationMemories.GetTranslationUnitForTm(tmId, translationUnitRequest);

            Assert.True(tus!=null);
        }
        [Fact]
        public async Task RecomputeStatistics()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var tmId = await CreateTm("TM");
            var request = new FuzzyRequest();

            var response = await groupShareClient.TranslationMemories.RecomputeStatistics(tmId, request);

            Assert.True(response!=null);
            await DeleteTm(tmId);
        }

        [Fact]
        public async Task Reindex()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var tmId = await CreateTm("TM");
            var request = new FuzzyRequest();

            var response = await groupShareClient.TranslationMemories.Reindex(tmId, request);

            Assert.True(response != null);
            await DeleteTm(tmId);
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task GetTusNumberForTm(string tmId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageParameters = new LanguageParameters("de-de", "ro-ro");

            var tusNumber = await groupShareClient.TranslationMemories.GetNumberOfTus(tmId, languageParameters);

            Assert.True(tusNumber>0);
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task GetTusNumberForPostDatedTm(string tmId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageParameters = new LanguageParameters("de-de", "ro-ro");

            var tusNumber = await groupShareClient.TranslationMemories.GetNumberOfPostDatedTus(tmId, languageParameters);

            Assert.Equal(tusNumber ,0);
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        public async Task GetTusNumberForPreDatedTm(string tmId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageParameters = new LanguageParameters("de-de", "ro-ro");

            var tusNumber = await groupShareClient.TranslationMemories.GetNumberOfPreDatedTus(tmId, languageParameters);

            Assert.Equal(tusNumber, 0);
        }
        //[Theory]
        //[InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        //public async Task GetTusNumberForUnalignedTm(string tmId)
        //{
        //    var groupShareClient = await Helper.GetGroupShareClient();
        //    var languageParameters = new LanguageParameters("de-de", "ro-ro");

        //    var tusNumber = await groupShareClient.TranslationMemories.GetNumberOfUnalignedTus(tmId, languageParameters);

        //    Assert.Equal(tusNumber, 0);
        //}

        [Fact]
        public async Task Filter()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            //      var languageDetails = new LanguageDetailsRequest("Europäischen", "de-de", "Acord ", "ro-ro");
            var languageDetails = new LanguageDetailsRequest("", "de-de", "Informare", "ro-ro");
            var tmDetails = new TranslationMemoryDetailsRequest(new Guid("27782e18-a0df-4266-ac9f-29965d3a3638"),0,50);

            var filter = await groupShareClient.TranslationMemories.FilterAsPlainText(languageDetails, tmDetails,true,true);

            foreach (var segment in filter)
            {
                Assert.True(segment.Target.Contains("Informare"));
            }

        }

        [Fact]
        public async Task SimpleSearch()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var searchRequest = new SearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "Blu", "en-us", "ca-es");

            var searchResponse = await groupShareClient.TranslationMemories.SearchText(searchRequest);
            
            foreach(var response in searchResponse)
            {
                Assert.Contains("Blue eye", response.Source);
            }
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638", " \"andrea\" = \"TestValue\"")]
        public async Task CustomFilterExpression(string tmId, string simpleExpression)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            // simple expression 
            var filedsList = new List<FieldFilter>
            {
                new FieldFilter
                {
                    Name = "andrea",
                    Type = FieldFilter.TypeEnum.SingleString,
                    Values = null
                }
            };

            var filterRequest = new FieldFilterRequest(filedsList, simpleExpression);

            var rawFilterRequest = new RawFilterRequest(new Guid(tmId), "de-de", "ro-ro", 0, 30, filterRequest);

            var responseSimpleExpr = await groupShareClient.TranslationMemories.RawFilter(rawFilterRequest);

            foreach (var item in responseSimpleExpr)
            {
                Assert.Equal(item.Target, "TRADUCERE");
            }

        }
    }
}
