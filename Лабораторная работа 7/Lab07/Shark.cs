using System;

namespace Lab06
{
    internal class Shark : Fish, IVitalActivity
    {
        public Shark(string name, int year, int weight = 50) : base(name, year)
        {
            this.weight = 50;
            this.feedingStrategy = feedingStrategies.carnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Акула плывет");
        }

        public override string ToString()
        {
            return "Акула: Name: " + name + ", Year: " + dateOfBirth + ", Weight: " + weight + ", Feeding Strategy: " + feedingStrategy;
        }

        void IVitalActivity.Eat()
        {
            Console.WriteLine("Акула ест");
        }

        void IVitalActivity.Sleep()
        {
            Console.WriteLine("Акула спит... ZzZ...");
        }

        public override void VitalActivity()
        {
            Console.WriteLine("virtual activity in shark");
        }

        void IVitalActivity.VitalActivity()
        {
            Console.WriteLine("virtual activity in interface in shark");
        }
    }
}