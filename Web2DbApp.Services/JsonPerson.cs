using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Web2DbApp.Entities;
namespace Web2DbApp.Services
{
    public class JsonPerson
    {
        /// <summary>
        /// Used when we cast Json to our person
        /// </summary>
        /// <param name="jperson"></param>
        public static explicit operator Person (JsonPerson jperson)
        {
            Person person = new Person(jperson.First, jperson.Last, jperson.Title);
            return person;
        }

        public string First { get; set; }
        public string Last { get; set; }
        public string Title { get; set; }

        //Basicly the same as the one before but i think i understand how it works now
        public class PersonName
        {
            //holding a list of Results
            public List<Result> results { get; set; }
        }
        public class Result
        {
            //holding the name used in the json response
            public Name name { get; set; }
        }
        public class Name
        {
            //holing firstname
            public string first { get; set; }
            public string last { get; set; }
            public string title { get; set; }
        }
    }
}
