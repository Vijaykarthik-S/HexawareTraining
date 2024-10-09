
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.BusinessLayer.Services;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public void AssignTeacher(Teacher teacher)
        {
            _courseRepository.AssignTeacher(teacher);
        }
        public void UpdateCourseInfo(string courseCode, string courseName, int teacherId)
        {
            _courseRepository.UpdateCourseInfo(courseCode, courseName, teacherId);
        }
        public void DisplayCourseInfo()
        {
            _courseRepository.DisplayCourseInfo();
        }
        public void GetEnrollments()
        {
            _courseRepository.GetEnrollments();
        }

        public void GetTeacher()
        {
            _courseRepository.GetTeacher();
        }
    }
}