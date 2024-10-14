using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Entity
{
    public class MaintenanceRecord
    {
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public string MaintenanceDate { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}