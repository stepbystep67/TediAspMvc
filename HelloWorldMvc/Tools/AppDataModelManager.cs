using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvc.Tools
{
    public class AppDataModelManager<T> where T : AppDataModel, new()
    {
        public List<T> Items { get { return dataManager.Items; } }

        protected AppDataManager<T> dataManager;

        public AppDataModelManager() : this("AppModelManager") { }

        public AppDataModelManager(string _filename)
        {
            dataManager = new AppDataManager<T>(_filename);
        }

        public AppDataModelManager(string _filename, List<T> _defaultItems)
        {
            dataManager = new AppDataManager<T>(_filename, _defaultItems);
        }

        #region Search

        public virtual T Search(int id)
        {
            T result = dataManager.Items.FirstOrDefault(item => item.Id == id);

            return (result != default(T)) ? result : new T();
        }

        public virtual T Search(string name)
        {
            T result = dataManager.Items.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());

            return (result != default(T)) ? result : new T();
        }

        public virtual T Search(T item)
        {
            return Search(item.Id);
        }

        #endregion

        #region Serialization

        public void Load()
        {
            dataManager.Load();
        }

        public void Save()
        {
            dataManager.Save();
            dataManager.SaveXml();
        }

        #endregion
    }
}