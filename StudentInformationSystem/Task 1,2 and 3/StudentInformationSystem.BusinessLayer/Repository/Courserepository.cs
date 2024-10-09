using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    public class CourseRepository : ICourseRepository
    {
        Course c = new Course();

        //Task 2 and 3
        public CourseRepository(int course_id, string course_name, string course_code, int teacher_id)
        {
            c.CourseID = course_id;
            c.CourseName = course_name;
            c.CourseCode = course_code;
            c.TeacherID = teacher_id;
        }

        public CourseRepository(int id)
        {
            c.CourseID = id;
        }
        public void AssignTeacher(Teacher teacher)
        {
            c.TeacherID = teacher.TeacherID;

        }
        public void UpdateCourseInfo(string courseCode, string courseName, int teacherId)
        {
            c.CourseCode = courseCode;
            c.CourseName = courseName;
            c.TeacherID = teacherId;
        }
        public void DisplayCourseInfo()
        {
            Console.WriteLine("Displaying Course Information:");
            Console.WriteLine($"{c.CourseID}\t{c.CourseName}\t{c.CourseCode}\t{c.TeacherID}");
        }

        public void GetEnrollments()
        {

        }

        public void GetTeacher()
        {
            TeacherRepository t = new TeacherRepository(c.TeacherID);
            t.DisplayTeacherInfo();

        }


    }
}