using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab16
{
    public partial class Program
    {
        static Task task1;
        static Task task2;
        static Task task3_1;
        static Task task3_2;

        static void SieveEratosthenes_ex1()
        {
            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Идентификатор текущей задачи: " + Task.CurrentId.ToString());
            Console.WriteLine("Завершена ли задача: " + task1.IsCompleted.ToString());
            Console.WriteLine("Статус задачи: " + task1.Status.ToString());
            int n = 2000;
            var numbers = new List<int>();
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);  
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }
            watch.Stop();
            Console.WriteLine("Алгоритм занял: " + watch.Elapsed); //00:00:00.0739856   00:00:00.0713163    00:00:00.0776418
            foreach (int a in numbers)
                Console.WriteLine(a);
        }
        static void SieveEratosthenes_ex2()
        {
            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Идентификатор текущей задачи: " + Task.CurrentId.ToString());
            Console.WriteLine("Завершена ли задача: " + task2.IsCompleted.ToString());
            Console.WriteLine("Статус задачи: " + task2.Status.ToString());
            int n = 2000;
            var numbers = new List<int>();
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
                //if (token.IsCancellationRequested)
                //{
                //    Console.WriteLine("\nОперация прервана токеном");
                //    return;
                //}
            }
            watch.Stop();
            
            Console.WriteLine("Алгоритм занял: " + watch.Elapsed); //00:00:00.0739856   00:00:00.0713163    00:00:00.0776418
            foreach (int a in numbers)
            {
                Thread.Sleep(500);
                Console.WriteLine(a);
            }
        }


        public static void Main(string[] args)
        {
            /*---------------------------------------------------------------------------------------------------------------*/
            Console.WriteLine("1. Используя TPL создайте длительную по времени задачу (на основе Task)");
            Action ex1 = new Action(SieveEratosthenes_ex1);
            task1 = Task.Factory.StartNew(ex1);
            task1.Wait();
            task1.Dispose();

            /*---------------------------------------------------------------------------------------------------------------*/
            //Console.WriteLine("2. ");
            //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            //new Task(SieveEratosthenes_ex2, cancelTokenSource.Token).Start();
            //Console.WriteLine("Введите:");
            //string s = Console.ReadLine();
            //if (s == "Y")
            //    cancelTokenSource.Cancel();

            //Console.WriteLine("efwf:");
            //Console.WriteLine("efwef:");

            /*---------------------------------------------------------------------------------------------------------------*/
            Console.WriteLine("3. ");
            Random rand = new Random();
            Task<int> rand1 = new Task<int>(() => { Thread.Sleep(500); return rand.Next(1, 10) / 1; });
            Task<int> rand2 = new Task<int>(() => { Thread.Sleep(500); return rand.Next(1, 20) / 2; });
            Task<int> rand3 = new Task<int>(() => { Thread.Sleep(500); return rand.Next(1, 30) / 3; });
            rand1.Start(); Console.WriteLine("1: ");
            rand2.Start(); Console.WriteLine("2: ");
            rand3.Start(); Console.WriteLine("3: ");

            int sum(int a, int b, int c) { return a + b + c; }
            Task<int> result = new Task<int>(() => sum(rand1.Result, rand2.Result, rand3.Result));
            result.Start();
            Console.WriteLine("Задание 3: " + result.Result);


            /*Continue With--------------------------------------------------------------------------------------------------*/
            Console.WriteLine("4. ");
            int Sum(int a, int b) => a + b;
            Task<int> task3_1 = new Task<int>(() => Sum(4, 5));
            Task task3_2 = task3_1.ContinueWith(sum => Console.WriteLine($"Сумма: {sum.Result}"));
            task3_1.Start();

            /*GetAwaiter GetResult-------------------------------------------------------------------------------------------*/
            Console.WriteLine("4. Awaiter: ");
            Task<int> what = new Task<int>(() => Sum(4, 5));                                           // получаем объект продолжения 
            var awaiter = what.GetAwaiter();                                            // что делать после окончания предшественника 
            awaiter.OnCompleted(() =>                                                // получаем результат вычислений предшественника 
            {                                            
                int res = awaiter.GetResult();
                Console.WriteLine(res);
            });

            /*Задание 5 -----------------------------------------------------------------------------------------------------*/
            

        }
    }
}
