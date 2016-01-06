using SIMS.Entities;

namespace FC.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FcEntities : DbContext
    {
        // Your context has been configured to use a 'FcEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FC.Entities.FcEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FcEntities' 
        // connection string in the application configuration file.
        public FcEntities()
            : base("name=FCEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<FC_Users> FC_Users { get; set; }
        public virtual DbSet<FC_Supplier> FC_Supplier { get; set; }
        public virtual DbSet<FC_Product> FC_Product { get; set; }
        public virtual DbSet<FC_ProductType> FC_ProductType { get; set; }
        public virtual DbSet<FC_Manufacture> FC_Manufacture { get; set; }
        public virtual DbSet<SIMS_Designation> SIMS_Designation { get; set; }
        public virtual DbSet<SIMS_Employee> SIMS_Employee { get; set; }
        public virtual DbSet<SIMS_EmployeeType> SIMS_EmployeeType { get; set; }

 
    }
}