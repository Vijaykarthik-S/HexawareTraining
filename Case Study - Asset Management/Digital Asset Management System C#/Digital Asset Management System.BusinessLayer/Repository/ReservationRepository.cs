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
    public class ReservationRepository : IReservationRepository
    {
        public bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection connection = DBUtil.SqlConnection)
                {
                    connection.Open();

                    // Step 1: Check if the asset exists
                    string assetCheckQuery = "SELECT COUNT(*) FROM assets WHERE asset_id = @asset_id";
                    using (SqlCommand assetCheckCmd = new SqlCommand(assetCheckQuery, connection))
                    {
                        assetCheckCmd.Parameters.AddWithValue("@asset_id", assetId);
                        int assetExists = (int)assetCheckCmd.ExecuteScalar();

                        if (assetExists == 0)
                        {
                            throw new AssetNotFoundException($"Asset with ID {assetId} not found.");
                        }
                    }

                    // Step 2: Retrieve the current maximum reservation_id
                    int newReservationId;
                    string maxIdQuery = "SELECT ISNULL(MAX(reservation_id), 0) + 1 FROM reservations";
                    using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, connection))
                    {
                        newReservationId = (int)maxIdCmd.ExecuteScalar();
                    }

                    // Step 3: Insert the new reservation with the newly generated reservation_id
                    string insertQuery = "INSERT INTO reservations (reservation_id, asset_id, employee_id, reservation_date, start_date, end_date, status) " +
                                         "VALUES (@reservation_id, @asset_id, @employee_id, @reservation_date, @start_date, @end_date, 'Pending')";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@reservation_id", newReservationId);
                        insertCmd.Parameters.AddWithValue("@asset_id", assetId);
                        insertCmd.Parameters.AddWithValue("@employee_id", employeeId);
                        insertCmd.Parameters.AddWithValue("@reservation_date", reservationDate);
                        insertCmd.Parameters.AddWithValue("@start_date", startDate);
                        insertCmd.Parameters.AddWithValue("@end_date", endDate);

                        int result = insertCmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (AssetNotFoundException)
            {
                throw; // Re-throw the specific exception
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error reserving asset: " + ex.Message);
            }
        }

        public bool WithdrawReservation(int reservationId)
        {
            try
            {
                using (SqlConnection connection = DBUtil.SqlConnection)
                {
                    connection.Open(); // Ensure connection is opened

                    string query = "DELETE FROM reservations WHERE reservation_id = @reservation_id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@reservation_id", reservationId);

                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new System.Exception($"Reservation with ID {reservationId} not found.");
                        }
                        return true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error withdrawing reservation: " + ex.Message);
            }
        }
    }
}