using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM1Project
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string occupation { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public char gender { get; set; }
        public string nationality { get; set; }
        public string eyeColor { get; set; }
        public string education { get; set; }
        public string hairColor { get; set; }
        public string favoriteColor { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate, string occupation, int height, int weight, char gender, string nationality, string eyeColor, string education, string hairColor, string favoriteColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.occupation = occupation;
            this.height = height;
            this.weight = weight;
            this.gender = gender;
            this.nationality = nationality;
            this.eyeColor = eyeColor;
            this.education = education;
            this.hairColor = hairColor;
            this.favoriteColor = favoriteColor;
        }
    }
}
