using System;
using System.IO;

namespace Lab06
{
    public class WrongWeightException : Exception
    {
        public WrongWeightException(string message) : base(message) { }
        public override string ToString()
        {
            return "-----------------------------WrongWeightException: " + this.Message + ", метод вызвавший исключение: " + this.TargetSite;
        }
    }

    public class ZeroException : Exception
    {
        public ZeroException(string message = "Делить на ноль нельзя!") : base(message)
        {
            this.HelpLink = "https://github.com/pasyagitka";
        }
        public override string ToString()
        {
            return "ZeroException: " + this.Message + ", метод вызвавший исключение: " + this.TargetSite + ", helplink: " + this.HelpLink;
        }
    }

    public class FileExistsException : IOException
    {
        public FileExistsException(string message = "Файла не существует") : base(message)
        {
            this.HelpLink = "https://duckduckgo.com/";
        }
        public override string ToString()
        {
            return "-----------------------------FileExistsException: " + this.Message + ", метод вызвавший исключение: " + this.TargetSite + ", имена и сигнатуры методов, вызов которых стал источником исключения: " + this.StackTrace + ", helplink: " + this.HelpLink;
        }
    }
}
