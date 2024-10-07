using System.Collections.Generic;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;

namespace StudentInfoSystem.BusinessLayer.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void UpdateCourse(int courseId, string courseName)
        {
            var course = courses.Find(c => c.Id == courseId);
            if (course != null)
            {
                course.Name = courseName;
            }
        }

        public void GetCourseInfo(int courseId)
        {
            var course = courses.Find(c => c.Id == courseId);
            // Display course information
        }
    }
}
