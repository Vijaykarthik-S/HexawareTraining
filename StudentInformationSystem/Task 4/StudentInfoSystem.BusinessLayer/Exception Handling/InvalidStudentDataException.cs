using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class InvalidStudentDataException : Exception
    {
        public InvalidStudentDataException(string message) : base(message) { }
    }
}
