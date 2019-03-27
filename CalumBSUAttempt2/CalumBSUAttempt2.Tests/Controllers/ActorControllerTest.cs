using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CalumBSUAttempt2.Controllers;

namespace CalumBSUAttempt2.Tests.Controllers
{
    [TestClass]
    public class ActorControllerTest
    {
        [TestMethod]
        public void Actors()
        {
            //arrange
            ActorsController controller = new ActorsController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
