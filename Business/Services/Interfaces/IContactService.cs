using MainApp.Business.Model;

namespace MainApp.Business.Services.Interfaces
{
    public interface IContactService 
    {
        List<Contact> GetContacts(); 
        //returnerar en lista av Contact objekt
        void AddContact(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city);
        //lägger till en ny användare och tar emot flera parametrar, är void så utför bara handlingen
        void SaveContactsToFile();
        //sparar alla Contacts till en fil
        void ReadContactsFromFile();
        //läser in användardata från en fil, i detta fall JSON
    }
}
