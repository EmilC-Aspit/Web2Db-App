using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web2DbApp.Services;
using Web2DbApp.Entities;
using Web2DbApp.DataAccess;
using System.Collections.Generic;

namespace Web2DbApp.ServicesTests
{
    [TestClass]
    public class MockDataProviderTests
    {
        [TestMethod]
        public void List_WithValidCount_FromWebService()
        {
            //arrange
            int expectedAmount = 5;
            MockDataProvider data = new MockDataProvider();
            //act
            int actualAmount = data.GetPeople(expectedAmount).Count;
            //assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void PropertyFirstName()
        {
            //arrange
            string firstName = "jensen";
            string firstName2 = " ";
            Person person = new Person(firstName, "fff", "mr.");
            Person personNumb = new Person(firstName2, "ffg", "ffg");
            //act
            firstName = firstName.Replace(firstName[0], char.ToUpper(firstName[0]));
            //assert
            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(string.Empty, personNumb.FirstName);
        }

        [TestMethod]
        public void PropertyLastName()
        {
            //arrange
            string lastName = "jensen";
            string lastName2 = "العَرَ";
            Person person = new Person("ff", lastName, "mr.");
            Person personNumb = new Person("ff", lastName2, "ffg");
            //act
            lastName = lastName.Replace(lastName[0], char.ToUpper(lastName[0]));
            //assert
            Assert.AreEqual(lastName, person.LastName);
            Assert.AreEqual(string.Empty, personNumb.LastName);
        }

        [TestMethod]
        public void List_WithValidCount_DB()
        {
            //arrange
            int ammount = 5;
            MockDataProvider data = new MockDataProvider();
            Reporsitory executor = new Reporsitory();
            List<Person> personList = new List<Person>();
            int expectedAmmount = 0;
            //act
            personList = data.GetPeople(ammount);
            expectedAmmount = personList.Count;
            executor.Save(personList);
            int actualAmmount = executor.GetAll().Count;
            //assert
            Assert.AreEqual(expectedAmmount, actualAmmount);
        }
    }
}
