using System;
using System.Collections.Generic;
using System.Text;

namespace Excel_Reader
{
    public class EmployeePublicInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }

        public WorkInfo Work { get; set; }
        public PrivateInfo PrivateInfo { get; set; }
    }
}
