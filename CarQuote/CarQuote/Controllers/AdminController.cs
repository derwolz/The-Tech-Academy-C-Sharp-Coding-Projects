using CarQuote.Models;
using CarQuote.ViewModel;
using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarQuote.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                
                List<CustomerVM> Customers = new List<CustomerVM>();

                var persons = (from c in db.Customers                       //create Table object joined with CustomerCars and CustomerRecords
                               join d in db.CustomerCars on c.Id equals d.CustomerId
                               join e in db.CustomerRecords on c.Id equals e.CustomerId
                               select new
                {
                    c.FirstName,
                    c.LastName,
                    c.EmailAddress,
                    c.DateofBirth,
                    d.CarYear,
                    d.CarMake,
                    d.CarModel,
                    e.DUI,
                    e.FullCoverage,
                    e.NumofTicket,
                    person = c.Id
                }).ToList();
                
                foreach (var person in persons)                             //Iterate through the table mapping it to View Model Object
                {
                    CustomerVM Customer = new CustomerVM
                    {
                        Birthday = (DateTime)person.DateofBirth,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        EmailAddress = person.EmailAddress,
                        CarMake = person.CarMake,
                        CarModel = person.CarModel,
                        CarYear = person.CarYear,
                        DUI = person.DUI,
                        FullCoverage = person.FullCoverage,
                        NumofTicket = person.NumofTicket
                    };
                    Customers.Add(Customer);
                }


                return View(Customers);
            }
            
        }
    }
}