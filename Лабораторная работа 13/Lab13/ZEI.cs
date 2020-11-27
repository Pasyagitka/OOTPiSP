using System;
using System.IO;

namespace Lab13
{
    public class ZEIDiskInfo
    {
        public void DiskInfo()
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var d in allDrives)
            {
                Console.WriteLine("Диск: {0}, метка тома: {5}, свободное место: {1}, объем {2}, доступный объем: {3}, файловая система: {4}",
                    d.Name, d.AvailableFreeSpace, d.TotalSize, d.TotalFreeSpace, d.DriveFormat, d.VolumeLabel);
            }
        }
    }
    public class ZEIFileInfo
    {
        public void FileInfo(string filepath = "..//..//..//ZEI.cs")
        {
            FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь к файлу: {fileInfo.FullName}, \n" +
                    $"размер: {fileInfo.Length} байт, расширение: {fileInfo.Extension}, имя: {fileInfo.Name}, время создания: {fileInfo.CreationTime}, " +
                    $"последнее изменение: {fileInfo.LastWriteTime}");
            }
        }
    }
    public class ZEIDirInfo
    {
        public void DirInfo(string dirname = @"G:\3 семестр\ООТПиСП лабораторные")
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirname);
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}, количество файлов: {dirInfo.GetFiles().Length}, " +
                $"количество поддиректориев: {dirInfo.GetDirectories().Length}, родительский директорий: {dirInfo.Parent}");
        }
    }
}
