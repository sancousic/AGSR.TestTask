using System.ComponentModel.DataAnnotations.Schema;

namespace AGSR.Patients.Domain.Entities
{
    public class GivenName : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public string? Value { get; set; }

        public Name Name { get; set; } = null!;
    }
}
