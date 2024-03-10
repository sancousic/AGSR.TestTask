using AGSR.Patients.Constants;
using static AGSR.Patients.Constants.Prefixes;

namespace AGSR.Patients.DataSearch.Models
{
    public abstract class DataSearchModel<T>
    {
        protected string Search { get; }

        public string Prefix { get; set; }

        public T? Data { get; set; }

        protected DataSearchModel(string searchValue)
        {
            Search = searchValue;

            var prefix = searchValue[..2];

            if(!ValidPrefixes.Contains(prefix))
            {
                prefix = prefix.Any(char.IsLetter)
                    ? throw new ArgumentException()
                    : Prefixes.Equals;
            }

            Prefix = prefix;
        }

        public abstract void Init();
    }
}
