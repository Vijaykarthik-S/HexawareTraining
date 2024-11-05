namespace Code_first_Assignment.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Doctor? Doctors { get; set; }

        public virtual Patient? Patients { get; set; }
    }
}
