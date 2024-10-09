using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string message) : base(message) { }
    }
}
