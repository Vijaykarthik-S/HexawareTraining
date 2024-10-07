using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher teacher);
        void UpdateTeacherInfo(int teacherId, string firstName, string lastName, string email, string phoneNumber);
    }
}
