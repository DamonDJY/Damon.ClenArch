using Ardalis.Result;
using Damon.ClenArch.UseCases.Contributors;
using Damon.ClenArch.Web.Contributors;
using FastEndpoints;
using MediatR;

namespace Damon.ClenArch.Web.Contributors;

public class Edit(IMediator mediator) : Endpoint<EditContributorRequest>
{

  public override void Configure()
  {
    Put(EditContributorRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    EditContributorRequest request,
    CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new EditContributorCommand(request.ContributorId, request.Name, request.PhoneNumber), cancellationToken);

  if (result.Status == ResultStatus.NotFound)
  {
    await SendNotFoundAsync(cancellationToken);
    return;
  }
    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
      return;
    }
  }
}

 