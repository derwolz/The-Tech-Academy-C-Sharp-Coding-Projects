using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Reader
{
    public class WorkInfo
    {
        public int WorkInfoId { get; set; }
        public DateTime DateHired { get; set; }
        public string Department { get; set; }
        public double HourlyRate { get; set; }
        public ICollection<EmployeePublicInfo> PublicInfo { get; set; }
    }
}
