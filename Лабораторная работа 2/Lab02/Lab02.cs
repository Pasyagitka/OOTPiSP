using System;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool varbool = false; 
            byte varbyte = 1; 
            sbyte varsbyte = 0; 
            char varchar = 'l';
            decimal vardecimal = 1.2M; 
            double vardouble = 1.203; 
            float varfloat = 1.2F; 
            int varint = -5;
            uint varuint = 5U; 
            long varlong = 9348L; 
            ulong varulong = 348UL; 
            short varshort = 32767; 
            ushort varushort = 65535;
            string varstring = "varstring"; 
            object varobject = "varobject";

            Console.Write("bool: ");    varbool = Convert.ToBoolean(Console.ReadLine());                              
            Console.Write("byte: ");    varbyte = Convert.ToByte(Console.ReadLine());  //0-255 
            Console.Write("sbyte: ");   varsbyte = Convert.ToSByte(Console.ReadLine());  //-128 - +127 
            Console.Write("char: ");    varchar = Convert.ToChar(Console.ReadLine());                                                   
            Console.Write("decimal: "); vardecimal = Convert.ToDecimal(Console.ReadLine());                                            
            Console.Write("double: ");  vardouble = Convert.ToDouble(Console.ReadLine());                                            
            Console.Write("float: ");   varfloat = Convert.ToSingle(Console.ReadLine());                                           
            Console.Write("int: ");     varint = Convert.ToInt32(Console.ReadLine());                               
            Console.Write("uint: ");    varuint = Convert.ToUInt32(Console.ReadLine());   //0 до 4294967295 и занимает 4 байта System.UInt32
            Console.Write("long: ");    varlong = Convert.ToInt64(Console.ReadLine());                                            
            Console.Write("ulong: ");   varulong = Convert.ToUInt64(Console.ReadLine());                                                
            Console.Write("short: ");   varshort = Convert.ToInt16(Console.ReadLine());                                                 
            Console.Write("ushort: ");  varushort = Convert.ToUInt16(Console.ReadLine());
            Console.Write("string: ");  varstring = Console.ReadLine();
            Console.Write("object: ");  varobject = Console.ReadLine();

            Console.WriteLine("varbool = {varbool}, varbyte = {varbyte}, varsbyte = {varsbyte}, varchar = {varchar}, vardecimal = {vardecimal}, vardouble = {vardouble},\nvarfloat = {varfloat}, varint = {varint}, varuint = {varuint}, varlong = {varlong}, varulong = {varulong}, varshort = {varshort},\nvarushort = {varushort}, varstring = {varstring}, varobject = {varobject}");
        }
    }
}