using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Web2DbApp.Entities;
namespace Web2DbApp.DataAccess
{
    public class Reporsitory
    {
        private Executor executor;


        public Reporsitory()
        {
            executor = new Executor();
        }

        /// <summary>
        /// Gets all persons in the DB, and stores them in a list 
        /// </summary>
        /// <returns>List of Persons</returns>
        public List<Person> GetAll()
        {
            string sqlQuery = "SELECT * FROM Persons";
            DataSet data = executor.Execute(sqlQuery);
            List<Person> returnList = new List<Person>();
            DataTableReader reader = data.CreateDataReader();
            while(reader.Read())
            {
                string firstName = reader["Firstname"].ToString();
                string lastName = reader["Lastname"].ToString();
                string title = reader["Title"].ToString();
                Person tempPerson = new Person(firstName,lastName, title);
                returnList.Add(tempPerson);
            }
            return returnList;
        }

        /// <summary>
        /// Saves a list of persons in the DB
        /// </summary>
        /// <param name="persons">List of persons</param>
        public void Save(List<Person>persons)
        {
            string realPerson = "";
            string sqlQuery = "INSERT INTO Persons (Firstname,Lastname,Title) VALUES ";
            string procedureName = "createPerson";
            for(int i = persons.Count -1; i >= 0; i--)
            {
                if (string.IsNullOrEmpty(persons[i].FirstName))
                    persons.RemoveAt(i);
                else if (string.IsNullOrEmpty(persons[i].LastName))
                    persons.RemoveAt(i);
                else
                {
                    realPerson = $"'{persons[i].FirstName}','{persons[i].LastName}','{persons[i].TitleOfCourtesy}'";
                    sqlQuery += $"({realPerson}),";
                }
            }
            sqlQuery = sqlQuery.Remove(sqlQuery.Length - 1);
            executor.Execute(procedureName, sqlQuery);
        }


    }
}
