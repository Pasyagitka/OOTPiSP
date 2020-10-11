using System;
using System.Linq;

namespace Lab04
{
    public static class StatisticOperation
    {
        public static int StackSum(Stack stack)
        {
            int stacksum = 0;
            foreach (int e in stack.Elements){
                stacksum += e;
            }
            return stacksum;
        }
        public static int DeltaBetweenMinAndMax(Stack stack)
        {
            int[] temp = new int[stack.CurrentSize];
            for (int i = 0; i < stack.CurrentSize; i++)
            {
                temp[i] = stack.Elements[i];
            }
            return Math.Abs(temp.Max()) - Math.Abs(temp.Min());
        }

        public static int CountElements(Stack stack)
        {
            return stack.CurrentSize;
        }

        public static float Average(Stack stack)
        {     
            return (float)StackSum(stack) / (float)stack.CurrentSize;
        }

        //str.split([separator[, limit]])
        public static int StringSentCount(this string currentstring)
        {
            return currentstring.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

