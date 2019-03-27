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
    public class DirectorControllerTest
    {
        [TestMethod]
        public void Director()
        {
            //arrange
            DirectorsController controller = new DirectorsController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
