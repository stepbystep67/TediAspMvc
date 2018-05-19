using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldMvc.Models;
using System.Web;


namespace HelloWorldMvc.Tests
{
    [TestClass]
    public class PersonManager_Test
    {
        Person person1 = new Person(1, "Prénom", "Emploi");
        Person person2 = new Person(2, "Prénom2", "Emploi2");
        
        [TestMethod]
        public void Test_DataPerson()
        {
            Assert.AreEqual(1, person1.Id, "person1 Id");

            Assert.AreEqual("Prénom".ToLower(), person1.Name.ToLower(), "person1 Name");

            Assert.AreEqual("Emploi".ToUpper(), person1.Job.ToUpper(), "person1 Job");

            Assert.IsTrue(person1.IsValid(), "person1");
            Assert.IsTrue(person1.IsRegistered(), "person1 R");

            Assert.IsTrue(person2.IsValid(), "person2");
            Assert.IsTrue(person2.IsRegistered(), "person2 R");
        }

        [TestMethod]
        public void Test_ValidPerson()
        {
            Person p1 = new Person();

            Assert.IsFalse(p1.IsValid(), "p1");
            Assert.IsFalse(p1.IsRegistered(), "p1 R");


            Person p2 = new Person(0, "Prénom", "Job");

            Assert.IsTrue(p2.IsValid(), "p2");
            Assert.IsFalse(p2.IsRegistered(), "p2 R");


            Person p3 = new Person(-1, "Prénom", "Job");

            Assert.IsTrue(p3.IsValid(), "p3");
            Assert.IsFalse(p3.IsRegistered(), "p3 R");


            Person p4 = new Person(1, "Prénom", "");

            Assert.IsFalse(p4.IsValid(), "p4");
            Assert.IsFalse(p4.IsRegistered(), "p4 R");


            Person p5 = new Person(1, "", "Job");

            Assert.IsFalse(p5.IsValid(), "p5");
            Assert.IsFalse(p5.IsRegistered(), "p5 R");


            Person p6 = new Person(42, "Name", "Job");

            Assert.IsTrue(p6.IsValid(), "p6");
            Assert.IsTrue(p6.IsRegistered(), "p6 R");

        }

        [TestMethod]
        public void Test_ValidManager()
        {
            PersonManager personManager = new PersonManager();
            
            foreach (Person p in PersonManager.DefaultPersonList)
            {
                Assert.IsTrue(p.IsValid(), (p.Id + " " + p.Name));
                Assert.IsTrue(p.IsRegistered(), (p.Id + " " + p.Name));
            }

            Person p1 = personManager.Search(1);
            Assert.AreEqual(p1.Name, "Didier");

            Person p2 = personManager.Search("Mickaël");
            Assert.AreEqual(p2.Id, 4);

            Person p3 = personManager.Search(person2);
            Assert.AreEqual(p3.Id, 2);

            //Assert.IsTrue(false, personManager.BinPath);
            
        }
    }
}
