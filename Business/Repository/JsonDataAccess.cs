using MainApp.Business.Model;
using MainApp.Business.Repository.Interfaces;
using System.Text.Json;

namespace MainApp.Business.Repository
{
    public class JsonDataAccess : IContactsDataAccess
        //Här ska metoden ta en lista med kontakter och sedan serialisera den till JSON-format och skriva om den till strängar.
    {
        private const string filePath = @"JsonExport.json";


        public void ExportUsers(List<Contact> ContactsList)
        {
            var json = JsonSerializer.Serialize(ContactsList);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Importerar kontakterna från en Json fil
        /// </summary>
        /// <returns></returns>
        public List<Contact> ImportContactsFromJsonFile()
        {
            if (!JsonFileExists())
            {
                return new List<Contact>();
            }

            var jsonText = File.ReadAllText(@"JsonExport.json"); 
            //Läser in innehållet från en fil och använder metoden ReadAllText som läser upp filens innehåll och sparar det som en sträng i variabeln jsonText
            
            var list = JsonSerializer.Deserialize<List<Contact>>(jsonText);
            //Konverterar det som lagrats i filen till en lista med objekt av typen "Contact".

            if (list == null)
            {
                return new List<Contact>();
                //Säkerställer att metoden alltid returnerar en giltig lista
            }

            return list;
            //Anropar en metod som kontrollerar listan och om data saknas returneras en tom lista istället för ett null-värde.
        }

        public bool JsonFileExists()
        {
            return File.Exists(filePath);
        }
    }
}
