namespace SIMS.Entities.Migrations
{
    using FC.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FC.Entities.FcEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(FC.Entities.FcEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.FC_Users.AddOrUpdate(new FC_Users { Name = "admin", Password = "C4My6XDwIQt1Afc8j4A2gY8PWt9ETmJh2rTDlwWqEDs=", PasswordSalt = "lZXCT1hnX3nMcc1E" });
            //context.SIMS_Department.AddOrUpdate(new SIMS_Department { Name = "Arts" });
            //context.SIMS_Department.AddOrUpdate(new SIMS_Department { Name = "account" });
            //context.SIMS_Department.AddOrUpdate(new SIMS_Department { Name = "commerce" });
            //context.SIMS_Department.AddOrUpdate(new SIMS_Department { Name = "Science"});

            //context.SIMS_Designation.AddOrUpdate(new SIMS_Designation { Name = "Teacher" });
            //context.SIMS_Designation.AddOrUpdate(new SIMS_Designation { Name = "Student" });
            //context.SIMS_Designation.AddOrUpdate(new SIMS_Designation { Name = "Accountant" });

            //context.SIMS_EmployeeType.AddOrUpdate(new SIMS_EmployeeType { Name = "Permanant" });
            //context.SIMS_EmployeeType.AddOrUpdate(new SIMS_EmployeeType { Name = "Contract" });
        }
    }
}
