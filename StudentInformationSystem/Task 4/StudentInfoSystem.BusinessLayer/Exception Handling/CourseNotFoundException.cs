using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException(string message) : base(message) { }
    }
}
