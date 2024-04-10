using Ardalis.HttpClientTestExtensions;
using Damon.ClenArch.Infrastructure.Data;
using Damon.ClenArch.Web.Contributors;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Damon.ClenArch.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorList : IClassFixture<CustomWebApplicationFactory<Program>>
{
 private readonly HttpClient _client;

  public ContributorList(CustomWebApplicationFactory<Program> factory, ITestOutputHelper outputHelper)
  {
    factory.ConfigureLogging(outputHelper);
   _client = factory.CreateClient();
  }

 

  [Fact]
  public async Task ReturnsTwoContributors()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

    Log.Information("ContributorList:ReturnsTwoContributors: result.Contributors.Count: " + result.Contributors.Count);
    Assert.Equal(2, result.Contributors.Count);
    Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor1.Name);
    Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor2.Name);
  }
}
