using System.ComponentModel.DataAnnotations;

namespace AGSR.Patients.Models
{
    public class NameModel
    {
        public Guid Id { get; set; }

        public string? Use { get; set; }

        [Required]
        public string Family { get; set; } = null!;

        public IEnumerable<string> GivenNames { get; set; } = new List<string>();
    }
}
