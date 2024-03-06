using System.ComponentModel.DataAnnotations;

namespace AGSR.Patients.Domain.Entities
{
    public class Name
    {
        public Guid Id { get; set; }

        public string? Use { get; set; }

        [Required]
        public string Family { get; set; } = null!;

        public IEnumerable<GivenName> GivenNames { get; set; } = new List<GivenName>();
    }
}
