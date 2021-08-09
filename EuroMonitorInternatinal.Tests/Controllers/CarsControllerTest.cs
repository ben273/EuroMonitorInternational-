using System;
using System.Web.Mvc;
using EuroMonitorInternatinal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuroMonitorInternatinal.Tests.Controllers
{
    [TestClass]
    public class CarsControllerTest
    {
        [TestMethod]
        public void GetModelSales()
        {
            CarsController cars = new CarsController();
            ViewResult result = cars.GetModelSales() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAverage()
        {
            CarsController cars = new CarsController();
            ViewResult result = cars.GetAverage() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void GetManufacturer()
        {
            CarsController cars = new CarsController();
            ViewResult result = cars.GetManufacturerSales() as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]

        public void GetMostCommonColour()
        {
            CarsController cars = new CarsController();
            ViewResult result = cars.GetMostCommonColour() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
