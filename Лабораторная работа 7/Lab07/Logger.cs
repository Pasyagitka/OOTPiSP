using System;
using System.IO;

namespace Lab07
{
    public abstract class Logger 
    {
        public enum RecordTypes { Exception, Information, Message };

        public class FileLogger : Logger
        {
            StreamWriter sw;
            string FilePath = "../../../log.txt";
            public bool OpenLogFile()
            {
                sw = new StreamWriter(FilePath, false, System.Text.Encoding.Default);
                if (sw != null)    
                    return true;
                return false;
            }
            public void CloseLogFile()
            {
                sw.Close();
            }
            public void GetLog(Exception e, RecordTypes recordtype = RecordTypes.Exception)
            {
                sw.WriteLine(DateTime.Now + ", " + recordtype + ": " + e.Message);
            }
            public void GetLog(string warningofonfomessage, RecordTypes recordtype)
            {
               sw.WriteLine(DateTime.Now + ", " + recordtype + ": " + warningofonfomessage);
            }
        }

        public class ConsoleLogger : Logger
        {
            public void GetLog(Exception e, RecordTypes recordtype = RecordTypes.Exception)
            {
                Console.WriteLine(DateTime.Now + ", " + recordtype + ": " + e.Message);
            }
            public void GetLog(string warningofonfomessage, RecordTypes recordtype)
            { 
                Console.WriteLine(DateTime.Now + ", " + recordtype + ": " + warningofonfomessage);
            }
        }
    }
}
