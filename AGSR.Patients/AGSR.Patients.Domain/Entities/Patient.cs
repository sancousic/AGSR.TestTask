using AGSR.Patients.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGSR.Patients.Domain.Entities;

public class Patient : IEntity
{
    [ForeignKey("Id")]
    public Name Name { get; set; } = new();

    [Required]
    public DateTimeOffset BirthDate { get; set; }

    public Gender? Gender { get; set; }

    public Active? Active { get; set; }
}