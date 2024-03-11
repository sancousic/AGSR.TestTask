using AGSR.Patients.DataSearch.Models;
using static AGSR.Patients.Constants.Prefixes;

namespace AGSR.Patients.Services.Implementations;

public abstract class RangeDataSearchModelBuilder<T> : IDataSearchModelBuilder<T>
{
    public abstract DataSearchModel<T> Build(string searchValue);

    protected string GetPrefix(string searchValue)
    {
        var prefix = searchValue[..2];

        if(!ValidPrefixes.Contains(prefix))
        {
            prefix = prefix.Any(char.IsLetter)
                ? throw new ArgumentException()
                : null;
        }

        return prefix;
    }
}