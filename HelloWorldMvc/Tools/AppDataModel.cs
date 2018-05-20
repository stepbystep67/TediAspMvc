using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvc.Tools
{
    [Serializable]
    abstract public class AppDataModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public AppDataModel()
        {
            Id = 0;
            Name = "";
        }

        public virtual bool IsValid()
        {
            return (!String.IsNullOrEmpty(Name));
        }

        public virtual bool IsRegistered()
        {
            return (IsValid() && (Id > 0));
        }
    }
}