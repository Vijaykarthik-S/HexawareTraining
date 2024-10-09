using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.BusinessLayer.Services;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
        Course course;
        IStudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void EnrollInCourse(Course course)
        {
            _studentRepository.EnrollInCourse(course);
        }

        public void UpdateStudentInfo(string firstName, string lastName, string dateOfBirth, string email, string phoneNumber)
        {
            _studentRepository.UpdateStudentInfo(firstName, lastName, dateOfBirth, email, phoneNumber);
        }
        public void DisplayStudentInfo()
        {
            _studentRepository.DisplayStudentInfo();
        }
        public void MakePayment(decimal amount, string paymentDate)
        {
            _studentRepository.MakePayment(amount, paymentDate);
        }

        public void GetEnrolledCourses()
        {
            _studentRepository.GetEnrolledCourses();
        }

        public void GetPaymentHistory()
        {
            _studentRepository.GetPaymentHistory();
        }
    }
}