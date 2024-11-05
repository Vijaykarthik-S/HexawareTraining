namespace Code_first_Assignment.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public double MobileNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection <Doctor>? Doctors { get; set; }


    }
}
