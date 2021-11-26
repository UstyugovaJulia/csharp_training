using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;


namespace addressbook_test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[3];
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
             if (type == "groups")
             {
                 List<GroupData> groups = new List<GroupData>();
                 for (int i = 0; i < count; i++)
                 {
                     groups.Add(new GroupData(TestBase.GeneratrRandomString(10))
                     {
                         Header = TestBase.GeneratrRandomString(100),
                         Footer = TestBase.GeneratrRandomString(100)

                     });
                 }
                 if (format == "csv")
                 {
                     writeGroupsToCsvFile(groups, writer);
                 }
                 else if (format == "xml")
                 {
                     writeGroupsToXmlFile(groups, writer);
                 }

                 else if (format == "json")
                 {
                     writeGroupsToJsonFile(groups, writer);
                 }

                 else
                 {
                     System.Console.Out.Write("Unrecognize format " + format);
                 }
                 writer.Close();
             }else
            if (type == "contacts")
            {
                //рабочий код
               /* List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {

                    writer.WriteLine(String.Format("${0},${1},${2}",
                        TestBase.GeneratrRandomString(10),
                        TestBase.GeneratrRandomString(10),
                        TestBase.GeneratrRandomString(10)
                        ));
                }
                    //TestBase.GeneratrRandomString(10);
                writer.Close();*/
                
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GeneratrRandomString(10))
                    {
                        Firstname = TestBase.GeneratrRandomString(100),
                        Lastname = TestBase.GeneratrRandomString(100),

                    });
                }
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                 else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                    {
                        writeContactsToJsonFile(contacts, writer);
                    }
                else
                {
                       System.Console.Out.Write("Unrecognize format " + format);
                   }
                writer.Close();
            }

        }

         static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
contact.Firstname, contact.Lastname, contact.Middlename));
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer) 
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
group.Name, group.Header, group.Footer));
            }
        }
        

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
