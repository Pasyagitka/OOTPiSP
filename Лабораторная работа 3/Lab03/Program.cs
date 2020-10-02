using System;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;

namespace Lab03
{
    public partial class Airline
    {
        string Destination;
        int FlightNumber;
        string AircraftType;
        DateTime DepartureTime;
        string DaysOfWeek;
        public static int NumberOfObjects = 0;

        public readonly int ID;
        const string DefaultDaysOfWeek = "Unknown";
        const int DefaultFlightNumber = 0;

        public string DestinationGetSet
        {
            get { return Destination; }
            private set
            {
                if (Char.IsLower(value[0]))
                    Destination = value.ToUpper();
            }
        }

        public int FlightNumberGetSet
        {
            get { return FlightNumber; }
            set
            {
                if (value >= 0)
                {
                    FlightNumber = value;
                }
            }
        }

        public string DaysOfWeekGetSet
        {
            get { return DaysOfWeek; }
            set
            {
                if (value == "Mon" || value == "Tue" || value == "Wed" || value == "Thu" || value == "Fri" || value == "Sat" || value == "Sun")
                    DaysOfWeek = value;
            }
        }

        public Airline()
        {
            Destination = "Unknown";
            FlightNumber = 0;
            AircraftType = "Unknown";
            DepartureTime = new DateTime(2020, 01, 01, 00, 00, 00);
            DaysOfWeek = DefaultDaysOfWeek;
            ID = GetHashCode();
            NumberOfObjects++;
        }

        public Airline(string destination, int flightnumber, string aircrafttype, DateTime departureTime, string daysofweek)
        {
            Destination = destination;
            if (FlightNumber >= 0) FlightNumber = flightnumber;
            else FlightNumber = DefaultFlightNumber;
            AircraftType = aircrafttype;
            DepartureTime = departureTime;
            if (daysofweek == "Mon" || daysofweek == "Tue" || daysofweek == "Wed" || daysofweek == "Thu" || daysofweek == "Fri" || daysofweek == "Sat" || daysofweek == "Sun") DaysOfWeek = daysofweek;
            else DaysOfWeek = DefaultDaysOfWeek;
            ID = GetHashCode();
            NumberOfObjects++;
        }

        public Airline(int flightnumber, string destination = "OTTAWA", string aircrafttype = "Boeing 737-8kn", string daysofweek = "Sun") : this(flightnumber)
        {
            Destination = destination;
            AircraftType = aircrafttype;
            DepartureTime = default;
            if (daysofweek == "Mon" || daysofweek == "Tue" || daysofweek == "Wed" || daysofweek == "Thu" || daysofweek == "Fri" || daysofweek == "Sat" || daysofweek == "Sun") DaysOfWeek = daysofweek;
            else DaysOfWeek = DefaultDaysOfWeek;
            ID = GetHashCode();
            NumberOfObjects++;
        }

        private Airline(int flightnumber)
        {
            if (flightnumber >= 0) this.FlightNumber = flightnumber;
            else this.FlightNumber = DefaultFlightNumber;
            Console.WriteLine("Private constructor");
        }

        static Airline()
        {
            Console.WriteLine("Static constructor");
        }
    }



    public partial class Airline {

        public void FlightInfo()
        {
            Console.WriteLine($"Flight number: {FlightNumber}, to: {Destination}, aircraft type: {AircraftType}, departure time: {DepartureTime}, day: {DaysOfWeek}, ID: {ID}");
        }

        public void Parameters(ref int flightnumber, ref int number, out int result)
        {
            flightnumber++;
            number++;
            result = flightnumber + number;
        }

        public static void ShowNumberOfObjects()
        {
            Console.WriteLine($"NumberOfObjects: {NumberOfObjects}");
        }

        public static void FlightInfoByDestination(Airline[] airlinesarray, string destination)
        {
            for (int i = 0; i < airlinesarray.Length; i++)
                if (airlinesarray[i].Destination == destination)
                    Console.WriteLine($"Flight number: {airlinesarray[i].FlightNumber}, to: {airlinesarray[i].Destination}, aircraft type: {airlinesarray[i].AircraftType}, departure time: {airlinesarray[i].DepartureTime}, day: {airlinesarray[i].DaysOfWeek},  ID: {airlinesarray[i].ID}");
        }

