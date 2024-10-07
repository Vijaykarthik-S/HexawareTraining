using StudentInformationSystem.Entity;


namespace StudentInfoSystem.BusinessLayer.Repository
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        void GetPaymentInfo(int paymentId);
    }
}
