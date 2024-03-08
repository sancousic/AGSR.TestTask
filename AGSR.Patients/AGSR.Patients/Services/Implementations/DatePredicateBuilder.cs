using AGSR.Patients.DateSearch.PeriodInfo;
using LinqKit;
using PatientEntity = AGSR.Patients.Domain.Entities.Patient;

namespace AGSR.Patients.Services.Implementations
{
    public class DatePredicateBuilder : IPredicateBuilder<PatientEntity>
    {
        public ExpressionStarter<PatientEntity> BuildPredicate(IEnumerable<PeriodInfo> periodInfos)
        {
            var starter = PredicateBuilder.New<PatientEntity>();

            periodInfos.ForEach(x =>
            {
                var innerStarter = PredicateBuilder.New<PatientEntity>();

                if (x.StartDate.HasValue)
                {
                    if (x.IsExlude)
                    {
                        innerStarter.Start(p => p.BirthDate < x.StartDate);
                    }
                    else
                    {
                        innerStarter.And(p => p.BirthDate >= x.StartDate);
                    }
                }

                if (x.EndDate.HasValue)
                {
                    if (x.IsExlude)
                    {
                        innerStarter.Or(p => p.BirthDate > x.EndDate);
                    }
                    else
                    {
                        innerStarter.And(p => p.BirthDate < x.EndDate);
                    }
                }

                starter.And(innerStarter);
            });

            return starter;
        }
    }
}
