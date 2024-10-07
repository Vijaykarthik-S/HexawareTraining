using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Student(int studentID, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            StudentId = studentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public void EnrollInCourse(Course course)
        {
            // Implementation for enrolling in a course
        }

        public void UpdateStudentInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            // Implementation for recording a payment
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
        }

        public List<Course> GetEnrolledCourses()
        {
            // Implementation to retrieve enrolled courses
            return new List<Course>();
        }

        public List<Payment> GetPaymentHistory()
        {
            // Implementation to retrieve payment history
            return new List<Payment>();
        }
    }

}

