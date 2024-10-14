using DigitalAssetManagement.Business.Repository;
using DigitalAssetManagement.Business.Services;
using DigitalAssetManagement.Entity;
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
    public class AssetAllocationRepository : IAssetAllocationRepository
    {
        public bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate, DateTime? returnDate = null)
        {
            using (SqlConnection connection = DBUtil.SqlConnection)
            {
                try
                {
                    // Step 1: Retrieve the max allocation_id from the asset_allocations table
                    string getMaxIdQuery = "SELECT ISNULL(MAX(allocation_id), 0) FROM asset_allocations";
                    using (SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection))
                    {
                        connection.Open();
                        int maxAllocationId = (int)getMaxIdCmd.ExecuteScalar();

                        // Step 2: Generate new allocation_id
                        int newAllocationId = maxAllocationId + 1;

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
                            cmd.Parameters.AddWithValue("@return_date", returnDate.HasValue ? (object)returnDate.Value : DBNull.Value);

                            int result = cmd.ExecuteNonQuery();
                            return result > 0;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Error allocating asset: " + ex.Message);
                }
            }
        }

        public bool DeallocateAsset(int assetId, int employeeId, DateTime? returnDate) // Change returnDate to DateTime?
        {
            try
            {
                using (SqlConnection connection = DBUtil.SqlConnection)
                {
                    connection.Open(); // Open the connection here

                    string query = "UPDATE asset_allocations SET return_date = @return_date WHERE asset_id = @asset_id AND employee_id = @employee_id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Check for nullable DateTime before assigning it
                        cmd.Parameters.AddWithValue("@return_date", returnDate.HasValue ? (object)returnDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@asset_id", assetId);
                        cmd.Parameters.AddWithValue("@employee_id", employeeId);

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
                // Log or handle the specific AssetNotFoundException as needed
                throw; // Rethrow without additional context if you're handling it higher up
            }
            catch (System.Exception ex)
            {
                // Log the general exception for further investigation
                throw new System.Exception("Error deallocating asset: " + ex.Message, ex); // Include the original exception for more context
            }
        }
    }
}





