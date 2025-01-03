using MainApp.UserService.Model;
using MainApp.UserService.Repository.Interfaces;
using MainApp.UserService.Services.Interfaces;

namespace MainApp.UserService.Services
{
    public class ContactService : IContactService
        //måste implementera alla metoder som definieras i IContactService
    {
        private readonly IContactsDataAccess dataAccess;
        private List<User> _users;
        //
        public ContactService(IContactsDataAccess contactsDataAccess)
        //Här används dependency injection, ContactService tar emot en instans av IContactsDataAccess som en parameter vid skapandet av objektet
        {
            dataAccess = contactsDataAccess;
            _users = new List<User>();
        }

                public void AddUser(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city)
        {
            _users.Add(new User(firstName, lastName, email, phoneNumber, streetAdress, postalCode, city));
        }

        public List<User> GetUsers()
        {
            return _users.ToList();
        }

        public void SaveUsersToFile()
        {
            dataAccess.ExportUsers(_users);
        }

        public void ReadUsersFromFile()
        {
            _users = dataAccess.ImportUsers();
        }
    }
}
