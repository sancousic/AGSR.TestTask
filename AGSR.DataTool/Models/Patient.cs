namespace AGSR.DataTool.Models
{
    public class Patient
    {
        public Name Name { get; set; }

        public DateTimeOffset? BirthDate { get; set; }

        public Gender? Gender { get; set; }

        public Active? Active { get; set; }
    }
}
