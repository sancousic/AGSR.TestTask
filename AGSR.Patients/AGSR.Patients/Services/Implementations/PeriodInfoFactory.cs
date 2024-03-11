using AGSR.Patients.Constants;
using AGSR.Patients.DataSearch;
using AGSR.Patients.DataSearch.Models;
using AGSR.Patients.DataSearch.Specifications.Patients.Date;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.Services.Implementations;

public class PeriodInfoFactory : IPeriodInfoFactory<Patient, PeriodInfo>
{
    private DataSearchModel<PeriodInfo> SearchModel { get; }

    public PeriodInfoFactory(DataSearchModel<PeriodInfo> searchModel)
    {
        SearchModel = searchModel;
    }

    public SpecificationBase<Patient, PeriodInfo> GetBuilder()
        => SearchModel.Prefix switch
        {
            Prefixes.EqualsPrefix => new DateEqualsPeriodInfoBuilder(SearchModel.Data),
            Prefixes.NotEqualsPrefix => new DateNotEqualsPeriodInfoBuilder(SearchModel.Data),
            Prefixes.GreaterThanPrefix => new DateGreatThanPeriodInfoBuilder(SearchModel.Data),
            Prefixes.LessThanPrefix => new DateLessThanPeriodInfoBuilder(SearchModel.Data),
            Prefixes.GreaterOrEqualsPrefix => new DateGreatOrEqualPeriodInfoBuilder(SearchModel.Data),
            Prefixes.LessOrEqualPrefix => new DateLessOrEqualPeriodInfoBuilder(SearchModel.Data),
            Prefixes.StartAfterPrefix => new DateStartAfterPeriodInfoBuilder(SearchModel.Data),
            Prefixes.EndsBeforePrefix => new DateEndsBeforePeriodInfoBuilder(SearchModel.Data),
            Prefixes.ApproximatelySamePrefix => new DateApproximatelySamePredicateBuilder(SearchModel.Data),
            _ => throw new NotSupportedException(),
        };
}