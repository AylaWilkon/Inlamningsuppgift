using MainApp.UserService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UserService.Services.Interfaces
{
    public interface IContactService 
    {
        List<User> GetUsers(); 
        //returnerar en lista av User objekt
        void AddUser(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string postalCode, string city);
        //lägger till en ny användare och tar emot flera parametrar, är void så utför bara handlingen
        void SaveUsersToFile();
        //sparar alla användare till en fil
        void ReadUsersFromFile();
        //läser in användardata från en fil, i detta fall JSON
    }
}
