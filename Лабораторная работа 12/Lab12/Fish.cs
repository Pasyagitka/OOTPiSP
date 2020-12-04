using System;

namespace Lab06
{
    internal class Fish : IVitalActivity
    {
        public string name;
        public int dateOfBirth;
        public string color;

        public Fish()
        {
            this.name = "fish1";
            this.dateOfBirth = 2000;
            this.color = "Blue";
        }

        public void Eat()
        {
            Console.WriteLine("Рыба ест");
        }

        public void Sleep(string e1, string e2)
        {
            Console.WriteLine("Рыба спит... ZzZ...");
            Console.WriteLine($"Рыба видит во сне {e1}");
            Console.WriteLine($"Рыба видит во сне {e2}");
        }

        public override string ToString()
        {
            return "Рыба: Name: " + name + ", Year: " + dateOfBirth;
        }

        public void VitalActivity() {
            Console.WriteLine("Рыба живёт");
        }
    }
}