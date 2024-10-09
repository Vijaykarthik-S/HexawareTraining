using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }
}
