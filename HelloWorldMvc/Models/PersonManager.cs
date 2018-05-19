using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvc.Models
{
    public class PersonManager
    {
        public static List<string> Personlist { get; protected set; } = new List<string>()
        {
            "pierre",
            "paul",
            "jacques",
        };

        public static List<Person> TeamMembers { get; protected set; } = new List<Person>()
        {
            new Person(1, "Sophie"),
            new Person(2, "Franck"),
            new Person(3, "Mickaël"),
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


    }
}