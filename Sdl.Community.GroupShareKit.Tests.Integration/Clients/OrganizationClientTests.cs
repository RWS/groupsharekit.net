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
        public async Task UpdateOrganization(Guid organizationId)
        {
            var groupShareClient = Helper.GsClient;

            var organization = await groupShareClient.Organization.GetOrganization(organizationId);

            organization.Description = "Edited using GroupShare Kit";

            var updatedOrganizationId = await groupShareClient.Organization.UpdateOrganization(organization);
            var updatedOrganization = await groupShareClient.Organization.GetOrganization(updatedOrganizationId);

            Assert.Equal("Edited using GroupShare Kit", updatedOrganization.Description);
        }

        [Fact]
        public async Task CreateOrganization()
        {
            var groupShareClient = Helper.GsClient;
            var uniqueId = Guid.NewGuid();
            var organizationName = $"Organization - {uniqueId}";

            var organizationRequest = new Organization()
            {
                UniqueId = uniqueId,
                Name = organizationName,
                IsLibrary = true,
                Description = "Created using GroupShare Kit",
                Path = "/",
                ParentOrganizationId = new Guid(Helper.OrganizationId),
                ChildOrganizations = null,
                Tags = new List<string> { "tagTest" }
            };

            var organizationId = await groupShareClient.Organization.CreateOrganization(organizationRequest);
            var organization = await groupShareClient.Organization.GetOrganization(organizationId);

            Assert.Equal(organizationName, organization.Name);
            Assert.Equal("Created using GroupShare Kit", organization.Description);

            var response = await groupShareClient.Organization.GetByTag("tagTest");
            Assert.True(response.Count > 0);

            await UpdateOrganization(organizationId);
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
                new OrganizationResourcesRequest(new List<string> { templateId.ToString() },
                    organizationId);
            await grClient.Organization.MoveResourceToOrganization(resourceRequest);

            var resources = await grClient.Organization.GetAllOrganizationResources(organizationId);
            var addedResource = resources.FirstOrDefault(r => r.Id == templateId);
            Assert.NotNull(addedResource);

            await grClient.Project.DeleteProjectTemplate(templateId);
            await grClient.Organization.DeleteOrganization(newOrganizationId);
        }


        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task LinkResourceToOrganization(Guid organizationId)
        {
            var groupShareClient = Helper.GsClient;

            var newOrganizationId = await Helper.CreateOrganizationAsync();
            var firstResource = await Helper.CreateTemplateResourceAsync(organizationId);
            var secondResource = await Helper.CreateTemplateResourceAsync(organizationId);
            var resourceRequest =
                new OrganizationResourcesRequest(new List<string> { firstResource.ToString(), secondResource.ToString() },
                    newOrganizationId.ToString());

            await groupShareClient.Organization.LinkResourceToOrganization(resourceRequest);

            var organizationResources = await groupShareClient.Organization.GetOrganizationResources(newOrganizationId);
            Assert.True(organizationResources.Count > 0);

            await groupShareClient.Organization.UnlinkResourceToOrganization(resourceRequest);

            var resources = await groupShareClient.Organization.GetOrganizationResources(newOrganizationId);
            Assert.Empty(resources);

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