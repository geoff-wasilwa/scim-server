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
    public class GroupControllerTest
    {
        GroupController controller;
        [TestInitialize]
        public void Initialize()
        {
            controller = new GroupController();
        }
        [TestMethod]
        public void GetAllGroups()
        {
            var result = controller.GetAll().Value;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Resources.Count > 0);
        }
        [TestMethod]
        public void GetKnowGroup()
        {
            var result = controller.Get("e9e30dba-f08f-4109-8486-d5c6a331660a").Value;

            Assert.IsNotNull(result);
            Assert.AreEqual("Tour Guides", result.DisplayName);
            Assert.AreEqual(2, result.Members.Length);
        }
        [TestMethod]
        public void Delete()
        {
            var group = new Group { DisplayName = "Rangers" };
            controller.Create(group);

            var deleteResult = controller.Delete(group.Id).Result;
            //var getResult = (ObjectResult)controller.Get(group.Id).Result;

            Assert.IsInstanceOfType(deleteResult, typeof(NoContentResult));
            //Assert.AreEqual(404, getResult.StatusCode);
            //Assert.IsInstanceOfType(getResult.Value, typeof(Error));
        }
    }
}
