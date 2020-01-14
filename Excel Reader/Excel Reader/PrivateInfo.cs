using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Reader
{
    public class PrivateInfo
    {
        public int privateInfoId { get; set; }
        public string SocialSecurity { get; set; }
        public DateTime DateofBirth { get; set; }
        public ICollection<EmployeePublicInfo> PublicInfo { get; set; }
    }
}
