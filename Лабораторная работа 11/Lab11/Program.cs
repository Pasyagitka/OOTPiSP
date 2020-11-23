using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] Month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<Airline> airline = new List<Airline>
            {
                new Airline( 1435, "MIAMI", "Boeing 767-232", "Tue"),
                new Airline("HONG KONG", 29589, "Boeing 737-8kn", new DateTime(2020, 10, 4, 00, 14, 00), "Fri"),
                new Airline("HANNOVER", 3841, "Airbus A320-251N", new DateTime(2020, 10, 2, 7, 34, 00), "Wed"),
                new Airline("TEL AVIV", 30491, "Boeing 737-8kn", new DateTime(2020, 10, 3, 17, 11, 00), "Thu"),
                new Airline("LONDON", 30491, "Boeing 737-8kn", new DateTime(2020, 10, 3, 15, 11, 00), "Thu"),
                new Airline("LYON", 83812, "Boeing 767-232", new DateTime(2020, 10, 5, 5, 20, 00), "Sat"),
                new Airline("CASABLANCA", 43589, "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun"),
                new Airline("CASABLANCA", 4989, "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun"),
                new Airline("CHICAGO", 23848, "Boeing 737-823", new DateTime(2020, 10, 6, 22, 05, 00), "Sun" ),
            };

            IEnumerable<string> result1 = from month in Month where month.Length == 6 select month;
            var result2 = Month.Where(month => month == Month[0] || month == Month[1] || month == Month[11] || month == Month[5] || month == Month[6] || month == Month[7]).Select(month => month);
            var result3 = Month.OrderBy(month => month).ThenBy(month => month).Select(month => month);
            int result4 = Month.Where(month => month.Length >= 4 && month.Contains('u')).Count();

            var airlineres1 = airline.Where(a => a.Destination == "CASABLANCA");
            var airlineres2 = airline.Where(a => a.m_DaysOfWeek == "Thu");
            var airlineres3 = airline.OrderByDescending(a => a.m_DaysOfWeek).FirstOrDefault();
            var airlineres4 = airline.Where(a => a.m_DaysOfWeek == "Sun").OrderByDescending(a => a.DepartureTime).FirstOrDefault();
            var airlineres5 = airline.OrderBy(a => a.m_DaysOfWeek).ThenBy(a => a.DepartureTime);
            var airlineres6 = airline.Where(a => a.AircraftType == "Boeing 737-8kn").Count();

            var myquery = airline.Where(a => a.m_DaysOfWeek != "Fri").OrderByDescending(a => a.m_FlightNumber).Distinct().Skip(1).Take(5);

            List<int> list1 = new List<int> { 436, 4, 1192, 36, 257, 1 };
            List<int> list2 = new List<int> { 1, 436, 58, 1192, 393};

            var joinresult = list1.Join(list2, elem1 => elem1, elem2=>elem2,  (elem1, elem2) => new { elem1, elem2 });

            #region Output

            Console.WriteLine("Месяцы с длиной строки 6: "); foreach (var i in result1) Console.Write(" " + i);
            Console.WriteLine("Летние и зимние месяцы: "); foreach (var i in result2) Console.Write(" " + i);
            Console.WriteLine("Месяцы в алфавитном порядке: "); foreach (var i in result3) Console.Write(" " + i);
            Console.WriteLine("\nКоличество месяцев с буквой \'u\' и длиной имени не менее 4: " + result4);
            Console.WriteLine("Cписок рейсов для заданного пункта назначения"); foreach (Airline a in airlineres1) Console.WriteLine(a);
            Console.WriteLine("Cписок рейсов для заданного дня недели"); foreach (Airline a in airlineres2) Console.WriteLine(a);
            Console.WriteLine("Максимальный по дню недели рейс"); Console.WriteLine(airlineres3);
            Console.WriteLine("Все рейсы в определенный день недели и с самым поздним временем вылета"); Console.WriteLine(airlineres4);
            Console.WriteLine("Упорядоченные по дню и времени рейсы"); foreach (Airline a in airlineres5) Console.WriteLine(a);
            Console.WriteLine("Количество рейсов для заданного типа самолета"); Console.WriteLine(airlineres6);
            Console.WriteLine("Мой запрос: "); foreach (Airline a in myquery) Console.WriteLine(a);
            Console.WriteLine("Пример с Join: "); foreach (var num in joinresult) Console.Write(" " + num);

            #endregion Output
        }
    }
}