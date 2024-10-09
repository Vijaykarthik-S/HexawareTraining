public class Teacher
{
    public int TeacherID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    // Task 5: List of assigned courses
    public List<Course> AssignedCourses { get; set; } = new List<Course>();
}
