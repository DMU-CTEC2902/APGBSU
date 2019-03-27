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
    public class FilmControllerTest
    {
        [TestMethod]
        public void Films()
        {
            //arrange
            FilmsController controller = new FilmsController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
