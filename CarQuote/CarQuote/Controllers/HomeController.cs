using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarQuote.Models;

namespace CarQuote.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string fname, string lname,string email, DateTime dob, int year, string make, string carmodel, bool coverage, bool dui, int? ticket)
        {
            if (fname != "" || lname != "" || email != null || year <= DateTime.Today.Year || year > DateTime.Today.AddYears(-130).Year || carmodel != "" || make != "" ) //check for null values
            {
                if (ticket == null) ticket = 0;

                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    string NewId = Guid.NewGuid().ToString();

                    var signUpCustomer = new Customer();            //Mapping objects instantiated for all three tables
                    var signupCar = new CustomerCar();
                    var signupRecord = new CustomerRecord();
                    signUpCustomer.DateofBirth = dob;
                    signUpCustomer.EmailAddress = email;
                    signUpCustomer.FirstName = fname;
                    signUpCustomer.LastName = lname;
                    
                    signupCar.CarMake = make;
                    signupCar.CarModel = carmodel;
                    signupCar.CarYear = year;
                    signupRecord.DUI = dui;
                    signupRecord.FullCoverage = coverage;
                    signupRecord.NumofTicket = (int)ticket;
                    signUpCustomer.Id = NewId;
                    signupCar.CustomerId = NewId;
                    signupRecord.CustomerId = NewId;

                    db.Customers.Add(signUpCustomer);
                    db.CustomerCars.Add(signupCar);
                    db.CustomerRecords.Add(signupRecord);
                    db.SaveChanges();
                }
            } else
            {
                return RedirectToAction(@"~/views/Shared/Error.cshtml");
            }
            return View("Success");

        }
    }
}