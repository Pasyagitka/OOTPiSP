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
        static Mutex mut = new Mutex();

        public static void Even(object n) //четные
        {
            x = 2;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " = " + i);
                using (StreamWriter sw = new StreamWriter("../../../ex4numbers.txt", true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + "  = " + i);
                }
                Thread.Sleep(1000);
            }
        }
        public static void Odd(object n) //нечетные
        {
            x = 1;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " = " + i);
                using (StreamWriter sw = new StreamWriter("../../../ex4numbers.txt", true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " = " + i);
                }
                Thread.Sleep(1000);
            }
        }
        public static void Even_2(object n)
        {
            mut.WaitOne();
            x = 2;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " = " + i);
                using (StreamWriter sw = new StreamWriter("../../../ex4numbers2.txt", true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " = " + i);
                }
                Thread.Sleep(1000);
            }
            mut.ReleaseMutex();
        }
        public static void Odd_2(object n)
        {
            mut.WaitOne();
            x = 1;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + "  = " + i);
                using (StreamWriter sw = new StreamWriter("../../../ex4numbers2.txt", true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " = " + i);
                }
                Thread.Sleep(1000);
            }
            mut.ReleaseMutex();
        }
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


            Console.WriteLine("Задание 4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и записывают их в общий файл и на консоль.");
            Thread mythread4E = new Thread(new ParameterizedThreadStart(Even));
            mythread4E.Name = "Ex4_Even";
            
            Thread mythread4O = new Thread(new ParameterizedThreadStart(Odd));
            mythread4O.Name = "Ex4_Odd";

            //mythread4O.Start(n);
            //Thread.Sleep(500);
            //mythread4E.Start(n);


            Thread mythread4E2 = new Thread(new ParameterizedThreadStart(Even_2));
            mythread4E2.Name = "Ex4_Even2";

            Thread mythread4O2 = new Thread(new ParameterizedThreadStart(Odd_2));
            mythread4O2.Name = "Ex4_Odd2";

            //Thread.Sleep(10000);
            //mythread4O2.Start(n);
            //mythread4E2.Start(n);

            //Thread.Sleep(1000);
            int num = 0;         // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);       // создаем таймер
            Timer timer = new Timer(tm, num, 0, 2000);//num null
            Console.ReadLine();
        }

        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 5; i++, x++)
            {
                Console.WriteLine($"{x}");
            }
        }
    }
}

