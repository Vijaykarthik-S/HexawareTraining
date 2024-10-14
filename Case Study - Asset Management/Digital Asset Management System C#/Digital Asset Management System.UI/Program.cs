using System;
using System.Data.SqlClient;
using DigitalAssetManagement.Business;
using DigitalAssetManagement.Util;
using DigitalAssetManagement.Entity;
using DigitalAssetManagement.Business.Services;
using DigitalAssetManagement.Business.Repository;
using System.Configuration;
using DigitalAssetManagement.Exception;


namespace DigitalAssetManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

  
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("****************************************************** \n");
            Console.WriteLine("       Asset management done by Vijay Karthick         \n");
            Console.WriteLine("****************************************************** \n");
            Console.ResetColor();  

            

            string connectionString = ConfigurationManager.ConnectionStrings["MyDBconnection"].ConnectionString;

            using (SqlConnection connection = DBUtil.SqlConnection)
            {
                
                IAssetRepository assetRepository = new AssetRepository();
                IAssetAllocationRepository assetAllocationRepository = new AssetAllocationRepository();
                IReservationRepository reservationRepository = new ReservationRepository();
                IMaintenanceRecordRepository maintenanceRecordRepository = new MaintenanceRecordsRepository();

                
                AssetService assetService = new AssetService(assetRepository);
                AssetAllocationService assetAllocationService = new AssetAllocationService(assetAllocationRepository);
                ReservationService reservationService = new ReservationService(reservationRepository);
                MaintenanceRecordService maintenanceRecordService = new MaintenanceRecordService(maintenanceRecordRepository);



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connection to the database established successfully!\n");
                Console.ResetColor();

                while (true)
                {
                    try
                    {
                        PrintMenu();
                        string choice = Console.ReadLine();
                        HandleUserChoice(choice, assetService, assetAllocationService, reservationService, maintenanceRecordService);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Input format is incorrect. Please enter valid data.");
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║              Main Menu               ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Add Asset");
            Console.WriteLine("2. Update Asset");
            Console.WriteLine("3. Delete Asset");
            Console.WriteLine("4. Allocate Asset");
            Console.WriteLine("5. Deallocate Asset");
            Console.WriteLine("6. Perform Maintenance");
            Console.WriteLine("7. Reserve Asset");
            Console.WriteLine("8. Withdraw Reservation");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter the operation which you want to perform :");
            Console.ResetColor();
           
        }
        

        static void HandleUserChoice(string choice, AssetService assetService, AssetAllocationService assetAllocationService, ReservationService reservationService, MaintenanceRecordService maintenanceRecordService)
        {
         
            switch (choice)
            {
                
                case "1": AddAsset(assetService); break;
                case "2": UpdateAsset(assetService); break;
                case "3": DeleteAsset(assetService); break;
                case "4": AllocateAsset(assetAllocationService); break;
                case "5": DeallocateAsset(assetAllocationService); break;
                case "6": PerformMaintenance(maintenanceRecordService); break;
                case "7": ReserveAsset(reservationService); break;
                case "8": WithdrawReservation(reservationService); break;
                case "0": Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice. Please try again."); break;
            }
        }

        static void AddAsset(AssetService assetService)
        {
            Console.WriteLine("Enter asset details:");
            Console.Write("Asset ID (PK): ");
            int assetId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Serial Number: ");
            string serialNumber = Console.ReadLine();
            Console.Write("Purchase Date (yyyy-mm-dd): ");
            string purchaseDate = Console.ReadLine();
            Console.Write("Location: ");
            string location = Console.ReadLine();
            Console.Write("Status: ");
            string status = Console.ReadLine();
            Console.Write("Owner ID: ");
            int ownerId = int.Parse(Console.ReadLine());

            Asset newAsset = new Asset
            {
                AssetId = assetId,
                Name = name,
                Type = type,
                SerialNumber = serialNumber,
                PurchaseDate = purchaseDate,
                Location = location,
                Status = status,
                OwnerId = ownerId
            };

            if (assetService.AddAsset(newAsset))
            {
                Console.WriteLine("Asset added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add asset.");
            }
        }


        static void UpdateAsset(AssetService assetService)
        {
            try
            {
                int assetId = GetIntInput("Enter Asset ID to update: ");
                Console.WriteLine("Enter new asset details:");
                string name = GetStringInput("Name: ");
                string type = GetStringInput("Type: ");
                string serialNumber = GetStringInput("Serial Number: ");
                string purchaseDate = GetStringInput("Purchase Date (yyyy-mm-dd): ");
                string location = GetStringInput("Location: ");
                string status = GetStringInput("Status: ");
                int ownerId = GetIntInput("Owner ID: ");

                Asset updatedAsset = new Asset
                {
                    AssetId = assetId,
                    Name = name,
                    Type = type,
                    SerialNumber = serialNumber,
                    PurchaseDate = purchaseDate,
                    Location = location,
                    Status = status,
                    OwnerId = ownerId
                };

                if (assetService.UpdateAsset(updatedAsset))
                {
                    Console.WriteLine("Asset updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update asset.");
                }
            }
            catch (AssetNotFoundException ex)
            {
                Console.WriteLine($"Custom Exception: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DeleteAsset(AssetService assetService)
        {
            try
            {
                int assetId = GetIntInput("Enter Asset ID to delete: ");

                if (assetService.DeleteAsset(assetId))
                {
                    Console.WriteLine("Asset deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete asset.");
                }
            }
            catch (AssetNotFoundException ex)
            {
                Console.WriteLine($"Custom Exception: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void AllocateAsset(AssetAllocationService assetAllocationService)
        {
            try
            {
                int assetId = GetIntInput("Enter Asset ID to allocate: ");
                int employeeId = GetIntInput("Enter Employee ID: ");
                DateTime allocationDate = GetDateTimeInput("Enter Allocation Date (yyyy-mm-dd): ");

                if (assetAllocationService.AllocateAsset(assetId, employeeId, allocationDate))
                {
                    Console.WriteLine("Asset allocated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to allocate asset.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred while allocating the asset: {ex.Message}");
            }
        }

        static void DeallocateAsset(AssetAllocationService assetAllocationService)
        {
            try
            {
                // Get input from the user
                int assetId = GetIntInput("Enter Asset ID to deallocate: ");
                int employeeId = GetIntInput("Enter Employee ID: ");
                DateTime? returnDate = GetDateTimeInput("Enter Return Date (yyyy-mm-dd) or leave blank: ");

                // Call the service method to deallocate the asset
                if (assetAllocationService.DeallocateAsset(assetId, employeeId, returnDate))
                {
                    Console.WriteLine("Asset deallocated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to deallocate asset.");
                }
            }
            catch (AssetNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred while deallocating the asset: {ex.Message}");
            }
        }
        static void PerformMaintenance(MaintenanceRecordService maintenanceRecordService)
        {
            try
            {
                Console.Write("Enter Asset ID for maintenance: ");
                int assetId = int.Parse(Console.ReadLine());

                Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
                string maintenanceDateInput = Console.ReadLine();

                // Try to parse the input string to a DateTime
                if (!DateTime.TryParse(maintenanceDateInput, out DateTime maintenanceDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd.");
                    return; // Exit if the date is invalid
                }

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                Console.Write("Enter Cost: ");
                if (!double.TryParse(Console.ReadLine(), out double cost))
                {
                    Console.WriteLine("Invalid input for cost. Please enter a valid number.");
                    return; // Exit if the cost is invalid
                }

                // Perform the maintenance
                if (maintenanceRecordService.PerformMaintenance(assetId, maintenanceDate, description, cost))
                {
                    Console.WriteLine("Maintenance performed successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to perform maintenance.");
                }
            }
            catch (AssetNotMaintainException ex)
            {
                // Handle the custom exception for assets not maintained for 2 years
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (AssetNotFoundException ex)
            {
                // Handle the case where the asset ID is invalid
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }




        static void ReserveAsset(ReservationService reservationService)
        {
            try
            {
                int assetId = GetIntInput("Enter Asset ID to reserve: ");
                int employeeId = GetIntInput("Enter Employee ID: ");
                DateTime reservationDate = DateTime.Now; // Or you can get it as input
                DateTime startDate = GetDateTimeInput("Enter Start Date (yyyy-mm-dd): ");
                DateTime endDate = GetDateTimeInput("Enter End Date (yyyy-mm-dd): ");

                if (reservationService.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate))
                {
                    Console.WriteLine("Asset reserved successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to reserve asset.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred while reserving the asset: {ex.Message}");
            }
        }

        static void WithdrawReservation(ReservationService reservationService)
        {
            try
            {
                int reservationId = GetIntInput("Enter Reservation ID to withdraw: ");

                if (reservationService.WithdrawReservation(reservationId))
                {
                    Console.WriteLine("Reservation withdrawn successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to withdraw reservation.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred while withdrawing the reservation: {ex.Message}");
            }
        }

        // Helper methods to get user inputs
        static int GetIntInput(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static DateTime GetDateTimeInput(string prompt)
        {
            Console.Write(prompt);
            return DateTime.Parse(Console.ReadLine());
        }
    }
}
