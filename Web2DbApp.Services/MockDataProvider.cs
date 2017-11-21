using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2DbApp.Entities;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Web2DbApp.Services
{
    public class MockDataProvider
    {
        //the url to the website
        private string url;

        /// <summary>
        /// Calls our service and converts the json Reponse
        /// </summary>
        /// <param name="amount">The Ammount of people we want back from the service</param>
        /// <returns>A list of persons</returns>
        public List<Person> GetPeople(int amount = 1)
        {
            //new list of people 
            List<Person> personList = new List<Person>();
            //our ourl link
            url = $"https://randomuser.me/api/?inc=name&results={amount}&noinfo&format=PrettyJSON";
            using (WebClient client = new WebClient())
            {
                //download the data from the url
                string data = client.DownloadString(url);
                //Convert our string to some Json
                JsonPerson.PersonName jsonPersonC = JsonConvert.DeserializeObject<JsonPerson.PersonName>(data);
                //save the from our JsonPerson in Properties used when we cast the json back to person
                foreach(var randPerson in jsonPersonC.results)
                {
                    JsonPerson tempPerson = new JsonPerson();
                    tempPerson.First = randPerson.name.first;
                    tempPerson.Last = randPerson.name.last;
                    tempPerson.Title = randPerson.name.title;
                    Person jPerson = (Person)tempPerson;
                    personList.Add(jPerson);
                }
            }
            return personList;
        }
    }
}
