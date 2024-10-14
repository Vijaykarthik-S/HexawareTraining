using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Entity
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public string ReservationDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}