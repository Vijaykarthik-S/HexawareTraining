using BooksandAuthors;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static BooksandAuthors.Validators;

namespace AssignmentTask
{
    internal class Program
    {
        static void Main(string[] args)
        {




            //        12) create a Customer class with the below properties
            //public string Name { get; set; }
            //    public string Email { get; set; }
            //    public string PhoneNumber { get; set; }
            //    public DateTime DateOfBirth { get; set; }
            // create a separate class to validate PhoneNumber, Email, DOB using some
            // function which should return bool (true if valid ,False if invalid)
            #region Regular Expressions
            //    Customer customer = new Customer
            //    {
            //        Name = "Sunidhi",
            //        Email = "johndoe@example.com",
            //        PhoneNumber = "+12345678",
            //        DateOfBirth = new DateTime(2000, 5, 15)
            //    };

            //    // Validating Customer data
            //    bool isPhoneValid = Validators.ValidatePhoneNumber(customer.PhoneNumber);
            //    bool isEmailValid = Validators.ValidateEmail(customer.Email);
            //    bool isDOBValid = Validators.ValidateDateOfBirth(customer.DateOfBirth);

            //    // Display validation results
            //    Console.WriteLine($"Customer: {customer.Name}");
            //    Console.WriteLine($"Phone Valid: {isPhoneValid}");
            //    Console.WriteLine($"Email Valid: {isEmailValid}");
            //    Console.WriteLine($"Date of Birth Valid (Age >= 18): {isDOBValid}");
            //}

            #endregion


            // 13) Create a TransportManager class to manage a list of transport schedules

            //LINQ Operations:

            //Search.Find schedules by transport type, route, or time
            //Group By, Group schedules by transport type(bus or flight)

            //Order By.Order schedules by departure time, price, or seats available

            //Filter Filter schedules based on availability of seats or routes within a time range

            //Aggregate Calculate the total number of available seats and the average price of transport

            //Select Project a list of rouses and their departure times

TransportManager manager = new TransportManager();

// Adding sample data
manager.AddSchedule(new TransportSchedule { TransportType = "bus", Route = "Route A", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(3), Price = 25.50m, SeatsAvailable = 30 });
manager.AddSchedule(new TransportSchedule { TransportType = "flight", Route = "Route B", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(5), Price = 150.00m, SeatsAvailable = 20 });
manager.AddSchedule(new TransportSchedule { TransportType = "bus", Route = "Route C", DepartureTime = DateTime.Now.AddHours(4), ArrivalTime = DateTime.Now.AddHours(6), Price = 15.00m, SeatsAvailable = 50 });
manager.AddSchedule(new TransportSchedule { TransportType = "flight", Route = "Route A", DepartureTime = DateTime.Now.AddHours(6), ArrivalTime = DateTime.Now.AddHours(8), Price = 200.00m, SeatsAvailable = 10 });
manager.AddSchedule(new TransportSchedule { TransportType = "bus", Route = "Route B", DepartureTime = DateTime.Now.AddHours(1.5), ArrivalTime = DateTime.Now.AddHours(2.5), Price = 20.00m, SeatsAvailable = 5 });

// Example usage of LINQ operations
Console.WriteLine("Search Results:");
foreach (var schedule in manager.Search(transportType: "bus"))
    Console.WriteLine(schedule);

Console.WriteLine("\nGrouped By Transport Type:");
foreach (var group in manager.GroupByTransportType())
{
    Console.WriteLine($"\nTransport Type: {group.Key}");
    foreach (var schedule in group)
        Console.WriteLine(schedule);
}

Console.WriteLine("\nOrdered by Price:");
foreach (var schedule in manager.OrderBy("price"))
    Console.WriteLine(schedule);

Console.WriteLine("\nFilter by Seats Available >= 20:");
foreach (var schedule in manager.Filter(minSeats: 20))
    Console.WriteLine(schedule);

var (totalSeats, avgPrice) = manager.AggregateSeatsAndPrice();
Console.WriteLine($"\nTotal Seats Available: {totalSeats}, Average Price: {avgPrice}");

Console.WriteLine("\nRoutes and Departure Times:");
foreach (var routeInfo in manager.SelectRoutesAndDepartureTimes())
    Console.WriteLine($"Route: {routeInfo.Route}, Departure Time: {routeInfo.DepartureTime}");
        }

    }
}
