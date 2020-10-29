using System;
using System.IO;

namespace Lab06
{
    public class WrongWeightException : Exception
    {
        public WrongWeightException(string message) : base(message) { }
    }

    public class ZeroException : Exception
    {
        public ZeroException(string message = "Делить на ноль нельзя!") : base(message)
        {
            this.HelpLink = "https://vk.com/maxicids";
        }
    }

    public class FileExistsException : IOException
    {
        public FileExistsException(string message = "Файла не существует") : base(message)
        {
            this.HelpLink = "https://duckduckgo.com/";
        }
    }
}
