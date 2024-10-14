using DigitalAssetManagement.Exception;
using DigitalAssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Repository
{
    public interface IMaintenanceRecordRepository
    {
        bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost);
    }
}


