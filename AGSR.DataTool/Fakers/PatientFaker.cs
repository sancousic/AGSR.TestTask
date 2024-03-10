using AGSR.DataTool.Models;
using Bogus;

namespace AGSR.DataTool.Rules
{
    internal class PatientFaker : Faker<Patient>
    {
        public PatientFaker(string locale) : base(locale)
        {
            RuleFor(x => x.Name, _ => new NameFaker(locale).Generate());
            RuleFor(x => x.BirthDate, f => f.Date.PastOffset().OrNull(f, 0.2f));
            RuleFor(x => x.Gender, f => f.Random.Enum<Gender>().OrNull(f, 0.2f));
            RuleFor(x => x.Active, f => f.Random.Enum<Active>().OrNull(f, 0.2f));
        }
    }
}
