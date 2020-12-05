using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Tiger tiger1 = new Tiger("Тигр", 2005);
            Tiger tiger2 = new Tiger("Ргит", 5002);
            Serialize.BinarySerialization(tiger1, "tiger1");
            Serialize.BinarySerialization(tiger2, "tiger2");

            var tiger3 = Serialize.BinaryDeserialization("tiger1");
            var tiger4 = Serialize.BinaryDeserialization("tiger2");
            Console.WriteLine(tiger3);
            Console.WriteLine(tiger4);

            Serialize.SoapSerialization(tiger1, "tiger1");
            Serialize.SoapSerialization(tiger2, "tiger2");
            var tiger5 = Serialize.SoapDeserialization("tiger1");
            var tiger6 = Serialize.SoapDeserialization("tiger2");
            Console.WriteLine(tiger5);
            Console.WriteLine(tiger6);

            
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
        }
    }
}
