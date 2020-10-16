using System;

namespace Lab04
{
    class Program
    {
        private static void Main(string[] args)
        { 
            Stack Stack1 = new Stack();
            Stack1.Push(2); Stack1 = Stack1 + 5 + 6 + 3 + 9 + 4 + 111;
            Stack1--;
            Console.WriteLine("Current size of stack1 = {0}", Stack1.StackSize());
            Console.WriteLine("Stack1: "); Stack1.ShowStack();
            Console.WriteLine("Sum is: {0}", StatisticOperation.StackSum(Stack1));
            Console.WriteLine("Delta between min&max elements: {0}", StatisticOperation.DeltaBetweenMinAndMax(Stack1));
            Console.WriteLine("Number of elements in stack: {0}", StatisticOperation.CountElements(Stack1));
            Console.WriteLine("Average stack element: {0}", Stack1.Average());
           
            Stack Stack2 = new Stack();
            if (Stack2) Console.WriteLine("Stack is empty");

            Stack2 = Stack1 > Stack2;
            Console.WriteLine("Stack2");  Stack2.ShowStack();
            Console.WriteLine("Stack1");  Stack1.ShowStack();
            string String1 = "Предложение 1. Предложение 2. Предложение 3! Предложение 4?";
            Console.WriteLine("Строка \"{0}\", \nколичество предложений в строке: {1}", String1, StatisticOperation.StringSentCount(String1));
        }
    }
}

