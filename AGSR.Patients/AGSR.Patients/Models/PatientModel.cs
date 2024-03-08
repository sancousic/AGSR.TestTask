using AGSR.Patients.Domain.Enums;

namespace AGSR.Patients.Models
{
    public class PatientModel
    {
        public NameModel? Name { get; set; } = new();

        public DateTimeOffset BirthDate { get; set; }

        public Gender? Gender { get; set; }

        public Active? Active { get; set; }
    }
}
