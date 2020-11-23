using System;
using System.Text;

namespace Lab09
{
    class Program
    {
        private static void HealEvent(int heal)
        {
            Console.WriteLine($"Исцеление #1 на {heal} единиц");
        }
        private static void HealEvent2(int heal)
        {
            Console.WriteLine("!!!Произошло исцеление");
        }
        private static void AttackEvent()
        {
            Console.WriteLine("!!!Произошла атака");
        }


        public static string RemovePunctuationMarks(string str)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0, j = 0; i < str.Length; i++)
                if (str[i] != ',' && str[i] != '?' && str[i] != '!' && str[i] != ':' && str[i] != ';' && str[i] != '.')
                    s.Append(str[i], 1);

            Console.WriteLine($"Строка без знаков пунктуации: {s}");
            return s.ToString();
        }
        public static string ToUpperCase(string str)
        {
            Console.WriteLine($"Замена символов в строке на заглавные: {str.ToUpper()}");
            return str.ToUpper();
        }
        public static string DeleteSpaces(string str)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')   {
                    s.Append(str[i], 1);
                    while (str[i + 1] == ' ')
                        i++;
                }
                else   s.Append(str[i], 1);
            Console.WriteLine($"Строка без лишних пробелов: {s}");
            return s.ToString();
        }
        public static string ReplaceSymbols(string str)
        {
            str = str.Replace("р", "*");
            Console.WriteLine($"Строка с заменой символов \"p\" на \"*\": {str}");
            return str;
        }

        public static void AddSymbols(string str, string additionalsymbols)
        {
            str = str.Insert(0, additionalsymbols);
            str += additionalsymbols;
            Console.WriteLine($"Строка с добавленными символами: {str}");
        }

        public static void Main()
        {
            Game Game1 = new Game();
            Game1.AttackEvent += AttackEvent;
            Game1.AttackEvent += () => Console.WriteLine($"Нанесен урон в {Game.damage} единиц");
            Game1.HealEvent += HealEvent;
            Game1.HealEvent += HealEvent2;

            Game1.Damage();
            Game1.Status();
            Game1.Heal(100);
            Game1.Status();
            Game1.Heal(500);
            Game1.Status();

            string testString1 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string testString2 = "рр!!22?рррр:::р а кк ! нннг   бб.!";

            Action<string, string> editaction;
                                              
            Console.WriteLine($"\nИсходная строка: {testString1}");
            editaction = AddSymbols;
            editaction(testString1, "!!!");
            editaction(testString2, "!!!");

            Func<string, string> editfunc; 
            Console.WriteLine($"\nИсходная строка: {testString2}");
            editfunc = RemovePunctuationMarks;
            editfunc += ToUpperCase;
            editfunc += DeleteSpaces;
            editfunc += ReplaceSymbols;
            string result = editfunc(testString2);
        }
    }
}
