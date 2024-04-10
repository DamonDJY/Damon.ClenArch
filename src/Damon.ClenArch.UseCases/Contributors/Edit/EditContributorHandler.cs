using Ardalis.Result;
using Ardalis.SharedKernel;
using Damon.ClenArch.Core.Interfaces;

namespace Damon.ClenArch.UseCases.Contributors;

public class EditContributorHandler(IEditContributorService _editContributorService) 
: ICommandHandler<EditContributorCommand, Result>
{
  public async Task<Result> Handle(EditContributorCommand command, CancellationToken cancellationToken)
  {
    var result = await _editContributorService.EditContributorAsync(command.ContributorId, command.Name!, command.PhoneNumber!);
    return result;
  }
}
