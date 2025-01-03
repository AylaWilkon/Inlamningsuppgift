using MainApp.UserService.Model;
using MainApp.UserService.Repository.Interfaces;
using System.Text.Json;

namespace MainApp.UserService.Repository
{
    public class JsonDataAccess : IContactsDataAccess
        //Här ska metoden ta en lista med användare och sedan serialisera den till JSON-format och skriva om den till strängar.1
    {
        public void ExportUsers(List<User> ContactsList)
        {
            var json = JsonSerializer.Serialize(ContactsList);
            File.WriteAllText(@"JsonExport.json", json);
        }

        public List<User> ImportUsers()
        {
            var jsonText = File.ReadAllText(@"JsonExport.json"); 
            //Läser in innehållet från en fil och använder metoden ReadAllText som läser upp filens innehåll och sparar det som en sträng i variabeln jsonText
            
            var list = JsonSerializer.Deserialize<List<User>>(jsonText);
            //Konverterar det som lagrats i strängen till en lista med objekt av typen "User".

            return ReturnEmptyListIfNoJsonFilePresent(list!);
            //Anropar en metod som kontrollerar listan och om data saknas returneras en tom lista istället för ett null-värde.
        }

        private List<User> ReturnEmptyListIfNoJsonFilePresent(List<User> list)
            //Tar emot en lista av "User" objekt
        {
            if (list == null)
            {
                return new List<User>();
                //Säkerställer att metoden alltid returnerar en giltig lista
            }
            return list;
            //Är listan inte null returneras listan som skickades in till metoden oförändrad.
        }
    }
}
