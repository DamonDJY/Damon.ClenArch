using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Damon.ClenArch.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
