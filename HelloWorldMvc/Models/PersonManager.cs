using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace HelloWorldMvc.Models
{
    public class PersonManager
    {

        public static string DefaultFileName = "PersonManager";
              
        public static List<Person> DefaultPersonList { get; protected set; } = new List<Person>()
        {
            new Person(1, "Didier", "Responsable de formation"),
            new Person(2, "Sophie", "Formatrice"),
            new Person(3, "Franck", "Formateur"),
            new Person(4, "Mickaël", "Formateur"),
        };


        #region Properties

        string fileName;

        public string BinPath { get; protected set; }

        public string XmlPath { get; protected set; }

        public bool BinExists { get; protected set; }

        public bool XmlExists { get; protected set; }

        public List<Person> PersonList { get; protected set; }

        #endregion

        #region Constructors

        public PersonManager() : this(DefaultFileName)
        {
            
        }

        public PersonManager(string _file)
        {
            if(String.IsNullOrEmpty(_file))
            {
                _file = DefaultFileName;
            }

            _file = Path.Combine("App_Data", _file);

            if (HttpContext.Current != null)
            {
                fileName = HttpContext.Current.Server.MapPath(_file);
            }
            else
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tedi", _file);
            }

            BinPath = Path.Combine("App_Data", fileName + ".bin");
            XmlPath = Path.Combine("App_Data", fileName + ".xml");

            BinExists = File.Exists(BinPath);
            XmlExists = File.Exists(XmlPath);

            PersonList = DefaultPersonList;
        }

        #endregion

        #region Search

        public Person Search(int id)
        {
            Person member = PersonList.FirstOrDefault(item => item.Id == id);

            return (member != default(Person)) ? member : new Person();
        }

        public Person Search(string name)
        {
            Person member = PersonList.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());

            return (member != default(Person)) ? member : new Person();
        }

        public Person Search(Person p)
        {
            return Search(p.Id);
        }

        public List<Person> SearchJob(string job)
        {
            return PersonList.FindAll(item => item.Job.ToLower() == job.ToLower());
        }

        #endregion

        #region Binary Serialization

        public void Save()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(BinPath, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, PersonList);
                stream.Close();
                SaveXml();
            }
            catch
            {

            }
            
        }

        public void Load()
        {
            try
            {
                if(BinExists)
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(BinPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    List<Person> loaded = formatter.Deserialize(stream) as List<Person>;
                    stream.Close();
                    if(loaded != null)
                    {
                        PersonList = loaded;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region XML Serialization

        public void SaveXml()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

                using (StreamWriter writer = new StreamWriter(XmlPath))
                {
                    serializer.Serialize(writer, PersonList);
                }
            }
            catch
            {

            }
            
        }

        public void LoadXml()
        {
            try
            {
                if(XmlExists)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

                    using (StreamReader reader = new StreamReader(XmlPath))
                    {
                        List<Person> loaded = serializer.Deserialize(reader) as List<Person>;

                        if (loaded != null)
                        {
                            PersonList = loaded;
                        }
                    }
                }
                
            }
            catch
            {

            }
        }

        #endregion

    }
}