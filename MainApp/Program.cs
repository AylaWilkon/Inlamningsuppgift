using MainApp.UserService.Repository;
using MainApp.UserService.Services.Interfaces;
using MainApp.UserService.Services;
using MainApp.Enums;
namespace MainApp
{
    internal class Program
    {
        private static IContactService contactService;
        //contactService är en statisk variabel av typen IContactService, används för att interagera med tjänsten som hanterar användardata

        static void Main(string[] args)
        {

            bool running = true;
            contactService = new ContactService(new JsonDataAccess());

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

                string input = RequestUserInput(menu, ValidationType.Int);

                switch (input)
                    //Switch sats för användarens alternativ
                {
                    case "1":
                        // Lägger till en ny användare                        
                        string firstName = RequestUserInput("Ange förnamn: ", ValidationType.String);
                        string lastName = RequestUserInput("Ange efternamn: ", ValidationType.String);
                        string email = RequestUserInput("Ange email: ", ValidationType.String);
                        string phoneNumber = RequestUserInput("Ange telefonnummer: ", ValidationType.String);
                        string streetAdress = RequestUserInput("Ange gatuadress: ", ValidationType.String);
                        string postalCode = RequestUserInput("Ange postnummer: ", ValidationType.Int);
                        string city = RequestUserInput("Ange ort: ", ValidationType.String);

                        contactService.AddUser(firstName, lastName, email, phoneNumber, streetAdress, postalCode, city);

                        // Skapar en ny användare med användarnamn, e-post och datum skapat
                        Console.WriteLine("Användare tillagd!");
                        break;

                    case "2":
                        // Visar alla användare
                        Console.WriteLine("Alla användare:");
                        if (contactService.GetUsers().Any())
                        {
                            PrintContacts();
                            break;
                        }
                        Console.WriteLine("Inga användare tillagda.");
                        break;
                    case "3":
                        // Läser in kontakter
                        contactService.ReadUsersFromFile();
                        break;
                    case "4":
                        // Sparar kontakter till JSON
                        contactService.SaveUsersToFile();
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
        /// hämtar alla användare, rensar konsolen och skriver ut den inmatade informationen och varje användare i formatet nedan
        /// </summary>
        private static void PrintContacts()
        {
            Console.Clear();
            foreach (var user in contactService.GetUsers())
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"Förnamn:{user.FirstName} Efternamn: {user.LastName} Epost: {user.Email}TelefonNummer: {user.PhoneNumber} Adress:{user.Adress.FullAddress}");
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        private static string RequestUserInput(string question, ValidationType validationType)
        {
            const string noValueProvided = "Inget värde angivet.";
            const string notANumericValueProvided = $"Angivna värdet är inte ett numeriskt värde";
            string input = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine(question);
                input = Console.ReadLine()!;

                switch (validationType)
                {
                    case ValidationType.None:
                        Console.Clear();
                        isValid = true;
                        break;
                    case ValidationType.String:
                        Console.Clear();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine(noValueProvided);
                            continue;
                        }
                        isValid = true;
                        break;

                    case ValidationType.Int:
                        Console.Clear();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine(noValueProvided);
                        }
                        if (!int.TryParse(input, out int number))
                        {
                            Console.WriteLine(notANumericValueProvided);
                            continue;
                        }
                        isValid = true;
                        break;
                }
            }
            return input;
        }
    }
}