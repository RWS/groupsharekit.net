using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;
using Attribute = Sdl.Community.GroupShareKit.Models.Response.Attribute;
using ConceptResponse = Sdl.Community.GroupShareKit.Clients.ConceptResponse;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TermbaseClient
    {
        [Fact]
        public async Task GetTermbases()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var termbases = await groupShareClient.TermBase.GetTermbases();

            Assert.True(termbases.TotalCount > 0);
        }

        [Theory]
        [InlineData("TestFromMultiterm")]
        public async Task GetTermbaseById(string termbaseId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var termbase = await groupShareClient.TermBase.GetTermbaseById(termbaseId);

            Assert.Equal(termbase.Termbase.Id, termbaseId);
            Assert.Equal(termbase.Termbase.Name, termbaseId);
        }

        [Theory]
        [InlineData("TestFromMultiterm")]
        public async Task GetFilters(string termbaseId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var filters = await groupShareClient.TermBase.GetFilters(termbaseId);

            Assert.True(filters != null);

        }

        [Theory]
        [InlineData("testTB", "ttt", "German")]
        public async Task SearchTerm(string termbaseId, string query, string language)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new SearchTermRequest(termbaseId, language, query);

            var searchedResponse = await groupShareClient.TermBase.SearchTerm(request);
            var searchedWord = searchedResponse.Terms.FirstOrDefault(s => s.TermText == query);
            Assert.True(searchedWord != null);
        }
        [Theory]
        [InlineData("testTB", "window", "German")]
        public async Task SearrchNotFoundTerm(string termbaseId, string query, string language)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new SearchTermRequest(termbaseId, language, query);

            var searchedResponse = await groupShareClient.TermBase.SearchTerm(request);

            Assert.Equal(searchedResponse.Terms.Count,0);
        }

        [Theory]
        [InlineData("testTB", "16")]
        public async Task GetConcept(string termbaseId, string conceptId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);

            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
            Assert.Equal(conceptResponse.Concept.Id, conceptId);

            var conceptResponse1 = await groupShareClient.TermBase.GetConcept(termbaseId, conceptId);
            Assert.Equal(conceptResponse1.Concept.Id, conceptId);

        }

        [Theory]
        [InlineData("testTB")]

        public async Task UpdateConcept(string termbaseId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var conceptId = await CreateConcept(termbaseId, "NewEntry");
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
            conceptResponse.Concept.Languages[0].Terms[0].Text = "updated";

            var updatedResponse = await groupShareClient.TermBase.EditConcept(termbaseId, conceptResponse);

            var updatedText = updatedResponse.Concept.Languages[0].Terms[0].Text;

            Assert.Equal(updatedText, "updated");
            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task UpdateConceptWithCustomFields(string termbaseId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var conceptId = await CreateConceptWithCustomFields(termbaseId, "conceptName");
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
            conceptResponse.Concept.Languages[0].Terms[0].Text = "Updated Term From kit with custm fields";

            var updatedResponse = await groupShareClient.TermBase.EditConcept(termbaseId, conceptResponse);

            var updatedText = updatedResponse.Concept.Languages[0].Terms[0].Text;

            Assert.Equal(updatedText, "Updated Term From kit with custm fields");
            await DeleteConcept(termbaseId, conceptId);
        }
  
        [Theory]
        [InlineData("testTB")]
        public async Task AddTermForConceptWithoutCustomFields(string termbaseId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var conceptId = await CreateConcept(termbaseId, "NewEntry");

            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
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

            var updatedResponse = await groupShareClient.TermBase.EditConcept(termbaseId, conceptResponse);
            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task AddTermForConceptWithCustomFields(string termbaseId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var conceptId = await CreateConceptWithCustomFields(termbaseId, "NewEntry");
            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
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

            var updatedResponse = await groupShareClient.TermBase.EditConcept(termbaseId, conceptResponse);

            await DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB", "3")]
        public async Task DeleteConcept(string termbaseId, string conceptId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            await groupShareClient.TermBase.DeleteConcept(termbaseId, conceptId);
        }

   
        public async Task<string> CreateConcept(string termbaseId,string entryName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var termBase = await groupShareClient.TermBase.GetTermbaseById(termbaseId);
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

            var conceptResponse = await groupShareClient.TermBase.CreateConcept(termBase, conceptRequest);

            Assert.True(conceptResponse.Concept.Id!=string.Empty);
            return conceptResponse.Concept.Id;
        }

        public async Task<string> CreateConceptWithCustomFields(string termbaseId,string entryName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var termBase = await groupShareClient.TermBase.GetTermbaseById(termbaseId);        
            
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

            var conceptResponse = await groupShareClient.TermBase.CreateConcept(termBase, conceptRequest);
            return conceptResponse.Concept.Id;
        }
        [Theory]
        [InlineData("testTB", "customClassId", "2")]
        public async Task CreateConceptCustomClassId(string termbaseId, string entryName, string customClassId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
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

            var conceptResponse =
                await
                    groupShareClient.TermBase.CreateConceptWithCustomEntryClass(customClassId, termbaseId,
                        conceptRequest);

            Assert.True(conceptResponse.Concept.Id != string.Empty);
        }

        [Theory]
        [InlineData("testTB", "18")]
        public async Task UpdateNewCreatedConcept(string termbaseId, string conceptId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var conceptRequest = new ConceptResponse(termbaseId, conceptId);
            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);

            conceptResponse.Concept.Languages[0].Terms[0].Text = "json";

            var updatedResponse = await groupShareClient.TermBase.EditConcept(termbaseId, conceptResponse);
        }



    }
}
