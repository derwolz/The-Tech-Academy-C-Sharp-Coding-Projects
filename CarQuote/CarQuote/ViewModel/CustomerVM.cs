using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQuote.ViewModel
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string EmailAddress { get; set; }
        public bool FullCoverage { get; set; }
        public bool DUI { get; set; }
        public int NumofTicket { get; set; }

        public double GetQuote()
        {
            double Quote = 50f;
            if (Birthday > DateTime.Now.AddYears(-25)) Quote += 25;
            if (Birthday > DateTime.Now.AddYears(-18)) Quote += 100;
            if (Birthday < DateTime.Now.AddYears(-100)) Quote += 100;
            if (CarYear < 200) Quote += 25;
            if (CarMake.ToLower() == "porsche") Quote += 25;
            if (CarMake.ToLower() == "porsche" && CarModel == "911 Carrera") Quote += 25;
            for (int i = 0; i < NumofTicket; i++) Quote += 10;
            if (DUI == true) Quote *= 1.25;
            if (FullCoverage == true) Quote *= 1.5;
            return Quote;
        }
    }
}