using System.Collections.Generic;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private List<Teacher> teachers = new List<Teacher>();

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void UpdateTeacherInfo(int teacherId, string firstName, string lastName, string email, string phoneNumber)
        {
            var teacher = teachers.Find(t => t.Id == teacherId);
            if (teacher != null)
            {
                teacher.FirstName = firstName;
                teacher.LastName = lastName;
                teacher.Email = email;
               
            }
        }
    }
}
