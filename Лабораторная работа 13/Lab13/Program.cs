using System;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            ZEIDiskInfo d1 = new ZEIDiskInfo();
            try
            {
                d1.DiskInfo();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Ошибка! " + e.Message);
            }


            ZEIFileInfo file = new ZEIFileInfo();
            file.FileInfo();

            ZEIDirInfo dir = new ZEIDirInfo();
            dir.DirInfo();
        }
    }
}
