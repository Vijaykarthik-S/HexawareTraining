using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
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
