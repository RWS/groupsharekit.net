using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TermbaseClient
    {
        [Fact]
        public async Task GetTermbases()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var termbases = await groupShareClient.TermBase.GetTermbases();

            Assert.True(termbases.TotalCount>0);
        }

        [Theory]
        [InlineData("TestFromMultiterm")]
        public async Task GetTermbaseById(string termbaseId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var termbase = await groupShareClient.TermBase.GetTermbaseById(termbaseId);

            Assert.Equal(termbase.Termbase.Id, termbaseId);
            Assert.Equal(termbase.Termbase.Name,termbaseId);
        }

        [Theory]
        [InlineData("TestFromMultiterm")]
        public async Task GetFilters(string termbaseId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var filters = await groupShareClient.TermBase.GetFilters(termbaseId);

            Assert.True(filters!=null);

        }

        [Theory]
        [InlineData("testTB","window", "English", "German")]
        public async Task SearchTerm(string termbaseId,string query, string sourceLanguageId, string targetLanguageId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var request = new SearchTermRequest(termbaseId,sourceLanguageId,query,targetLanguageId);

            var searchedResponse = await groupShareClient.TermBase.SearchTerm(request);
            var searchedWord = searchedResponse.Terms.FirstOrDefault(s => s.TermText == query);
            Assert.True(searchedWord != null);
        }

        [Theory]
        [InlineData("testTB", "1")]
        public async Task GetConcept(string termbaseId, string conceptId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var conceptRequest = new ConceptRequest(termbaseId,conceptId);

            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
            Assert.Equal(conceptResponse.Concept.Id,conceptId);

            var conceptResponse1 = await groupShareClient.TermBase.GetConcept(termbaseId,conceptId);
            Assert.Equal(conceptResponse1.Concept.Id, conceptId);

        }

        [Theory]
        [InlineData("testTB", "2")]
        public async Task UpdateConcept(string termbaseId, string conceptId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var conceptRequest = new ConceptRequest(termbaseId, conceptId);
            var conceptResponse = await groupShareClient.TermBase.GetConcept(conceptRequest);
            conceptResponse.Concept.Languages[0].Terms[0].Text = "Updated Term From kit2";

            var updatedResponse = await groupShareClient.TermBase.EditConcept(termbaseId, conceptResponse);

            var updatedText = updatedResponse.Concept.Languages[0].Terms[0].Text;

            Assert.Equal(updatedText, "Updated Term From kit2");
        }

        [Theory]
        [InlineData("testTB", "3")]
        public async Task DeleteConcept(string termbaseId, string conceptId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            await groupShareClient.TermBase.DeleteConcept(termbaseId, conceptId);
        }

        [Theory]
        [InlineData("testTB")]
        public async Task CreateConcept(string termbaseId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var concept = new Concept
            {
                Id = "2",
                EntryClass = new Entry() {Id = "2"},
                Attributes = new List<Attributes>(),
                Languages = new List<TermbaseLanguages>
                {
                    new TermbaseLanguages
                    {
                        Language = new Language
                        {
                            Id = "English",
                            Name = "English",
                            Code = "en"
                        },
                        Attributes = null,
                        Terms = new List<TermbaseTerms>
                        {
                            new TermbaseTerms
                            {
                                Attributes = new List<Attributes>(),
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
                                            Type = "created"
                                        }

                                    }
                                },
                                Text = "car"

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
                                Attributes = new List<Attributes>(),
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
                                            Type = "created"
                                        }

                                    }
                                },
                                Text = "ttt"

                            }
                        }

                    },
                }

            };

            var created = await groupShareClient.TermBase.CreateConcept(termbaseId, concept);

        }
    }
}
