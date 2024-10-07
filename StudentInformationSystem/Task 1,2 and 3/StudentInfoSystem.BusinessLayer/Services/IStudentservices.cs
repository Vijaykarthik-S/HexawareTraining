using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void UpdateStudentInfo(int studentId, string firstName, string lastName, string email, string phoneNumber);
        void DisplayStudentInfo(int studentId);
        void EnrollInCourse(Course course);
        void GetEnrolledCourses(int studentId);
        void MakePayment(decimal amount, string paymentDate);
        void GetPaymentHistory(int studentId);
    }
}
