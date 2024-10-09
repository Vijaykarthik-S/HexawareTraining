using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class InvalidTeacherDataException : Exception
    {
        public InvalidTeacherDataException(string message) : base(message) { }
    }
}
