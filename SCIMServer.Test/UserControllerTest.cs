using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCIMServer.Controllers;
using SCIMServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCIMServer.Test
{
    [TestClass]
    public class UserControllerTest
    {
        UserController controller;
        User user;
        [TestInitialize]
        public void Setup()
        {
            controller = new UserController();
            user = new User { UserName = "jyombo", Name = new Name { FamilyName = "Yombo", GivenName = "Jose" } };
            controller.Create(user);
        }
        [TestCleanup]
        public void Cleanup()
        {
            controller.Delete(user.Id);
        }
        [TestMethod]
        public void GetAllWithAttributes()
        {
            var result = controller.GetAll("name").Value;

            Assert.IsTrue(result.Resources.Count > 0);
            Assert.IsNotNull(result.Resources.ElementAt(0).Name);
            Assert.IsNull(result.Resources.ElementAt(0).ExternalId);
            Assert.IsNull(result.Resources.ElementAt(0).UserName);
        }
        [TestMethod]
        public void GetReturns404()
        {
            var result = (ObjectResult) controller.Get("abc").Result;

            Assert.AreEqual(404, result.StatusCode);
        }
        [TestMethod]
        public void CreateFailsOnDuplicate()
        {
            var user = new User { UserName = "jyombo", Name = new Name { FamilyName = "Jose", GivenName = "Yombo" } };

            var result = (ObjectResult) controller.Create(user).Result;

            Assert.AreEqual(StatusCodes.Status409Conflict, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(Error));
        }
        [TestMethod]
        public void Delete()
        {
            var deleteResult = controller.Delete(user.Id).Result;
            var getResult = (ObjectResult) controller.Get(user.Id).Result;

            Assert.IsInstanceOfType(deleteResult, typeof(NoContentResult));
            Assert.AreEqual(404, getResult.StatusCode);
            Assert.IsInstanceOfType(getResult.Value, typeof(Error));
        }
    }
}
