using MainApp.Business.Model;

namespace MainApp.Business.Repository.Interfaces
{
    public interface IContactsDataAccess
        //Deklarerar ett interface som kan användas av andra klasser i samma eller externa projekt. 
    {
        /// <summary>
        /// Importerar contacts från Json fil och returnerar en lista av typen list1<User>
        /// </summary>
        /// <returns></returns>
        List<Contact> ImportContactsFromJsonFile();
        //Metodens syfte här är att importera användardata som ska resultera i att en lista med Contacts-objekt returneras.
        void ExportUsers(List<Contact> users);
        //Tar emot en lista med kontakter och exporterar sedan datan. 

        bool JsonFileExists();
    }
}
