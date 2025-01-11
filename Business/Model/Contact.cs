using System.Text.Json.Serialization;

namespace MainApp.Business.Model
{
    public class Contact
    {
        public Guid Id { get; set; } //skapar en unik identifierare av typen guid varje gång ett nytt Contact objekt skapas

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;  //behöver vara en sträng då ett telefonnummer kan innehålla icke numeriska värden så som +, - samt ()
        public Address Adress { get; set; } = null!;

        [JsonConstructor]
        //Konstruktor som bara ska användas när objektet skapas från JSON-data
        private Contact()
        {

        }

        public Contact(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city)
            //publik konstruktor som gör att man kan skapa en ny kontakt med alla dessa egenskaper
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
