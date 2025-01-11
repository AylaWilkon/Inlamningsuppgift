using MainApp.UserService.Model;
using MainApp.UserService.Repository.Interfaces;
using MainApp.UserService.Services;
using Moq;

namespace Tests.Services
{
    public class ContactService_Tests
    {

        [Fact]
        public void ContactService_ImportUsers_SholdReturnEmptyListWhenFileNotFound()
        {
            //Arrange

            //Mockar upp att om någon kallar på DataAccess metoden Import users så ska den svara med nedan.
            //(Metoden kommer inte köras på riktigt) Då vi inte kan garantera att det finns en fil att läsa från Så man kör en MOQ dvs Fake.
            var mockDataAccess = new Mock<IContactsDataAccess>();

            //Här bestämmer vi vad den svarar
            mockDataAccess.Setup(DataAccess => DataAccess.ImportContactsFromJsonFile())
                .Returns(new List<Contact>()
                {
                    new Contact("MyFirstName","MyLastName", "MyEmail@email.com","0723232323","Streetname 123","299 99","Malmoe"),
                    new Contact("MyFirstName1","MyLastName1", "MyEmail1@email.com","0723232324","Streetname 124","299 98","Trelleborg")
                });

            //Act

            //Skapar upp en Contact Service med "FAKE DataAccess" som vi bestämt vad den ska svara.
            var contactService = new ContactService(mockDataAccess.Object);
            //Anropar inläsning av contacts för att fylla på user listan i ContactSerivce
            contactService.ReadContactsFromFile();
            //Hämtar ut listan via Contacts Servicens GetUsers.
            var userList = contactService.GetContacts();


            //Assert

            //Validerar att det svaret vi fick är kompletta listan, dvs 2 stycken Users
            Assert.Equal(2, userList.Count());
            //Validerar så att det anropades enbart en gång. (Man vill inte anropa DataAccesser flertalsgånger ifall det inte behövs.)
            mockDataAccess.Verify(DataAccess => DataAccess.ImportContactsFromJsonFile(), Times.Once());
            //Validerar så att användaren på plats 0 har korrekt namn. (Bra att göra om ordningen på listan då det är viktig att de är likadana.
            Assert.Equal("MyFirstName", userList[0].FirstName);

            //Man kan lägga till fler asserts ifall man vill kolla så att Ex alla värden är med
            //dvs applikationen förväntar sig att användaren alltid har ett nummer. Då kan man se till att detta Unit test smäller om någon ändrar på inladdningen.
        }

        [Fact]
        public void AddUser_UserShouldBeInUserList()
        {
            //Arrange
            var mockDataAccess = new Mock<IContactsDataAccess>();

            //Act
            var contactService = new ContactService(mockDataAccess.Object);

            contactService.AddContact("MyFirstName", "MyLastName", "MyEmail@email.com", "0723232323", "Streetname 123", "299 99", "Malmoe");
            
            var userList = contactService.GetContacts();

            //Assert

            Assert.True(userList.Any());
        }

    }
}
