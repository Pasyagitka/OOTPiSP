using System;
using System.IO;

namespace Lab13
{
    public class ZEIDiskInfo
    {
        public void DiskInfo(ZEILog log)
        {
            log.WriteAction("Вызван метод DiskInfo класса ZEIDiskInfo");
            var allDrives = DriveInfo.GetDrives();
            foreach (var d in allDrives)
            {
                Console.WriteLine("Диск: {0}, метка тома: {5}, свободное место: {1}, объем {2}, доступный объем: {3}, файловая система: {4}",
                    d.Name, d.AvailableFreeSpace, d.TotalSize, d.TotalFreeSpace, d.DriveFormat, d.VolumeLabel);
                log.WriteAction($"Диск: {d.Name}  метка тома: {d.VolumeLabel}, свободное место: {d.AvailableFreeSpace}, объем { d.TotalSize}, доступный объем: {d.TotalFreeSpace}, файловая система: {d.DriveFormat}"); 
            }
        }
    }
    public class ZEIFileInfo
    {
        public void FileInfo(ZEILog log, string filepath = "..//..//..//ZEI.cs")
        {
            log.WriteAction("Вызван метод FileInfo класса ZEIFileInfo");
            FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь к файлу: {fileInfo.FullName}, \n" +
                    $"размер: {fileInfo.Length} байт, расширение: {fileInfo.Extension}, имя: {fileInfo.Name}, время создания: {fileInfo.CreationTime}, " +
                    $"последнее изменение: {fileInfo.LastWriteTime}");
                log.WriteAction($"Полный путь к файлу: {fileInfo.FullName}, \n" +
                    $"размер: {fileInfo.Length} байт, расширение: {fileInfo.Extension}, имя: {fileInfo.Name}, время создания: {fileInfo.CreationTime}, " +
                    $"последнее изменение: {fileInfo.LastWriteTime}");
            }
            else throw new Exception("Файла не существует");
        }
    }
    public class ZEIDirInfo
    {
        public void DirInfo(ZEILog log, string dirname = @"G:\3 семестр\ООТПиСП лабораторные")
        {
            log.WriteAction("Вызван метод DirInfo класса ZEIDirInfo");
            DirectoryInfo dirInfo = new DirectoryInfo(dirname);
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}, количество файлов: {dirInfo.GetFiles().Length}, " +
                $"количество поддиректориев: {dirInfo.GetDirectories().Length}, родительский директорий: {dirInfo.Parent}");
            log.WriteAction($"Время создания каталога: {dirInfo.CreationTime}, количество файлов: {dirInfo.GetFiles().Length}, " +
                $"количество поддиректориев: {dirInfo.GetDirectories().Length}, родительский директорий: {dirInfo.Parent}");
        }
    }
}
