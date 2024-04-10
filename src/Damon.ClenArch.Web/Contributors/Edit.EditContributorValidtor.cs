using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;

namespace Damon.ClenArch.Web.Contributors;

public class EditContributorValidtor : Validator<EditContributorRequest>
{
  public EditContributorValidtor()
  {
    RuleFor(x => x.ContributorId).GreaterThan(0);
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.PhoneNumber).NotEmpty();
  }
}
