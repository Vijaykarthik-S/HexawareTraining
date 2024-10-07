using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public interface IEnrollmentService
    {
        void EnrollStudentInCourse(int studentId, int courseId);
        void DropCourse(int studentId, int courseId);
        void GetEnrollments(int studentId);
    }
}
