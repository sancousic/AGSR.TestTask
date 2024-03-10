using System.ComponentModel.DataAnnotations;

namespace AGSR.DataTool.Models
{
    public class Name
    {
        public string? Use { get; set; }

        [Required]
        public string Family { get; set; }

        public IEnumerable<string> GivenNmes { get; set; }
    }
}
