using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvc.Models
{
    [Serializable]
    public class Person
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Job { get; set; }


        public Person()
        {
            Id = 0;
            Name = "Anonyme";
            Job = "";
        }

        public Person(int _id, string _firstname, string _job)
        {
            Id = _id;
            Name = _firstname;
            Job = _job;
        }

        public bool IsValid()
        {
            return (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Job));
        }

        public bool IsRegistered()
        {
            return (IsValid() && (Id > 0));
        }
    }
}