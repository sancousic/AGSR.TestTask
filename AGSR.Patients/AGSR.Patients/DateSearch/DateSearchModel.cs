using static AGSR.Patients.Extensions.DateTimeOffsetX;
using static AGSR.Patients.Constants.Prefixes;
using System.Globalization;

namespace AGSR.Patients.DateSearch
{
    public class DateSearchModel
    {
        private string search { get; }

        public string Prefix { get; }

        public string? Format { get; }

        public DateTimeOffset? Date { get; }

        public DateSearchModel(string searchValue)
        {
            search = searchValue;

            var prefix = searchValue.Substring(0, 2);

            if(!ValidPrefixes.Contains(prefix))
            {
                throw new ArgumentException();
            }

            Prefix = prefix;

            if (DateTimeOffset.Now.TryParseExactWithFormat(searchValue[2..], CultureInfo.InvariantCulture, DateTimeStyles.None, out var format, out var date))
            {
                Format = format;
                Date = date;

                return;
            }

            throw new ArgumentException();
        }
    }
}
