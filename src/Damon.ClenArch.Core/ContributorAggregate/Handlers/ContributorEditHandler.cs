using Damon.ClenArch.Core.ContributorAggregate.Events;
using Damon.ClenArch.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Damon.ClenArch.Core.ContributorAggregate.Handlers;

public class ContributorEditHandler(ILogger<ContributorEditHandler> _logger,
IEmailSender _emailSender) : INotificationHandler<ContributorEditEvent>
{
  public async Task Handle(ContributorEditEvent notification, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Contributor {ContributorId} edited", notification.ContributorId);
     await _emailSender.SendEmailAsync("to@test.com",
                                  "from@test.com",
                                  "Contributor Deleted",
                                  $"Contributor with id {notification.ContributorId} was edited.");
  }
}
