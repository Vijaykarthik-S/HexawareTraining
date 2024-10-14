
using DigitalAssetManagement.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate)
        {
            return _reservationRepository.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate);
        }

        public bool WithdrawReservation(int reservationId)
        {
            return _reservationRepository.WithdrawReservation(reservationId);
        }
    }


}