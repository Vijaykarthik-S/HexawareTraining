using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        //Task 2 and 3
        Enrollment e = new Enrollment();
        public EnrollmentRepository(int enroll_id, int student_id, int course_id, DateTime enrollDate)
        {
            e.EnrollmentID = enroll_id;
            e.StudentID = student_id;
            e.CourseID = course_id;
            e.EnrollmentDate = enrollDate;
        }
        public void GetStudent()
        {
            StudentRepository s = new StudentRepository(e.StudentID);
            s.DisplayStudentInfo();
        }
        public void GetCourse()
        {
            CourseRepository c = new CourseRepository(e.CourseID);
            c.DisplayCourseInfo();
        }


    }
}