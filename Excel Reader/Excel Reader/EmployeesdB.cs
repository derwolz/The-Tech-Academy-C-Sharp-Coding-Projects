namespace Excel_Reader
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeesdB : DbContext
    {
        public EmployeesdB()
            : base("name=EmployeesdB")
        {
            
        }
        public DbSet<EmployeePublicInfo> publicInfos {get; set;}
        public DbSet<PrivateInfo> privateInfos { get; set; }
        public DbSet<WorkInfo> workInfos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
