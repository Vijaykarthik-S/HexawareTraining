using System;

namespace StudentInformationSystem.BusinessLayer.Exceptions
{
    public class PaymentValidationException : Exception
    {
        public PaymentValidationException(string message) : base(message) { }
    }
}
