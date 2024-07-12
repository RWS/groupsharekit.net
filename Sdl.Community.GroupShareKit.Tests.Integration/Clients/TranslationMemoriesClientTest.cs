using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoriesClientTests : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private Guid _databaseServerId;
        private Guid _containerId;
        private Guid _fieldTemplateId;
        private Guid _languageResourceTemplateId;
        private Guid _languageDirectionId;
        private Guid _translationMemoryId;

        public TranslationMemoriesClientTests()
        {
            _databaseServerId = CreateTestDatabaseServer().Result;
            _containerId = CreateTestContainer().Result;
            _fieldTemplateId = CreateTmSpecificFieldTemplate().Result;
            _languageResourceTemplateId = CreateTmSpecificLanguageResourceTemplate().Result;
            _translationMemoryId = CreateTranslationMemory(_fieldTemplateId, _languageResourceTemplateId).Result;
        }

        private async Task<Guid> CreateTestDatabaseServer()
        {
            var databaseServerRequest = new CreateDatabaseServerRequest
            {
                Name = $"Server - {Guid.NewGuid()}",
                Description = "Created using GroupShare Kit",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            _databaseServerId = await GroupShareClient.TranslationMemories.CreateDbServer(databaseServerRequest);
            return _databaseServerId;
        }

        private async Task<Guid> CreateTestContainer()
        {
            var containerName = $"Container_{DateTime.Now.Ticks}";

            var request = new CreateContainerRequest
            {
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                DatabaseServerId = _databaseServerId,
                DatabaseName = containerName,
                DisplayName = containerName,
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
                ContainerId =_containerId
            };

            var translationMemoryId = await GroupShareClient.TranslationMemories.CreateTranslationMemory(tmRequest);

            var translationMemory = await GroupShareClient.TranslationMemories.GetTranslationMemory(translationMemoryId);
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
                ContainerId = _containerId
            };

            var translationMemoryId = await GroupShareClient.TranslationMemories.CreateTranslationMemory(tmRequest);

            var translationMemory = await GroupShareClient.TranslationMemories.GetTranslationMemory(translationMemoryId);
            _languageDirectionId = Guid.Parse(translationMemory.LanguageDirections.First().LanguageDirectionId);

            return translationMemoryId;
        }

        private async Task<ImportResponse> ImportTranslationUnitsIntoTestTm(Guid translationMemoryId, string fileName = "")
        {
            var languageParameters = new LanguageParameters("en-us", "de-de");

            var filePath = fileName == ""
                ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\FiveWords_EN-DE_TM.tmx")
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\" + fileName);

            var file = System.IO.File.ReadAllBytes(filePath);

            var response = await GroupShareClient.TranslationMemories.ImportTm(translationMemoryId, languageParameters, file, fileName);
            Thread.Sleep(3000);

            return response;
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
            var fieldTemplate = await GroupShareClient.TranslationMemories.GetFieldTemplate(fieldTemplateId);

            Assert.Equal(fieldTemplateName, fieldTemplate.Name);
            Assert.Equal(2, fieldTemplate.Fields.Count);
            Assert.False(fieldTemplate.IsTmSpecific);
            Assert.Equal("created using GroupShare Kit", fieldTemplate.Description);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId);
        }

        [Fact]
        public async Task CreateLanguageResourceTemplateWithoutLanguageResources()
        {
            var name = $"Language resource template - {Guid.NewGuid()}";

            var languageResourceTemplateRequest = new CreateLanguageResourceTemplateRequest
            {
                Name = name,
                Description = "Created using GroupShare Kit",
                IsTmSpecific = false,
                Recognizers = "RecognizeAll",
                WordCountFlags = "DefaultFlags",
                TokenizerFlags = "DefaultFlags",
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            var languageResourceTemplateId = await GroupShareClient.TranslationMemories.CreateLanguageResourceTemplate(languageResourceTemplateRequest);
            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(languageResourceTemplateId);

            Assert.Equal(name, languageResourceTemplate.Name);
            Assert.Empty(languageResourceTemplate.LanguageResources);
            Assert.False(languageResourceTemplate.IsTmSpecific);
            Assert.Equal("Created using GroupShare Kit", languageResourceTemplate.Description);

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
            var tm = await GroupShareClient.TranslationMemories.GetTranslationMemory(_translationMemoryId);
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

        [Fact]
        public async Task ImportTranslationUnits()
        {
            var response = await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "FiveWords_EN-DE_TM.tmx");

            Assert.Equal("Queued", response.Status);
            Assert.Equal(_translationMemoryId, Guid.Parse(response.TranslationMemoryId));
        }

        [Fact]
        public async Task ExportTm()
        {
            var languageParam = new LanguageParameters("en-us", "de-de");
            var exportRequest = new ExportRequest();

            var tmExport = await GroupShareClient.TranslationMemories.ExportTm(_translationMemoryId, exportRequest, languageParam);

            Assert.True(tmExport.Length > 0);

            //Example of how the byte[] can be decompressed and how to write the exported TM can be written to the disk

            //using (var compressedStream = new MemoryStream(tm))
            //using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            //using (var resultStream = new MemoryStream())
            //{
            //    zipStream.CopyTo(resultStream);
            //    var test = resultStream.ToArray();
            //    File.WriteAllBytes(@"C:Temp\Export.tmx", test);
            //}
        }

        [Fact]
        public async Task HealthVersion()
        {
            var healthVersion = await GroupShareClient.TranslationMemories.TmServiceInfo();
            Assert.NotNull(healthVersion);
        }

        [Fact]
        public async Task GetTmsNumberByLanguageResourceTemplateId()
        {
            var tmNumber = await GroupShareClient.TranslationMemories.GetTmsNumberByLanguageResourceTemplateId(_languageResourceTemplateId);
            Assert.Equal(1, tmNumber);
        }

        [Fact]
        public async Task GetTmsNumberByFieldTemplateId()
        {
            var tmNumber = await GroupShareClient.TranslationMemories.GetTmsNumberByFieldTemplateId(_fieldTemplateId);
            Assert.Equal(1, tmNumber);
        }

        [Fact]
        public async Task UpdateTm()
        {
            var tm = await GroupShareClient.TranslationMemories.GetTranslationMemory(_translationMemoryId);

            tm.Description = "Updated tm";
            await GroupShareClient.TranslationMemories.UpdateTranslationMemory(_translationMemoryId, tm);

            var updatedTm = await GroupShareClient.TranslationMemories.GetTranslationMemory(_translationMemoryId);
            Assert.Equal("Updated tm", updatedTm.Description);
        }

        [Fact]
        public async Task GetTmServiceHealth()
        {
            var health = await GroupShareClient.TranslationMemories.Health();

            Assert.Equal("UP", health.Status);
        }

        [Fact]
        public async Task GetTusForTm()
        {
            var translationUnitRequest = new TranslationUnitDetailsRequest("en-us", "de-de", 0, 50);
            var translationUnits = await GroupShareClient.TranslationMemories.GetTranslationUnitsForTm(_translationMemoryId, translationUnitRequest);

            // there are no TUs in the empty TM
            Assert.Null(translationUnits);
        }

        [Fact]
        public async Task RecomputeStatistics()
        {
            var tmId = await CreateTranslationMemory();
            var request = new FuzzyRequest();

            var response = await GroupShareClient.TranslationMemories.RecomputeStatistics(tmId, request);

            Assert.Equal(tmId, Guid.Parse(response.TranslationMemoryId));
            Assert.Equal("Queued", response.Status);

            await GroupShareClient.TranslationMemories.DeleteTranslationMemory(tmId);
        }

        [Fact]
        public async Task Reindex()
        {
            var tmId = await CreateTranslationMemory();
            var request = new FuzzyRequest();

            var response = await GroupShareClient.TranslationMemories.Reindex(tmId, request);

            Assert.Equal(tmId, Guid.Parse(response.TranslationMemoryId));
            Assert.Equal("Queued", response.Status);

            await GroupShareClient.TranslationMemories.DeleteTranslationMemory(tmId);
        }

        [Fact]
        public async Task GetTusNumberForTm()
        {
            var languageParameters = new LanguageParameters("en-us", "de-de");
            var tusNumber = await GroupShareClient.TranslationMemories.GetTranslationUnitsCount(_translationMemoryId, languageParameters);

            Assert.Equal(0, tusNumber);
        }

        [Fact]
        public async Task GetTusNumberForPostDatedTm()
        {
            var languageParameters = new LanguageParameters("en-us", "de-de");


            var predatedTUsCount = await GroupShareClient.TranslationMemories.GetPredatedTranslationUnitsCount(_translationMemoryId, languageParameters);
            Assert.Equal(0, predatedTUsCount);

            var postdatedTUsCount = await GroupShareClient.TranslationMemories.GetPostdatedTranslationUnitsCount(_translationMemoryId, languageParameters);
            Assert.Equal(0, postdatedTUsCount);
        }

        [Fact]
        public async Task GetUnalignedTranslationUnitsCount()
        {
            var languageParameters = new LanguageParameters("en-us", "de-de");

            var unalignedTusCount = await GroupShareClient.TranslationMemories.GetUnalignedTranslationUnitsCount(_translationMemoryId, languageParameters);

            Assert.Equal(0, unalignedTusCount);
        }

        [Fact]
        public async Task FilterTranslationUnits()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "FiveWords_EN-DE_TM.tmx");

            var languageDetails = new LanguageDetailsRequest("en-us", "de-de");
            var tmDetails = new TranslationMemoryDetailsRequest(_translationMemoryId, 0, 10);

            var filteredTranslationUnits = await GroupShareClient.TranslationMemories.FilterAsPlainText(languageDetails, tmDetails, true, true);

            Assert.Equal(5, filteredTranslationUnits.Count);
            Assert.Contains(filteredTranslationUnits, translationUnit => translationUnit.Source.Equals("car") && translationUnit.Target.Equals("Auto"));
            Assert.Contains(filteredTranslationUnits, translationUnit => translationUnit.Source.Equals("dog") && translationUnit.Target.Equals("Hund"));
            Assert.Contains(filteredTranslationUnits, translationUnit => translationUnit.Source.Equals("cat") && translationUnit.Target.Equals("Katze"));
            Assert.Contains(filteredTranslationUnits, translationUnit => translationUnit.Source.Equals("house") && translationUnit.Target.Equals("Haus"));
            Assert.Contains(filteredTranslationUnits, translationUnit => translationUnit.Source.Equals("phone") && translationUnit.Target.Equals("Telefon"));
        }

        #region Text Search

        // search examples

        [Fact]
        public async Task SimpleSearch()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "FiveWords_EN-DE_TM.tmx");

            var searchRequest = new SearchRequest(_translationMemoryId, "car", "en-us", "de-de");

            var searchResults = await GroupShareClient.TranslationMemories.SearchText(searchRequest);

            Assert.Equal("car", searchResults.Single().Source);
            Assert.Equal("Auto", searchResults.Single().Target);
        }

        [Fact]
        public async Task SearchWithFilterExpression()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "Sample_EN-DE_TM_with_fields.tmx");

            var fields = new List<FieldFilter>
            {
                new FieldFilter
                {
                    Name = "Text field",
                    Type = FieldFilter.TypeEnum.SingleString,
                    Values = null
                }
            };

            string expression = "(\"Text field\" = \"marked segment\")";

            var filter = new List<ConcordanceSearchFilter>
            {
                new ConcordanceSearchFilter
                {
                    Name = "Filter_1",
                    Expression = new FieldFilterRequest(fields, expression),
                    Penalty = 0
                }
            };

            var searchSettings = new SearchTextSettings
            {
                Filters = filter
            };

            var searchRequest = new SearchRequest(_translationMemoryId, "programme", "en-us", "de-de", searchSettings);

            var searchResponse = await GroupShareClient.TranslationMemories.SearchText(searchRequest);

            Assert.Empty(searchResponse);
        }

        [Fact]
        public async Task TextSearchMinScoreMaxResults()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "Sample_EN-DE_TM.tmx");

            var settings = new SearchTextSettings
            {
                MinScore = 70
            };

            var searchRequest = new SearchRequest(_translationMemoryId, "contact", "en-us", "de-de", settings);
            var searchResults = await GroupShareClient.TranslationMemories.SearchText(searchRequest);
            Assert.Single(searchResults);

            settings = new SearchTextSettings
            {
                MinScore = 30,
                MaxResults = 1
            };

            searchRequest = new SearchRequest(_translationMemoryId, "officer", "en-us", "de-de", settings);
            searchResults = await GroupShareClient.TranslationMemories.SearchText(searchRequest);
            Assert.Single(searchResults);

            settings = new SearchTextSettings
            {
                MinScore = 30
            };

            searchRequest = new SearchRequest(_translationMemoryId, "officer", "en-us", "de-de", settings);
            searchResults = await GroupShareClient.TranslationMemories.SearchText(searchRequest);
            Assert.Equal(2, searchResults.Count);
        }

        [Fact]
        public async Task TextSearchPenalties()
        {
            var settings = new SearchTextSettings
            {
                Penalties = new List<Penalty>
                {
                    new Penalty
                    {
                        Malus = 2,
                        PenaltyType = Penalty.PenaltyTypeEnum.FilterPenalty
                    }
                }
            };

            var searchRequest = new SearchRequest(_translationMemoryId, "car", "en-us", "de-de", settings);

            var results = await GroupShareClient.TranslationMemories.SearchText(searchRequest);
            Assert.Empty(results);
        }

        #endregion

        #region Concordance Search for source

        [Fact]
        public async Task ConcordanceSimpleSearch()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "FiveWords_EN-DE_TM.tmx");

            var concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "phone", "en-us", "de-de");
            var results = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            Assert.Equal("100", results.Single().MatchScore);
            Assert.Equal("phone", results.Single().Source);
            Assert.Equal("Telefon", results.Single().Target);
        }

        [Fact]
        public async Task ConcordanceSearchWithCustomSettings()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "Sample_EN-DE_TM.tmx");

            var settings = new ConcordanceSearchSettings
            {
                MinScore = 90
            };

            var concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "random words", "en-us", "de-de", settings);
            var response = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);
            Assert.Empty(response);

            concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "education programme", "en-us", "de-de", settings);
            response = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);
            Assert.Equal(5, response.Count);

            settings = new ConcordanceSearchSettings
            {
                MaxResults = 3
            };

            concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "school children", "en-us", "de-de", settings);
            response = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public async Task ConcordanceSearchWithCustomFilter()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "Sample_EN-DE_TM_with_fields.tmx");

            var fields = new List<FieldFilter>
            {
                new FieldFilter
                {
                    Name = "Text field",
                    Type = FieldFilter.TypeEnum.SingleString,
                    Values = null
                }
            };

            string expression = "(\"Text field\" = \"marked segment\")";

            var concordanceSearchSettings = new ConcordanceSearchSettings
            {
                Filters = new List<ConcordanceSearchFilter>
                {
                    new ConcordanceSearchFilter
                    {
                        Name = "Filter_1",
                        Expression = new FieldFilterRequest(fields, expression),
                        Penalty = 0
                    },

                },
                IncludeTokens = false
            };

            var concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "Education", "en-us", "de-de", concordanceSearchSettings);

            var results = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);
            Assert.True(results.Count > 0);
        }

        [Fact]
        public async Task ConcordanceSearchWithPenalties()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "Sample_EN-DE_TM_with_fields.tmx");

            var fields = new List<FieldFilter>
            {
                new FieldFilter
                {
                    Name = "Text field",
                    Type = FieldFilter.TypeEnum.SingleString,
                    Values = null
                }
            };

            var penalties = new List<Penalty>
            {
                new Penalty
                {
                    Malus = 3,
                    PenaltyType = Penalty.PenaltyTypeEnum.MultipleTranslations
                },
                new Penalty
                {
                    Malus = 2,
                    PenaltyType = Penalty.PenaltyTypeEnum.Alignment
                }
            };

            string expression = "(\"Text field\" = \"marked segment\")";

            var concordanceSearchSettings = new ConcordanceSearchSettings
            {
                Filters = new List<ConcordanceSearchFilter>
                {
                    new ConcordanceSearchFilter
                    {
                        Name = "Filter_1",
                        Expression = new FieldFilterRequest(fields, expression),
                        Penalty = 0,
                    },
                },
                Penalties = penalties,
                IncludeTokens = false
            };

            var concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "place", "en-us", "de-de", concordanceSearchSettings);

            var results = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);
            Assert.True(results.Count > 0);
        }

        [Fact]
        public async Task ConcordanceSearchWithEmptySettings()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "FiveWords_EN-DE_TM.tmx");

            var concordanceSearchRequest = new ConcordanceSearchRequest(_translationMemoryId, "house", "en-us", "de-de", new ConcordanceSearchSettings());
            var results = await GroupShareClient.TranslationMemories.ConcordanceSearchAsPlainText(concordanceSearchRequest);

            Assert.Equal("100", results.Single().MatchScore);
            Assert.Equal("house", results.Single().Source);
            Assert.Equal("Haus", results.Single().Target);
        }

        [Fact]
        public async Task CustomFilterExpression()
        {
            await ImportTranslationUnitsIntoTestTm(_translationMemoryId, "Sample_EN-DE_TM_with_fields.tmx");

            var fields = new List<FieldFilter>
            {
                new FieldFilter
                {
                    Name = "Text field",
                    Type = FieldFilter.TypeEnum.SingleString,
                    Values = null
                }
            };

            string expression = "(\"Text field\" = \"marked segment\")";
            var filterRequest = new FieldFilterRequest(fields, expression);

            var rawFilterRequest = new RawFilterRequest(_translationMemoryId, "en-us", "de-de", 0, 30, filterRequest);

            var results = await GroupShareClient.TranslationMemories.RawFilter(rawFilterRequest);
            Assert.Equal(4, results.Count);

            fields = new List<FieldFilter>
            {
                new FieldFilter
                {
                    Name = "Text field",
                    Type = FieldFilter.TypeEnum.SingleString,
                    Values = null
                }
            };

            expression = "(\"Text field\" = \"discarded\")";
            filterRequest = new FieldFilterRequest(fields, expression);

            rawFilterRequest = new RawFilterRequest(_translationMemoryId, "en-us", "de-de", 0, 30, filterRequest);

            results = await GroupShareClient.TranslationMemories.RawFilter(rawFilterRequest);
            Assert.Equal(2, results.Count);
        }
        #endregion
    }
}