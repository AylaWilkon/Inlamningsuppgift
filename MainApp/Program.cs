using MainApp.Business.Repository;
using MainApp.Business.Services;
using MainApp.Business.Services.Interfaces;
using MainApp.Enums;
using MainApp.Validators;

namespace MainApp
{
    internal class Program
    {
        private static IContactService contactService = null!;
        //contactService är en statisk property som ska nås överallt i klassen

        static void Main(string[] args)
        {

            bool running = true;
            contactService = new ContactService(new JsonDataAccess());
            var inputValidator = new InputValidator();

            Console.WriteLine("Vill du läsa in kontakter från Json fil? Y/N");

            var readContacts = Console.ReadLine();
            if (!string.IsNullOrEmpty(readContacts) && readContacts.ToLower() == "y")
            {
                contactService.ReadContactsFromFile();
                if (!contactService.GetContacts().Any())
                {
                    Console.WriteLine("Inga kontakter fanns i filen eller saknas filen. ");
                    Console.WriteLine("Tryck på enter för att fortsätta.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            while (running)
            {
                // Meny för att välja alternativ
                Console.Clear();
                var menu = $"Välj ett alternativ: \n " +
                    $"[1] Skapa Kontakt \n " +
                    $"[2] Visa Kontakter \n " +
                    $"[3] Läs in Kontakter från Json \n " +
                    $"[4] Spara Kontakter till Json \n " +
                    $"[5] Avsluta programmet.\n " +
                    $"Ange ditt val: ";

                string input = inputValidator.RequestUserInput(menu, ValidationType.Int);

                switch (input)
                //Switch sats för användarens alternativ
                {
                    case "1":
                        // Lägger till en ny contact                        
                        string firstName = inputValidator.RequestUserInput("Ange förnamn: ", ValidationType.String);
                        string lastName = inputValidator.RequestUserInput("Ange efternamn: ", ValidationType.String);
                        string email = inputValidator.RequestUserInput("Ange email: ", ValidationType.String);
                        string phoneNumber = inputValidator.RequestUserInput("Ange telefonnummer: ", ValidationType.String);
                        string streetAdress = inputValidator.RequestUserInput("Ange gatuadress: ", ValidationType.String);
                        string postalCode = inputValidator.RequestUserInput("Ange postnummer: ", ValidationType.Int);
                        string city = inputValidator.RequestUserInput("Ange ort: ", ValidationType.String);

                        contactService.AddContact(firstName, lastName, email, phoneNumber, streetAdress, postalCode, city);

                        // Skapar en ny contact med användarnamn, e-post och datum skapat
                        Console.WriteLine("Användare tillagd!");
                        Console.WriteLine("Vill du uppdatera din Json fil med senaste kontakten? Y/N");

                        var importContacts = Console.ReadLine();
                        if (!string.IsNullOrEmpty(importContacts) && importContacts.ToLower() == "y")
                        {
                            contactService.SaveContactsToFile();

                            Console.WriteLine("Din Json fil har uppdaterats.");
                            Console.ReadLine();
                            Console.Clear();
                        }                      

                        break;

                    case "2":
                        // Visar alla contacts
                        Console.WriteLine("Alla användare:");
                        if (contactService.GetContacts().Any())
                        {
                            PrintContacts();
                            break;
                        }
                        Console.WriteLine("Inga användare tillagda.");
                        break;
                    case "3":
                        // Läser in kontakter
                        contactService.ReadContactsFromFile();
                        break;
                    case "4":
                        // Sparar kontakter till JSON
                        contactService.SaveContactsToFile();
                        Console.WriteLine("Kontakter sparade!");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "5":
                        // Avslutar programmet
                        Console.WriteLine("Avslutar programmet...");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                // Väntar på användarens input för att fortsätta
                if (running)
                {
                    Console.WriteLine("\nTryck på en tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// hämtar alla contacts, rensar konsolen och skriver ut den inmatade informationen och varje användare i formatet nedan
        /// </summary>
        private static void PrintContacts()
        {
            Console.Clear();
            foreach (var user in contactService.GetContacts())
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"Förnamn: {user.FirstName}, Efternamn: {user.LastName}, Epost: {user.Email}, Mobilnummer: {user.PhoneNumber}, Adress: {user.Adress.FullAddress}");
            }
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}