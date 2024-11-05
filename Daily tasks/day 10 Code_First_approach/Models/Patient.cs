namespace Code_first_Assignment.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string CauseofHealthIssue { get; set; }
        public string DoctorId { get; set; }

        public virtual Doctor? Doctors { get; set; }

       

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
