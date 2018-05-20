using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using HelloWorldMvc.Tools;

namespace HelloWorldMvc.Models
{
    public class PersonManager : AppDataModelManager<Person>
    {              
        public static List<Person> DefaultPersonList { get; protected set; } = new List<Person>()
        {
            new Person(1, "Didier", "Responsable de formation"),
            new Person(2, "Sophie", "Formatrice"),
            new Person(3, "Franck", "Formateur"),
            new Person(4, "Mickaël", "Formateur"),
        };

        #region Constructors

        public PersonManager() : this("PersonManager")
        {
            
        }

        public PersonManager(string _filename) : base(_filename, DefaultPersonList)
        {

        }

        #endregion

        #region Search

        public List<Person> SearchJob(string job)
        {
            return dataManager.Items.FindAll(item => item.Job.ToLower() == job.ToLower());
        }

        #endregion

    }
}