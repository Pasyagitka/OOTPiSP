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

    class Stack
    {
        private string[] Elements;
        private int CurrentNumberOfElements;
        const int N = 20;

        public Stack()
        {
            Elements = new string[N];
        }

        public Stack(int StackSize)
        {
            Elements = new string[StackSize];
        }

        public static bool operator true(Stack elements)
        {
            return elements.CurrentNumberOfElements == 0;
        }
        public static bool operator false(Stack elements)
        {
            return elements.CurrentNumberOfElements != 0;
        }

        //public static Stack operator +(Stack[] elements, string NewElement)
        //{
        //    if (elements.CurrentNumberOfElements == elements.N)
        //        throw new InvalidOperationException("Stack overflow");
        //    elements[elements.Length++] = NewElement;
        //}
       
        //public T Pop()
        //{
        //    if (IsEmpty())
        //        throw new InvalidOperationException("Stack is empty");
        //    T Element = Elements[--CurrentNumberOfElements];
        //    Elements[CurrentNumberOfElements] = default(T); // сбрасываем ссылку
        //    return Element;
        //}

        //public static 
    }

    class Program
    {
        
    }
}
