namespace Lab04
{
    interface IStack<T>
    {
        void Push(T element);
        T Pop();
        void Show();
    }
}

