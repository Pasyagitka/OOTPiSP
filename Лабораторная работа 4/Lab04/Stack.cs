using System;
//Класс - стек Stack. Дополнительно перегрузить следующие 
//операции: + -добавить элемент в стек; -- -извлечь элемент из 
//стека; true - проверка, пустой ли стек; > -копирование одного
//стека в другой с сортировкой в возрастающем порядке.
//Вариант 13 Методы расширения:
//1) Подсчет количества предложений
//2) Определение среднего элемента стека

namespace Lab04
{

    public class Stack<T>
    {
        private T[] Elements;
        private int CurrentSize;
        private const int StackMaxSize = 30;

        public Stack()
        {
            Elements = new T[StackMaxSize];
            CurrentSize = 0;
        }

        public int StackSize()
        {
            return CurrentSize;
        }

        public void ShowStack()
        {
            for (int i = 0; i < CurrentSize; i++)
            {
                Console.WriteLine("Element N{0} is {1}", i + 1, Elements[i]);
            }
        }

        public void Push(T element)
        {
            if (CurrentSize == StackMaxSize)
                throw new Exception("StackOverflow was thrown");
            Elements[CurrentSize] = element;
            CurrentSize++;
        }

        public T Peek()
        { // чтение главного элемента 
            if (StackSize() == 0)
                throw new Exception("Stack is empty");
            return Elements[CurrentSize - 1];
        }

        public T Pop()
        {
            if (StackSize() == 0)
                throw new Exception("Stack is empty");
            T element = Elements[--CurrentSize];
            Elements[CurrentSize] = default(T); // сбрасываем ссылку
            return element;
        }

        public void Clear()
        {
            Elements = new T[StackMaxSize];
            CurrentSize = 0;
        }

        //public int this[int index]  {
        //    get { return this.Elements[index]; }
        //    set {  this.Elements[index] = value; }
        //}

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

        public static Stack<T> operator <(Stack<T> a, Stack<T> b)
        {
            if (a.CurrentSize < b.CurrentSize)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public static Stack<T> operator >(Stack<T> stack1, Stack<T> stack2)
        {
            Sort(stack1);
            var buffer = stack1; //надо копирование чтоб не ссылалось
            while (buffer.CurrentSize != 0)
            {
                stack2 += buffer.Pop();
            }
            return stack2;
        }
        private static int Compare(string element1, string element2)
        {
            return (element1[0] > element2[0] || element1[0] == element2[0]) ? 1 : 0;
        }
        private static int Compare(int element1, int element2)
        {
            return (element1 > element2 || element1 == element2) ? 1 : 0;               
        }
        private static void Sort(Stack<T> stack)
        {
            dynamic element1;
            dynamic element2;
            for (int i = 0; i < stack.CurrentSize; i++)
            {
                for (int j = (stack.CurrentSize - 1); j >= (i + 1); j--)
                {
                    element1 = stack.Elements[j];
                    element2 = stack.Elements[j - 1];
                    if (Compare(element1, element2) == 1)
                    {
                        var temp = stack.Elements[j];
                        stack.Elements[j] = stack.Elements[j - 1];
                        stack.Elements[j - 1] = temp;
                    }
                }
            }
        }
           

        //public void Average()
        //{
        //   // не вывзываю
        //    dynamic temp = this.Elements[0];
        //    if (IsInteger(temp) == 1)
        //    {
        //        dynamic sum = 0;
        //        int i;
        //        for (i = 0; i < this.CurrentSize; i++)
        //        {
        //            sum += this.Elements[i];
        //        }
        //        sum /= i;
        //        Console.WriteLine("sum = {0}", sum);
        //    }
        //    else Console.WriteLine("Невозможно найти средний элемент строки!");
        //}


    }
}
