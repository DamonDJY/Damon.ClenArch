using Ardalis.SharedKernel;

namespace Damon.ClenArch.Core.ContributorAggregate.Events;

public sealed class ContributorEditEvent(int contributorId, string name, string phoneNumber) 
: DomainEventBase
{
    public int ContributorId { get; } = contributorId;
    public string Name { get; } = name;
    public string PhoneNumber { get; } = phoneNumber;
}
