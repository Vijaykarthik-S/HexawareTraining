using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Repository
{
    public interface IReservationRepository
    {
        // Method to reserve an asset
        bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate);

        // Method to withdraw a reservation
        bool WithdrawReservation(int reservationId);
    }
}