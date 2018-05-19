using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvc.Models
{
    public class Person
    {
        
        public int Id { get; set; }

        public string Name { get; set; }


        public Person()
        {
            Id = 0;
            Name = "Anonyme";
        }

        public Person(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
    }
}