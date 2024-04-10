using System.ComponentModel.DataAnnotations;

namespace Damon.ClenArch.Web;

public class CreateContributorsDto
{
 public const string Route = "/Contributors";

  [Required]
  public string? Name { get; set; }
  public string? PhoneNumber { get; set; }
}
