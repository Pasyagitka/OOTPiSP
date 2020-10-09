using System;

namespace Lab04
{
    class Program
    {
        private static void Main(string[] args)
        {
            var Stack1 = new Stack<string>();
            Stack1.Push("Lora"); Stack1.Push("Dale"); Stack1.Push("Jack"); Stack1.Push("Anna"); Stack1.Push("Yodi"); Stack1.Push("Lisa");     
            Stack1 = Stack1 + "Voh";
            Console.WriteLine("Current size of stack1 = {0}", Stack1.StackSize());
            Stack1.ShowStack();

            var Stack2 = new Stack<int>();
            Stack2.Push(2);  Stack2.Push(1);  Stack2.Push(5);  Stack2.Push(3);
            

            Console.WriteLine("Copy");
            Console.WriteLine("Стек1 до:");
            Stack1.ShowStack();
            var Stack3 = new Stack<string>();
            Stack3 = Stack1 > Stack3;
            Console.WriteLine("Стек3:");
            Stack3.ShowStack();
            Console.WriteLine("Стек1:");
            Stack1.ShowStack();
            Console.WriteLine("Стек2:");
            Stack2.ShowStack();
            var Stack4= new Stack<int>();
            Stack4 = Stack2 > Stack4;
            Console.WriteLine("Стек4:");
            Stack4.ShowStack();

            //Average(Stack4);
        }
    }
}
