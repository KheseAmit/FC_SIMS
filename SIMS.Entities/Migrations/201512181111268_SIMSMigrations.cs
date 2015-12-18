namespace SIMS.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIMSMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FC_Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        PasswordSalt = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SIMS_Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SIMS_Designation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SIMS_Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        DesignationId = c.Int(),
                        Experience = c.String(),
                        Qualification = c.String(),
                        EmployeeTypeId = c.Int(),
                        ContactNumber = c.String(),
                        EmailId = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FC_Users", t => t.CreatedBy)
                .ForeignKey("dbo.FC_Users", t => t.UpdatedBy)
                .ForeignKey("dbo.SIMS_Department", t => t.DepartmentId)
                .ForeignKey("dbo.SIMS_Designation", t => t.DesignationId)
                .ForeignKey("dbo.SIMS_EmployeeType", t => t.EmployeeTypeId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId)
                .Index(t => t.EmployeeTypeId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.SIMS_EmployeeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SIMS_Employee", "EmployeeTypeId", "dbo.SIMS_EmployeeType");
            DropForeignKey("dbo.SIMS_Employee", "DesignationId", "dbo.SIMS_Designation");
            DropForeignKey("dbo.SIMS_Employee", "DepartmentId", "dbo.SIMS_Department");
            DropForeignKey("dbo.SIMS_Employee", "UpdatedBy", "dbo.FC_Users");
            DropForeignKey("dbo.SIMS_Employee", "CreatedBy", "dbo.FC_Users");
            DropIndex("dbo.SIMS_Employee", new[] { "UpdatedBy" });
            DropIndex("dbo.SIMS_Employee", new[] { "CreatedBy" });
            DropIndex("dbo.SIMS_Employee", new[] { "EmployeeTypeId" });
            DropIndex("dbo.SIMS_Employee", new[] { "DesignationId" });
            DropIndex("dbo.SIMS_Employee", new[] { "DepartmentId" });
            DropTable("dbo.SIMS_EmployeeType");
            DropTable("dbo.SIMS_Employee");
            DropTable("dbo.SIMS_Designation");
            DropTable("dbo.SIMS_Department");
            DropTable("dbo.FC_Users");
        }
    }
}
