using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HelloWorldMvc.Tools
{
    public class AppDataSerializer
    {
       /* static Stream stream;

        protected static void CloseStream()
        {
            if(stream != null)
            {
                try
                {
                    stream.Close();
                    stream = null;
                }
                catch
                {
                    stream = null;
                }
            }
        }*/

        public static T LoadBin<T>(string _path)
        {
            try
            {
                if (File.Exists(_path))
                {
                    IFormatter formatter = new BinaryFormatter();

                    using (FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        if (stream.Length > 0)
                        {
                            T loaded = (T)formatter.Deserialize(stream);

                            if (loaded != null)
                            {
                                return loaded;
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return default(T);
        }

        public static void SaveBin(string _path, object _o)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();

                using (FileStream stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, _o);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static T LoadXml<T>(string _path)
        {
            try
            {
                if (File.Exists(_path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    using (StreamReader reader = new StreamReader(_path))
                    {
                        T loaded = (T)serializer.Deserialize(reader);

                        if (loaded != null)
                        {
                            return loaded;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return default(T);
        }


        public static void SaveXml<T>(string _path, T _o)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StreamWriter writer = new StreamWriter(_path))
                {
                    serializer.Serialize(writer, _o);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}