using System;

namespace Lab05
{
    class Shark : Fish, IVitalActivity
    {
        public Shark(string name, int year, string color = "Grey", string feedingstrategy = "carnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Акула плывет");
        }

        public override string ToString()
        {
            return "Акула: Name: " + name + ", Year: " + dateOfBirth + ", Color: " + color + ", Feeding Strategy: " + feedingStrategy;
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
