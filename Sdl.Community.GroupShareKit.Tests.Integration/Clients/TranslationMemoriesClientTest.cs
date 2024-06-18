﻿using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoriesClientTest : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private string _databaseServerId;
        private string _containerId;
        private Guid _fieldTemplateId;
        private Guid _languageResourceTemplateId;
        private Guid _languageDirectionId;
        private Guid _translationMemoryId;

        public TranslationMemoriesClientTest()
        {
            _databaseServerId = CreateDatabaseServer().Result;
            _containerId = CreateContainer().Result;
            _fieldTemplateId = CreateTmSpecificFieldTemplate().Result;
            _languageResourceTemplateId = CreateTmSpecificLanguageResourceTemplate().Result;
            _translationMemoryId = CreateTranslationMemory(_fieldTemplateId, _languageResourceTemplateId).Result;
        }

        private async Task<string> CreateDatabaseServer()
        {
            var dbServerGuid = Guid.NewGuid().ToString();
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = dbServerGuid,
                Name = $"DB server {dbServerGuid}",
                Description = "created using GroupShare Kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            _databaseServerId = await GroupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);
            return _databaseServerId;
        }

        private async Task<string> CreateContainer()
        {
            var containerGuid = Guid.NewGuid().ToString();
            var request = new ContainerRequest
            {
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                ContainerId = containerGuid,
                DatabaseServerId = _databaseServerId,
                DatabaseName = $"TM_Container_{DateTime.Now.Ticks}",
                DisplayName = $"DB_container_{containerGuid}",
                IsShared = false
            };

            _containerId = await GroupShareClient.TranslationMemories.CreateContainer(request);
            return _containerId;
        }

        private async Task<Guid> CreateTmSpecificFieldTemplate()
        {
            var fieldTemplate = new CreateFieldTemplateRequest
            {
                Name = $"Field template - {Guid.NewGuid()}",
                Description = "created using GroupShare Kit",
                IsTmSpecific = true,
                Location = Helper.OrganizationPath,
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            _fieldTemplateId = await GroupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);
            return _fieldTemplateId;
        }

        private async Task<Guid> CreateTmSpecificLanguageResourceTemplate()
        {
            var languageResourceTemplateRequest = new CreateLanguageResourceTemplateRequest
            {
                Name = $"Language resource template - {Guid.NewGuid()}",
                Description = "created using GroupShare Kit",
                IsTmSpecific = true,
                Recognizers = "RecognizeAll",
                WordCountFlags = "DefaultFlags",
                TokenizerFlags = "DefaultFlags",
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            var languageResourceTemplateId = await GroupShareClient.TranslationMemories.CreateLanguageResourceTemplate(languageResourceTemplateRequest);
            return languageResourceTemplateId;

            //var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, "de-de");
            //var resource = await GroupShareClient.TranslationMemories.GetDefaultsType(request);

            //var lrTemplate = new LanguageResourceTemplate
            //{
            //    LanguageResourceTemplateId = Guid.NewGuid().ToString(),
            //    Name = $"Language resource template - {Guid.NewGuid()}",
            //    Description = "test language resource template",
            //    OwnerId = Helper.OrganizationId,
            //    Location = Helper.OrganizationPath,
            //    IsTmSpecific = false,
            //    LanguageResources = new List<Resource>
            //    {
            //        new Resource
            //        {
            //            Type = "Variables",
            //            LanguageResourceTemplateId = resource.LanguageResourceTemplateId,
            //            Data = "test",
            //            CultureName = "de-de"
            //        }
            //    }
            //};

            //lrTemplateId = await GroupShareClient.TranslationMemories.CreateTemplate(lrTemplate).ConfigureAwait(false);
            //return lrTemplateId;
        }

        private async Task<Guid> CreateTranslationMemory()
        {
            var languageDirections = new List<LanguageDirection>
                {
                    new LanguageDirection
                    {
                        Source = "en-US",
                        Target = "de-DE",
                    }
                };

            var fuzzyIndexTuningSettings = new FuzzyIndexTuningSettings
            {
                MinScoreIncrease = 20,
                MinSearchVectorLengthSourceCharIndex = 5,
                MinSearchVectorLengthSourceWordIndex = 3,
                MinSearchVectorLengthTargetCharIndex = 5,
                MinSearchVectorLengthTargetWordIndex = 3

            };

            var tmRequest = new CreateTranslationMemoryRequest
            {
                Name = $"TM - {Guid.NewGuid()}",
                LanguageDirections = languageDirections,
                Recognizers = "RecognizeAll",
                FuzzyIndexes = "SourceWordBased,TargetWordBased",
                WordCountFlags = "DefaultFlags",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                FuzzyIndexTuningSettings = fuzzyIndexTuningSettings,
                ContainerId = Guid.Parse(_containerId)
            };

            var translationMemoryId = await GroupShareClient.TranslationMemories.CreateTranslationMemory(tmRequest).ConfigureAwait(false);

            var translationMemory = await GroupShareClient.TranslationMemories.GetTmById(translationMemoryId.ToString());
            _languageDirectionId = Guid.Parse(translationMemory.LanguageDirections.First().LanguageDirectionId);

            return translationMemoryId;
        }

        private async Task<Guid> CreateTranslationMemory(Guid fieldTemplateId, Guid languageResourceTemplateId)
        {
            var languageDirections = new List<LanguageDirection>
                {
                    new LanguageDirection
                    {
                        Source = "en-US",
                        Target = "de-DE",
                    }
                };

            var fuzzyIndexTuningSettings = new FuzzyIndexTuningSettings
            {
                MinScoreIncrease = 20,
                MinSearchVectorLengthSourceCharIndex = 5,
                MinSearchVectorLengthSourceWordIndex = 3,
                MinSearchVectorLengthTargetCharIndex = 5,
                MinSearchVectorLengthTargetWordIndex = 3

            };

            var tmRequest = new CreateTranslationMemoryRequest
            {
                Name = $"TM - {Guid.NewGuid()}",
                LanguageDirections = languageDirections,
                FieldTemplateId = fieldTemplateId,
                LanguageResourceTemplateId = languageResourceTemplateId,
                Recognizers = "RecognizeAll",
                FuzzyIndexes = "SourceWordBased,TargetWordBased",
                WordCountFlags = "DefaultFlags",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                FuzzyIndexTuningSettings = fuzzyIndexTuningSettings,
                ContainerId = Guid.Parse(_containerId)
            };

            var translationMemoryId = await GroupShareClient.TranslationMemories.CreateTranslationMemory(tmRequest).ConfigureAwait(false);

            var translationMemory = await GroupShareClient.TranslationMemories.GetTmById(translationMemoryId.ToString());
            _languageDirectionId = Guid.Parse(translationMemory.LanguageDirections.First().LanguageDirectionId);

            return translationMemoryId;
        }

        // Cleanup
        public void Dispose()
        {
            GroupShareClient.TranslationMemories.DeleteTranslationMemory(_translationMemoryId).Wait();
            GroupShareClient.TranslationMemories.DeleteContainer(_containerId).Wait();
            GroupShareClient.TranslationMemories.DeleteDbServer(_databaseServerId).Wait();
        }

        [Fact]
        public async Task CreateFieldTemplateWithFields()
        {
            var fields = new List<Field>
            {
                new Field
                {
                    Name = "Text field",
                    Type = "SingleString",
                    Values = null
                },
                new Field
                {
                    Name = "Number field",
                    Type = "Integer",
                    Values = null
                }
            };

            var fieldTemplateName = $"Field template - {Guid.NewGuid()}";

            var fieldTemplateRequest = new CreateFieldTemplateRequest
            {
                Name = fieldTemplateName,
                Description = "created using GroupShare Kit",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                IsTmSpecific = false,
                Fields = fields
            };

            var fieldTemplateId = await GroupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplateRequest);
            var fieldTemplate = await GroupShareClient.TranslationMemories.GetFieldTemplateById(fieldTemplateId.ToString());

            Assert.Equal(fieldTemplateName, fieldTemplate.Name);
            Assert.Equal(2, fieldTemplate.Fields.Count);
            Assert.False(fieldTemplate.IsTmSpecific);
            Assert.Equal("created using GroupShare Kit", fieldTemplate.Description);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId.ToString());
        }

        [Fact]
        public async Task CreateLanguageResourceTemplateWithoutLanguageResources()
        {
            var name = $"Language resource template - {Guid.NewGuid()}";

            var languageResourceTemplateRequest = new CreateLanguageResourceTemplateRequest
            {
                Name = name,
                Description = "created using GroupShare Kit",
                IsTmSpecific = false,
                Recognizers = "RecognizeAll",
                WordCountFlags = "DefaultFlags",
                TokenizerFlags = "DefaultFlags",
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            var languageResourceTemplateId = await GroupShareClient.TranslationMemories.CreateLanguageResourceTemplate(languageResourceTemplateRequest);
            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetTemplateById(languageResourceTemplateId.ToString());

            Assert.Equal(name, languageResourceTemplate.Name);
            Assert.Empty(languageResourceTemplate.LanguageResources);
            Assert.False(languageResourceTemplate.IsTmSpecific);
            Assert.Equal("created using GroupShare Kit", languageResourceTemplate.Description);

            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
        }

        [Fact]
        public async Task GetTms()
        {
            var tmsResponse = await GroupShareClient.TranslationMemories.GetTms();
            Assert.True(tmsResponse.Items.Count > 0);
        }

        [Fact]
        public async Task GetTmById()
        {
            var tm = await GroupShareClient.TranslationMemories.GetTranslationMemoryById(_translationMemoryId);
            Assert.Equal(_translationMemoryId, Guid.Parse(tm.TranslationMemoryId));
        }

        [Fact]
        public async Task GetLanguageDirectionForTm()
        {
            var languageDirection = await GroupShareClient.TranslationMemories.GetTmLanguageDirection(_translationMemoryId, _languageDirectionId);

            Assert.Equal(_languageDirectionId, Guid.Parse(languageDirection.LanguageDirectionId));
            Assert.Equal("en-us", languageDirection.Source);
            Assert.Equal("de-de", languageDirection.Target);
            Assert.Equal(0, languageDirection.TuCount);
        }

        //[Fact]
        //public async Task ExportTm()
        //{
        //    var languageParam = new LanguageParameters("en-us", "de-de");
        //    var requestExportRequest = new ExportRequest();

        //    var tm = await GroupShareClient.TranslationMemories.ExportTm(tmId, requestExportRequest, languageParam).ConfigureAwait(true);

        //    Assert.True(tm.Length > 0);

        //    //Example of how the byte[] should be decompressed and how to write the tm to disk

        //    //using (var compressedStream = new MemoryStream(tm))
        //    //using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
        //    //using (var resultStream = new MemoryStream())
        //    //{
        //    //    zipStream.CopyTo(resultStream);
        //    //    var test = resultStream.ToArray();
        //    //    File.WriteAllBytes(@"C:\UserData\aghisa\Desktop\testTm.tmx", test);
        //    //}                    
        //}

        [Fact]
        public async Task HealthVersion()
        {
            var healthVersion = await GroupShareClient.TranslationMemories.TmServiceInfo();
            Assert.NotNull(healthVersion);
        }

        [Fact]
        public async Task GetTmsNumberByLanguageResourceTemplateId()
        {
            var tmNumber = await GroupShareClient.TranslationMemories.GetTmsNumberByLanguageResourceTemplateId(_languageResourceTemplateId.ToString());
            Assert.Equal(1, tmNumber);
        }

        [Fact]
        public async Task GetTmsNumberByFieldTemplateId()
        {
            var tmNumber = await GroupShareClient.TranslationMemories.GetTmsNumberByFieldTemplateId(_fieldTemplateId.ToString());
            Assert.Equal(1, tmNumber);
        }

        [Fact]
        public async Task UpdateTm()
        {
            var tm = await GroupShareClient.TranslationMemories.GetTranslationMemoryById(_translationMemoryId);

            tm.Description = "Updated tm";
            await GroupShareClient.TranslationMemories.Update(_translationMemoryId.ToString(), tm);

            var updatedTm = await GroupShareClient.TranslationMemories.GetTranslationMemoryById(_translationMemoryId);
            Assert.Equal("Updated tm", updatedTm.Description);
        }

        [Fact]
        public async Task GetTmServiceHealth()
        {
            var groupShareClient = Helper.GsClient;
            var health = await groupShareClient.TranslationMemories.Health();

            Assert.Equal("UP", health.Status);
        }

        [Fact]
        public async Task GetTusForTm()
        {
            var translationUnitRequest = new TranslationUnitDetailsRequest("en-us", "de-de", 0, 50);
            var tus = await GroupShareClient.TranslationMemories.GetTranslationUnitForTm(_translationMemoryId.ToString(), translationUnitRequest);

            // there are no TUs in the empty TM
            Assert.Null(tus);
        }

        [Fact]
        public async Task RecomputeStatistics()
        {
            var groupShareClient = Helper.GsClient;
            var tmId = await CreateTranslationMemory();
            var request = new FuzzyRequest();

            var response = await groupShareClient.TranslationMemories.RecomputeStatistics(tmId.ToString(), request);

            Assert.Equal(tmId, Guid.Parse(response.TranslationMemoryId));
            Assert.Equal("Queued", response.Status);
            
            await groupShareClient.TranslationMemories.DeleteTranslationMemory(tmId);
        }

        [Fact]
        public async Task Reindex()
        {
            var groupShareClient = Helper.GsClient;
            var tmId = await CreateTranslationMemory();
            var request = new FuzzyRequest();

            var response = await groupShareClient.TranslationMemories.Reindex(tmId.ToString(), request);

            Assert.Equal(tmId, Guid.Parse(response.TranslationMemoryId));
            Assert.Equal("Queued", response.Status);

            await groupShareClient.TranslationMemories.DeleteTranslationMemory(tmId);
        }

        [Fact]
        public async Task GetTusNumberForTm()
        {
            var languageParameters = new LanguageParameters("en-us", "de-de");
            var tusNumber = await GroupShareClient.TranslationMemories.GetNumberOfTus(_translationMemoryId.ToString(), languageParameters);

            Assert.Equal(0, tusNumber);
        }

        [Fact]
        public async Task GetTusNumberForPostDatedTm()
        {
            var groupShareClient = Helper.GsClient;
            var languageParameters = new LanguageParameters("en-us", "de-de");


            var preDatedTUs = await groupShareClient.TranslationMemories.GetNumberOfPreDatedTus(_translationMemoryId.ToString(), languageParameters);
            Assert.Equal(0, preDatedTUs);

            var postDatedTUs = await groupShareClient.TranslationMemories.GetNumberOfPostDatedTus(_translationMemoryId.ToString(), languageParameters);
            Assert.Equal(0, postDatedTUs);
        }

        //[Theory]
        //[InlineData("27782e18-a0df-4266-ac9f-29965d3a3638")]
        //public async Task GetTusNumberForUnalignedTm(string tmId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var languageParameters = new LanguageParameters("de-de", "ro-ro");

        //    var tusNumber = await groupShareClient.TranslationMemories.GetNumberOfUnalignedTus(tmId, languageParameters);

        //    Assert.Equal(tusNumber, 0);
        //}

        //[Fact]
        //public async Task Filter()
        //{
        //    var groupShareClient = Helper.GsClient;
        //    //      var languageDetails = new LanguageDetailsRequest("Europäischen", "de-de", "Acord ", "ro-ro");
        //    var languageDetails = new LanguageDetailsRequest("", "de-de", "Informare", "ro-ro");
        //    var tmDetails = new TranslationMemoryDetailsRequest(new Guid("27782e18-a0df-4266-ac9f-29965d3a3638"), 0, 50);

        //    var filter = await groupShareClient.TranslationMemories.FilterAsPlainText(languageDetails, tmDetails, true, true);

        //    foreach (var segment in filter)
        //    {
        //        Assert.Contains("Informare", segment.Target);
        //    }
        //}

        #region Text Search

        /* search examples

        [Fact]
        public async Task SimpleSearch()
        {
            var groupShareClient = Helper.GsClient;
            var searchRequest = new SearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "Blu", "en-us", "ca-es");

            var searchResponse = await groupShareClient.TranslationMemories.SearchText(searchRequest);

            foreach (var response in searchResponse)
            {
                Assert.Contains("Blue eye", response.Source);
            }
        }

        [Theory]
        [InlineData("773bbfe4-fd97-4a70-85e3-8b301e58064b", "\"Andrea\" = (\"AndreaField\")", "TestFilterName", "blue")]
        public async Task SearchWithFilterExpression(string tmId, string simpleExpression, string filterName, string searchText)
        {
            var groupShareClient = Helper.GsClient;
            // simple expression 
            var fieldFilter = new List<FieldFilter>
            {
                new FieldFilter
                {
                    //filed name
                    Name="Andrea",
                    Type = FieldFilter.TypeEnum.MultipleString,
                    Values = null
                }
            };

            var filterRequest = new List<ConcordanceSearchFilter>
                {
                    new ConcordanceSearchFilter
                    {
                        Expression = new FieldFilterRequest(fieldFilter,simpleExpression),
                        Penalty = 10,
                        Name=filterName
                    },
                };

            var searchSettings = new SearchTextSettings
            {
                Filters = filterRequest
            };

            var searchRequest = new SearchRequest(new Guid(tmId), searchText, "en-us", "ca-es", searchSettings);

            var searchResponse = await groupShareClient.TranslationMemories.SearchText(searchRequest);

            Assert.True(searchResponse.Count == 0);
        }
        
        [Fact]
        public async Task TextSearchMinAndMaxResultSet()
        {
            var groupShareClient = Helper.GsClient;
            //set Min score
            var settingsMin = new SearchTextSettings
            {
                MinScore = 40
            };
            var minSearchRequest = new SearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "Blue", "en-us", "ca-es", settingsMin);


            var minSearchResponse = await groupShareClient.TranslationMemories.SearchText(minSearchRequest);
            Assert.True(minSearchResponse != null);

            var settingsMax = new SearchTextSettings
            {
                MaxResults = 2
            };
            var maxSearchRequest = new SearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "Blue", "en-us", "ca-es", settingsMax);


            var maxSearchResponse = await groupShareClient.TranslationMemories.SearchText(maxSearchRequest);
            Assert.True(maxSearchResponse.Count <= 2);
        }

        [Fact]
        public async Task TextSearchPenalties()
        {
            var groupShareClient = Helper.GsClient;

            var settings = new SearchTextSettings
            {
                Penalties = new List<Penalty>
                {
                    new Penalty
                    {
                        Malus=2,
                        PenaltyType = Penalty.PenaltyTypeEnum.FilterPenalty
                    }
                }
            };
            var searchRequest = new SearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "Blue", "en-us", "ca-es", settings);

            var searchResponse = await groupShareClient.TranslationMemories.SearchText(searchRequest);
            Assert.True(searchResponse != null);
        }

        #endregion

        #region Concordance Search for source
        [Fact]
        public async Task ConcordanceSimpleSearch()
        {
            var groupShareClient = Helper.GsClient;
            var concordanceSearchRequest = new ConcordanceSearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "blue", "en-us", "ca-es");

            var searchResponse = await groupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            foreach (var response in searchResponse)
            {
                Assert.Contains("blue", response.Source.ToLower());
            }
        }

        //Concordance search with custom settings
        [Fact]
        public async Task ConcordanceSearchWithCustomSettings()
        {
            var groupShareClient = Helper.GsClient;

            // the score for this search is 85
            var concordanceSearchSettings = new ConcordanceSearchSettings
            {
                MinScore = 90
            };
            var concordanceSearchRequest = new ConcordanceSearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "blu", "en-us", "ca-es", concordanceSearchSettings);

            var searchResponse = await groupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            Assert.True(searchResponse.Count == 0);

            var concordanceSearchMaxResults = new ConcordanceSearchSettings
            {
                MaxResults = 3
            };
            var concordanceSearchMaxRequest = new ConcordanceSearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "blue", "en-us", "ca-es", concordanceSearchMaxResults);

            var concordanceMaxRequest = await groupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchMaxRequest);

            Assert.True(concordanceMaxRequest.Count == 3);
        }

        [Theory]
        [InlineData("773bbfe4-fd97-4a70-85e3-8b301e58064b", "\"Andrea\" = (\"AndreaField\")", "TestFilterName")]
        public async Task ConcordanceSearchWithCustomFilter(string tmId, string expression, string filterName)
        {
            var groupShareClient = Helper.GsClient;
            var fieldFilter = new List<FieldFilter>
            {
                new FieldFilter
                {
                    //filed name
                    Name="Andrea",
                    Type = FieldFilter.TypeEnum.MultipleString,
                    Values = null
                }
            };
            var concordanceSearchSettings = new ConcordanceSearchSettings
            {
                Filters = new List<ConcordanceSearchFilter>
                {
                    new ConcordanceSearchFilter
                    {
                        Expression = new FieldFilterRequest(fieldFilter,expression),
                        Penalty = 10,
                        Name=filterName
                    },

                },
                IncludeTokens = true

            };

            var concordanceSearchRequest = new ConcordanceSearchRequest(new Guid(tmId),
                "blue",
                "en-us",
                "ca-es",
                concordanceSearchSettings);

            var searchResponse = await groupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            foreach (var response in searchResponse)
            {
                Assert.Contains("blue", response.Source.ToLower());
            }
        }

        [Theory]
        [InlineData("773bbfe4-fd97-4a70-85e3-8b301e58064b", "\"Andrea\" = (\"AndreaField\")", "TestFilterName")]
        public async Task ConcordanceSearchWithPenalties(string tmId, string expression, string filterName)
        {
            var groupShareClient = Helper.GsClient;
            var fieldFilter = new List<FieldFilter>
            {
                new FieldFilter
                {
                    //filed name
                    Name="Andrea",
                    Type = FieldFilter.TypeEnum.MultipleString,
                    Values = null
                }
            };

            var concordanceSearchSettings = new ConcordanceSearchSettings
            {
                Filters = new List<ConcordanceSearchFilter>
                {
                    new ConcordanceSearchFilter
                    {
                        Expression = new FieldFilterRequest(fieldFilter,expression),
                        Penalty = 10,
                        Name=filterName
                    },

                },
                Penalties = new List<Penalty>
                {
                    new Penalty
                    {
                        Malus = 1,
                        PenaltyType = Penalty.PenaltyTypeEnum.AutoLocalization
                    }
                },
                IncludeTokens = true
            };

            var concordanceSearchRequest = new ConcordanceSearchRequest(new Guid(tmId),
                "blue",
                "en-us",
                "ca-es",
                concordanceSearchSettings);

            var searchResponse = await groupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            foreach (var response in searchResponse)
            {
                Assert.Contains("blue", response.Source.ToLower());
            }
        }

        #endregion
        [Fact]
        public async Task TargetConcordanceSearch()
        {
            var groupShareClient = Helper.GsClient;
            var concordanceSearchSettings = new ConcordanceSearchSettings();
            var concordanceSearchRequest = new ConcordanceSearchRequest(new Guid("773bbfe4-fd97-4a70-85e3-8b301e58064b"), "blue", "en-us", "ca-es", concordanceSearchSettings);
            var searchResponse = await groupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            Assert.True(searchResponse.Count > 0);
        }

        [Theory]
        [InlineData("27782e18-a0df-4266-ac9f-29965d3a3638", " \"andrea\" = \"TestValue\"")]
        public async Task CustomFilterExpression(string tmId, string simpleExpression)
        {
            var groupShareClient = Helper.GsClient;
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
                Assert.Equal("TRADUCERE", item.Target);
            }
        }
        */

        #endregion
    }
}