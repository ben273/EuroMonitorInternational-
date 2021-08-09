using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroMonitorInternatinal.Models;

namespace EuroMonitorInternatinal.Controllers
{
    public class CarsController : Controller
    {

        // For each string in the 'elements' variable, create a new SelectListItem object
        // that has both its Value and Text properties set to a particular value.
        // This will result in MVC rendering each item as:
        // <option value="State Name">State Name</option>
        // Create an empty list to hold result of the operation

        public ActionResult GetModelSales()
        {

            try
            {
                EuroCarsEntities db = new EuroCarsEntities();
                List<SelectListItem> items = new List<SelectListItem>();
                var cars = db.Cars.Where(x => x.id > 0);
                if (cars != null)
                {


                    foreach (var sales in cars)
                    {
                        var total = db.SalesHistories.Where(x => x.CarsId == sales.id && x.Year != null);
                        items.Add(new SelectListItem
                        {
                            Text = sales.model,
                            Value = total.Sum(x => x.VehiclesSold).ToString()
                        });

                    }
                }
                return View(items);
            }
            catch (Exception ex)
            {
                return View(ex.StackTrace);
            }

        }


        public ActionResult GetManufacturerSales()
        {
            try
            {

                EuroCarsEntities db = new EuroCarsEntities();

                List<SelectListItem> items = new List<SelectListItem>();
                var cars = from sale in db.SalesHistories
                           join car in db.Cars on sale.CarsId equals car.id
                           where sale.Year != null
                           group sale by car.Manufacturer;

                foreach (var sales in cars)
                {

                    items.Add(new SelectListItem
                    {
                        Text = sales.Key,
                        Value = sales.Sum(x => x.VehiclesSold).ToString()

                    }); ;
                }
                return View(items);
            }
            catch (Exception ex)
            {

                return View(ex.StackTrace);
            }

        }

        public ActionResult GetAverage()
        {
            try
            {
                int? sum = 0;
                EuroCarsEntities db = new EuroCarsEntities();
                var cars = db.Cars.GroupBy(x => x.Manufacturer).Count();
                var query = (from sale in db.SalesHistories
                             where sale.CarsId != null && sale.Year != null
                             select sale.VehiclesSold) ;
                {

                    sum = query.Sum();
                    ViewBag.Average = sum / cars;
                }
                return View();
            }
            catch (Exception ex)
            {

                return View(ex.StackTrace);
            }
        }

        public ActionResult GetMostCommonColour()
        {
            try
            {
                EuroCarsEntities db = new EuroCarsEntities();
                var cars = (from car in db.Cars                            
                            group car by car into grp                           
                            orderby grp.Count() descending
                            select grp.Key).First();
                {
                    ViewBag.colour = cars.colour;
                }
                return View();
            }
            catch (Exception ex)
            {

                return View(ex.StackTrace);
            }
        }
    }
}