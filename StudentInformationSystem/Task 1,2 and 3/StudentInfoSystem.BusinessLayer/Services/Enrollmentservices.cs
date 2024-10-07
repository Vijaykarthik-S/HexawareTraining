using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(EnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public void EnrollStudent(Enrollment enrollment)
        {
            _enrollmentRepository.EnrollStudent(enrollment);
        }

        public void GetEnrollmentDetails()
        {
            _enrollmentRepository.GetEnrollmentDetails();
        }
    }
}