        public static void FlightInfoByDayOfWeek(Airline[] airlinesarray, string daysofweek)
        {
            for (int i = 0; i < airlinesarray.Length; i++)
                if (airlinesarray[i].DaysOfWeek == daysofweek)
                    Console.WriteLine($"Flight number: {airlinesarray[i].FlightNumber}, to: {airlinesarray[i].Destination}, aircraft type: {airlinesarray[i].AircraftType}, departure time: {airlinesarray[i].DepartureTime}, day: {airlinesarray[i].DaysOfWeek},  ID: {airlinesarray[i].ID}");
        }

        public override bool Equals(object obj)
        {
            Airline airline1 = (Airline)obj;
            return (this.Destination == airline1.Destination && this.DepartureTime == airline1.DepartureTime);
        }

        public override int GetHashCode()
        {
            return Math.Abs(Destination.GetHashCode() + FlightNumber.GetHashCode());
        }

        public override string ToString()
        {
            return "Flight number: " + FlightNumber + ", to: " + Destination + ", aircraft type: " + AircraftType + ", departure time: " + DepartureTime + ", day: " + DaysOfWeek + ", ID: " + ID;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Airline.NumberOfObjects);
            Airline Airline1 = new Airline();
            Airline Airline2 = new Airline( -1435, "MIAMI", "Boeing 767-232", "Tue");
            Airline Airline3 = new Airline( 12498,"LEIPZIG", "Airbus A320-251N", "aaaaaaaaa");
            Airline Airline4 = new Airline("HONG KONG", 29589, "Boeing 737-8kn", new DateTime(2020, 10, 4, 00, 14, 00), "Fri");
            Airline Airline5 = new Airline("HANNOVER", -3841, "Airbus A320-251N", new DateTime(2020, 10, 2, 7, 34, 00), "Wed");
            Airline Airline6 = new Airline("TEL AVIV", 30491, "Boeing 737-8kn", new DateTime(2020, 10, 3, 15, 11, 00), "Thu");
            Airline Airline7 = new Airline("LONDON", 30491, "Boeing 737-8kn", new DateTime(2020, 10, 3, 15, 11, 00), "Thu");
            Airline Airline8 = new Airline("LYON", 83812, "Boeing 767-232", new DateTime(2020, 10, 5, 5, 20, 00), "Sat");
            Airline Airline9 = new Airline("CASABLANCA", 43589, "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun");
            Airline Airline10 = new Airline("CASABLANCA", 4989, "Boeing 737-8kn", new DateTime(2020, 10, 6, 20, 05, 00), "Sun");
            Airline Airline11 = new Airline( 325, "LUANDA");
            Airline Airline12 = new Airline(23848,"CHICAGO",  "Boeing 737-823");

            Airline[] AirlinesArray = new Airline[] { Airline1, Airline2, Airline3, Airline4, Airline5, Airline6, Airline7, Airline8, Airline9, Airline10, Airline11, Airline12 };

            Airline.FlightInfoByDestination(AirlinesArray, "LYON");
            Airline.FlightInfoByDayOfWeek(AirlinesArray, "Tue");

            Console.WriteLine("__________________________");
            Airline10.FlightInfo();
            //Airline10.DaysOfWeekGetSet = "Monday";
            Airline10.FlightNumberGetSet = 9999;
            //Airline10.DestinationGetSet = "minsk";
            Airline10.FlightInfo();

            int flnumber = Airline7.FlightNumberGetSet;
            int number = 9999999;
            Airline7.Parameters(ref flnumber, ref number, out int result);
            Console.WriteLine(result);

            Airline.ShowNumberOfObjects();
            Console.WriteLine(Airline9.Equals(Airline8));
            Console.WriteLine(Airline9.Equals(Airline10));
            Console.WriteLine(Airline4);
            Console.WriteLine(Airline6.GetType());


            var Anon = new { Destination = "TALLIN", FlightNumber = 1111, AircraftType = "Airbus A320-251N", DepartureTime = new DateTime(2020, 10, 6, 20, 05, 00), DaysOfWeek = "Monday" };
            Console.WriteLine($"Flight number: {Anon.FlightNumber}, to: {Anon.Destination}, aircraft type: {Anon.AircraftType}, departure time: {Anon.DepartureTime}, day: {Anon.DaysOfWeek}");
            //свойства анонимных типов доступны только для чтения; только в инициализаторе
        }
    }
}
