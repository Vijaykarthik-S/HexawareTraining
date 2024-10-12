using DigitalAssetManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.dao
{
    public interface AssetManagementService
    {
        bool AddAsset(Asset asset);               // Adds a new asset to the system.
        bool UpdateAsset(Asset asset);            // Updates an existing asset's information.
        bool DeleteAsset(int assetId);            // Deletes an asset from the system.
        bool AllocateAsset(int assetId, int employeeId, string allocationDate, string returnDate);  // Allocates an asset to an employee.
        bool DeallocateAsset(int assetId, int employeeId, string returnDate);    // Deallocates an asset from an employee.
        bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost); // Records maintenance activity.
        bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate); // Reserves an asset for a specified employee.
        bool WithdrawReservation(int reservationId);  // Withdraws a reservation based on the reservation ID.
    }
}