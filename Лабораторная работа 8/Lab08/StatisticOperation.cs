using System;
using System.IO;
using System.Linq;

namespace Lab04
{
    public static class StatisticOperation
    {
        public static int StackSum(Stack<int> stack)
        {
            //stack.Elements.Sum();
            int stacksum = 0;
            foreach (int e in stack.Elements){
                stacksum += e;
            }
            return stacksum;
        }
        public static int DeltaBetweenMinAndMax(Stack<int> stack)
        {
            int[] temp = new int[stack.CurrentSize];
            for (int i = 0; i < stack.CurrentSize; i++)
            {
                temp[i] = stack.Elements[i];
            }
            return Math.Abs(temp.Max()) - Math.Abs(temp.Min());
        }

        public static int CountElements(Stack<int> stack)
        {
            return stack.CurrentSize;
        }

        public static float Average(this Stack<int> stack)
        {
            return (float)StackSum(stack) / (float)stack.CurrentSize;
        }

        public static int StringSentCount(this string currentstring)
        {
            return currentstring.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string[] ReadFromFile(string path = @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 8\Lab08\File.txt")
        {
            StreamReader reader = new StreamReader(path);
            if (reader == null)
                throw new Exception("Ошибка открытия файла");

            string temp = reader.ReadLine();
            reader.Close();
            return temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

