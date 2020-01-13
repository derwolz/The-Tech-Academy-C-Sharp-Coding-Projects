using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
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
        public ActionResult SignUp(string fname, string lname,string email, DateTime dob, int year, string make, string carmodel, bool coverage, bool dui, int ticket)
        {
            if (fname != "" || lname != "" || email != null || year <= DateTime.Today.Year || carmodel != "" || make != "" )
            {
                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    var signUpCustomer = new Customer();
                    var signupCar = new CustomerCar();
                    var signupRecord = new CustomerRecord();
                    signUpCustomer.DateofBirth = dob;
                    signUpCustomer.EmailAddress = email;
                    signUpCustomer.FirstName = fname;
                    signUpCustomer.LastName = lname;
                    signupCar.Make = make;
                    signupCar.Model = carmodel;
                    signupCar.CarYear = year;
                    signupRecord.DUI = dui;
                    signupRecord.FullCoverage = coverage;
                    signupRecord.NumofTicket = ticket;
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