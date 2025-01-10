using MainApp.UserService.Model;
using MainApp.UserService.Repository.Interfaces;
using MainApp.UserService.Services;
using Moq;

namespace Tests
{
    public class ContactService_Tests
    {

        [Fact]
        public void ContactService_ImportUsers_SholdReturnEmptyListWhenFileNotFound()
        {
            //Arrange

            //Mockar upp att OM någon kallar på ett DataAccess metoden Import users så ska den svara med nedan.
            //(Metoden kommer inte köras på riktigt) Då vi inte kan garantera att det finns en fil att läsa från Så man kör en MOQ dvs Fake.
            var mockDataAccess = new Mock<IContactsDataAccess>();

            //Här bestämmer vi vad den svarar
            mockDataAccess.Setup(DataAccess => DataAccess.ImportContactsFromJsonFile())
                .Returns(new List<User>() 
                { 
                    new User("MyFirstName","MyLastName", "MyEmail@email.com","0723232323","Streetname 123","299 99","Malmoe"),
                    new User("MyFirstName1","MyLastName1", "MyEmail1@email.com","0723232324","Streetname 124","299 98","Trelleborg") 
                });

            //Act

            //Skapar upp en Contact Service med "FAKE DataAccess" som vi bestämt vad den ska svara.
            var contactService = new ContactService(mockDataAccess.Object);
            //Anropar inläsning av contacts för att fylla på user listan i ContactSerivce
            contactService.ReadUsersFromFile();         
            //Hämtar ut listan via Contacts Servicens GetUsers.
            var userList = contactService.GetUsers();
            
            
            //Assert

            //Validerar att det svaret vi fick är kompletta listan, dvs 2 stycken Users
            Assert.Equal(2, userList.Count());
            //Validerar så att det anropades enbart en gång. (Man vill inte anropa DataAccesser flertalsgånger ifall det inte behövs.)
            mockDataAccess.Verify(DataAccess => DataAccess.ImportContactsFromJsonFile(), Times.Once());
            //Validerar så att användaren på plats 0 har korrekt namn. (Bra att göra om ordningen på listan är viktig att vara samma.
            Assert.Equal("MyFirstName", userList[0].FirstName);

            //Man kan lägga till fler asserts ifall man vill kolla så att Ex alla värden är med
            //dvs applikationen förväntar sig att användaren alltid har ett nummer. Då kan man se till att detta Unit test smäller om någon ändrar på inladdningen.
        }

    }
}
