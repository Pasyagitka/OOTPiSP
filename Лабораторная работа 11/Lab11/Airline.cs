using System;

namespace Lab11
{
    internal class Places
    {
        public string city;
        public string country;

        public Places(string a, string b)
        {
            city = a;
            country = b;
        }
    }

    public class Airline
    {
        public string Destination;
        public int FlightNumber;
        public string AircraftType;
        public DateTime DepartureTime;
        private string DaysOfWeek;
        public static int NumberOfObjects = 0;
        public readonly int ID;
        private const string DefaultDaysOfWeek = "Unknown";
        private const int DefaultFlightNumber = 0;

        public string m_Destination
        {
            get { return Destination; }
            private set
            {
                if (Char.IsLower(value[0]))
                    Destination = value.ToUpper();
            }
        }

        public int m_FlightNumber
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

        public string m_DaysOfWeek
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
        }

        static Airline()
        {
        }

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
}