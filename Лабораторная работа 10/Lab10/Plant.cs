using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Plant<T> : IList<T>
    {
        public T[] elements;
       
    }
}
