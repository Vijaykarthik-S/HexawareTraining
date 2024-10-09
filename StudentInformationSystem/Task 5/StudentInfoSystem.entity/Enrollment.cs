public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int StudentID { get; set; }
    public int CourseID { get; set; }
    public DateTime EnrollmentDate { get; set; }

    // Task 5: Links to Student and Course
    public Student Student { get; set; }
    public Course Course { get; set; }
}
