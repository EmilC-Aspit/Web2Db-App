using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Web2DbApp.Entities
{
    public class Person
    {
        /// <summary>
        /// Firstname of the Person from our json response.
        /// </summary>
        private string firstName;
        /// <summary>
        /// Lastname of the Person from our json response.
        /// </summary>
        private string lastName;

        /// <summary>
        /// titleOfCourtesy of the Person from our json response.
        /// </summary>
        private string titleOfCourtesy;

        //Dont know what to write here
        public Person(string firstName, string lastName, string titleOfCourtesy)
        {
            FirstName = firstName;
            LastName = lastName;
            TitleOfCourtesy = titleOfCourtesy;
        }

        //Dont know what to write here
        public override string ToString()
        {
            if (firstName == "")
                return string.Empty;
            return $"Firstname is {firstName} Lastname is {lastName} TitleOfCourtesy is {titleOfCourtesy}";
        }

        /// <summary>
        /// Gets and sets FirstName.
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                
                if (value.All(char.IsLetter))
                {
                    if (char.IsUpper(value[0]))
                        firstName = value;
                    else
                       firstName =  value = value.Replace(value[0], char.ToUpper(value[0]));
                }
                else
                    firstName = "";
                    

            }
        }

        /// <summary>
        /// Gets and sets LastName.
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {                
                if (value.All(char.IsLetter))
                {
                    if (char.IsUpper(value[0]))
                        lastName = value;
                    else
                        lastName = value = value.Replace(value[0], char.ToUpper(value[0]));
                }
                else
                    lastName = "";
            }
        }

        /// <summary>
        /// Gets and sets TitleOfCourtesy.
        /// </summary>
        public string TitleOfCourtesy
        {
            get => titleOfCourtesy;
            set => titleOfCourtesy = value;
        }
    }
}
