using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        IPaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void MakePayment(decimal amount, string paymentDate)
        {
            _paymentRepository.MakePayment(amount, paymentDate);
        }

        public void GetPaymentHistory()
        {
            _paymentRepository.GetPaymentHistory();
        }
    }
}
