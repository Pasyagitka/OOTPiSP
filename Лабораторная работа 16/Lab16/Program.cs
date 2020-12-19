using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Console.WriteLine("Алгоритм2 занял: " + watch.Elapsed);
            foreach (int a in numbers)
            {
                Thread.Sleep(100);
                Console.WriteLine(a);
            }
        }


        public static void Main(string[] args)
        {
            /* Задание 1 ----------------------------------------------------------------------------------------------------*/
            Console.WriteLine("1. Используя TPL создайте длительную по времени задачу (на основе Task)");
            Action ex1 = new Action(SieveEratosthenes_ex1);
            task1 = Task.Factory.StartNew(ex1);
            task1.Wait(); //приостановить до завершения задач
            task1.Dispose();

            /* Задание 3 ----------------------------------------------------------------------------------------------------*/
            Console.WriteLine("3 Задание. ");
            Random rand = new Random();
            Task<int> task3_1r = new Task<int>(() => { Thread.Sleep(500); return rand.Next(1, 10); });
            Task<int> task3_2r = new Task<int>(() => { Thread.Sleep(500); return rand.Next(1, 20); });
            Task<int> task3_3r = new Task<int>(() => { Thread.Sleep(500); return rand.Next(1, 30); });
            Task<int> task3_r = new Task<int>(() => (task3_1r.Result - task3_2r.Result + task3_3r.Result));
            task3_1r.Start();  Console.WriteLine(task3_1r.Result);
            task3_2r.Start();  Console.WriteLine(task3_2r.Result);
            task3_3r.Start();  Console.WriteLine(task3_3r.Result);
            task3_r.Start(); Console.WriteLine("Задание 3, результат: " + task3_r.Result);

            /*Continue With--------------------------------------------------------------------------------------------------*/
            Console.WriteLine("4 Задание.");
            //После того как задача завершается, отказывает или отменяется, задача task3_2(продолжение) запускается
            Task task3_1 = Task.Run(() => Console.WriteLine("task3_1 "));
            Task task3_2 = task3_1.ContinueWith(x => Console.WriteLine("continue with task3_2"));

            /*GetAwaiter GetResult-------------------------------------------------------------------------------------------*/
            Thread.Sleep(300);
            Console.WriteLine("GetAwaiter GetResult");
            Task<int> what = Task.Run(() => Enumerable.Range(1, 20).Count(n => (n % 2 != 0)));                      // получаем объект продолжения
            var awaiter = what.GetAwaiter();                                                         // что делать после окончания предшественника
            awaiter.OnCompleted(() => { int res = awaiter.GetResult(); Console.WriteLine(res); }); //получаем результат вычислений предшественника 

            /*Задание 5 -----------------------------------------------------------------------------------------------------*/
            Random random = new Random();
            Stopwatch watch = Stopwatch.StartNew();
            const int arrlen = 10000000;
            int[] array51 = new int[arrlen];
            int[] array52 = new int[arrlen];

            Parallel.For(0, arrlen, i =>
            {
                array51[i] = random.Next(0, 50);
                array52[i] = random.Next(0, 50);
            }
            );
            watch.Stop();
            Console.WriteLine("Parralel.For: " + watch.Elapsed); //Parallel.For(int, int, Action<int>) -начальное и конечное зн счетчика

            watch = Stopwatch.StartNew();
            Parallel.ForEach<int>(array51, i =>
            {
                array51[i] = random.Next(0, 50);
                array52[i] = random.Next(0, 50);
            }
            );
            watch.Stop();
            Console.WriteLine("Parallel.ForEach: " + watch.Elapsed); //коллекция, делегат, выполняющийся один раз за итерацию для каждого перебираемого элемента коллекции

            watch = Stopwatch.StartNew();
            for (int i = 0; i < arrlen; i++)
            {
                array51[i] = random.Next(0, 50);
                array52[i] = random.Next(0, 50);
            }
            watch.Stop();
            Console.WriteLine("for: " + watch.Elapsed);

            watch = Stopwatch.StartNew();
            foreach (int i in array51)
            {
                array51[i] = random.Next(0, 50);
                array52[i] = random.Next(0, 50);
            }
            watch.Stop();
            Console.WriteLine("foreach: " + watch.Elapsed);

            /*Задание 6 -----------------------------------------------------------------------------------------------------*/
            //Их можно запустить одновременно,  Вызывающий поток должен дождаться завершения всех рабочих элементов
            Console.WriteLine("6. Используя Parallel.Invoke() распараллельте выполнение блока операторов."); //в одном блоке
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 5; i++)
                    Console.WriteLine("6.1 : " + i);
            },
            () =>
            {
                for (int i = 0; i < 5; i++)
                    Console.WriteLine("6.2 : " + i);
            });
            /*Задание 7 -----------------------------------------------------------------------------------------------------*/
            //BlockingCollection<string> blockingcollection = new BlockingCollection<string>();
            //Task[] producers = new Task[5]
            //{
            //    new Task(() => { while(true){Thread.Sleep(7000); blockingcollection.Add("Холодильник");  Console.WriteLine("+Холодильник"); } }),
            //    new Task(() => { while(true){Thread.Sleep(7000); blockingcollection.Add("Стиральная машина"); Console.WriteLine("+Стиральная машина");} }),
            //    new Task(() => { while(true){Thread.Sleep(8000); blockingcollection.Add("Микроволновая печь"); Console.WriteLine("+Микроволновая печь"); } }),
            //    new Task(() => { while(true){Thread.Sleep(9000); blockingcollection.Add("Миксер"); Console.WriteLine("+Миксер"); } }),
            //    new Task(() => { while(true){Thread.Sleep(9000); blockingcollection.Add("Электрочайник"); Console.WriteLine("+Электрочайник"); } })
            //};
            //Task[] customer = new Task[10]
            //{
            //    new Task(() => { while(true){ Thread.Sleep(200);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(310);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(500);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(400);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(350);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(450);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(150);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(270);   blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(40);    blockingcollection.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(650);   blockingcollection.Take(); } })
            //};

            //foreach (var i in producers)
            //{
            //    Thread.Sleep(800);
            //    if (i.Status != TaskStatus.Running)
            //        i.Start();
            //}

            //int count = 0;
            //while (true)
            //{
            //    string str;
            //    count = blockingcollection.Count;
            //    Thread.Sleep(1000);

            //    if (blockingcollection.TryTake(out str) == true)
            //        Console.WriteLine("Покупатель купил: " + str);
            //    else Console.WriteLine("Покупатель ушел");
            //}

            /*Задание 8 -----------------------------------------------------------------------------------------------------*/
            FactorialAsync();

            /* Задание 2 ----------------------------------------------------------------------------------------------------*/
            Thread.Sleep(1000);
            Console.WriteLine("2 Задание. ");
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            Task task2 = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= 10; i++)
                {
                    if (cancelTokenSource.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    result *= i;
                    Console.WriteLine($"Факториал числа равен {result}");
                    Thread.Sleep(1000);
                }
            });
            task2.Start();
            Console.WriteLine("Нажмите клавишу для отмены операции:");
            string s = Console.ReadLine();
            if (s == "O")
                cancelTokenSource.Cancel();
        }
        static async void FactorialAsync() // определение асинхронного метода
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }
        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 5; i++)
            {
                result *= i;
            }
            Thread.Sleep(500);
            Console.WriteLine("Факториал равен: " + result);
        }
    }
}
