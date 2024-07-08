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
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetOrganizations()
        {
            var response = await GroupShareClient.Organization.GetAll(new OrganizationRequest(false));

            Assert.True(response.Count > 0);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task GetOrganizationById(Guid organizationId)
        {
            var organization = await GroupShareClient.Organization.GetOrganization(organizationId);

            Assert.Equal(organization.UniqueId, organizationId);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task UpdateOrganization(Guid organizationId)
        {
            var organization = await GroupShareClient.Organization.GetOrganization(organizationId);

            organization.Description = "Edited using GroupShare Kit";

            var updatedOrganizationId = await GroupShareClient.Organization.UpdateOrganization(organization);
            var updatedOrganization = await GroupShareClient.Organization.GetOrganization(updatedOrganizationId);

            Assert.Equal("Edited using GroupShare Kit", updatedOrganization.Description);
        }

        [Fact]
        public async Task CreateOrganization()
        {
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

            var organizationId = await GroupShareClient.Organization.CreateOrganization(organizationRequest);
            var organization = await GroupShareClient.Organization.GetOrganization(organizationId);

            Assert.Equal(organizationName, organization.Name);
            Assert.Equal("Created using GroupShare Kit", organization.Description);

            var response = await GroupShareClient.Organization.GetByTag("tagTest");
            Assert.True(response.Count > 0);

            await UpdateOrganization(organizationId);
            await GroupShareClient.Organization.DeleteOrganization(organizationId);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task GetOrganizationResources(Guid organizationId)
        {
            var orgResources = await GroupShareClient.Organization.GetOrganizationResources(organizationId);

            Assert.True(orgResources.Count > 0);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task MoveResourceToOrganization(Guid organizationId)
        {
            var newOrganizationId = await Helper.CreateOrganizationAsync();
            var templateId = await Helper.CreateTemplateResourceAsync(newOrganizationId);

            var resourceRequest = new OrganizationResourcesRequest(new List<string> { templateId.ToString() }, organizationId.ToString());
            await GroupShareClient.Organization.MoveResourceToOrganization(resourceRequest);

            var resources = await GroupShareClient.Organization.GetOrganizationResources(organizationId);
            var addedResource = resources.FirstOrDefault(r => r.Id == templateId);
            Assert.NotNull(addedResource);

            await GroupShareClient.Project.DeleteProjectTemplate(templateId);
            await GroupShareClient.Organization.DeleteOrganization(newOrganizationId);
        }

        [Theory]
        [MemberData(nameof(OrganizationData.OrganizationId), MemberType = typeof(OrganizationData))]
        public async Task LinkResourceToOrganization(Guid organizationId)
        {
            var newOrganizationId = await Helper.CreateOrganizationAsync();
            var firstResource = await Helper.CreateTemplateResourceAsync(organizationId);
            var secondResource = await Helper.CreateTemplateResourceAsync(organizationId);
            var resourceRequest = new OrganizationResourcesRequest(new List<string> { firstResource.ToString(), secondResource.ToString() }, newOrganizationId.ToString());

            await GroupShareClient.Organization.LinkResourceToOrganization(resourceRequest);

            var organizationResources = await GroupShareClient.Organization.GetOrganizationResources(newOrganizationId);
            Assert.True(organizationResources.Count > 0);

            await GroupShareClient.Organization.UnlinkResourceToOrganization(resourceRequest);

            var resources = await GroupShareClient.Organization.GetOrganizationResources(newOrganizationId);
            Assert.Empty(resources);

            await GroupShareClient.Organization.DeleteOrganization(newOrganizationId);
            await GroupShareClient.Project.DeleteProjectTemplate(firstResource);
            await GroupShareClient.Project.DeleteProjectTemplate(secondResource);
        }

        [Fact]
        public async Task GetOrganizationId()
        {
            var orgGuid = await GroupShareClient.Organization.GetOrganizationId(Helper.OrganizationPath);

            Assert.Equal(new Guid(Helper.OrganizationId), orgGuid);
        }
    }
}