using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//yield return IEnumerable

namespace Lab12
{
    public static class Reflector
    {
        public static void GetAssemblyInfo(string classname)
        {
            Type classType = Type.GetType(classname, true, true);
            using (StreamWriter file = new StreamWriter("..//..//..//..//AssemblyInfo" + classname + ".txt"))
            {
                file.WriteLine($"Информация о классе {classname}");
                file.WriteLine($"Информация о сборке, в которой определен класс: {classType.Assembly.FullName}");
            }
        }
        public static void GetPublicCtors(string classname)
        {
            Type classType = Type.GetType(classname, true, true);
            using (StreamWriter file = new StreamWriter("..//..//..//..//PublicCtors" + classname + ".txt"))
            {
                if (classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length > 0)
                {
                    file.WriteLine($"Public конструкторы есть");
                    foreach (var ctor in classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
                        file.WriteLine(ctor);
                }

                else file.WriteLine($"Public конструкторов нет");
            }
        }
        //c. извлекает все общедоступные публичные методы класса  (возвращает IEnumerable<string>);
        public static IEnumerable<string> GetPublicMethods(string classname)
        {
            Type classType = Type.GetType(classname, true, true);
            foreach (var method in classType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                yield return method.Name;
        }
        //d. получает информацию о полях и свойствах класса(возвращает IEnumerable<string>);
        public static IEnumerable<string> GetInfoFieldProperty(string classname)
        {
            List<string> outputstrings = new List<string>();
            Type classType = Type.GetType(classname, true, true);

            outputstrings.Add($"Количество полей: {classType.GetFields().Length}");
            foreach (MemberInfo item in classType.GetFields())
                outputstrings.Add(" Name: " + item.Name);

            outputstrings.Add($"Количество свойств: {classType.GetProperties().Length}");
            foreach (MemberInfo item in classType.GetProperties())
                outputstrings.Add(" Name:" + item.Name);

            using (StreamWriter file = new StreamWriter("..//..//..//..//InfoFieldProperty" + classname + ".txt"))
            {
                foreach (var i in outputstrings)
                    file.WriteLine(i);
            }

            return outputstrings;
        }
        //e.получает все реализованные классом интерфейсы (возвращает  IEnumerable<string>);
        public static IEnumerable<string> GetInterface(string classname)
        {
            List<string> outputstrings = new List<string>();
            Type classType = Type.GetType(classname, true, true);

            outputstrings.Add($"Количество: {classType.GetInterfaces().Length}");

            foreach (var item in classType.GetInterfaces())
                outputstrings.Add(item.Name);

            using (StreamWriter file = new StreamWriter("..//..//..//..//Interface.txt" + classname + ".txt"))
            {
                foreach (var i in outputstrings)
                    file.WriteLine(i);
            }

            return outputstrings;
        }
        //f.выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра(имя класса передается в качестве аргумента);
        public static void GetMethodByType(string classname, Type parametertype)
        {
            List<string> outputstrings = new List<string>();
            Type classType = Type.GetType(classname, true, true);

            foreach (var mi in classType.GetMethods())
            {
                foreach (ParameterInfo pi in mi.GetParameters())
                {
                    if (pi.ParameterType == parametertype)
                    {
                        outputstrings.Add(" - " + mi.Name);
                        break;
                    }
                }
            }
          
            using (StreamWriter file = new StreamWriter("..//..//..//..//MethodByType" + classname + ".txt"))
            {
                file.WriteLine("\tВсе методы с типом параметра: " + parametertype);
                foreach (var i in outputstrings)
                    file.WriteLine(i);
            }
        }

        //g. метод Invoke, который вызывает метод класса, при этом значения  для его параметров необходимо 1) прочитать из текстового файла
        //(имя класса и имя метода передаются в качестве аргументов) 2) сгенерировать, используя генератор значений для каждого типа.
        //Параметрами метода Invoke должны быть : объект, имя метода, массив параметров.
        public static void InvokeMethod(string classname, string methodname)
        {
            Type classtype = Type.GetType(classname);

            var a = Activator.CreateInstance(classtype);
            string[] parameters = File.ReadAllLines("..//..//..//..//ParametersForInvokeMethod." + classname + ".txt");
            MethodInfo method = classtype.GetMethod(methodname);

            Console.WriteLine(method.Invoke(a, parameters));

        }

        public static object Create(Type typename)
        {
            return Activator.CreateInstance(typename);
        }
    }
}

