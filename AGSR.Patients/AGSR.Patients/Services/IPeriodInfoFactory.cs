using AGSR.Patients.DataSearch;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.Services;

public interface IPeriodInfoFactory<TEnitty, T> where TEnitty: class, IEntity
{
    SpecificationBase<TEnitty, T> GetBuilder();
}