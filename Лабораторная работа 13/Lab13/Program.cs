using System;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            ZEILog Log = new ZEILog();
            ZEIDiskInfo d1 = new ZEIDiskInfo();
            try
            {
                d1.DiskInfo(Log);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Ошибка! " + e.Message);
            }


            ZEIFileInfo file = new ZEIFileInfo();
            try
            {
                file.FileInfo(Log);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка! " + e.Message);
            }


            ZEIDirInfo dir = new ZEIDirInfo();
            dir.DirInfo(Log);

            try
            {
                ZEIFileManager.FileManager(Log, @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13");
                ZEIFileManager.CreateZIP(Log, @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13\ZEIInspect", @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13\ZEIFROMZIP");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка! " + e.Message);
            }

            Log.ReadFromLog();
            Log.FindInLog("ZEIFiles");
            Log.FindInLog("6.08.2020");
            Console.WriteLine("Количество записей в логе: " + Log.CountLog());
            //Log.DeleteInfo();
        }
    }
}
