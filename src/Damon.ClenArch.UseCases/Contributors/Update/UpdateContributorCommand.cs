using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Damon.ClenArch.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
