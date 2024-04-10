using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Damon.ClenArch.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
