using Ardalis.Result;

namespace Damon.ClenArch.Core.Interfaces;

public interface IEditContributorService
{
    public Task<Result> EditContributorAsync(int id, string name, string phoneNumber);
}
