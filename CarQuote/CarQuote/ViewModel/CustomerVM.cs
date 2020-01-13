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

        public int GetQuote()
        {
            int Quote = 50;
            if (Birthday > DateTime.Now.AddYears(-25)) Quote += 25;
            if (Birthday > DateTime.Now.AddYears(-18)) Quote += 100;
            if (Birthday < DateTime.Now.AddYears(-100)) Quote += 100;
        }
    }
}