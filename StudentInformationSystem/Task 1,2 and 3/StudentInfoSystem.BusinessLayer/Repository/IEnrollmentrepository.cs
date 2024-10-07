using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public interface IEnrollmentRepository
    {
        void AddEnrollment(Enrollment enrollment);
        void GetEnrollmentInfo(int enrollmentId);
    }
}
