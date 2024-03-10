using AGSR.Patients.DataSearch.Builders;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.Services
{
    public interface IPeriodInfoFactory<T> where T: class, IEntity
    {
        IPredicateBuilder<T, PeriodInfo> GetBuilder(string prefix);
    }
}