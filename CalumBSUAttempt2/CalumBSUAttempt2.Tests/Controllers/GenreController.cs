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
    public class GenreController
    {
        [TestMethod]
        public void Genre()
        {
            //arrange
            GenreController controller = new GenreController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
