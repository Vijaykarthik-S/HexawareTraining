using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        Student s = new Student();
        Payment p = new Payment();
        Course c = new Course();
        Enrollment e = new Enrollment();

        //Task 2 and 3
        public StudentRepository(int id, string first_name, string last_name, string DOB, string email, string phone_num)
        {
            s.StudentID = id;
            s.FirstName = first_name;
            s.LastName = last_name;
            s.DateOfBirth = Convert.ToDateTime(DOB);
            s.Email = email;
            s.PhoneNumber = phone_num;
        }

        public StudentRepository(int id)
        {
            s.StudentID = id;
        }
        public void DisplayStudentInfo()
        {
            Console.WriteLine("Student Repository- Display method");
            Console.WriteLine("Displaying Student Information:");
            Console.WriteLine($"{s.StudentID}\t{s.FirstName}\t{s.LastName}\t{s.DateOfBirth}\t{s.Email}\t{s.PhoneNumber}");
        }


        public void EnrollInCourse(Course course)
        {
            e.CourseID = course.CourseID;
        }

        public void GetEnrolledCourses()
        {
            Console.WriteLine($"Course in which student enrolled: {c.CourseID},{c.CourseName},{c.CourseCode}");
        }

        public void GetPaymentHistory()
        {
            Console.WriteLine($"Payment Details of Student: {p.PaymentID},{p.StudentID},{p.Amount},{p.PaymentDate}");
        }

        public void MakePayment(decimal amount, string paymentDate)
        {
            p.StudentID = s.StudentID;
            p.Amount = amount;
            p.PaymentDate = Convert.ToDateTime(paymentDate);
        }

        public void UpdateStudentInfo(string firstName, string lastName, string dateOfBirth, string email, string phoneNumber)
        {
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = Convert.ToDateTime(dateOfBirth);
            s.Email = email;
            s.PhoneNumber = phoneNumber;
        }
    }
}