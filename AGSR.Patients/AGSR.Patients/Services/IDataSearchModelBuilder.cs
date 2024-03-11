using AGSR.Patients.DataSearch.Models;

namespace AGSR.Patients.Services;

public interface IDataSearchModelBuilder<T>
{
    DataSearchModel<T> Build(string searchValue);
}