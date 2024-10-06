using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Entity
{
    public class Payment
    {

        public int PaymentID { get; set; }
        public int StudentID { get; set; } // Foreign key to Student
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(int paymentID, int studentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            StudentID = studentID;
            Amount = amount;
            PaymentDate = paymentDate;
        }
    }
}
