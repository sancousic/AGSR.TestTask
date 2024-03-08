namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public class GreatOrEquealPeriodInfoBuilder : IPeriodInfoBuilder
    {
        public IEnumerable<PeriodInfo> Build(DateSearchModel dateSearchModel)
        {
            var info = new PeriodInfo(dateSearchModel.Date, null, false);

            return new[] { info };
        }
    }
}
