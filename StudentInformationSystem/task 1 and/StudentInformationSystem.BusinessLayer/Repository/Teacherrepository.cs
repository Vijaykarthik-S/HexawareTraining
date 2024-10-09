using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        Teacher t = new Teacher();

        //Task 2 and 3
        public TeacherRepository(int teacher_id, string first_name, string last_name, string email)
        {
            t.TeacherID = teacher_id;
            t.FirstName = first_name;
            t.LastName = last_name;
            t.Email = email;
        }
        public TeacherRepository(int id)
        {
            t.TeacherID = id;
        }
        public void DisplayTeacherInfo()
        {
            Console.WriteLine("Displaying Teacher Information:");
            Console.WriteLine($"{t.TeacherID}\t{t.FirstName}\t{t.LastName}\t{t.Email}");
        }

        public void GetAssignedCourses()
        {

        }

        public void UpdateTeacherInfo(string name, string email)
        {
            t.FirstName = name;
            t.Email = email;
        }
    }
}