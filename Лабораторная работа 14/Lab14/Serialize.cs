using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lab14
{
    class Serialize
    {
        public static void BinarySerialization(object cl, string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fstream = new FileStream("..//..//..//..//" + filename + ".bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fstream, cl);
            }
        }

        public static object BinaryDeserialization(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fstream = new FileStream("..//..//..//..//" + filename + ".bin", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fstream);
            }
        }

        public static void SoapSerialization(object cl, string filename)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fstream = new FileStream("..//..//..//..//" + filename + ".soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fstream, cl); 
            }
        }

        public static object SoapDeserialization(string filename)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fstream = new FileStream("..//..//..//..//" + filename + ".soap", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fstream);
            }
        }
    }
}
