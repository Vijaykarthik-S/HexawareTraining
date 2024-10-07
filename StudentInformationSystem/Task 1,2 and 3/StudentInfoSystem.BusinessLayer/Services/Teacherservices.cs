using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepository _teacherRepository;

        public TeacherService(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.AddTeacher(teacher);
        }

        public void UpdateTeacherInfo(int teacherId, string firstName, string lastName, string email, string phoneNumber)
        {
            _teacherRepository.UpdateTeacherInfo(teacherId, firstName, lastName, email, phoneNumber);
        }

        public void GetTeacherDetails()
        {
            _teacherRepository.GetTeacherDetails();
        }
    }
}
