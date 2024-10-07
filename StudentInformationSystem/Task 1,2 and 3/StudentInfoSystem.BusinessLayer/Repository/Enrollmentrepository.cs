using System.Collections.Generic;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private List<Enrollment> enrollments = new List<Enrollment>();

        public void AddEnrollment(Enrollment enrollment)
        {
            enrollments.Add(enrollment);
        }

        public void GetEnrollmentInfo(int enrollmentId)
        {
            var enrollment = enrollments.Find(e => e.Id == enrollmentId);
            // Display enrollment information
        }
    }
}
