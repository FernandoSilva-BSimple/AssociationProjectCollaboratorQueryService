using System.Net;
using System.Text;
using System.Text.Json;
using Application.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApi.IntegrationTests;
using Xunit;

namespace WebApi.IntegrationTests.Tests;

public class AssociationProjectCollaboratorControllerTests
    : IntegrationTestBase, IClassFixture<IntegrationTestsWebApplicationFactory<Program>>
{
    public AssociationProjectCollaboratorControllerTests(IntegrationTestsWebApplicationFactory<Program> factory)
        : base(factory.CreateClient())
    {
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenAssociationDoesNotExist()
    {
        // Arrange
        var invalidId = Guid.NewGuid();

        // Act
        var response = await GetAsync($"/api/associationsPC/{invalidId}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetAssociationDetails_ReturnsNotFound_WhenAssociationDoesNotExist()
    {
        // Arrange
        var invalidId = Guid.NewGuid();

        // Act
        var response = await GetAsync($"/api/associationsPC/{invalidId}/details");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetAllWithDetailsByCollaboratorId_ReturnsEmpty_WhenNoneExist()
    {
        // Arrange
        var collaboratorId = Guid.NewGuid();

        // Act
        var response = await GetAsync($"/api/associationsPC/collaborator/{collaboratorId}/details");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<AssociationProjectCollaboratorDetailsDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAllWithDetailsByProjectId_ReturnsEmpty_WhenNoneExist()
    {
        // Arrange
        var projectId = Guid.NewGuid();

        // Act
        var response = await GetAsync($"/api/associationsPC/project/{projectId}/details");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<AssociationProjectCollaboratorDetailsDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(result);
        Assert.Empty(result);
    }


}
