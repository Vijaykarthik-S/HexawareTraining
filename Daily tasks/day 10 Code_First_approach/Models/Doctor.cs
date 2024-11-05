namespace Code_first_Assignment.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Role { get; set; }
       

        public int HospitalId { get; set; }

        public virtual Hospital? Hospitals { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
