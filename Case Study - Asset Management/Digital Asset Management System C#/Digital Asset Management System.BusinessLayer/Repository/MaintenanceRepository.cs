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
    public class MaintenanceRecordsRepository : IMaintenanceRecordRepository
    {
        public bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost)
        {
            using (SqlConnection connection = DBUtil.SqlConnection)
            {
                try
                {
                    connection.Open(); // Open the connection here

                    // Step 1: Check if the asset exists in the assets table
                    string checkAssetExistsQuery = "SELECT COUNT(*) FROM assets WHERE asset_id = @asset_id";
                    using (SqlCommand checkAssetExistsCmd = new SqlCommand(checkAssetExistsQuery, connection))
                    {
                        checkAssetExistsCmd.Parameters.AddWithValue("@asset_id", assetId);

                        int assetCount = (int)checkAssetExistsCmd.ExecuteScalar();

                        if (assetCount == 0)
                        {
                            throw new AssetNotFoundException($"Asset with ID {assetId} not found.");
                        }
                    }

                    // Step 2: Check the last maintenance date of the asset
                    string getLastMaintenanceDateQuery = "SELECT MAX(maintenance_date) FROM maintenance_records WHERE asset_id = @asset_id";
                    using (SqlCommand getLastMaintenanceDateCmd = new SqlCommand(getLastMaintenanceDateQuery, connection))
                    {
                        getLastMaintenanceDateCmd.Parameters.AddWithValue("@asset_id", assetId);
                        var lastMaintenanceDateObj = getLastMaintenanceDateCmd.ExecuteScalar();

                        if (lastMaintenanceDateObj != DBNull.Value)
                        {
                            DateTime lastMaintenanceDate = Convert.ToDateTime(lastMaintenanceDateObj);
                            DateTime currentDate = DateTime.Now;

                            // Check if the last maintenance was over 2 years ago
                            if ((currentDate - lastMaintenanceDate).TotalDays > 730)
                            {
                                throw new AssetNotMaintainException($"Asset {assetId} has not been maintained for more than 2 years.");
                            }
                        }
                    }

                    // Step 3: Retrieve the max maintenance_id from the maintenance_records table
                    string getMaxIdQuery = "SELECT ISNULL(MAX(maintenance_id), 0) FROM maintenance_records";
                    int newMaintenanceId;

                    using (SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection))
                    {
                        newMaintenanceId = (int)getMaxIdCmd.ExecuteScalar() + 1;
                    }

                    // Step 4: Insert the maintenance record
                    string insertQuery = "INSERT INTO maintenance_records (maintenance_id, asset_id, maintenance_date, description, cost) " +
                                         "VALUES (@maintenance_id, @asset_id, @maintenance_date, @description, @cost)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@maintenance_id", newMaintenanceId);
                        cmd.Parameters.AddWithValue("@asset_id", assetId);
                        cmd.Parameters.AddWithValue("@maintenance_date", maintenanceDate);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@cost", cost);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (AssetNotMaintainException ex)
                {
                    // Handle the AssetNotMaintainException specifically if needed
                    throw ex; // or log the exception
                }
                catch (System.Exception ex)
                {
                    // Handle other exceptions
                    throw new System.Exception("Error performing maintenance: " + ex.Message, ex);
                }
            }
        }

    }

}
