using System;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class ZEIFileManager 
    {
        public static void FileManager(ZEILog log, string path)
        {
            //Прочитать список файлов и папок заданного диска.
            log.WriteAction("Вызван метод ListOfFilesAndDirs класса ZEIFileManager");
            DirectoryInfo dir = new DirectoryInfo(path);
            Console.WriteLine("\nСписок папок заданного диска: ");
            log.WriteAction("\nСписок папок заданного диска: ");

            foreach (var item in dir.GetDirectories())
            {
                Console.WriteLine(item.Name);
                log.WriteAction(item.Name);
            }
            Console.WriteLine("Список файлов заданного диска: ");
            log.WriteAction("\nСписок файлов заданного диска: ");

            foreach (var item in dir.GetFiles())
            {
                Console.WriteLine(item.Name);
                log.WriteAction(item.Name);
            }
            //Создать директорий ZEIInspect
            DirectoryInfo directory = new DirectoryInfo(@"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13");
            directory.CreateSubdirectory("ZEIInspect");
            if (!directory.Exists) directory.Create();

            //создать текстовый файл xxxdirinfo.txt и сохранить туда информацию.
            FileInfo file = new FileInfo("..//..//..//..//ZEIdirinfo.txt");
            using (StreamWriter fs = new StreamWriter(file.FullName))
            {
                fs.Write("Информация");
            }
            // Создать копию файла и переименовать его. Удалить первоначальный файл
            File.Copy("..//..//..//..//ZEIdirinfo.txt", "..//..//..//..//ZEIdirinfoCOPY.txt", true); //перезаписывание, избежать исключения существующего файла
            file.Delete();

            //Создать директорий ZEIFiles. Скопировать в него все файлы с заданным расширением из заданного пользователем директория.
            DirectoryInfo directory2 = new DirectoryInfo(@"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13");
            directory.CreateSubdirectory("ZEIFiles");
            if (!directory.Exists) directory.Create();
            var filetxt = Directory.GetFiles(@"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13", "*.txt");
            foreach (string f in filetxt)
            {
                string fName = Path.GetFileName(f);
               // string fName = f.Substring(@"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13".Length + 1);
                File.Copy(f, Path.Combine(@"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13\ZEIFiles", fName), true); // перезаписать
            }
            //переместить ZEIFiles в ZEIInspect
            string sourcedirectorypath = @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13\ZEIFiles";
            string destdirectorypath = @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13\ZEIInspect\ZEIFiles";
            if (sourcedirectorypath == destdirectorypath)
                throw new Exception("Пути совпадают");
            DirectoryInfo destdirectory = new DirectoryInfo(destdirectorypath);
            if (!destdirectory.Exists)
            {
                Directory.Move(sourcedirectorypath, destdirectorypath);
            }
        }

        public static  void CreateZIP(ZEILog log, string dir1, string dir2)
        {
            //Сделайте архив из файлов директория XXXFiles.
            log.WriteAction("Вызван метод CreateZIP класса ZEIFileManager");
            string zipName = @"G:\3 семестр\ООТПиСП лабораторные\Лабораторная работа 13\ZEIFiles.zip";
            if (new DirectoryInfo("..//..//..//..//..//Лабораторная работа 13").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(dir1, zipName);
            }
            //Разархивируйте его в другой директорий
            DirectoryInfo ddir2 = new DirectoryInfo(dir2);
            if (!ddir2.Exists)
                ZipFile.ExtractToDirectory(zipName, dir2);
        }
    }
}



