using AGSR.Patients.Constants;
using static AGSR.Patients.Constants.Prefixes;

namespace AGSR.Patients.DataSearch.Models
{
    public abstract class DataSearchModel<T>
    {
        public string Prefix { get; protected set; }

        protected string Search { get; }
        
        public T? Data { get; protected set; }

        protected DataSearchModel(string searchValue)
        {
            Search = searchValue;

            var prefix = searchValue[..2];

            if(!ValidPrefixes.Contains(prefix))
            {
                prefix = prefix.Any(char.IsLetter)
                    ? throw new ArgumentException()
                    : Prefixes.EqualsPrefix;
            }

            Prefix = prefix;
        }

        public abstract void Init();
    }
}
