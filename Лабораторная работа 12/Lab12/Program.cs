using System;
using System.IO;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {        
            Reflector.GetAssemblyInfo("Lab04.Parrot");
            Reflector.GetPublicCtors("Lab04.Parrot");
            foreach (var i in Reflector.GetPublicMethods("Lab04.Parrot"))
            {
                Console.WriteLine(i);
            }
            foreach (var i in Reflector.GetInfoFieldProperty("Lab04.Parrot"))
            {
                Console.WriteLine(i);
            }
            foreach (var i in Reflector.GetInterface("Lab04.Parrot"))
            {
                Console.WriteLine(i);
            }
            Reflector.GetMethodByType("Lab04.Parrot", typeof(int) );
        }
    }
}
