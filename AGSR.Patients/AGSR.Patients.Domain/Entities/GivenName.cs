namespace AGSR.Patients.Domain.Entities
{
    public class GivenName
    {
        public Guid Id { get; set; }

        public string? Value { get; set; }

        public IEnumerable<Name>? Name { get; set; }
    }
}
