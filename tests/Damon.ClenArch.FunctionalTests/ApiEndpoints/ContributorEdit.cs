using System.Text;
using Ardalis.HttpClientTestExtensions;
using Damon.ClenArch.Infrastructure.Data;
using Damon.ClenArch.Web.Contributors;
using Newtonsoft.Json;
using Xunit;

namespace Damon.ClenArch.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorEdit(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsSeedContributorGivenId1()
    {
        var request = new EditContributorRequest
        {
            Name = "Damon",
            PhoneNumber = "1234567890"
        };
        var httpContent = JsonConvert.SerializeObject(request);
        HttpContent content = new StringContent(httpContent, Encoding.UTF8, "application/json");
        //var result = await _client.PutAndDeserializeAsync<ContributorRecord>(EditContributorRequest.BuildRoute(2), content);
             var response = await _client.PutAsync(EditContributorRequest.BuildRoute(2), content);
         var responseContent = await response.Content.ReadAsStringAsync();
        var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(2));

         //Assert.Equal(1, result.Id);
         //Assert.Equal(SeedData.Contributor1.Name, result.Name);
          Assert.Equal("Damon", result.Name);
    }

    
}
