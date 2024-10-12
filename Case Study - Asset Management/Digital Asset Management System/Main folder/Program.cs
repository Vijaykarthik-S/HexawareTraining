using System;
using System.Data.SqlClient;
using DigitalAssetManagement.Entity;
using DigitalAssetManagement.DAO;
using DigitalAssetManagement.Exception;
using DigitalAssetManagement.dao;


namespace DigitalAssetManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the background color
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            // Print the heading with a decorative box
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("******************************************************\n");
            Console.WriteLine("      Asset management done by Vijay Karthick         \n");
            Console.WriteLine("******************************************************\n");
            Console.ResetColor();

            // Assume connection established
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connection to the database established successfully!\n");
            Console.ResetColor();


            // Database connection string
            string connectionString = "Data Source=LAPTOP-7PTI9LUL;Initial Catalog=ASSET MANAGEMENT;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Open the connection here for use in the service

                AssetManagementServiceImpl assetService = new AssetManagementServiceImpl(connectionString);
                while (true)
                {
                    try
                    {
                        PrintMenu();
                        string choice = Console.ReadLine();
                        HandleUserChoice(choice, assetService);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Input format is incorrect. Please enter valid data.");
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        static void PrintMenu()
        {
            // Print menu options in different colors
            Console.ForegroundColor = ConsoleColor.Magenta;
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
            Console.ResetColor();
        }

        static void HandleUserChoice(string choice, AssetManagementServiceImpl assetService)
        {
            switch (choice)
            {
                case "1":
                    AddAsset(assetService);
                    break;
                case "2":
                    UpdateAsset(assetService);
                    break;
                case "3":
                    DeleteAsset(assetService);
                    break;
                case "4":
                    AllocateAsset(assetService);
                    break;
                case "5":
                    DeallocateAsset(assetService);
                    break;
                case "6":
                    PerformMaintenance(assetService);
                    break;
                case "7":
                    ReserveAsset(assetService);
                    break;
                case "8":
                    WithdrawReservation(assetService);
                    break;
                case "0":
                    Environment.Exit(0); // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


        static void AddAsset(AssetManagementServiceImpl assetService)
        {
            Console.WriteLine("Enter asset details:");
            Console.Write("Asset ID (PK): "); // Prompt for Asset ID
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
                AssetId = assetId, // Set Asset ID manually
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

        static void UpdateAsset(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Asset ID to update: ");
            int assetId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new asset details:");
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

        static void DeleteAsset(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Asset ID to delete: ");
            int assetId = int.Parse(Console.ReadLine());

            if (assetService.DeleteAsset(assetId))
            {
                Console.WriteLine("Asset deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete asset.");
            }
        }

        static void AllocateAsset(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Asset ID to allocate: ");
            int assetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Allocation Date (yyyy-mm-dd): ");
            string allocationDate = Console.ReadLine();

            if (assetService.AllocateAsset(assetId, employeeId, allocationDate))
            {
                Console.WriteLine("Asset allocated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to allocate asset.");
            }
        }

        static void DeallocateAsset(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Asset ID to deallocate: ");
            int assetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Return Date (yyyy-mm-dd): ");
            string returnDate = Console.ReadLine();

            if (assetService.DeallocateAsset(assetId, employeeId, returnDate))
            {
                Console.WriteLine("Asset deallocated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to deallocate asset.");
            }
        }

        static void PerformMaintenance(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Asset ID for maintenance: ");
            int assetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            string maintenanceDate = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Cost: ");
            double cost = double.Parse(Console.ReadLine());

            if (assetService.PerformMaintenance(assetId, maintenanceDate, description, cost))
            {
                Console.WriteLine("Maintenance performed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to perform maintenance.");
            }
        }

        static void ReserveAsset(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Asset ID to reserve: ");
            int assetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
            string reservationDate = Console.ReadLine();
            Console.Write("Enter Start Date (yyyy-mm-dd): ");
            string startDate = Console.ReadLine();
            Console.Write("Enter End Date (yyyy-mm-dd): ");
            string endDate = Console.ReadLine();

            if (assetService.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate))
            {
                Console.WriteLine("Asset reserved successfully.");
            }
            else
            {
                Console.WriteLine("Failed to reserve asset.");
            }
        }

        static void WithdrawReservation(AssetManagementServiceImpl assetService)
        {
            Console.Write("Enter Reservation ID to withdraw: ");
            int reservationId = int.Parse(Console.ReadLine());

            if (assetService.WithdrawReservation(reservationId))
            {
                Console.WriteLine("Reservation withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Failed to withdraw reservation.");
            }
        }
    }
}
