using StudentInformationSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    internal interface ICourseRepository
    {
        void AssignTeacher(Teacher teacher);
        void UpdateCourseInfo(string courseCode, string courseName, int teacherId);
        void DisplayCourseInfo();
        void GetEnrollments();
        void GetTeacher();
    }
}