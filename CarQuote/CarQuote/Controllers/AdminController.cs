using CarQuote.Models;
using CarQuote.ViewModel;
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
                var signups = (from c in db.Customers join d in db.CustomerCars on c.Id equals d.CustomerId 
                               join e in db.CustomerRecords on c.Id equals e.CustomerId select  new
                               {
                                   c.FirstName,
                                   c.LastName,
                                   c.EmailAddress,
                                   c.DateofBirth,
                                   d.CarYear,
                                   d.Make,
                                   d.Model,
                                   e.DUI,
                                   e.FullCoverage,
                                   e.NumofTicket
                               });
                
                CustomerVM Customer = new CustomerVM();
                foreach (var person in signups)
                {
                    
                    Customer.Birthday = (DateTime)person.DateofBirth;
                    Customer.FirstName = person.FirstName;
                    Customer.LastName = person.LastName;
                    Customer.EmailAddress = person.EmailAddress;
                    Customer.CarMake = person.Make;
                    Customer.CarModel = person.Model;
                    Customer.CarYear = person.CarYear;
                    Customer.DUI = person.DUI;
                    Customer.FullCoverage = person.FullCoverage;
                    Customer.NumofTicket = person.NumofTicket;
                    Customers.Add(Customer);
                }


                return View(Customers);
            }
            
        }
    }
}