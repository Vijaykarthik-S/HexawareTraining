using DigitalAssetManagement.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Services
{
    public class MaintenanceRecordService : IMaintenanceRecordService
    {
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

        // Constructor should accept an IMaintenanceRecordRepository type
        public MaintenanceRecordService(IMaintenanceRecordRepository maintenanceRecordRepository)
        {
            _maintenanceRecordRepository = maintenanceRecordRepository;
        }

        public bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost)
        {
            return _maintenanceRecordRepository.PerformMaintenance(assetId, maintenanceDate, description, cost);
        }
    }
}
