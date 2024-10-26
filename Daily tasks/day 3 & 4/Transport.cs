using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksandAuthors
{
    public class TransportSchedule
    {
        public string TransportType { get; set; } // "bus" or "flight"
        public string Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int SeatsAvailable { get; set; }

        public override string ToString()
        {
            return $"Type: {TransportType}, Route: {Route}, Departure: {DepartureTime}, Arrival: {ArrivalTime}, Price: {Price}, Seats Available: {SeatsAvailable}";
        }
    }

    public class TransportManager
    {
        private List<TransportSchedule> schedules;

        public TransportManager()
        {
            schedules = new List<TransportSchedule>();
        }

        // Add a new transport schedule
        public void AddSchedule(TransportSchedule schedule)
        {
            schedules.Add(schedule);
        }

        // LINQ Operations

        // 1. Search: Find schedules by transport type, route, or time
        public IEnumerable<TransportSchedule> Search(string transportType = null, string route = null, DateTime? time = null)
        {
            var result = schedules.AsEnumerable();
            if (!string.IsNullOrEmpty(transportType))
                result = result.Where(s => s.TransportType.Equals(transportType, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(route))
                result = result.Where(s => s.Route.Equals(route, StringComparison.OrdinalIgnoreCase));

            if (time.HasValue)
                result = result.Where(s => s.DepartureTime <= time && s.ArrivalTime >= time);

            return result;
        }

        // 2. Group By: Group schedules by transport type
        public IEnumerable<IGrouping<string, TransportSchedule>> GroupByTransportType()
        {
            return schedules.GroupBy(s => s.TransportType);
        }

        // 3. Order By: Order schedules by departure time, price, or seats available
        public IEnumerable<TransportSchedule> OrderBy(string orderBy)
        {
            return orderBy.ToLower() switch
            {
                "departuretime" => schedules.OrderBy(s => s.DepartureTime),
                "price" => schedules.OrderBy(s => s.Price),
                "seatsavailable" => schedules.OrderBy(s => s.SeatsAvailable),
                _ => schedules
            };
        }

        // 4. Filter: Filter schedules based on availability of seats or routes within a time range
        public IEnumerable<TransportSchedule> Filter(int? minSeats = null, DateTime? startTime = null, DateTime? endTime = null)
        {
            var result = schedules.AsEnumerable();
            if (minSeats.HasValue)
                result = result.Where(s => s.SeatsAvailable >= minSeats.Value);

            if (startTime.HasValue && endTime.HasValue)
                result = result.Where(s => s.DepartureTime >= startTime && s.ArrivalTime <= endTime);

            return result;
        }

        // 5. Aggregate: Calculate total number of available seats and average price of transport
        public (int totalSeats, decimal avgPrice) AggregateSeatsAndPrice()
        {
            int totalSeats = schedules.Sum(s => s.SeatsAvailable);
            decimal avgPrice = schedules.Average(s => s.Price);
            return (totalSeats, avgPrice);
        }

        // 6. Select: Project a list of routes and their departure times
        public IEnumerable<(string Route, DateTime DepartureTime)> SelectRoutesAndDepartureTimes()
        {
            return schedules.Select(s => (s.Route, s.DepartureTime));
        }

        // Display all schedules for debugging
        public void DisplaySchedules()
        {
            foreach (var schedule in schedules)
            {
                Console.WriteLine(schedule);
            }
        }
    }

}