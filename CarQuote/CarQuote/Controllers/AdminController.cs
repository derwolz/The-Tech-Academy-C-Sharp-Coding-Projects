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

                
                foreach (var person in (from c in db.Customers
                                        join d in db.CustomerCars on c.Id equals d.CustomerId
                                        join e in db.CustomerRecords on c.Id equals e.CustomerId
                                        select new
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
                                        }).ToList())
                {
                    CustomerVM Customer = new CustomerVM
                    {
                        Birthday = (DateTime)person.DateofBirth,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        EmailAddress = person.EmailAddress,
                        CarMake = person.Make,
                        CarModel = person.Model,
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