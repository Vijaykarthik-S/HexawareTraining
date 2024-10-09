using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.BusinessLayer.Repository
{
    internal interface IPaymentRepository
    {
        void GetStudent();
        decimal GetPaymentAmount();
        DateTime GetPaymentDate();
    }
}