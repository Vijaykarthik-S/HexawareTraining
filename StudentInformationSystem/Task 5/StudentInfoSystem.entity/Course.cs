using StudentInformationSystem.Entity;

public class Course
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }

    // Task 5: List of enrollments
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
