using System;
//V13. Создать класс Airline: Пункт назначения, Номер рейса, Тип самолета, Время вылета, Дни недели. 
//Свойства и конструкторы должны обеспечивать проверку корректности.
//Создать массив объектов.Вывести:
//a) список рейсов для заданного пункта назначения;
//b) список рейсов для заданного дня недели;
namespace Lab03
{
    public class Airline
    {
        public string Destination;
        public string FlightNumber;
        public string AircraftType;
        public DateTime DepartureTime;
        public string DaysOfWeek;


        public Airline()
        { 
            Destination = "";
            FlightNumber = "";
            AircraftType = "";
            DepartureTime = new DateTime(2020, 01, 01, 00, 00, 00);
            DaysOfWeek = "";
        }

        public Airline(string destination, string flightnumber, string aircrafttype, DateTime departureTime, string daysofweek)
        {
            Destination = destination;
            FlightNumber = flightnumber;
            AircraftType = aircrafttype;
            DepartureTime = departureTime;
            DaysOfWeek = daysofweek;
        }

        public Airline(string destination="OTTAWA", string flightnumber="a1m423", string aircrafttype="Boeing 737-8kn", string daysofweek = "Sun") {
            Destination = destination;
            FlightNumber = flightnumber;
            AircraftType = aircrafttype;
            DepartureTime = default;
            DaysOfWeek = daysofweek;
        }

        public void FlightInfoByDestination() {
            Console.WriteLine($"Flight number: {FlightNumber}, to: {Destination}, aircraft type: {AircraftType}, departure time: {DepartureTime}, day: {DaysOfWeek}");
        }
        public void FlightInfoByDayOfWeek() {
            Console.WriteLine($"Flight number: {FlightNumber}, to: {Destination}, aircraft type: {AircraftType}, departure time: {DepartureTime}, day: {DaysOfWeek}");
        }
    }
    class Program
    {
        static void Main(string[] args) {
            Airline Airline1 = new Airline();
            Airline Airline2 = new Airline("MIAMI", "n743ax", "Boeing 767-232", "Tue");
            Airline Airline3 = new Airline("LEIPZIG", "54m-2d", "Airbus A320-251N", "Tue");
            Airline Airline4 = new Airline("HONG KONG", "q123d5", "Boeing 737-8kn", new DateTime(2020, 10, 4, 00, 14, 00), "Fri");
            Airline Airline5 = new Airline("HANNOVER", "r99230", "Airbus A320-251N", new DateTime(2020, 10, 2, 7, 34, 00), "Wed");
            Airline Airline6 = new Airline("TEL AVIV", "p-129e3", "Boeing 737-8kn", new DateTime(2020, 10, 3, 15, 11, 00), "Thu");
            Airline Airline7 = new Airline("BRISTOL", "12d999", "Airbus A320-251N", new DateTime(2020, 10, 4, 12, 25, 00), "Fri");
            Airline Airline8 = new Airline("LYON", "5m3u2", "Boeing 767-232", new DateTime(2020, 10, 5, 5, 20, 00), "Sat");
            Airline Airline9 = new Airline("CASABLANCA", "a4-r23", "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun");
            Airline Airline10 = new Airline("IBIZA", "a6-fec", "Boeing 737-8kn", new DateTime(2020, 9, 30, 9, 18, 00), "Mon");
            Airline Airline11 = new Airline("LUANDA", "n234ax");
            Airline Airline12 = new Airline("CHICAGO", "tc-nbz", "Boeing 737-823");


            Airline1.FlightInfoByDestination();
            Airline2.FlightInfoByDestination();
            Airline3.FlightInfoByDestination();
            Airline4.FlightInfoByDestination();
            Airline5.FlightInfoByDestination();
            Airline6.FlightInfoByDestination();
            Airline7.FlightInfoByDestination();
            Airline8.FlightInfoByDestination();
            Airline9.FlightInfoByDestination();
            Airline10.FlightInfoByDestination();
            Airline11.FlightInfoByDestination();
            Airline12.FlightInfoByDestination();
        

        }
       
    }
}
