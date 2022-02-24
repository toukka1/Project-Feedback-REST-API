using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ProjectFeedbackAPI;

namespace ProjectFeedbackAPITests;

//public partial class Program {}
public class ProjectsControllerTests : IClassFixture<WebApplicationFactory<ProjectFeedbackAPI.Program>>
{
    readonly HttpClient _client;

    public ProjectsControllerTests(WebApplicationFactory<Program> app)
    {
        _client = app.CreateClient();
    }

    [Fact]
    public async Task GET_retrieves_projects()
    {
        HttpResponseMessage response = await _client.GetAsync("api/Projects");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}