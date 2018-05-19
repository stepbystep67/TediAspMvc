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
    public class PersonManager_old
    {
        
        public static string teamMembersBin = "App_Data/PersonManager.bin";

        public static string teamMembersXml = "App_Data/PersonManager.xml";
        
        public static List<string> Personlist { get; protected set; } = new List<string>()
        {
            "pierre",
            "paul",
            "jacques",
        };

        public static List<Person> TeamMembers { get; protected set; } = new List<Person>()
        {
            new Person(1, "Didier", "Responsable de formation"),
            new Person(2, "Sophie", "Formatrice"),
            new Person(3, "Franck", "Formateur"),
            new Person(4, "Mickaël", "Formateur"),
        };

        public static Person Search(int id)
        {
            Person member = TeamMembers.FirstOrDefault(item => item.Id == id);

            return (member != default(Person)) ? member : new Person();
        }

        public static Person Search(string name)
        {
            Person member = TeamMembers.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());

            return (member != default(Person)) ? member : new Person();
        }

        public static Person Search(Person p)
        {
            return Search(p.Id);
        }

        public static List<Person> SearchJob(string job)
        {
            return TeamMembers.FindAll(item => item.Job.ToLower() == job.ToLower());
        }


        public static void Save()
        {
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(HttpContext.Current.Server.MapPath(teamMembersBin), FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, TeamMembers);
            stream.Close();
            SaveXml();
        }

        public static void Load()
        {
            try
            {
                if(File.Exists(HttpContext.Current.Server.MapPath(teamMembersBin)))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(HttpContext.Current.Server.MapPath(teamMembersBin), FileMode.Open, FileAccess.Read, FileShare.Read);
                    List<Person> loaded = formatter.Deserialize(stream) as List<Person>;
                    stream.Close();
                    if(loaded != null)
                    {
                        TeamMembers = loaded;
                    }
                }
            }
            catch
            {

            }
        }

        public static void SaveXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath(teamMembersXml)))
            {
                serializer.Serialize(writer, TeamMembers);
            }
        }

        public static void LoadXml()
        {
            try
            {
                if(File.Exists(HttpContext.Current.Server.MapPath(teamMembersXml)))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

                    using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(teamMembersXml)))
                    {
                        List<Person> loaded = serializer.Deserialize(reader) as List<Person>;

                        if (loaded != null)
                        {
                            TeamMembers = loaded;
                        }
                    }
                }
                
            }
            catch
            {

            }
        }

    }
}