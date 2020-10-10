using System;
using System.Diagnostics;

namespace Lab04
{
    class Program
    {
        private static void Main(string[] args)
        {
            var Stack1 = new Stack();
            Stack1.Push(2); Stack1.Push(1); Stack1.Push(6); Stack1.Push(3); Stack1.Push(9); Stack1.Push(4);
            Console.WriteLine("Current size of stack1 = {0}", Stack1.StackSize());
            Console.WriteLine("Стек Stack1: "); Stack1.ShowStack();
            //в стеке вместо пустоты нули
            Console.WriteLine("Сумма: {0}", StatisticOperation.StackSum(Stack1));
            Console.WriteLine("Разница между наименьшим и наибольшим элементами: {0}", StatisticOperation.DeltaBetweenMinAndMax(Stack1));
            Console.WriteLine("Количество элементов в стеке: {0}", StatisticOperation.CountElements(Stack1));
            Console.WriteLine("Средний элемент стека: {0}", StatisticOperation.Average(Stack1));

            var Stack2 = new Stack();
            Stack2 = Stack1 > Stack2;
            //Stack1.ShowStack();
            //var Stack3 = new Stack();
            //Stack3 = Stack1 > Stack3;
            //Console.WriteLine("Стек2:");
            //Stack2.ShowStack();
            //var Stack4= new Stack();
            //Stack4 = Stack2 > Stack4;
            //Console.WriteLine("Стек4:");
            //Stack4.ShowStack();

            string String1 = "Предложение 1. Предложение 2. Предложение 3! Предложение 4?";
            Console.WriteLine("Строка \"{0}\", \nколичество предложений в строке: {1}", String1, StatisticOperation.StringSentCount(String1));
        }
    }
}
