using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab12
{
    public static class Reflector
    {
        public static void GetAssemblyInfo(string classname)
        {
            Type classType = Type.GetType(classname, true, true);
            using (StreamWriter file = new StreamWriter("..//..//..//AssemblyInfo.txt"))
            {
                file.WriteLine($"Информация о классе {classname}");
                file.WriteLine($"Информация о сборке, в которой определен класс: {classType.Assembly.FullName}");
            }
        }
        public static void GetPublicCtors(string classname)
        {
            Type classType = Type.GetType(classname, true, true);
            using (StreamWriter file = new StreamWriter("..//..//..//PublicCtors.txt"))
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
        public static IEnumerable<string> GetPublicMethods(string classname)
        {
            List<string> outputstrings = new List<string>();
            Type classType = Type.GetType(classname, true, true);

            foreach (var method in classType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                outputstrings.Add(method.Name);

            return outputstrings;
        }
        //d. получает информацию о полях и свойствах класса(возвращает IEnumerable<string>);
        public static IEnumerable<string> GetInfoFieldProperty(string classname)
        {
            List<string> outputstrings = new List<string>();
            Type classType = Type.GetType(classname, true, true);

            outputstrings.Add("\tПоля");
            outputstrings.Add($"Количество: {classType.GetFields().Length}");
            foreach (MemberInfo item in classType.GetFields())
                outputstrings.Add("Type:" + item.MemberType + " Name: " + item.Name);

            outputstrings.Add("\tСвойства");
            outputstrings.Add($"Количество: {classType.GetProperties().Length}");
            foreach (MemberInfo item in classType.GetProperties())
                outputstrings.Add("Type:" + item.MemberType + " Name:" + item.Name);

            using (StreamWriter file = new StreamWriter("..//..//..//InfoFieldProperty.txt"))
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

            outputstrings.Add("\tИнтерфейсы");
            outputstrings.Add($"Количество: {classType.GetInterfaces().Length}");

            foreach (var item in classType.GetInterfaces())
                outputstrings.Add("Type:" + item.MemberType + " Name:" + item.Name);

            using (StreamWriter file = new StreamWriter("..//..//..//Interface.txt"))
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

            var result = parametertype.GetMethods().Where(a => a.GetParameters().Where(t => t.ParameterType == parametertype).Count() != 0);
            outputstrings.Add($"\tВсе методы с типом параметра {parametertype.Name}: ");

            foreach (MethodInfo item in result)
                outputstrings.Add(item.Name);
            using (StreamWriter file = new StreamWriter("..//..//..//MethodByType.txt"))
            {
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
            string[] parameters = File.ReadAllLines(@"..//..//..//ParametersForInvokeMethod.txt");
            MethodInfo method = classtype.GetMethod(methodname);

            Console.WriteLine(method.Invoke(a, parameters));

        }
    }
}

