using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldMvc.Tools;

namespace HelloWorldMvc.Models
{
    [Serializable]
    public class Person : AppDataModel
    {

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

        public override bool IsValid()
        {
            return (base.IsValid() && !String.IsNullOrEmpty(Job));
        }

    }
}