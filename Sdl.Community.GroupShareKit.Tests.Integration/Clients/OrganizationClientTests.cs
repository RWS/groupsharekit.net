using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class OrganizationClientTests
    {
        [Fact]
        public async Task GetOrganizations()
        {
            var groupShareClient = Helper.GsClient;

            var response = await groupShareClient.Organization.GetAll(new OrganizationRequest(false));

            Assert.True(response.Count > 0);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task GetOrganizationById(string organizationId)
        {
            var groupShareClient = Helper.GsClient;
            var organization = await groupShareClient.Organization.Get(organizationId);

            Assert.Equal(organization.UniqueId.ToString(), organizationId);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task Update(string organizationId)
        {
            var groupShareClient = Helper.GsClient;

            var organization = await groupShareClient.Organization.Get(organizationId);

            organization.Description = "AddedDescription";

            var updatedOrgId = await groupShareClient.Organization.Update(organization);
            var updatedOrganization = await groupShareClient.Organization.Get(updatedOrgId);

            Assert.Equal("AddedDescription", updatedOrganization.Description);
        }

        [Fact]
        public async Task Create()
        {
            var groupShareClient = Helper.GsClient;
            var uniqueId = Guid.NewGuid();

            var organization = new Organization()
            {
                UniqueId = uniqueId,
                Name = $"test_ {uniqueId}",
                IsLibrary = true,
                Description = null,
                Path = "/",
                ParentOrganizationId = new Guid(Helper.OrganizationId),
                ChildOrganizations = null,
                Tags = new List<string>() { "tagTest" }
            };

            var organizationId = await groupShareClient.Organization.Create(organization);

            Assert.True(organizationId != string.Empty);

            var response = await groupShareClient.Organization.GetByTag("tagTest");
            Assert.True(response.Count > 0);

            await Update(organizationId);
            await groupShareClient.Organization.DeleteOrganization(organizationId);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task GetOrganizationResources(string organizationId)
        {
            var grClient = Helper.GsClient;
            var orgResources = await grClient.Organization.GetAllOrganizationResources(organizationId);

            Assert.True(orgResources.Count > 0);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task MoveResourceToOrganization(string organizationId)
        {
            var grClient = Helper.GsClient;
            var newOrganizationId = await Helper.CreateOrganizationAsync();
            var templateId = await Helper.CreateTemplateResourceAsync(newOrganizationId);

            var resourceRequest =
                new OrganizationResourcesRequest(new List<string>() { templateId },
                    organizationId);
            await grClient.Organization.MoveResourceToOrganization(resourceRequest);

            var resources = await grClient.Organization.GetAllOrganizationResources(organizationId);
            var addedResource = resources.FirstOrDefault(r => r.Id.ToString() == templateId);
            Assert.True(addedResource != null);

            await grClient.Project.DeleteProjectTemplate(templateId);
            await grClient.Organization.DeleteOrganization(newOrganizationId);
        }


        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task LinkResourceToOrganization(string organizationId)
        {
            var groupShareClient = Helper.GsClient;
           
            var newOrganizationId = await Helper.CreateOrganizationAsync();
            var firstResource = await Helper.CreateTemplateResourceAsync(organizationId);
            var secondResource = await Helper.CreateTemplateResourceAsync(organizationId);
            var resourceRequest =
                new OrganizationResourcesRequest(new List<string>() { firstResource, secondResource },
                    newOrganizationId);

            await groupShareClient.Organization.LinkResourceToOrganization(resourceRequest);

            var organizationResources = await groupShareClient.Organization.GetAllOrganizationResources(newOrganizationId);
            Assert.True(organizationResources.Count > 0);

            await groupShareClient.Organization.UnlinkResourceToOrganization(resourceRequest);

            var resources = await groupShareClient.Organization.GetAllOrganizationResources(newOrganizationId);
            Assert.Equal(0, resources.Count);

            await groupShareClient.Organization.DeleteOrganization(newOrganizationId);
            await groupShareClient.Project.DeleteProjectTemplate(firstResource);
            await groupShareClient.Project.DeleteProjectTemplate(secondResource);
        }

        [Fact]
        public async Task GetOrganizationId()
        {
            var groupShareClient = Helper.GsClient;

            var orgGuid = await groupShareClient.Organization.GetOrganizationId(Helper.OrganizationPath);

            Assert.Equal(new Guid(Helper.OrganizationId), orgGuid);
        }
    }
}