using System;
using System.IO;
using Lab07;

namespace Lab06
{
    internal class Program
    {
        private static void Main(string[] args)
        {
                Logger.ConsoleLogger ConsLog = new Logger.ConsoleLogger();
                Logger.FileLogger FileLog = new Logger.FileLogger();
                if (FileLog.OpenLogFile())
                    FileLog.GetLog("Создан файл протокола", Logger.RecordTypes.Information);

                Animal crocodile1 = new Crocodile("crocodile", 2026);
                Console.WriteLine(crocodile1); crocodile1.Move();

                Lion lion1 = new Lion("lion", 2010);
                Console.WriteLine(lion1); lion1.Move();
                Tiger tiger1 = new Tiger("tiger", 2001);
                Console.WriteLine(tiger1); tiger1.Move();

                Shark shark1 = new Shark("shark", 2014);
                Console.WriteLine(shark1); shark1.Move();
                ((IVitalActivity)shark1).Eat();
                shark1.VitalActivity();
                ((IVitalActivity)shark1).VitalActivity();

                Owl owl1 = new Owl("owl", 2003);
                owl1.Move();
                Console.WriteLine(owl1);
                Parrot parrot1 = new Parrot("parrot", 2020);
                parrot1.Move();
                Console.WriteLine(parrot1);

                Console.WriteLine("-----------------Массив-----------------");
                Printer a = new Printer();
                Animal[] animals = new Animal[6] { crocodile1, lion1, tiger1, shark1, owl1, parrot1 };
                for (int i = 0; i < animals.Length; i++)
                {
                    a.iAmPrinting(animals[i]);
                }

                Zoo zoo = new Zoo();
                zoo.AddToZoo(crocodile1);
                zoo.AddToZoo(lion1);
                zoo.AddToZoo(tiger1);
                zoo.AddToZoo(shark1);
                zoo.AddToZoo(owl1);
                zoo.AddToZoo(parrot1);
                zoo.ShowZoo();
                Controller.AverageWeight(zoo, "lion");
                Console.WriteLine("Количество хищных птиц в зоопарке: {0} ", Controller.PredatoryBirds(zoo));
                Controller.SortByYear(zoo);

            //Owl owl2 = new Owl("owl", 2003, -3); //Assert
            //специальная конструкция, позволяющая проверять предположения о значениях произвольных данных в произвольном месте программы. 
            //Эта конструкция может автоматически сигнализировать при обнаружении некорректных данных, что обычно приводит к
            //аварийному завершению программы с указанием места обнаружения некорректных данных.
            try
            {
                ConsLog.GetLog("Из файла-------------------------------------------", Logger.RecordTypes.Message);
                Zoo zoo1 = new Zoo();
                Controller.FillFromFile(zoo1);
                zoo1.ShowZoo();

                Lion lion2 = new Lion("lion", 2017, -7); 
            }            
            catch (WrongWeightException e)
            {
                //сюда Console
                Console.WriteLine(e);
                FileLog.GetLog(e);
                ConsLog.GetLog("-----------------------------WrongWeightException: ", Logger.RecordTypes.Exception);
            }
            try
            {
                FileStream newFile = new FileStream("aaa.txt", FileMode.Open); 
            }
            catch (IOException)
            {
                ConsLog.GetLog("-----------------------------IOException: Не удалось открыть файл", Logger.RecordTypes.Exception);
                FileLog.GetLog("IOException: Не удалось открыть файл", Logger.RecordTypes.Exception);
            }
            try  
            {
                Zoo zoo1 = new Zoo();
                Controller.AverageWeight(zoo);
            }
            catch (ZeroException e)
            {
                //сюда Console
                Console.WriteLine(e);
                FileLog.GetLog(e);
                // throw; снова будет исключение, уже необработанное 
            }
            try
            {
                throw new FileExistsException();
            }
            catch (FileExistsException e)
            {
                ConsLog.GetLog(e);
                FileLog.GetLog(e);
                ConsLog.GetLog("Информация", Logger.RecordTypes.Information);
                FileLog.GetLog("Сообщение....", Logger.RecordTypes.Message);
                Console.WriteLine(e);
            }
            try
            {
                Byte bbb = 99;
                bbb = checked((byte)(bbb + 9999999));
                ConsLog.GetLog("\nВызов неопознанного исключения", Logger.RecordTypes.Exception);
                FileLog.GetLog("\nВызов неопознанного исключения", Logger.RecordTypes.Exception);
                throw new Exception();
            }
            catch (Exception e) when (e.GetType() != typeof(System.OverflowException))
            {
                ConsLog.GetLog("Вызван общий обработчик исключений (кроме OverflowException)", Logger.RecordTypes.Exception);
                FileLog.GetLog("Вызван общий обработчик исключений(кроме OverflowException)", Logger.RecordTypes.Exception);
            }
            catch
            {
                ConsLog.GetLog("Вызван универсальный обработчик исключений", Logger.RecordTypes.Exception);
                FileLog.GetLog("Вызван универсальный обработчик исключений", Logger.RecordTypes.Exception);
            }
            finally
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("КОНЕЦ");
                Console.WriteLine("Finally выполняется всегда, кроме StackOverFlowException, System.Exit(0)");

                FileLog.GetLog("Файл протокола закрывается...", Logger.RecordTypes.Information);
                FileLog.CloseLogFile();
            }
        }
    }
}
