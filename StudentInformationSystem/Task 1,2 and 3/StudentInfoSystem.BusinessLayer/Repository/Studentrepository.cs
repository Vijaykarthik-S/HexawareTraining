using System.Collections.Generic;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void UpdateStudentInfo(int studentId, string firstName, string lastName, string email, string phoneNumber)
        {
            var student = students.Find(s => s.Id == studentId);
            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Email = email;
                student.PhoneNumber = phoneNumber;
            }
        }

        public void GetStudentInfo(int studentId)
        {
            var student = students.Find(s => s.Id == studentId);
            // Display student information
        }

        public void EnrollInCourse(Course course)
        {
            // Implement enrollment logic
        }

        public void MakePayment(decimal amount, string paymentDate)
        {
            // Implement payment logic
        }

        public void GetEnrolledCourses()
        {
            // Implement logic to get enrolled courses
        }

        public void GetPaymentHistory()
        {
            // Implement logic to get payment history
        }
    }
}
