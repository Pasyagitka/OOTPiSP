using System;

namespace Lab06
{
    internal class Printer
    {
        public virtual void iAmPrinting(Animal someobj)
        {
            if (someobj is Crocodile)
            {
                Console.WriteLine("Это крокодил");
            }
            if (someobj is Mammal)
            {
                if (someobj as Lion != null)
                {
                    Console.WriteLine("Это лев");
                }
                else if (someobj as Tiger != null)
                {
                    Console.WriteLine("Это тигр");
                }
            }
            if (someobj is Fish)
            {
                if (someobj as Shark != null)
                {
                    Console.WriteLine("Это акула");
                }
            }
            if (someobj is Bird)
            {
                if (someobj as Owl != null)
                {
                    Console.WriteLine("Это сова");
                }
                else if (someobj as Parrot != null)
                {
                    Console.WriteLine("Это попугай");
                }
            }
            Console.WriteLine(someobj.ToString());
        }
    }
}