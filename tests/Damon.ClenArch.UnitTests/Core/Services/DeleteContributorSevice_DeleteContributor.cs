using Ardalis.SharedKernel;
using Damon.ClenArch.Core.ContributorAggregate;
using Damon.ClenArch.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Damon.ClenArch.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
  private readonly IRepository<Contributor> _repository = Substitute.For<IRepository<Contributor>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeleteContributorService> _logger = Substitute.For<ILogger<DeleteContributorService>>();

  private readonly DeleteContributorService _service;

  public DeleteContributorService_DeleteContributor()
  {
    _service = new DeleteContributorService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(0);

System.Console.WriteLine("DeleteContributorService_DeleteContributor:ReturnsNotFoundGivenCantFindContributor: result.Status: " + result.Status);
    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
    
  }
}
