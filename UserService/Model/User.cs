using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MainApp.UserService.Model
{
    public class User
    {
        public Guid Id { get; set; } //skapar en unik identifierare av typen guid varje gång ett nytt User objekt skapas
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } //behöver vara en sträng då ett telefonnummer kan innehålla icke numeriska värden så som +, - samt ()
        public Address Adress { get; set; }

        [JsonConstructor]
        //Konstruktor som bara ska användas när objektet skapas från JSON-data
        private User()
        {

        }

        public User(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city)
            //publik konstruktor som gör att man kan skapa en ny användare med alla dessa egenskaper
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = new Address
            {
                StreetName = streetAdress,
                PostalCode = postalCode,
                City = city,
            };
        }
    }
}
