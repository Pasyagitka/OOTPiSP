using System;
using System.IO;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------- Класс Parrot ---------");                      
            Reflector.GetAssemblyInfo("Lab04.Parrot");   
            Reflector.GetPublicCtors("Lab04.Parrot");
            Console.WriteLine("Все общедоступные публичные методы класса: ");
            foreach (var i in Reflector.GetPublicMethods("Lab04.Parrot"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\tПоля и свойства класса: ") ;
            foreach (var i in Reflector.GetInfoFieldProperty("Lab04.Parrot"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\tИнтерфейсы");
            foreach (var i in Reflector.GetInterface("Lab04.Parrot"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Методы, содержащие параметр типа int: ");
            Reflector.GetMethodByType("Lab04.Parrot", typeof(int) );
            Console.WriteLine("Invoke: ");
            Reflector.InvokeMethod("Lab04.Parrot", "Eat");


            Console.WriteLine("--------- Класс Fish ---------");
            Reflector.GetAssemblyInfo("Lab06.Fish");
            Reflector.GetPublicCtors("Lab06.Fish");
            Console.WriteLine("Все общедоступные публичные методы класса: ");
            foreach (var i in Reflector.GetPublicMethods("Lab06.Fish"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\tПоля и свойства класса: ");
            foreach (var i in Reflector.GetInfoFieldProperty("Lab06.Fish"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\tИнтерфейсы");
            foreach (var i in Reflector.GetInterface("Lab06.Fish"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Методы, содержащие параметр типа strng: ");
            Reflector.GetMethodByType("Lab06.Fish", typeof(string));
            Console.WriteLine("Invoke: ");
            Reflector.InvokeMethod("Lab06.Fish", "Sleep");

          
            var i1 = Reflector.Create(typeof(Lab04.Parrot));
            var i2 = Reflector.Create(typeof(Lab06.Fish));
            var i3 = Reflector.Create(typeof(System.Int32));
            Console.WriteLine(i1 + "\n" + i2 + "\n" + i3);
        }
    }
}
