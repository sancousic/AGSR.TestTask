namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public class LessThanPeriodInfoBuilder : IPeriodInfoBuilder
    {
        public IEnumerable<PeriodInfo> Build(DateSearchModel dateSearchModel)
        {
            var info = new PeriodInfo(null, dateSearchModel.Date, false);

            return new[] { info };
        }
    }
}