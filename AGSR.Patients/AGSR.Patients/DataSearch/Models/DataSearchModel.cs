namespace AGSR.Patients.DataSearch.Models;

public class DataSearchModel<T>
{
    public string Prefix { get; set; }
        
    public T? Data { get; set; }
}