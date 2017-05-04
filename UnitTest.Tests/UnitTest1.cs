using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Controllers;
using System.Web.Http;
using System.Net.Http;
using TestProject.Models;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using TestProject.Repository;
using Moq;
using System.Net;

namespace UnitTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
 
        [TestMethod]
        public void UserGetById()
        {
            //var controller = new UsersController(); 
            //var response = controller.GetUser(1);
            //var contentResult = response as OkNegotiatedContentResult<User>;
            //Assert.AreEqual(1, contentResult.Content.Id);

            //имитируется функциональность репозитория
            var mockRepository = new Mock<IUserRepository>();
            //настройка на определенный обьект
            mockRepository.Setup(x => x.GetUser(1))
                .Returns(new User { Id =1 });

            var controller = new UsersController(mockRepository.Object);
            IHttpActionResult actionResult = controller.GetUser(1);
            //результат действия, согласующего содержимое и возвращающего ответ HttpStatusCode.OK при успешном согласовании содержимого.
            var contentResult = actionResult as OkNegotiatedContentResult<User>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void AddUser()
        {
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UsersController(mockRepository.Object);
          
            IHttpActionResult actionResult = controller.PostUser(new User() {Id=10,  FirstName = "dsds", LastName = "ff", Email = "dsds@mail.ru", Position = TestProject.Enum.PositionEnum.Position.PM });
           
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));

        }

        [TestMethod]
        public void UpdateUser()
        {
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UsersController(mockRepository.Object);
            
            IHttpActionResult actionResult = controller.UpdateUser(new User { Id = 1, FirstName = "dsds", LastName = "ff", Email = "dsds@mail.ru", Position = TestProject.Enum.PositionEnum.Position.PM });
           
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UsersController(mockRepository.Object);

            IHttpActionResult actionResult = controller.DeleteUser(10);
            
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
