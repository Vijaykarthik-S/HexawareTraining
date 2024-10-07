using StudentInformationSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudentInfo(int studentId, string firstName, string lastName, string email, string phoneNumber);
        void GetStudentInfo(int studentId);
        void EnrollInCourse(Course course);
        void MakePayment(decimal amount, string paymentDate);
        void GetEnrolledCourses();
        void GetPaymentHistory();
    }
}
