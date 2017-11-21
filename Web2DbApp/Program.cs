using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2DbApp.Entities;
using Web2DbApp.Services;
using Web2DbApp.DataAccess;
namespace Web2DbApp.UI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Creates a instance of MockDataProvider so we can access the functions in it
            MockDataProvider dataProvider = new MockDataProvider();

            //Create a instance of Reporsitory so we can call the database function
            Reporsitory executor = new Reporsitory();

            //First it gets the results from dataProvider, and saves it all in the database.
            executor.Save((dataProvider.GetPeople(99)));
            //Calls a function to print all persons to the console
            PrintAll(executor.GetAll());
            //Wait for user to press any key on the keyboard
            Console.ReadKey();
        }


        /// <summary>
        /// Prints all the persons from personList.
        /// </summary>
        /// <param name="personList">A list of the Person class</param>
        private static void PrintAll(List<Person> personList)
        {
            foreach (Person person in personList)
            {
                if (!string.IsNullOrEmpty(person.FirstName))
                    Console.WriteLine(person);
            }
        }
    }
}
