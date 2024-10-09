using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    internal interface ITeacherRepository
    {
        void UpdateTeacherInfo(string name, string email);
        void DisplayTeacherInfo();
        void GetAssignedCourses();
    }
}