using System;
using System.IO;
using System.Linq;

namespace Lab04
{
    public static class StatisticOperation
    {
        public static int StackSum(CollectionType<int> stack)
        {
            //stack.Elements.Sum();
            int stacksum = 0;
            foreach (int e in stack.Elements){
                stacksum += e;
            }
            return stacksum;
        }
        public static int DeltaBetweenMinAndMax(CollectionType<int> stack)
        {
            int[] temp = new int[stack.CurrentSize];
            for (int i = 0; i < stack.CurrentSize; i++)
            {
                temp[i] = stack.Elements[i];
            }
            return Math.Abs(temp.Max()) - Math.Abs(temp.Min());
        }

        public static int CountElements(CollectionType<int> stack)
        {
            return stack.CurrentSize;
        }

        public static float Average(this CollectionType<int> stack)
        {
            return (float)StackSum(stack) / (float)stack.CurrentSize;
        }

        public static int StringSentCount(this string currentstring)
        {
            return currentstring.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static char[] ReadFromFile(string path = @"E:\3 семестр\ООТПиСП лабораторные\Лабораторнаяя работа 8\Lab08\File.txt")
        {
            StreamReader reader = new StreamReader(path);
            if (reader == null)
                throw new Exception("Ошибка открытия файла");

            char[] temp = reader.ReadLine().ToArray();
            reader.Close();
            return temp;
        }
    }
}

