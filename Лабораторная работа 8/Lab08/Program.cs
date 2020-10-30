using System;
using System.IO;

namespace Lab04
{
    class Program
    {
        private static void Main(string[] args)
        {
            
            Stack<int> Stack1 = new Stack<int>();
            Stack1.Push(2); Stack1 = Stack1 + 5 + 6 + 3 + 9 + 4 + 111 + 2834;
            Stack1--;
            Console.WriteLine("Current size of stack1 = {0}", Stack1.StackSize());
            Console.WriteLine("Stack1: "); Stack1.Show();
            Console.WriteLine("Sum is: {0}", StatisticOperation.StackSum(Stack1));
            Console.WriteLine("Delta between min&max elements: {0}", StatisticOperation.DeltaBetweenMinAndMax(Stack1));
            Console.WriteLine("Number of elements in stack: {0}", StatisticOperation.CountElements(Stack1));
            Console.WriteLine("Average stack element: {0}", Stack1.Average());

            Stack<int> Stack2 = new Stack<int>();
            if (Stack2) Console.WriteLine("Stack is empty");

            Stack2 = Stack1 > Stack2;
            Console.WriteLine("Stack2"); Stack2.Show();
            Console.WriteLine("Stack1"); Stack1.Show();
            string String1 = "Предложение 1. Предложение 2. Предложение 3! Предложение 4?";
            Console.WriteLine("Строка \"{0}\", \nколичество предложений в строке: {1}", String1, String1.StringSentCount());

            Stack<float> Stack3 = new Stack<float>();
            Stack3.Push(8.65f);
            Stack3.Show();

            Stack<bool> BoolStack = new Stack<bool>();
            BoolStack = BoolStack + true + false + true + false + false;
            BoolStack.Show();


            Stack<Parrot> StackParrot = new Stack<Parrot>();
            Parrot par1 = new Parrot();
            Parrot par2 = new Parrot("Popug");
            Parrot par3 = new Parrot("Пипиг", 2020);
            StackParrot.Push(par1);
            StackParrot = StackParrot + par2 + par3;
            StackParrot.Show();

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(@"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 8\Lab08\FileOut.txt", false);
                if (writer == null)
                    throw new Exception("Ошибка открытия файла");


                Stack2.WriteToFile(writer);
                Stack<int> Stack4 = new Stack<int>();
                string[] temp = StatisticOperation.ReadFromFile();
                foreach (string s in temp)
                    Stack4 += Convert.ToInt32(s);
                Stack4.Show();

                Stack4.WriteToFile(writer);
                StackParrot.WriteToFile(writer);
                Stack3.WriteToFile(writer);
                BoolStack.WriteToFile(writer);
            }
            finally
            {
                Console.WriteLine("Закрыть открытый файл");
                if(writer!=null) writer.Close();
            }
        }
    }
}

