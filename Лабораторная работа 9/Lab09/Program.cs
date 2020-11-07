using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    class Program
    {
        public static int Regeneration(int heal)
        {
            Console.WriteLine("Регенерация здоровья");
            return heal;
        }

        public static string RemovePunctuationMarks(string str)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0, j = 0; i < str.Length; i++)
                if (str[i] != ',' && str[i] != '?' && str[i] != '!' && str[i] != ':' && str[i] != ';')
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
            StringBuilder rc = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                {
                    rc.Append(str[i], 1);
                    while (str[i + 1] == ' ')
                        i++;
                }
                else
                    rc.Append(str[i], 1);
            Console.WriteLine($"Строка без лишних пробелов: {rc}");
            return rc.ToString();
        }

        public static void AddSymbols(string str, string additionSymbols)
        {
            str = str.Insert(0, additionSymbols);
            str += additionSymbols;
            Console.WriteLine($"Результат: {str}");
        }


        public static void Main()
        {
            Game Game1 = new Game();
            Game1.AttackEvent += () => Console.WriteLine("Атакую!");
            Game1.AttackEvent += () => Console.WriteLine($"Нанесенный урон: {Game1.damage}");
            Game1.HealEvent += Regeneration;

            Game1.Attack();
            Game1.Heal(400);

            Game Game2 = new Game(); 
            Game1.AttackEvent += () => Console.WriteLine("Атакую!");
            Game1.HealEvent += Regeneration;


            Action<string, string> formatingForTitle;

            formatingForTitle = AddSymbols;
            formatingForTitle("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "!!!");

            string testString = "рр!!22?рррр:::р а кк ! нннг               бб.!";
            Func<string, string> func;
            func = RemovePunctuationMarks;
            func += ToUpperCase;
            func += DeleteSpaces;

            string result = func(testString);
        }
    }
}
