using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class InvalidEnrollmentDataException : Exception
    {
        public InvalidEnrollmentDataException(string message) : base(message) { }
    }
}
