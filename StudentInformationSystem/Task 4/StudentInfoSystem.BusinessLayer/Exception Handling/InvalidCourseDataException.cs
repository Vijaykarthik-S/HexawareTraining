using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class InvalidCourseDataException : Exception
    {
        public InvalidCourseDataException(string message) : base(message) { }
    }
}
