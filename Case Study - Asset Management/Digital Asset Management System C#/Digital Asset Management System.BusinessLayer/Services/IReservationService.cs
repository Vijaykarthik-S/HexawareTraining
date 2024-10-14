using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Services
{
    public interface IReservationService
    {
        // Method to reserve an asset
        bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate);

        // Method to withdraw a reservation
        bool WithdrawReservation(int reservationId);
    }
}