using System.Collections.Generic;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private List<Payment> payments = new List<Payment>();

        public void AddPayment(Payment payment)
        {
            payments.Add(payment);
        }

        public void GetPaymentInfo(int paymentId)
        {
            var payment = payments.Find(p => p.Id == paymentId);
            // Display payment information
        }
    }
}
