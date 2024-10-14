using DigitalAssetManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalAssetManagement.Util;
using DigitalAssetManagement.Business.Repository;
using DigitalAssetManagement.Business.Services;
using DigitalAssetManagement.Exception;

namespace DigitalAssetManagement.Business.Repository
{
    public class AssetRepository : IAssetRepository
    {

        public bool AddAsset(Asset asset)
        {
            try
            {
                // Check if asset ID is valid
                if (asset.AssetId <= 0) // Assuming AssetId must be greater than zero
                {
                    throw new ArgumentException("Asset ID must be greater than zero.");
                }

                using (SqlConnection connection = DBUtil.SqlConnection)
                {
                    string query = "INSERT INTO assets (asset_id, name, type, serial_number, purchase_date, location, status, owner_id) " +
                                   "VALUES (@asset_id, @name, @type, @serial_number, @purchase_date, @location, @status, @owner_id)";

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

                        // Open connection
                        connection.Open();

                        // Execute the command
                        int result = cmd.ExecuteNonQuery();

                        return result > 0; // Returns true if one or more rows were affected
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error adding asset: " + ex.Message);
            }
        }


        // Method to update an existing asset in the database
        public bool UpdateAsset(Asset asset)
        {
            try
            {
                if (asset.AssetId <= 0)
                {
                    throw new ArgumentException("Asset ID must be greater than zero.");
                }

                using (SqlConnection connection = DBUtil.SqlConnection)
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
                        cmd.Parameters.AddWithValue("@asset_id", asset.AssetId);

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


        // Method to delete an asset by its ID
        public bool DeleteAsset(int assetId)
        {
            try
            {
                using (SqlConnection connection = DBUtil.SqlConnection)
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

                    // Step 4: Now delete the asset itself
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
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error deleting asset: " + ex.Message);
            }
        }




        // Method to get a single asset by its ID
        public Asset GetAssetById(int assetId)
        {
            using (SqlConnection connection = DBUtil.SqlConnection)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT AssetId, Name, Type, SerialNumber, Status, OwnerId FROM Assets WHERE AssetId = @AssetId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@AssetId", assetId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Asset
                            {
                                AssetId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                SerialNumber = reader.GetString(3),
                                Status = reader.GetString(4),
                                OwnerId = reader.GetInt32(5)
                            };
                        }
                        else
                        {
                            throw new AssetNotFoundException($"Asset with ID {assetId} not found.");
                        }
                    }
                }
                catch (AssetNotFoundException ex)
                {
                    throw ex; // Re-throw the custom exception
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Error while fetching asset by ID: " + ex.Message);
                }
            }
        }

        // Method to get all assets from the database
        public List<Asset> GetAllAssets()
        {
            List<Asset> assets = new List<Asset>();
            using (SqlConnection connection = DBUtil.SqlConnection)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT AssetId, Name, Type, SerialNumber, Status, OwnerId FROM Assets";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assets.Add(new Asset
                            {
                                AssetId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                SerialNumber = reader.GetString(3),
                                Status = reader.GetString(4),
                                OwnerId = reader.GetInt32(5)
                            });
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Error while fetching all assets: " + ex.Message);
                }
            }
            return assets;
        }
    }
}