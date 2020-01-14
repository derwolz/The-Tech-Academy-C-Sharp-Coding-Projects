using ExcelDataReader;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace Excel_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to XLS to DB transfer Program");
            string path = @"C:\Users\Dr Sam Hyde\source\repos\The-Tech-Academy-C-Sharp-Coding-Projects\Excel Reader\Excel Reader\Remote Employees.xls";
            Console.WriteLine("The file is located at \n{0} \n if you want to make changes, please ensure that you don not modify the layout of Remote Employees", path);
            List<EmployeePublicInfo> publicinfos = new List<EmployeePublicInfo>();
            List<PrivateInfo> privateInfos = new List<PrivateInfo>();
            List<WorkInfo> workInfos = new List<WorkInfo>();

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                reader = ExcelReaderFactory.CreateReader(stream);
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };
                var dataSet = reader.AsDataSet(conf);
                var dataTable = dataSet.Tables[0];
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    PrivateInfo privateInfo = new PrivateInfo();
                    WorkInfo workInfo = new WorkInfo();
                    EmployeePublicInfo publicinfo = new EmployeePublicInfo();
                    publicinfo.FirstName = dataTable.Rows[i][0].ToString();
                    publicinfo.LastName = dataTable.Rows[i][1].ToString();
                    privateInfo.SocialSecurity = dataTable.Rows[i][2].ToString();
                    publicinfo.PhoneNumber = dataTable.Rows[i][3].ToString();
                    publicinfo.Address = dataTable.Rows[i][4].ToString();
                    publicinfo.EmailAddress = dataTable.Rows[i][5].ToString();
                    privateInfo.DateofBirth = (DateTime)dataTable.Rows[i][6];
                    workInfo.DateHired = (DateTime)dataTable.Rows[i][7];
                    workInfo.Department = dataTable.Rows[i][8].ToString();
                    workInfo.HourlyRate = double.Parse(dataTable.Rows[i][9].ToString());
                    publicinfos.Add(publicinfo);
                    workInfos.Add(workInfo);
                    privateInfos.Add(privateInfo);
                }
                


            };
            Console.WriteLine("random sampling ....");
            foreach (var person in publicinfos)
            {
                Console.WriteLine(person.FirstName);
            }
            Console.ReadLine();
            try
            {
                using (var ctx = new EmployeesdB())
                {
                    foreach (var info in publicinfos)
                        ctx.publicInfos.Add(info);
                    foreach (var info in workInfos)
                        ctx.workInfos.Add(info);
                    foreach (var info in privateInfos)
                        ctx.privateInfos.Add(info);
                    ctx.SaveChanges();
                }

            } catch (FormatException)
            {
                Console.WriteLine("Formatting was wrong please correct error and try again");
                return;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null encountered in non nullable field");
            }
            finally
            {
                using (EmployeesdB db = new EmployeesdB())
                {
                    var query = (from c in db.publicInfos join d in db.privateInfos on c.Id equals d.privateInfoId
                                select new
                                {
                                    c.FirstName,
                                    c.LastName,
                                    d.SocialSecurity
                                }
                                 ).ToList();
                    foreach (var person in query)
                    {
                        Console.WriteLine("{0} {1} has a social of {2}", person.FirstName, person.LastName, person.SocialSecurity);
                    }
                    Console.WriteLine("Thank you for using the xls transfer system. If it gets too crowded just drop the tables");
                    Console.ReadLine();
                }
                
            }
            
        }
    }
    
}
