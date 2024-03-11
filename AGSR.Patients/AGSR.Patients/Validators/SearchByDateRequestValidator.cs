using AGSR.Patients.Requests;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AGSR.Patients.Validators;

public class SearchByDateRequestValidator : AbstractValidator<SearchByDateRequest>
{
    private const string regex = "^(^(?i)[A-Z]{2})?([0-9]([0-9]([0-9][1-9]|[1-9]0)|[1-9]00)|[1-9]000)(-(0[1-9]|1[0-2])(-(0[1-9]|[1-2][0-9]|3[0-1])(T([01][0-9]|2[0-3]):[0-5][0-9]:([0-5][0-9]|60)(\\.[0-9]{1,9})?)?)?(Z|(\\+|-)((0[0-9]|1[0-3]):[0-5][0-9]|14:00)?)?)?$";

    public SearchByDateRequestValidator()
    {
        RuleFor(x => x.date)
            .ForEach(x => x.Matches(regex, RegexOptions.Compiled));
    }
}