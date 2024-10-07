using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly Courserepository _courseRepository;

        // Constructor for CourseService with dependency injection
        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // Adds a course to the repository
        public void AddCourse(Course course)
        {
            _courseRepository.AddCourse(course);
        }

        // Retrieves a course by its ID
        public Course GetCourseByID(int courseID)
        {
            return _courseRepository.GetCourseByID(courseID);
        }

        // Updates course information
        public void UpdateCourse(Course updatedCourse)
        {
            _courseRepository.UpdateCourse(updatedCourse);
        }

        // Retrieves all courses
        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

    }
}