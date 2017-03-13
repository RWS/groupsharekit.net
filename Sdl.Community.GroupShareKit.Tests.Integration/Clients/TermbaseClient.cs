using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
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
    }
}
