using System.Windows.Input;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Damon.ClenArch.UseCases.Contributors;

public record class EditContributorCommand(int ContributorId, string? Name, string? PhoneNumber) :ICommand<Result>;
