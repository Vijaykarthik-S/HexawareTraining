using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException(string message) : base(message) { }
    }
}
