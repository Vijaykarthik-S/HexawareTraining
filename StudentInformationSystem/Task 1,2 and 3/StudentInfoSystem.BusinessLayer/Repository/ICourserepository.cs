using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        void UpdateCourse(int courseId, string courseName);
        void GetCourseInfo(int courseId);
    }
}
