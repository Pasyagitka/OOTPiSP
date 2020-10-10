using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
//Класс - стек Stack. Дополнительно перегрузить следующие 
//операции: + -добавить элемент в стек; -- -извлечь элемент из 
//стека; true - проверка, пустой ли стек; > -копирование одного
//стека в другой с сортировкой в возрастающем порядке.
//Вариант 13 Методы расширения:
//1) Подсчет количества предложений
//2) Определение среднего элемента стека


//индексатор, тестирование
namespace Lab04
{

    public class Stack
    {
        public int[] Elements;
        public int CurrentSize;
        const int StackMaxSize = 30;
        public Owner owner;
        public Date DateOfCreation;

        public Stack()
        {
            this.Elements = new int[StackMaxSize];
            this.owner = new Owner(1029, "Lizaveta", "BSTU");
            this.DateOfCreation = new Date();
            this.CurrentSize = 0;
        }

        public int StackSize()
        {
            return CurrentSize;
        }

        public void ShowStack()
        {
            Console.WriteLine("Создатель: {0}", this.owner);
            for (int i = 0; i < CurrentSize; i++)
            {
                Console.WriteLine("Element N{0} is {1}", i + 1, Elements[i]);
            }
            Console.WriteLine("Дата создания: {0}", this.DateOfCreation);
        }

        public void Push(int element)
        {
            if (CurrentSize == StackMaxSize)
                throw new Exception("StackOverflow was thrown");
            Elements[CurrentSize] = element;
            CurrentSize++;
        }

        public int Peek()
        { // чтение главного элемента 
            if (StackSize() == 0)
                throw new Exception("Stack is empty");
            return Elements[CurrentSize - 1];
        }

        public int Pop()
        {
            if (StackSize() == 0)
                throw new Exception("Stack is empty");
            int element = Elements[--CurrentSize];
            Elements[CurrentSize] = default(int); // сбрасываем ссылку
            return element;
        }

        public void Clear()
        {
            Elements = new int[StackMaxSize];
            CurrentSize = 0;
        }

        public int this[int index]
        {
            get { return Elements[index]; }
            set { Elements[index] = value; }
        }

        public static Stack operator +(Stack stack, int element)
        {
            stack.Push(element);
            return stack;
        }

        public static Stack operator --(Stack stack)
        {
            stack.Pop();
            return stack;
        }

        public static bool operator true(Stack stack)
        {
            return stack.CurrentSize == 0;
        }
        public static bool operator false(Stack stack)
        {
            return stack.CurrentSize != 0;
        }

        public static Stack operator <(Stack stack1, Stack stack2)
        {
            Stack result = new Stack();
            while (stack1.CurrentSize != 0)
            {
                result = result + stack1.Pop();
            }
            while (stack2.CurrentSize != 0)
            {
                result = result + stack2.Pop();
            }
            result.Elements.Sort();
            return result;
        }
        public static Stack operator >(Stack stack1, Stack stack2)
        {
            return stack1;
        }

        public class Owner
        {
            public int ID;
            public string Name;
            public string Organization;

            public Owner(int id, string name, string organization)
            {
                this.ID = id;
                this.Name = name;
                this.Organization = organization;
            }
            public override string ToString()
            {
                return "ID: " + this.ID + ", Name: " + this.Name + ", Organization: " + this.Organization;
            }
        }

        public class Date
        {
            DateTime currentdate =  DateTime.Now;

            public override string ToString()
            {
                return currentdate.ToString();
            }
        }

    }
}
