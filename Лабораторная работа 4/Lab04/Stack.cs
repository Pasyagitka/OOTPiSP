using System;

//Вариант 13 Методы расширения:
//1) Подсчет количества предложений
//2) Определение среднего элемента стека


namespace Lab04
{
    public class Stack
    {
        public int[] Elements;
        public int CurrentSize;
        const int StackMaxSize = 30;
        Owner owner;
        Date DateOfCreation;

        public Stack()
        {
            this.Elements = new int[StackMaxSize];
            this.owner = new Owner();
            this.DateOfCreation = new Date();
            this.CurrentSize = 0;
        }

        public int StackSize()
        {
            return CurrentSize;
        }

        public void ShowStack()
        {
            Console.WriteLine("Creator: {0}", this.owner);
            for (int i = 0; i < CurrentSize; i++)
            {
                Console.WriteLine("Element N{0} is {1}", i + 1, Elements[i]);
            }
            Console.WriteLine("Date: {0}", this.DateOfCreation);
        }

        public void Push(int element)
        {
            if (CurrentSize == StackMaxSize)
                throw new Exception("StackOverflow was thrown");
            Elements[CurrentSize++] = element;
        }

        public int Peek()
        { 
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

        public static Stack operator >(Stack stack1, Stack stack2)
        {
            stack2 = (Stack)stack1.MemberwiseClone();
            int[] temp = new int[stack1.CurrentSize];
            for (int i = 0; i < stack1.CurrentSize; i++)
            {
                temp[i] = stack1.Elements[i];
            }
            Array.Sort(temp);
            stack2.Elements = temp;
            return stack2;
        }

        public static Stack operator <(Stack stack1, Stack stack2)
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
            DateTime currentdate =  DateTime.Now;

            public override string ToString()
            {
                return currentdate.ToString();
            }
        }

    }
}
