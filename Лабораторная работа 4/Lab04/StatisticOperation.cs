using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab04
{
    static class StatisticOperation
    {
        public static int StackSum(Stack stack)
        {
            int stacksum = 0;
            //for (int i = 0; i < stack.CurrentSize; i++)
            //{
            //    stacksum += stack.Elements[i]; 
            //}
            foreach (int e in stack.Elements){
                stacksum += e;
            }
            return stacksum;
        }
        public static int DeltaBetweenMinAndMax(Stack stack)
        {
            int[] temp = stack.Elements;
            return Math.Abs(temp.Max()) - Math.Abs(temp.Min());
        }

        public static int CountElements(Stack stack)
        {
            int i = 0;
            for (; i < stack.CurrentSize; i++) { }
            return i;
        }

        public static int Average(Stack stack)
        {
            return StackSum(stack)/stack.CurrentSize;
        }

        //str.split([separator[, limit]])
        public static int StringSentCount(this string currentstring)
        {
            return currentstring.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

