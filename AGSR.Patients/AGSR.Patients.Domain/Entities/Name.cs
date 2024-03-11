using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGSR.Patients.Domain.Entities;

public class Name : IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

    public string? Use { get; set; }

    [Required]
    public string Family { get; set; } = null!;

    public List<GivenName> GivenNames { get; set; } = new List<GivenName>();

    public Patient Patient { get; set; } = null!;
}