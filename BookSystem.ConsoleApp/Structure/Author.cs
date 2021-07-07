using System;
using System.Collections.Generic;
using System.Text;

namespace BookSystem.ConsoleApp.Structure
{
    class Author
    {
        static int idcount = 0;

        public Author()
        {
            idcount++;
            this.AuthorID = idcount;
        }
        public Author(string AuthorInfo, string AuthorCountry, string AuthorGender)
            : this()
        {
            this.NameSurname = AuthorInfo;
            this.Country = AuthorCountry;
            this.Gender = AuthorGender;
        }

        public string NameSurname { get; set; }
        public int AuthorID { get; private set; }
        public string Country { get; set; }
        public string Gender { get; set; }


        public override string ToString()
        {
            return $"{AuthorID}. {NameSurname} \n" +
                $"{NameSurname} was born in {Country}.\n" +
                $"{Gender} was a popular since its own times.";
        }
    }
}
