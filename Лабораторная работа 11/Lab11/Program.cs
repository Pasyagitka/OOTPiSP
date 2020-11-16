using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            IEnumerable<string> result1 = from month in Month where month.Length == 6 select month;
            foreach (var i in result1)    Console.Write(" " + i);
            var result2 = Month.Where(month => month == Month[0] || month == Month[1] || month == Month[11] || month == Month[5] || month == Month[6] || month == Month[7]).Select(month => month);
            Console.Write("\n");  foreach (var i in result2) Console.Write(" " + i);
            var result3 = Month.OrderBy(month => month).ThenBy(month => month).Select(month => month);
            Console.Write("\n"); foreach (var i in result3) Console.Write(" " + i); 
            int result4 = Month.Where(month => month.Length >= 4 && month.Contains('u')).Count();
            Console.Write("\n" + result4);

            List<Airline> airline = new List<Airline> 
            {
            new Airline( -1435, "MIAMI", "Boeing 767-232", "Tue"),
            new Airline(12498, "LEIPZIG", "Airbus A320-251N", "aaaaaaaaa"),
            new Airline("HONG KONG", 29589, "Boeing 737-8kn", new DateTime(2020, 10, 4, 00, 14, 00), "Fri"),
            new Airline("HANNOVER", -3841, "Airbus A320-251N", new DateTime(2020, 10, 2, 7, 34, 00), "Wed"),
            new Airline("TEL AVIV", 30491, "Boeing 737-8kn", new DateTime(2020, 10, 3, 17, 11, 00), "Thu"),
            new Airline("LONDON", 30491, "Boeing 737-8kn", new DateTime(2020, 10, 3, 15, 11, 00), "Thu"),
            new Airline("LYON", 83812, "Boeing 767-232", new DateTime(2020, 10, 5, 5, 20, 00), "Sat"),
            new Airline("CASABLANCA", 43589, "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun"),
            new Airline("CASABLANCA", 4989, "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun"),
            new Airline(23848, "CHICAGO", "Boeing 737-823"),
            };

            var airlineres1 = airline.Where(a => a.Destination == "CASABLANCA").Select(a => a);
            var airlineres2 = airline.Where(a => a.m_DaysOfWeek == "Thu").Select(a => a);
            //var airlineres3 = (airline.Select(a => a.m_DaysOfWeek)).Max();
            //var airlineres4 = airline.Where(a=> a.m_DaysOfWeek == "Thu").OrderBy(a => a.DepartureTime).Select(a => a);
            //var airlineres5 = airline.Where(a => a.m_DaysOfWeek == "Thu").Select(a => a);
            int airlineres6 = airline.Where(a => a.AircraftType == "Boeing 737-8kn").Count();

            Console.WriteLine("Cписок рейсов для заданного пункта назначения");     foreach (Airline a in airlineres1)          Console.WriteLine(a);
            Console.WriteLine("Cписок рейсов для заданного дня недели");            foreach (Airline a in airlineres2)          Console.WriteLine(a);
            //Console.WriteLine("Максимальный по дню недели рейс");                 Console.WriteLine(airlineres3);
            //Console.WriteLine("Все рейсы в определенный день недели и с самым поздним временем вылета"); foreach (Airline a in airlineres4) Console.WriteLine(a);
            //Console.WriteLine("Упорядоченные по дню и времени рейсы");
            Console.WriteLine("Количество рейсов для заданного типа самолета");     Console.WriteLine(airlineres6);

            var myquery = airline.Where(a=> a.m_DaysOfWeek != "Fri").OrderByDescending(a=>a.m_FlightNumber).Distinct().Skip(1).Take(5);
            foreach (Airline a in myquery) Console.WriteLine(a);
                      
            List<Places> places = new List<Places>
            {
                new Places("LYON", "France"),
                new Places("LONDON", "UK"),
            };
            Console.WriteLine("1");
            var result = airline.Join(places, a => a.Destination,  с => с.country,  (a, c) => new { Number = a.m_FlightNumber, Destination = a.Destination, Country = c.country });
            foreach (var a in result) Console.WriteLine(a);
            //Join
        }
    }
}
