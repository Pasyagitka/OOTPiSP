using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Tiger tiger1 = new Tiger("Тигр", 2005);
            Tiger tiger2 = new Tiger("Ргит", 5002);

            Console.WriteLine("\tТигр, Binary:");
            Serialize.BinarySerialization(tiger1, "tiger1");
            Serialize.BinarySerialization(tiger2, "tiger2");
            var tiger3 = Serialize.BinaryDeserialization("tiger1");
            var tiger4 = Serialize.BinaryDeserialization("tiger2");
            Console.WriteLine(tiger3);
            Console.WriteLine(tiger4);

            Console.WriteLine("\tТигр, SOAP:");
            Serialize.SoapSerialization(tiger1, "tiger1");
            Serialize.SoapSerialization(tiger2, "tiger2");
            var tiger5 = Serialize.SoapDeserialization("tiger1");
            var tiger6 = Serialize.SoapDeserialization("tiger2");
            Console.WriteLine(tiger5);
            Console.WriteLine(tiger6);

            Console.WriteLine("\tТигр, XML:");
            XmlSerializer xSer = new XmlSerializer(tiger1.GetType());
            using (FileStream fstream = new FileStream("..//..//..//..//Tiger1.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fstream, tiger1);
            }
            using (FileStream fs = new FileStream("..//..//..//..//Tiger1.xml", FileMode.OpenOrCreate))
            {
                Tiger newP = xSer.Deserialize(fs) as Tiger;
                Console.WriteLine(newP.ToString());
            }

            Console.WriteLine("\tТигр, JSON:");
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Tiger));
            using (FileStream fs = new FileStream("..//..//..//..//Tiger1.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, tiger1);
            }
            using (FileStream fs = new FileStream("..//..//..//..//Tiger1.json", FileMode.OpenOrCreate))
            {
                Tiger newtiger = (Tiger)jsonFormatter.ReadObject(fs);
                Console.WriteLine(newtiger.ToString());
            }

            Console.WriteLine("\tСписок тигров, XML:");
            List<Tiger> tigers = new List<Tiger>();
            tigers.Add(tiger1);
            tigers.Add(tiger2);
            var xmlFormatter = new XmlSerializer(typeof(List<Tiger>));
            using (FileStream fs = new FileStream("..//..//..//..//Tigers.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, tigers);
            }
            using (FileStream file = new FileStream("..//..//..//..//Tigers.xml", FileMode.OpenOrCreate))
            {
                var detigers = xmlFormatter.Deserialize(file) as List<Tiger>;
                if (detigers != null)
                {
                    foreach (var tiger in detigers)
                        Console.WriteLine(tiger);
                }
            }
            Console.WriteLine("\tСписок тигров, JSON:");
            DataContractJsonSerializer jsonFormatter2 = new DataContractJsonSerializer(typeof(List<Tiger>));
            using (var fs = new FileStream("..//..//..//..//Tigers.json", FileMode.OpenOrCreate))
            {
                jsonFormatter2.WriteObject(fs, tigers);
            }
            using (var file = new FileStream("..//..//..//..//Tigers.json", FileMode.OpenOrCreate))
            {
                var detigers = jsonFormatter2.ReadObject(file) as List<Tiger>;
                if (detigers != null)
                {
                    foreach (var tiger in detigers)
                        Console.WriteLine(tiger);
                }
            }


            Console.WriteLine("\tИспользуя XPath напишите два селектора для вашего XML документа");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("..//..//..//..//Tigers.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode childnode = xRoot.SelectSingleNode("Tiger[name='Ргит']");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);

            XmlNodeList childnode2 = xRoot.SelectNodes("//Tiger/dateOfBirth");
            foreach (XmlNode n in childnode2)
                Console.WriteLine(n.InnerText);


            Console.WriteLine("Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - документ и напишите несколько запросов");
            XDocument xdoc = new XDocument(new XElement("Animals",
            new XElement("TIGER",
                new XAttribute("n", "ТИГР"),
                new XElement("name", "Игорь"),
                new XElement("color", "ОРАНЖЕВЫЙ"),
                new XElement("age", "43")),
            new XElement("LION",
                new XAttribute("n", "ТИГР"),
                new XElement("name", "Златик"),
                new XElement("color", "ЖЕЛТЫЙ"),
                new XElement("age", "6")),
            new XElement("LION",
                new XAttribute("n", "ЛЕВ"),
                new XElement("name", "Олег"),
                new XElement("color", "БЕЛЫЙ"),
                new XElement("age", "10"))));
                    xdoc.Save("..//..//..//..//LTXTigerLion.xml");

            IEnumerable<XElement> elements = xdoc.Descendants("LION").Where(e => ((string)e.Element("name")) == "Златик");
            foreach (var e in elements)
                Console.WriteLine(e);
            IEnumerable<XElement> elements2 = xdoc.Descendants("LION").Where(e => ((string)e.Element("age")) != "6");
                foreach (var e in elements2)
                    Console.WriteLine(e);
 
        }
    }
}
