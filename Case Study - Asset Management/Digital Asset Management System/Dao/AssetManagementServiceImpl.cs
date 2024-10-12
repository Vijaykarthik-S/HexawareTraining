using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DigitalAssetManagement.dao;
using DigitalAssetManagement.Entity;
using DigitalAssetManagement.Exception;

namespace DigitalAssetManagement.DAO
{
    public class AssetManagementServiceImpl : AssetManagementService
    {
        private readonly string _connectionString;

        public AssetManagementServiceImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public bool AddAsset(Asset asset)
        {
            try
            {
                using (var connection = GetConnection())
                {

                    if (asset.AssetId <= 0) // Assuming AssetId must be greater than zero
                    {
                        throw new ArgumentException("Asset ID must be greater than zero.");
                    }

                    string query = "INSERT INTO assets (asset_id, name, type, serial_number, purchase_date, location, status, owner_id) VALUES (@asset_id, @name, @type, @serial_number, @purchase_date, @location, @status, @owner_id)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@asset_id", asset.AssetId);
                        cmd.Parameters.AddWithValue("@name", asset.Name);
                        cmd.Parameters.AddWithValue("@type", asset.Type);
                        cmd.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                        cmd.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                        cmd.Parameters.AddWithValue("@location", asset.Location);
                        cmd.Parameters.AddWithValue("@status", asset.Status);
                        cmd.Parameters.AddWithValue("@owner_id", asset.OwnerId);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error adding asset: " + ex.Message);
            }
        }



        public bool DeleteAsset(int assetId)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    // Step 1: Delete from maintenance_records
                    string deleteMaintenanceRecordsQuery = "DELETE FROM maintenance_records WHERE asset_id = @asset_id";
                    using (SqlCommand deleteMaintenanceCmd = new SqlCommand(deleteMaintenanceRecordsQuery, connection))
                    {
                        deleteMaintenanceCmd.Parameters.AddWithValue("@asset_id", assetId);
                        deleteMaintenanceCmd.ExecuteNonQuery();
                    }

                    // Step 2: Delete from asset_allocations
                    string deleteAllocationsQuery = "DELETE FROM asset_allocations WHERE asset_id = @asset_id";
                    using (SqlCommand deleteAllocationsCmd = new SqlCommand(deleteAllocationsQuery, connection))
                    {
                        deleteAllocationsCmd.Parameters.AddWithValue("@asset_id", assetId);
                        deleteAllocationsCmd.ExecuteNonQuery();
                    }

                    // Step 3: Delete from reservations
                    string deleteReservationsQuery = "DELETE FROM reservations WHERE asset_id = @asset_id";
                    using (SqlCommand deleteReservationsCmd = new SqlCommand(deleteReservationsQuery, connection))
                    {
                        deleteReservationsCmd.Parameters.AddWithValue("@asset_id", assetId);
                        deleteReservationsCmd.ExecuteNonQuery();
                    }

