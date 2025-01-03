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
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } //behöver vara en sträng då ett telefonnummer kan innehålla icke numeriska värden så som +, - samt ()
        public Address Adress { get; set; }

        [JsonConstructor]
        private User()
        {

        }

        public User(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city)
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
