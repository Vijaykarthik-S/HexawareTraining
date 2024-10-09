using StudentInformationSystem.Entity;

public class Student
{
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // Task 5: List of enrollments
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
