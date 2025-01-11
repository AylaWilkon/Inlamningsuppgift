using MainApp.UserService.Model;
using MainApp.UserService.Repository.Interfaces;
using MainApp.UserService.Services.Interfaces;

namespace MainApp.UserService.Services
{
    public class ContactService : IContactService
    //måste implementera alla metoder som definieras i IContactService
    {
        private readonly IContactsDataAccess dataAccess;
        //interface för hantering av dataåtkomst
        private List<Contact> _users;
        //lagrar en lista med contacts

        /// <summary>
        /// Contact service konstruktor för användning av dependency injection och att skapa en ny lista för kontakter
        /// </summary>
        /// <param name="contactsDataAccess"></param>
        public ContactService(IContactsDataAccess contactsDataAccess)
        {
            dataAccess = contactsDataAccess;
            _users = new List<Contact>();
        }

        /// <summary>
        /// En metod som används för att lägga till en ny användare i listan
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="streetAdress"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        public void AddContact(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city)
        {
            _users.Add(new Contact(firstName, lastName, email, phoneNumber, streetAdress, postalCode, city));
        }

        /// <summary>
        /// returnerar en lista med alla användare som lagras i _contact
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetContacts()
        {
            return _users.ToList();
            //gör att den ursprungliga listan inte ändras om man skulle modifiera den i andra delar av programmet
        }

        public void SaveContactsToFile()
        //ansvarar för att exportera den sparade datan till en fil
        {
            dataAccess.ExportUsers(_users);
        }

        public void ReadContactsFromFile()
        //läser användardata från en fil
        {
            _users = dataAccess.ImportContactsFromJsonFile();
        }
    }
}
