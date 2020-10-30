using System;
using System.IO;

namespace Lab04
{
    public class Stack<T> : IStack<T> where T : new() //ограничение на конструктор, Требование предоставить конструктор без параметров
    {
        public T[] Elements;
        public int CurrentSize;
        const int StackMaxSize = 30;
        Owner owner;
        Date DateOfCreation;

        public Stack()
        {
            this.Elements = new T[StackMaxSize];
            this.owner = new Owner();
            this.DateOfCreation = new Date();
            this.CurrentSize = 0;
        }

        public void Push(T element)
        {
            if (CurrentSize == StackMaxSize)
                throw new Exception("StackOverflow was thrown");
            Elements[CurrentSize++] = element;
        }

        public T Pop()
        {
            if (StackSize() == 0)
                throw new Exception("Stack is empty");
            T element = Elements[--CurrentSize];
            Elements[CurrentSize] = default(T); // сбрасываем ссылку
            return element;
        }

        public void Show()
        {
            Console.WriteLine("Creator: {0}", this.owner);
            for (int i = 0; i < CurrentSize; i++)
            {
                Console.WriteLine("Element N{0} is {1}", i + 1, Elements[i]);
            }
            Console.WriteLine("Date: {0}", this.DateOfCreation);
        }

        public int StackSize()
        {
            return CurrentSize;
        }

        public T Peek()
        {
            if (StackSize() == 0)
                throw new Exception("Stack is empty");
            return Elements[CurrentSize - 1];
        }

        public void Clear()
        {
            Elements = new T[StackMaxSize];
            CurrentSize = 0;
        }

        public static Stack<T> operator +(Stack<T> stack, T element)
        {
            stack.Push(element);
            return stack;
        }

        public static Stack<T> operator --(Stack<T> stack)
        {
            stack.Pop();
            return stack;
        }

        public static bool operator true(Stack<T> stack)
        {
            return stack.CurrentSize == 0;
        }
        public static bool operator false(Stack<T> stack)
        {
            return stack.CurrentSize != 0;
        }

        public static Stack<T> operator >(Stack<T> stack1, Stack<T> stack2)
        {
            stack2 = (Stack<T>)stack1.MemberwiseClone();
            T[] temp = new T[stack1.CurrentSize];
            for (int i = 0; i < stack1.CurrentSize; i++)
            {
                temp[i] = stack1.Elements[i];
            }
            Array.Sort(temp);
            stack2.Elements = temp;
            return stack2;
        }

        public static Stack<T> operator <(Stack<T> stack1, Stack<T> stack2)
        {
            return stack1;
        }

        private class Owner
        {
            int ID;
            string Name;
            string Organization;

            public Owner()
            {
                this.ID = 129812;
                this.Name = "Lizaveta";
                this.Organization = "BSTU";
            }
            public override string ToString()
            {
                return "ID: " + this.ID + ", Name: " + this.Name + ", Organization: " + this.Organization;
            }
        }

        private class Date
        {
            DateTime currentdate = DateTime.Now;

            public override string ToString()
            {
                return currentdate.ToString();
            }
        }

        public void WriteToFile(StreamWriter writer)
        {
            writer.WriteLine("Стек " + (this.Elements).GetType());
            for (int i = 0; i < CurrentSize; i++)
            {
              writer.WriteLine(Elements[i]);
            }
        }
    }
}