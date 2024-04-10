using System.ComponentModel.DataAnnotations;

namespace Damon.ClenArch.Web.Contributors;

public record EditContributorRequest
{
    public const string Route = "/ContributorsForEdit/{ContributorId:int}";

    public static string BuildRoute(int contributorId) => Route.Replace("{ContributorId:int}", contributorId.ToString());

    public int ContributorId { get; set; }
[Required]
    public string? Name { get; set; }
[Required]
    public string? PhoneNumber { get; set; }
}

