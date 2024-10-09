using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
