using AGSR.DataTool.Models;
using Bogus;

namespace AGSR.DataTool.Rules
{
    public class NameFaker : Faker<Name>
    {
        public NameFaker(string locale) : base(locale) 
        {
            RuleFor(x => x.Use, f => f.Random.String2(15).OrNull(f, .2f));
            RuleFor(x => x.GivenNmes, f => f.Name.LastName().Split(' '));
            RuleFor(x => x.Family, f => f.Name.FirstName());
        }
    }
}
