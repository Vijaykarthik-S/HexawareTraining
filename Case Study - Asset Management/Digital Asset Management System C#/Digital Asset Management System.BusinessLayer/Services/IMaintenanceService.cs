using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Services
{
    public interface IMaintenanceRecordService
    {
        bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost);
    }
}