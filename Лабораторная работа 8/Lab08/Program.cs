using System;


//T-файл и еще что-то
namespace Lab04
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                CollectionType<int> Stack1 = new CollectionType<int>();
                Stack1.Push(2); Stack1 = Stack1 + 5 + 6 + 3 + 9 + 4 + 111;
                Stack1--;
                Console.WriteLine("Current size of stack1 = {0}", Stack1.StackSize());
                Console.WriteLine("Stack1: "); Stack1.Show();
                Console.WriteLine("Sum is: {0}", StatisticOperation.StackSum(Stack1));
                Console.WriteLine("Delta between min&max elements: {0}", StatisticOperation.DeltaBetweenMinAndMax(Stack1));
                Console.WriteLine("Number of elements in stack: {0}", StatisticOperation.CountElements(Stack1));
                Console.WriteLine("Average stack element: {0}", Stack1.Average());

                CollectionType<int> Stack2 = new CollectionType<int>();
                if (Stack2) Console.WriteLine("Stack is empty");

                Stack2 = Stack1 > Stack2;
                Console.WriteLine("Stack2"); Stack2.Show();
                Console.WriteLine("Stack1"); Stack1.Show();
                string String1 = "Предложение 1. Предложение 2. Предложение 3! Предложение 4?";
                Console.WriteLine("Строка \"{0}\", \nколичество предложений в строке: {1}", String1, String1.StringSentCount());

                CollectionType<float> Stack3 = new CollectionType<float>();
                Stack3.Push(8.65f);
                Stack3.Show();

                CollectionType<Parrot> StackParrot = new CollectionType<Parrot>();
                Parrot par1 = new Parrot();
                Parrot par2 = new Parrot("Popug");
                Parrot par3 = new Parrot("Пипиг", 2020);
                StackParrot.Push(par1);
                StackParrot = StackParrot + par2 + par3;
                StackParrot.Show();


                Stack2.WriteToFile();
                CollectionType<int> Stack4 = new CollectionType<int>();
                char[] temp = StatisticOperation.ReadFromFile();
                foreach (int t in temp)
                {
                    Stack4 += Convert.ToInt32(t) - 48;
                }
                Stack4.Show();
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}

