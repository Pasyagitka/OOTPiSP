using System;
using System.Collections.Generic;
using System.Text;

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


            Console.Write("bool: "); varbool = Convert.ToBoolean(Console.ReadLine());
            Console.Write("byte: "); varbyte = Convert.ToByte(Console.ReadLine());  //0-255 
            Console.Write("sbyte: "); varsbyte = Convert.ToSByte(Console.ReadLine());  //-128 - +127 
            Console.Write("char: "); varchar = Convert.ToChar(Console.ReadLine());
            Console.Write("decimal: "); vardecimal = Convert.ToDecimal(Console.ReadLine());
            Console.Write("double: "); vardouble = Convert.ToDouble(Console.ReadLine());
            Console.Write("float: "); varfloat = Convert.ToSingle(Console.ReadLine());
            Console.Write("int: "); varint = Convert.ToInt32(Console.ReadLine());
            Console.Write("uint: "); varuint = Convert.ToUInt32(Console.ReadLine());   //0 до 4294967295 и занимает 4 байта System.UInt32
            Console.Write("long: "); varlong = Convert.ToInt64(Console.ReadLine());
            Console.Write("ulong: "); varulong = Convert.ToUInt64(Console.ReadLine());
            Console.Write("short: "); varshort = Convert.ToInt16(Console.ReadLine());
            Console.Write("ushort: "); varushort = Convert.ToUInt16(Console.ReadLine());
            Console.Write("string: "); varstring = Console.ReadLine();
            Console.Write("object: "); varobject = Console.ReadLine();

            Console.WriteLine($"varbool = {varbool}, varbyte = {varbyte}, varsbyte = {varsbyte}, varchar = {varchar}, vardecimal = {vardecimal}, vardouble = {vardouble},\nvarfloat = {varfloat}, varint = {varint}, varuint = {varuint}, varlong = {varlong}, varulong = {varulong}, varshort = {varshort},\nvarushort = {varushort}, varstring = {varstring}, varobject = {varobject}");


            double doublevar = (double)varfloat; 
            long longvar = (long)varint; 
            int intvar = (int)varshort; 
            short shortvar1 = (short)varsbyte; 
            short shortvar2 = (short)varbyte; 
            Console.WriteLine($"{doublevar},  {longvar}, {intvar}, {shortvar1}, {shortvar2}");

            doublevar = varfloat;
            longvar = varint; 
            intvar = varshort; 
            shortvar1 = varsbyte; 
            shortvar2 = varbyte; 
            Console.WriteLine($"{doublevar},  {longvar}, {intvar}, {shortvar1}, {shortvar2}");

            int intboxing = 5;
            object o = intboxing;     
            int intunboxing = (int)o;
            Console.WriteLine("intunboxing: {0}", intunboxing);
            float floatboxing = 1.2f;
            o = floatboxing;
            float floatunboxing = (float)o;
            Console.WriteLine("floatunboxing: {0}", floatunboxing);

            var variable1 = 9999;
            var variable2 = "variable2";
            //variable1 = "variable2";
            Console.WriteLine($"Работа с неявно типизированной переменной: {variable1}, {variable2}");

  
            int? nullable1 = null;
            if (nullable1.HasValue)  Console.WriteLine("nullable1 = {0}", nullable1.Value);
                else Console.WriteLine("nullable1 does not have a value");
            Nullable<int> nullable2 = 9;
            if (nullable2.HasValue)  Console.WriteLine("nullable2 = {0}", nullable2.Value);
                else  Console.WriteLine("nullable2 does not have a value");

            string string1 = "ABC";
            string string2 = "BCD";         
            //Данная версия метода Compare принимает две строки и возвращает число.
            //Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля
            //В противном случае возвращается число больше нуля.И третий случай - если строки равны, то возвращается число 0.
            int result1 = String.Compare(string1, string2);
 
            if (result1 < 0)   {
                Console.WriteLine("string1 стоит выше строки string2");
            }
            else if (result1 > 0) {
                Console.WriteLine("string1 стоит ниже строки string2");
            }
            else {
                Console.WriteLine("string1 и string2 идентичны");
            }

            string str1 = "string1";
            string str2 = "string2";
            string str3= String.Concat(str1, " ");
            str3 += str2;
            Console.WriteLine($"Конкатенация - \"{str3}\".");
            string[] strings = new string[] { str1, str2 };
            str3 = String.Join(" ", strings);
            Console.WriteLine($"Конкатенация - \"{str3}\".");
            str3 = String.Copy(str1);
            Console.WriteLine($"Копирование - \"{str3}\".");
            str3 = str1.Substring(3);
            Console.WriteLine($"Выделение подстроки (обрезать) - \"{str3}\".");
            str3 = "abcde fgh ijkl mn";
            string[] words = str3.Split(new char[] { ' ' });
            Console.WriteLine("Разделения строки на слова:");
            foreach (string s in words)
                Console.WriteLine(s);
            str3 = str3.Insert(2, str1);
            Console.WriteLine($"Вставка подстроки в заданную позицию - \"{str3}\".");
            str3 = str3.Remove(1, 8);
            Console.WriteLine($"Удаление подстроки из заданной позиции - \"{str3}\"."); //  - интерполирование строк.

            string nullstring = null; 
            string emptystring = String.Empty;
            if (String.IsNullOrEmpty(nullstring))
                Console.WriteLine($"nullstring is null or empty: \"{nullstring}\".");
            else Console.WriteLine($"nullstring is neither null nor empty: \"{nullstring}\".");
            if (String.IsNullOrEmpty(emptystring))
                Console.WriteLine($"emptystring is null or empty: \"{emptystring}\".");
            else Console.WriteLine($"emptystring is neither null nor empty: \"{emptystring}\".");
            if (String.IsNullOrEmpty(str3))
                Console.WriteLine($"str3 is null or empty: \"{str3}\".");
            else Console.WriteLine($"str3 is neither null nor empty: \"{str3}\".");
            if (nullstring == null) Console.WriteLine("nullstring is null");
            if (emptystring == String.Empty) Console.WriteLine("emptystring is empty");
            Console.WriteLine($"Размер пустой строки: {emptystring.Length}.");
            emptystring += "____";
            Console.WriteLine($"Пустая строка: {emptystring}."); //методы
            nullstring += "____";
            Console.WriteLine($"null строка: {nullstring}."); //объединение и сравнение

            StringBuilder strbuild = new StringBuilder("abcdefghijk", 50);
            strbuild.Insert(0, "!!!");
            strbuild.Append(new char[] { 'A', 'B', 'C' });
            strbuild.Remove(3, 1); strbuild.Remove(6, 1);
            Console.WriteLine("StringBuilder: {0}", strbuild);

            int[,] Array = { { 1, 2, 3 }, { 4, 5, 6 } };
            int rows = Array.GetUpperBound(0) + 1;
            int columns = Array.Length / rows;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) 
                    Console.Write($"{Array[i, j]} \t");
                Console.WriteLine();
            }
            string[] StrArray = { "A", "B", "C", "D", "EF" };
            foreach (string u in StrArray)  {
                Console.Write($"{u}\t");
            }
            Console.WriteLine($"Размер массива: {StrArray.Length}\t");
            Console.Write("Введите позицию: "); int position = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите элемент на замену: "); string value = Console.ReadLine();
            StrArray[--position] = value;
            foreach (string u in StrArray)
                Console.Write($"{u}\t");

            int[][] Array2 = new int[3][];
            Array2[0] = new int[2];
            Array2[1] = new int[3];
            Array2[2] = new int[4];
            Console.Write("Заполните массив: ");
            for (int i = 0; i < Array2.Length; i++)
            {
                for (int j = 0; j < Array2[i].Length; j++)
                    Array2[i][j] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < Array2.Length; i++)
            {
                for (int j = 0; j < Array2[i].Length; j++)
                    Console.Write($"{Array2[i][j]} \t");
                Console.WriteLine();
            }

            var A = new[] { 1, 2, 3};
            var S = "STRING";

     
            (int one, string two, char three, string four, ulong five) tuple1 = (1, "это", '-', "кортеж", 111);
            Console.WriteLine($"Первый: {tuple1.Item1}, третий:  {tuple1.Item2}, четвертый: {tuple1.Item3}.");
            Console.WriteLine(tuple1.ToString());
            var tuple2 = (1, "это", '-', "кортеж", 111);
            var (one, two, three, four, five) = tuple2;
            Console.WriteLine("Распаковка 2, two: {0}", two);
            var a = 0; var b = String.Empty; var c = '\0'; var d = String.Empty; var e = 0L;
            var tuple3 = (1, "это", '-', "кортеж", 111);
            (a, b, c, d, e) = tuple3;
            Console.WriteLine("Распаковка 3, d: {0}", d);

            (int, int) Tuple1 = (10, 100);
            (int, int) Tuple2 = (10, 100);
            if (Tuple1 == Tuple2)   Console.WriteLine("Кортежи Tuple2 и Tuple2 равны");
            else  Console.WriteLine("Кортежи Tuple2 и Tuple2  не равны");
          
            int[] NumArray = { 5, 2, 6, 9, 1, 7, 3, 4 };
            string strk = "aaaaaaaaaaaaaaaa";
            static Tuple<int, int, int, char> Z5(int[] NumArray, string str)
            {
                int min = NumArray[0], max = NumArray[0], sum = 0;
                for (int i = 0; i < NumArray.Length; i++)
                {
                    if (NumArray[i] < min) min = NumArray[i];
                    if (NumArray[i] > max) max = NumArray[i];
                    sum += NumArray[i];
                }
                return new Tuple<int, int, int, char>(max, min, sum, str[0]);
            }
            Console.WriteLine(Z5(NumArray, strk).ToString());

            static int Z61()
            {
                checked   {
                    int maxint = 2147483647;
                    return maxint + 1;
                }
            }
            static int Z62()
            {
                unchecked  {
                    int maxint = 2147483647;
                    return maxint + 1;
                }
            }
            //Console.WriteLine(Z61());
            Z62();
        }
    }
}