using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04
{
    interface ICollectionType<T>
    {
        void Push(T element);
        T Pop();
        void Show();
    }
}
