using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab13
{
    public class ZEILog
    {
        string path = "..//..//..//../ZEILog.txt";
       
        public ZEILog()
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("Лог создан : " + DateTime.Now);
            }

        }
        public void WriteAction(string action = "")
        {
            if (action == "")
                throw new Exception("Неверное действие");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(DateTime.Now + " : " + action);
            }
        }
        public void ReadFromLog()
        {
            Console.WriteLine("\nЧтение из файла ZEILog");
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
        }
        public void FindInLog(string item)
        {
            Console.WriteLine("Поиск в логе:  " + item);
            new List<string>(File.ReadAllLines(path)).Where(l => l.Contains(item)).ToList().ForEach(Console.WriteLine);
        }
        public int CountLog()
        {
            return File.ReadAllLines(path).ToList().Count;
        }
        public void DeleteInfo()
        {
            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveRange(5, 10);
            File.WriteAllLines(path, lines);
        }
    }
}
