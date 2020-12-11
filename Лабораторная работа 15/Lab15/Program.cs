using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Lab15
{
    class Program
    {
        public static int x;

        public static void Even(object n)
        {
            x = 2;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                using (StreamWriter sw = new StreamWriter("../../../ex4numbers.txt", true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                }
                Thread.Sleep(1000);
            }
        }
        //public static bool IsOdd(int a)
        //{
        //    return (a % 2) != 0;
        //}
        public static bool IsPrimeNumber(int n)
        {
            var result = true;
            if (n >= 1)
            {
                for (var i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static void Numbers(object n)
        {
            Console.WriteLine($"Имя потока {Thread.CurrentThread.Name}, приоритет потока {Thread.CurrentThread.Priority}, Id потока {Thread.CurrentThread.ManagedThreadId}, Статус потока: {Thread.CurrentThread.ThreadState}");
            using (StreamWriter fout = new StreamWriter("../../../ex3numbers.txt"))
            {
                Console.WriteLine("Простые числа от 1 до {0}", n);
                for (int i = 0; i < (int)n; i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        Console.WriteLine("\t" + i.ToString());
                        fout.WriteLine("\t" + i.ToString());
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Все запущенные процессы: ");
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine($"{process.Id}, {process.ProcessName}, {process.BasePriority}, {process.StartTime}, {process.TotalProcessorTime}.");
                }
                catch (Exception e) { }
            }
            Console.WriteLine("Исследование доменов: ");
            AppDomain currentdomain = AppDomain.CurrentDomain;
            Console.WriteLine($"{currentdomain.FriendlyName}, {currentdomain.SetupInformation.ApplicationBase}, {currentdomain.SetupInformation.TargetFrameworkName}.\n");
            Console.WriteLine("Все сборки, загруженные в домен: ");
            Assembly[] asm = currentdomain.GetAssemblies();
            foreach (Assembly a in asm)
            {
                Console.WriteLine(a.GetName().Name);
            }

            try
            {
                AppDomain newdomain = AppDomain.CreateDomain("NEWDOMAIN");
                newdomain.Load(asm[5].GetName());
                AppDomain.Unload(newdomain);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //Secondary AppDomains are not supported on this platform
            }

            Console.WriteLine("Задание 3");
            var n = Convert.ToInt32(Console.ReadLine());
            Thread mythread = new Thread(new ParameterizedThreadStart(Numbers));
            mythread.Name = "Ex3";
            mythread.Priority = ThreadPriority.Highest;
            mythread.Start(n);


            Console.WriteLine("Создайте два потока. Первый выводит четные числа, второй нечетные до n и записывают их в общий файл и на консоль.");
            


        }
    }
}

