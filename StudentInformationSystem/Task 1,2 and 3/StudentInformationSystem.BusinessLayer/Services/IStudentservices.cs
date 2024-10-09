using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Services
{
    internal interface IStudentService
    {
        void EnrollInCourse(Course course);
        void UpdateStudentInfo(string firstName, string lastName, string dateOfBirth, string email, string phoneNumber);
        void MakePayment(decimal amount, string paymentDate);
        void DisplayStudentInfo();
        void GetEnrolledCourses();
        void GetPaymentHistory();
    }
}