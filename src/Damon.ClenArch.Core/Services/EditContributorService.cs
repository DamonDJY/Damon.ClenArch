using Ardalis.Result;
using Ardalis.SharedKernel;
using Damon.ClenArch.Core.ContributorAggregate;
using Damon.ClenArch.Core.ContributorAggregate.Events;
using Damon.ClenArch.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Damon.ClenArch.Core.Services;

public class EditContributorService (IRepository<Contributor> _repository, IMediator _mediator
, ILogger<EditContributorService> _logger)
: IEditContributorService
{
  public async Task<Result> EditContributorAsync(int id, string name, string phoneNumber)
  {
    _logger.LogInformation("Editing contributor {ContributorId}", id);
    var aggreateToEdit = await _repository.GetByIdAsync(id);
    if (aggreateToEdit == null)
    {
      _logger.LogWarning("Contributor {ContributorId} not found", id);
      return Result.NotFound();
    }
    aggreateToEdit.UpdateName(name);
    aggreateToEdit.SetPhoneNumber(phoneNumber);
    await _repository.UpdateAsync(aggreateToEdit);
    var domainEvent = new ContributorEditEvent(id, name!, phoneNumber!);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
