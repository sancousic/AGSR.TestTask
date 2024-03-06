using AGSR.Patients.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AGSR.Patients.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }

        public Name? Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public Gender? Gender { get; set; }

        public Active? Active { get; set; }
    }
}
