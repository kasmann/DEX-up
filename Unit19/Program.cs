using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Unit19
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var element = new ListElement<int>(10);
            var list = new DoubleLinkList<int>();
            list.Add(10);
            list.Add(15);
            list.Add(20);
            list.Add(25);
            list.Add(30);
            list.Add(35);

            //создание циклической ссылки в экземпляре объекта
            element.Previous = element;
            element.Next = element;
            
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //сериализация объекта, содержащего циклическую ссылку
            using (FileStream fs = new FileStream("element.txt", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, element); //без ошибок
            }
            using (FileStream fs = new FileStream("element.txt", FileMode.Open))
            {
                var newElement = binaryFormatter.Deserialize(fs) as ListElement<int>;
                //корректная десериализация
                Console.WriteLine("\\\\-------------------------------------\nBinary deserialization\n");
                Console.WriteLine(newElement.Value);
                Console.WriteLine(newElement.Next.Value);
                Console.WriteLine();
            }
            
            
            using (FileStream fs = new FileStream("doublelinked_list.txt", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, list);
            }
            using (FileStream fs = new FileStream("doublelinked_list.txt", FileMode.Open))
            {
                var newList = binaryFormatter.Deserialize(fs) as DoubleLinkList<int>;
                Console.WriteLine("\\\\-------------------------------------\nBinary deserialization\n");
                foreach (var elem in newList.BackwardEnumerator())
                {
                    Console.WriteLine(elem);
                }
                Console.WriteLine();
            }
            
            
            XmlSerializer elementXmlSerializer = new XmlSerializer(element.GetType());//          
//          using (FileStream fs = new FileStream("element.xml", FileMode.OpenOrCreate))
//          {
//              elementXmlSerializer.Serialize(fs, element); //ошибка, циклическая ссылка
//          }

            XmlSerializer listXmlSerializer = new XmlSerializer(list.GetType());
            using (FileStream fs = new FileStream("doublelinked_list.xml", FileMode.OpenOrCreate))
            {
                listXmlSerializer.Serialize(fs, list);
            }
            using (FileStream fs = new FileStream("doublelinked_list.xml", FileMode.Open))
            {
                var newList = listXmlSerializer.Deserialize(fs) as DoubleLinkList<int>;
                Console.WriteLine("\\\\-------------------------------------\nXML deserialization\n");
                foreach (var elem in newList.BackwardEnumerator())
                {
                    Console.WriteLine(elem);
                }
                Console.WriteLine();
            }

            //string jsonElement = JsonConvert.SerializeObject(element); //ошибка - циклическая ссылка
            //Console.WriteLine(jsonElement);

            //var jsonList = JsonConvert.SerializeObject(list); //StackOverFlow Exception
            //Console.WriteLine(jsonList);
            
            var jsonException = JsonConvert.SerializeObject(new NotFoundException("not found"), Formatting.Indented);
            Console.WriteLine(jsonException);
            
            var newException = JsonConvert.DeserializeObject<NotFoundException>(jsonException);
            Console.WriteLine(newException.Message);
        }
    }
}