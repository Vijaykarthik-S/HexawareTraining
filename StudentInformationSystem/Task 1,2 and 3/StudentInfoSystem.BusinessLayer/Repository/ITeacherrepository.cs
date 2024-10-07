using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public interface ITeacherRepository
    {
        void AddTeacher(Teacher teacher);
        void UpdateTeacherInfo(int teacherId, string firstName, string lastName, string email, string phoneNumber);
    }
}
