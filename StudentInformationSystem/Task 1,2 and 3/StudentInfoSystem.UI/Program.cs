using System;
using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer;

namespace StudentInfoSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of repositories
            var studentRepository = new StudentRepository(1, "John", "Doe", "2000-01-01", "john.doe@example.com", "1234567890");
            var courseRepository = new CourseRepository();

            // Create instances of services
            var studentService = new StudentService(studentRepository);
            var courseService = new CourseService(courseRepository);

            // Example: Display student information
            studentService.DisplayStudentInfo();

            // Example: Update student information
            studentService.UpdateStudentInfo("John", "Doe", "2000-01-01", "john.updated@example.com", "0987654321");
            studentService.DisplayStudentInfo();

            // Example: Enroll a student in a course
            var course = new Course { Id = 101, Name = "Mathematics" };
            courseService.AddCourse(course); // Assuming you have a method to add a course in the CourseService
            studentService.EnrollInCourse(course);

            // Example: Display enrolled courses
            studentService.GetEnrolledCourses();

            // Example: Make a payment
            studentService.MakePayment(500.00m, DateTime.Now.ToString("yyyy-MM-dd"));
            studentService.GetPaymentHistory();

            // Example: Update course information
            courseService.UpdateCourse(101, "Advanced Mathematics");

            // Example: Get course information
            courseService.GetCourseInfo(101);
        }
    }
}
