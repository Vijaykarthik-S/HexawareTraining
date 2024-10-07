using StudentInformationSystem.Entity;

namespace StudentInformationSystem.BusinessLayer.Services
{
    public interface IPaymentService
    {
        void MakePayment(int studentId, decimal amount, string paymentDate);
        void GetPaymentHistory(int studentId);
    }
}
