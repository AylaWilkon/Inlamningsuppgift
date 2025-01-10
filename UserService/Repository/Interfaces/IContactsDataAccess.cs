

using MainApp.UserService.Model;

namespace MainApp.UserService.Repository.Interfaces
{
    public interface IContactsDataAccess
        //Deklarerar ett interface som kan användas av andra klasser i samma eller externa projekt. 
    {
        /// <summary>
        /// Importerar contacts från Json fil och returnerar en lista av typen list1<User>
        /// </summary>
        /// <returns></returns>
        List<User> ImportContactsFromJsonFile();
        //Metodens syfte här är att importera användardata som ska resultera i att en lista med User-objekt returneras.
        void ExportUsers(List<User> users);
        //Tar emot en lista med användare och exporterar sedan datan. 
    }
}
