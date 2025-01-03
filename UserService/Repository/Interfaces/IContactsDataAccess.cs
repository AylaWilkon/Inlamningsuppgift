

using MainApp.UserService.Model;

namespace MainApp.UserService.Repository.Interfaces
{
    public interface IContactsDataAccess
        //Deklarerar ett interface som kan användas av andra klasser i samma eller externa projekt. 
    {
        List<User> ImportUsers();
        //Metodens syfte här är att importera användardata som ska resultera i att en lista med User-objekt returneras.
        void ExportUsers(List<User> users);
        //Tar emot en lista med användare och exporterar sedan datan. 
    }
}
