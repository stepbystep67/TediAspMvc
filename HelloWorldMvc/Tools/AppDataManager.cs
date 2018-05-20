using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace HelloWorldMvc.Tools
{
    public class AppDataManager<T>
    {
        string fileName;

        public string BinPath { get; protected set; }

        public string XmlPath { get; protected set; }

        //public bool BinExists { get; protected set; }

        //public bool XmlExists { get; protected set; }

        public List<T> Items { get; protected set; }


        public AppDataManager() : this("") { }

        public AppDataManager(string _filename)
        {
            if (String.IsNullOrEmpty(_filename))
            {
                _filename = "AppDataManager";
            }

            _filename = Path.Combine("App_Data", _filename);

            if (HttpContext.Current != null)
            {
                fileName = HttpContext.Current.Server.MapPath(_filename);
            }
            else
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tedi", _filename);
            }

            BinPath = Path.Combine(fileName + ".bin");
            XmlPath = Path.Combine(fileName + ".xml");

            //BinExists = File.Exists(BinPath);
            //XmlExists = File.Exists(XmlPath);

            Items = new List<T>();
        }

        public AppDataManager(string _filename, List<T> _defaultItems) : this(_filename)
        {
            if(_defaultItems != null)
            {
                Items = _defaultItems;
            }
        }

        public void Load()
        {
            List<T> loaded = AppDataSerializer.LoadBin<List<T>>(BinPath);

            if (loaded != null)
            {
                Items = loaded;
            }
        }

        public void LoadXml()
        {
            List<T> loaded = AppDataSerializer.LoadXml<List<T>>(XmlPath);

            if (loaded != null)
            {
                Items = loaded;
            }
        }

        public void Save()
        {
            AppDataSerializer.SaveBin(BinPath, Items);
        }

        public void SaveXml()
        {
            AppDataSerializer.SaveXml(XmlPath, Items);
        }
    }
}