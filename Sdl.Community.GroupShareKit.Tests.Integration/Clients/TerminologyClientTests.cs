using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Browse;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Concepts;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Images;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using Attribute = Sdl.Community.GroupShareKit.Models.Response.Attribute;
using ConceptResponse = Sdl.Community.GroupShareKit.Clients.ConceptResponse;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TerminologyClientTests
    {
        private readonly GroupShareClient _groupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetTermbases()
        {
            var termbases = await _groupShareClient.Terminology.GetTermbases();

            Assert.True(termbases.TotalCount > 0);
        }

        [Fact]
        public async Task GetTermbasesV2()
        {
            var termbases = await _groupShareClient.Terminology.GetTermbasesV2();

            Assert.True(termbases.Count > 0);
        }

        [Fact]
        public async Task GetTermbasesWithPaginationV2()
        {
            var termbases = await _groupShareClient.Terminology.GetTermbasesV2(page: 2, limit: 2);

            Assert.True(termbases.Count > 0);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task SearchTermbaseV2()
        {
            var request = new TermbaseSearchRequest
            {
                Query = "interface",
                SourceIndex = "English"
            };
            
            var searchResult = await _groupShareClient.Terminology.SearchTermbaseV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), request);
            Assert.Equal("interface", searchResult.LastTerm);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task BrowseExTermbaseV2()
        {
            var request = new TermbaseBrowseRequest
            {
                SourceIndex = "English",
                TargetIndex = "French",
                LastTerm = "interface",
                SortDirection = Direction.Desc
            };

            var browseResult = await _groupShareClient.Terminology.BrowseExTermbaseV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), request);
            Assert.NotEmpty(browseResult.Terms);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task GetTermbaseDefinitionV2()
        {
            var termbaseDefinition = await _groupShareClient.Terminology.GetTermbaseDefinitionV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"));
            Assert.NotNull(termbaseDefinition);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task GetTermbasePublicObjectsV2()
        {
            var publicObjects = await _groupShareClient.Terminology.GetTermbasePublicObjectsV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"));
            Assert.NotNull(publicObjects);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task GetConceptV2()
        {
            var concept = await _groupShareClient.Terminology.GetConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 12);
            var conceptXml = await _groupShareClient.Terminology.GetConceptXmlV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 12);

            Assert.NotNull(concept);
            Assert.NotNull(conceptXml);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task CreateConceptV2()
        {
            var conceptToCreate = new ConceptV2
            {
                EntryClass = new ConceptV2.EntryClassBase
                {
                    Id = 1
                },
                Languages = new List<ConceptV2.IndexLanguage>
                {
                    new ConceptV2.IndexLanguage
                    {
                        Language = new ConceptV2.LanguageDescription
                        {
                            Id = "English"
                        },
                        Terms = new List<ConceptV2.Term>
                        {
                            new ConceptV2.Term
                            {
                                Text = "red"
                            }
                        }
                    }
                },
            };

            var conceptId = await _groupShareClient.Terminology.CreateConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), conceptToCreate);
            var concept = await _groupShareClient.Terminology.GetConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), conceptId);

            Assert.NotNull(concept);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task UpdateConceptV2()
        {
            var newConceptVersion = new ConceptV2
            {
                Id = "7",
                EntryClass = new ConceptV2.EntryClassBase
                {
                    Id = 3
                },
                Languages = new List<ConceptV2.IndexLanguage>
                {
                    new ConceptV2.IndexLanguage
                    {
                        Language = new ConceptV2.LanguageDescription
                        {
                            Id = "English"
                        },
                        Terms = new List<ConceptV2.Term>
                        {
                            new ConceptV2.Term
                            {
                                Text = "modified term"
                            }
                        }
                    }
                }
            };

            await _groupShareClient.Terminology.UpdateConceptV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), newConceptVersion);

            var updatedConcept = await _groupShareClient.Terminology.GetConceptV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 7);
            Assert.Equal("modified term", updatedConcept.Languages.First().Terms.First().Text);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task CreateConceptXmlV2()
        {
            var conceptXml = new ConceptXmlObject(Regex.Unescape("<?xml version=\"1.0\"?><cG><c>1</c><sy type=\"entryClass\">1</sy><lG><l type=\"English\" lang=\"EN\"/><tG><t>car</t><trG><tr type=\"origination\">sa</tr><dt>2025-07-30T16:46:03</dt></trG><trG><tr type=\"modification\">sa</tr><dt>2025-07-30T16:46:03</dt></trG></tG></lG><lG><l type=\"French\" lang=\"FR\"/><tG><t>voiture</t><trG><tr type=\"origination\">sa</tr><dt>2025-07-30T16:46:03</dt></trG><trG><tr type=\"modification\">sa</tr><dt>2025-07-30T16:46:03</dt></trG></tG></lG><trG><tr type=\"origination\">sa</tr><dt>2025-07-30T16:46:03</dt></trG><trG><tr type=\"modification\">sa</tr><dt>2025-07-30T16:46:03</dt></trG></cG>"));
            var conceptId = await _groupShareClient.Terminology.CreateConceptXmlV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), conceptXml);

            Assert.True(conceptId > 0);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task UpdateConceptXmlV2()
        {
            var conceptXml = new ConceptXmlObject(Regex.Unescape("<?xml version=\"1.0\"?><cG><c>1</c><sy type=\"entryClass\">1</sy><lG><l type=\"English\" lang=\"EN\"/><tG><t>green</t><trG><tr type=\"origination\">sa</tr><dt>2025-07-30T16:46:03</dt></trG><trG><tr type=\"modification\">sa</tr><dt>2025-07-30T16:46:03</dt></trG></tG></lG><lG><l type=\"French\" lang=\"FR\"/><tG><t>vert</t><trG><tr type=\"origination\">sa</tr><dt>2025-07-30T16:46:03</dt></trG><trG><tr type=\"modification\">sa</tr><dt>2025-07-30T16:46:03</dt></trG></tG></lG><trG><tr type=\"origination\">sa</tr><dt>2025-07-30T16:46:03</dt></trG><trG><tr type=\"modification\">sa</tr><dt>2025-07-30T16:46:03</dt></trG></cG>"));
            await _groupShareClient.Terminology.UpdateConceptXmlV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), conceptXml);
            
            var updatedConcept = await _groupShareClient.Terminology.GetConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 1);
            var language = updatedConcept.Languages.Single(l => l.Language.Name.Equals("French", StringComparison.OrdinalIgnoreCase));
            var termText = language.Terms.First().Text;

            Assert.Equal("vert", termText);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task SearchConceptV2()
        {
            var request = new SearchConceptRequest
            {
                SourceIndex = "English",
                Term = "adapter"
            };

            var conceptXml = await _groupShareClient.Terminology.SearchConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), request);
            Assert.NotNull(conceptXml);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task DeleteConceptV2()
        {
            await _groupShareClient.Terminology.DeleteConceptV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 5);

            var exception = await Record.ExceptionAsync(() => _groupShareClient.Terminology.GetConceptV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 6));
            Assert.NotNull(exception);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task LockConceptV2()
        {
            var lockException = await Record.ExceptionAsync(() => _groupShareClient.Terminology.LockConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 1));
            var stealLockException = await Record.ExceptionAsync(() => _groupShareClient.Terminology.LockConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 1, stealLock: true));
            var unLockException = await Record.ExceptionAsync(() => _groupShareClient.Terminology.UnlockConceptV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 1));

            Assert.Null(lockException);
            Assert.Null(stealLockException);
            Assert.Null(unLockException);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task DeleteTermbaseV2()
        {
            await _groupShareClient.Terminology.DeleteTermbaseV2(Guid.Parse("95cdb6b7-33ac-4541-ace3-911a05795035"));

            var exception = await Record.ExceptionAsync(() => _groupShareClient.Terminology.GetTermbaseDefinitionV2(Guid.Parse("95cdb6b7-33ac-4541-ace3-911a05795035")));
            Assert.NotNull(exception);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task GetTermbaseGuidByNameV2()
        {
            var termbaseName = new TermbaseNameModel
            {
                TermbaseName = "T1 - Sample - en_de_fr"
            };

            var termbaseId = await _groupShareClient.Terminology.GetTermbaseGuidByNameV2(termbaseName);
            var publicObjects = await _groupShareClient.Terminology.GetTermbasePublicObjectsV2(termbaseId);

            Assert.Equal("T1 - Sample - en_de_fr", publicObjects.Name);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task GetCatalogObjectV2()
        {
            var catalogObject = await _groupShareClient.Terminology.GetCatalogObjectV2(Guid.Parse("5b1e4f26-cdcf-44b8-888a-3d87d1bb4b3c"), 1);
            Assert.NotNull(catalogObject);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task DeleteCatalogObjectV2()
        {
            var catalogObject = await _groupShareClient.Terminology.GetCatalogObjectV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 12);
            await _groupShareClient.Terminology.DeleteCatalogObjectV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 12);

            var exception = await Record.ExceptionAsync(() => _groupShareClient.Terminology.GetCatalogObjectV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 12));
            Assert.NotNull(exception);
        }

        // This test relies on resources specific to a single server and will fail in other environments.
        [Fact]
        public async Task MultimediaV2()
        {
            var request = new MultimediaRequest
            {
                Extension = ".JPG",
                Base64data = "iVBORw0KGgoAAAANSUhEUgAABAAAAAQAAQMAAABF07nAAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAABlBMVEVmAJn///+7PN20AAAAAWJLR0QB/wIt3gAAAAd0SU1FB+kIGgsgH+aS2mYAAACWSURBVHja7cEBAQAAAIIg/69uSEABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAO8GBB4AAQ3eOGQAAAAldEVYdGRhdGU6Y3JlYXRlADIwMjUtMDgtMjZUMTE6MzI6MzErMDA6MDA8b/cMAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDI1LTA4LTI2VDExOjMyOjMxKzAwOjAwTTJPsAAAAABJRU5ErkJggg==",
                ConceptId = "4"
            };

            var imageId = await _groupShareClient.Terminology.AddMultimediaV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), request);
            var image = await _groupShareClient.Terminology.GetMultimediaV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), imageId);
            Assert.NotNull(image);

            await _groupShareClient.Terminology.DeleteMultimediaV2(Guid.Parse("91745d42-0cd7-4836-ba2b-57ab18797fc5"), 4);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task GetTermbaseById(string termbaseId)
        {
            var termbase = await _groupShareClient.Terminology.GetTermbaseById(termbaseId);

            Assert.Equal(termbase.Termbase.Id, termbaseId);
            Assert.Equal(termbase.Termbase.Name, termbaseId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task GetFilters(string termbaseId)
        {
            var filters = await _groupShareClient.Terminology.GetFilters(termbaseId);

            Assert.NotNull(filters);
        }

        [Theory]
        [InlineData("testTB", "ttt", "German")]
        public async Task SearchTerm(string termbaseId, string query, string language)
        {
            var request = new SearchTermRequest(termbaseId, language, query);

            var searchedResponse = await _groupShareClient.Terminology.SearchTerm(request);
            var searchedWord = searchedResponse.Terms.FirstOrDefault(s => s.TermText == query);
            Assert.NotNull(searchedWord);
        }

        [Theory]
        [InlineData("testTB", "window", "German")]
        public async Task SearchNotFoundTerm(string termbaseId, string query, string language)
        {
            var request = new SearchTermRequest(termbaseId, language, query);

            var searchedResponse = await _groupShareClient.Terminology.SearchTerm(request);

            Assert.Empty(searchedResponse.Terms);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task GetConcept(string termbaseId)
        {
            var conceptId = await CreateConcept(termbaseId, "NewEntry");

            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await _groupShareClient.Terminology.GetConcept(conceptRequest);

            Assert.Equal(conceptResponse.Concept.Id, conceptId);

            var conceptResponse1 = await _groupShareClient.Terminology.GetConcept(termbaseId, conceptId);

            Assert.Equal(conceptResponse1.Concept.Id, conceptId);

            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task UpdateConcept(string termbaseId)
        {
            var conceptId = await CreateConcept(termbaseId, "NewEntry");
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await _groupShareClient.Terminology.GetConcept(conceptRequest);
            conceptResponse.Concept.Languages[0].Terms[0].Text = "updated";

            var updatedResponse = await _groupShareClient.Terminology.EditConcept(termbaseId, conceptResponse);

            var updatedText = updatedResponse.Concept.Languages[0].Terms[0].Text;

            Assert.Equal("updated", updatedText);
            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task UpdateConceptWithCustomFields(string termbaseId)
        {
            var conceptId = await CreateConceptWithCustomFields(termbaseId, "conceptName");
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await _groupShareClient.Terminology.GetConcept(conceptRequest);
            conceptResponse.Concept.Languages[0].Terms[0].Text = "Updated Term From kit with custom fields";

            var updatedResponse = await _groupShareClient.Terminology.EditConcept(termbaseId, conceptResponse);

            var updatedText = updatedResponse.Concept.Languages[0].Terms[0].Text;

            Assert.Equal("Updated Term From kit with custom fields", updatedText);
            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task AddTermForConceptWithoutCustomFields(string termbaseId)
        {
            var conceptId = await CreateConcept(termbaseId, "NewEntry");

            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await _groupShareClient.Terminology.GetConcept(conceptRequest);
            var newTerm = new TermbaseTerms
            {
                Attributes = null,
                Transactions = new List<Transactions>
                {
                    new Transactions
                    {
                        DateTime = DateTime.Now,
                        Id = null,
                        Username = "",
                        Details = new TransactionsDetails
                        {
                            User = "",
                            Type = "Create"
                        }
                    }
                },
                Text = "gsKit2"
            };

            conceptResponse.Concept.Languages[0].Terms.Add(newTerm);

            var updatedResponse = await _groupShareClient.Terminology.EditConcept(termbaseId, conceptResponse);

            var exception = await Record.ExceptionAsync(() => DeleteConcept(termbaseId, conceptId));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task AddTermForConceptWithCustomFields(string termbaseId)
        {
            var conceptId = await CreateConceptWithCustomFields(termbaseId, "NewEntry");
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await _groupShareClient.Terminology.GetConcept(conceptRequest);
            var newTerm = new TermbaseTerms
            {
                Attributes = null,
                Transactions = new List<Transactions>
                {
                    new Transactions
                    {
                        DateTime = DateTime.Now,
                        Id = null,
                        Username = "",
                        Details = new TransactionsDetails
                        {
                            User = "",
                            Type = "Create"
                        }
                    }
                },
                Text = "Added term with custom fields"
            };

            conceptResponse.Concept.Languages[0].Terms.Add(newTerm);

            var updatedResponse = await _groupShareClient.Terminology.EditConcept(termbaseId, conceptResponse);
            Assert.NotNull(updatedResponse);

            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB", "3")]
        public async Task DeleteConcept(string termbaseId, string conceptId)
        {
            // conceptId may not exist, but neither RestAPI nor Kit return an error in this case
            var exception = await Record.ExceptionAsync(() => _groupShareClient.Terminology.DeleteConcept(termbaseId, conceptId));
            Assert.Null(exception);
        }

        public async Task<string> CreateConcept(string termbaseId, string entryName)
        {
            var termBase = await _groupShareClient.Terminology.GetTermbaseById(termbaseId);
            var conceptRequest = new ConceptRequest
            {
                Attributes = null,
                Languages = new List<TermbaseLanguages>
                {
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "English",
                            Name = "English",
                            Code = "EN"
                        },
                        Attributes = null,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = null,
                                Transactions = new List<Transactions>
                                {
                                    new Transactions
                                    {
                                        DateTime = DateTime.Now,
                                        Id = null,
                                        Username = "aghisa",
                                        Details = new TransactionsDetails
                                        {
                                            User = "aghisa",
                                            Type = "Create"
                                        }

                                    }
                                },
                                Text = entryName
                            }
                        }
                    },
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "German",
                            Name = "German",
                            Code = "DE"
                        },
                        Attributes = null,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = null,
                                Transactions = new List<Transactions>
                                {
                                    new Transactions
                                    {
                                        DateTime = DateTime.Now,
                                        Id = null,
                                        Username = "aghisa",
                                        Details = new TransactionsDetails
                                        {
                                            User = "aghisa",
                                            Type = "Create"
                                        }
                                    }
                                },
                                Text = "NewCreated"
                            }
                        }
                    }
                },
                Transactions = new List<Transactions>
                {
                    new Transactions
                    {
                        DateTime = DateTime.Now,
                        Id = null,
                        Details = new TransactionsDetails
                        {
                            User = "sdlcommunity",
                            Type = "Create"
                        },
                        Username = "sdlcommunity"
                    }
                }
            };

            var conceptResponse = await _groupShareClient.Terminology.CreateConcept(termBase, conceptRequest);

            Assert.True(conceptResponse.Concept.Id != string.Empty);
            return conceptResponse.Concept.Id;
        }

        public async Task<string> CreateConceptWithCustomFields(string termbaseId, string entryName)
        {
            var termBase = await _groupShareClient.Terminology.GetTermbaseById(termbaseId);

            var conceptRequest = new ConceptRequest
            {
                Attributes = null,
                Languages = new List<TermbaseLanguages>
                {
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "English",
                            Name = "English",
                            Code = "EN"
                        },
                        Attributes = new List<Attribute>
                        {
                          new Attribute
                          {
                              Name = "Note",
                              Value = new List<Types>
                              {
                                  new Types
                                  {
                                      Type = "Text",
                                      Value = "kitNote"
                                  }
                              }
                          }
                        }
                        ,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = null,
                                Transactions = new List<Transactions>
                                {
                                    new Transactions
                                    {
                                        DateTime = DateTime.Now,
                                        Id = null,
                                        Username = "aghisa",
                                        Details = new TransactionsDetails
                                        {
                                            User = "aghisa",
                                            Type = "Create"
                                        }
                                    }
                                },
                                Text = entryName
                            }
                        }
                    },
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "German",
                            Name = "German",
                            Code = "DE"
                        },
                        Attributes = null,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = null,
                                Transactions = new List<Transactions>
                                {
                                    new Transactions
                                    {
                                        DateTime = DateTime.Now,
                                        Id = null,
                                        Username = "aghisa",
                                        Details = new TransactionsDetails
                                        {
                                            User = "aghisa",
                                            Type = "Create"
                                        }
                                    }
                                },
                                Text = "NewCreated"
                            }
                        }
                    }
                },
                Transactions = new List<Transactions>
                {
                    new Transactions
                    {
                        DateTime = DateTime.Now,
                        Id = null,
                        Details = new TransactionsDetails
                        {
                            User = "sdlcommunity",
                            Type = "Create"
                        },
                        Username = "sdlcommunity"
                    }
                }
            };
            var conceptResponse = await _groupShareClient.Terminology.CreateConcept(termBase, conceptRequest);
            return conceptResponse.Concept.Id;
        }

        [Theory]
        [InlineData("testTB", "customClassId", "2")]
        public async Task CreateConceptCustomClassId(string termbaseId, string entryName, string customClassId)
        {
            var conceptRequest = new ConceptRequest
            {
                Attributes = null,
                Languages = new List<TermbaseLanguages>
                {
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "English",
                            Name = "English",
                            Code = "EN"
                        },
                        Attributes = null,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = null,
                                Transactions = new List<Transactions>
                                {
                                    new Transactions
                                    {
                                        DateTime = DateTime.Now,
                                        Id = null,
                                        Username = "aghisa",
                                        Details = new TransactionsDetails
                                        {
                                            User = "aghisa",
                                            Type = "Create"
                                        }
                                    }
                                },
                                Text = entryName
                            }
                        }
                    },
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "German",
                            Name = "German",
                            Code = "DE"
                        },
                        Attributes = null,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = null,
                                Transactions = new List<Transactions>
                                {
                                    new Transactions
                                    {
                                        DateTime = DateTime.Now,
                                        Id = null,
                                        Username = "aghisa",
                                        Details = new TransactionsDetails
                                        {
                                            User = "aghisa",
                                            Type = "Create"
                                        }
                                    }
                                },
                                Text = "ttt"
                            }
                        }
                    }
                },
                Transactions = new List<Transactions>
                {
                    new Transactions
                    {
                        DateTime = DateTime.Now,
                        Id = null,
                        Details = new TransactionsDetails
                        {
                            User = "sdlcommunity",
                            Type = "Create"
                        },
                        Username = "sdlcommunity"
                    }
                }
            };

            var conceptResponse = await _groupShareClient.Terminology.CreateConceptWithCustomEntryClass(
                customClassId,
                termbaseId,
                conceptRequest);

            Assert.True(conceptResponse.Concept.Id != string.Empty);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task UpdateNewCreatedConcept(string termbaseId)
        {
            var conceptId = await CreateConcept(termbaseId, "NewEntry");
            Assert.True(Convert.ToInt32(conceptId) > 0);

            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await _groupShareClient.Terminology.GetConcept(conceptRequest);

            conceptResponse.Concept.Languages[0].Terms[0].Text = "json";

            await _groupShareClient.Terminology.EditConcept(termbaseId, conceptResponse);
            await DeleteConcept(termbaseId, conceptId);
        }

    }
}