                    // Step 2: Now delete the asset itself
                    string query = "DELETE FROM assets WHERE asset_id=@asset_id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@asset_id", assetId);
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new AssetNotFoundException($"Asset with ID {assetId} not found.");
                        }
                        return true;
                    }
                }
            }
            catch (AssetNotFoundException ex)
            {
                throw ex; // Re-throw the custom exception
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error deleting asset: " + ex.Message);
            }
        }


        public bool AllocateAsset(int assetId, int employeeId, string allocationDate, string returnDate = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    // Step 1: Retrieve the max allocation_id from the asset_allocations table
                    string getMaxIdQuery = "SELECT ISNULL(MAX(allocation_id), 0) FROM asset_allocations";
                    using (SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection))
                    {
                        connection.Open();
                        int maxAllocationId = (int)getMaxIdCmd.ExecuteScalar();

                        // Step 2: Generate new allocation_id
                        int newAllocationId = maxAllocationId + 1;
                        connection.Close();

                        // Step 3: Insert new record with the generated allocation_id and optional return_date
                        string query = "INSERT INTO asset_allocations (allocation_id, asset_id, employee_id, allocation_date, return_date) " +
                                       "VALUES (@allocation_id, @asset_id, @employee_id, @allocation_date, @return_date)";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@allocation_id", newAllocationId);
                            cmd.Parameters.AddWithValue("@asset_id", assetId);
                            cmd.Parameters.AddWithValue("@employee_id", employeeId);
                            cmd.Parameters.AddWithValue("@allocation_date", allocationDate);

                            // If returnDate is null, set it as DBNull
                            if (string.IsNullOrEmpty(returnDate))
                            {
                                cmd.Parameters.AddWithValue("@return_date", DBNull.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@return_date", returnDate);
                            }

                            connection.Open();
                            int result = cmd.ExecuteNonQuery();
                            return result > 0;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error allocating asset: " + ex.Message);
            }
        }
        public bool UpdateAsset(Asset asset)
        {
            try
            {
                if (asset.AssetId <= 0) // Ensure AssetId is provided
                {
                    throw new ArgumentException("Asset ID must be greater than zero.");
                }

                using (var connection = GetConnection())
                {
                    string query = "UPDATE assets SET name=@name, type=@type, serial_number=@serial_number, purchase_date=@purchase_date, location=@location, status=@status, owner_id=@owner_id WHERE asset_id=@asset_id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", asset.Name);
                        cmd.Parameters.AddWithValue("@type", asset.Type);
                        cmd.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                        cmd.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                        cmd.Parameters.AddWithValue("@location", asset.Location);
                        cmd.Parameters.AddWithValue("@status", asset.Status);
                        cmd.Parameters.AddWithValue("@owner_id", asset.OwnerId);
                        cmd.Parameters.AddWithValue("@asset_id", asset.AssetId); // Use the provided AssetId

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new AssetNotFoundException($"Asset with ID {asset.AssetId} not found.");
                        }
                        return result > 0;
                    }
                }
            }
            catch (AssetNotFoundException ex)
            {
                throw ex; // Re-throw the custom exception
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error updating asset: " + ex.Message);
            }
        }

        public bool DeallocateAsset(int assetId, int employeeId, string returnDate)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    string query = "UPDATE asset_allocations SET return_date=@return_date WHERE asset_id=@asset_id AND employee_id=@employee_id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@return_date", returnDate);
                        cmd.Parameters.AddWithValue("@asset_id", assetId);
                        cmd.Parameters.AddWithValue("@employee_id", employeeId);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new AssetNotFoundException($"Allocation not found for Asset ID {assetId} and Employee ID {employeeId}.");
                        }
                        return true;
                    }
                }
            }
            catch (AssetNotFoundException ex)
            {
                throw ex; // Re-throw the custom exception
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error deallocating asset: " + ex.Message);
            }
        }

        public bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    // Step 1: Retrieve the max maintenance_id from the maintenance_records table
                    string getMaxIdQuery = "SELECT ISNULL(MAX(maintenance_id), 0) FROM maintenance_records";
                    using (SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection))
                    {
                        connection.Open();
                        int maxMaintenanceId = (int)getMaxIdCmd.ExecuteScalar();

                        // Step 2: Generate new maintenance_id
                        int newMaintenanceId = maxMaintenanceId + 1;
                        connection.Close();

                        // Step 3: Insert the new record with the generated maintenance_id
                        string query = "INSERT INTO maintenance_records (maintenance_id, asset_id, maintenance_date, description, cost) " +
                                       "VALUES (@maintenance_id, @asset_id, @maintenance_date, @description, @cost)";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@maintenance_id", newMaintenanceId);
                            cmd.Parameters.AddWithValue("@asset_id", assetId);
                            cmd.Parameters.AddWithValue("@maintenance_date", maintenanceDate);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@cost", cost);

                            connection.Open();
                            int result = cmd.ExecuteNonQuery();
                            return result > 0;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error performing maintenance: " + ex.Message);
            }
        }

        public bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    // Step 1: Retrieve the current maximum reservation_id
                    int newReservationId;
                    string maxIdQuery = "SELECT ISNULL(MAX(reservation_id), 0) + 1 FROM reservations"; // Use 0 if no entries exist

                    using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, connection))
                    {
                        newReservationId = (int)maxIdCmd.ExecuteScalar(); // Fetch the next reservation_id
                    }

                    // Step 2: Insert the new reservation with the newly generated reservation_id
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

                        int result = insertCmd.ExecuteNonQuery(); // Executes the insert command
                        return result > 0; // Returns true if the insert was successful
                    }
                }
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
                using (var connection = GetConnection())
                {
                    string query = "DELETE FROM reservations WHERE reservation_id=@reservation_id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@reservation_id", reservationId);

                        connection.Open();
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


