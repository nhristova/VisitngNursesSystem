namespace VNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datamodels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Visits", name: "Nurse_Id", newName: "VisitingNurse_Id");
            RenameIndex(table: "dbo.Visits", name: "IX_Nurse_Id", newName: "IX_VisitingNurse_Id");
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        AssignedNurse_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedNurse_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.AssignedNurse_Id);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Family_Id = c.Guid(),
                        Father_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .ForeignKey("dbo.FamilyMembers", t => t.Father_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Family_Id)
                .Index(t => t.Father_Id);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Address_Id = c.Guid(),
                        Family_Id = c.Guid(),
                        Nurse_Id = c.String(maxLength: 128),
                        Visit_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Nurse_Id)
                .ForeignKey("dbo.Visits", t => t.Visit_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Address_Id)
                .Index(t => t.Family_Id)
                .Index(t => t.Nurse_Id)
                .Index(t => t.Visit_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Location = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Town_Id = c.Guid(),
                        Municipality_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id)
                .ForeignKey("dbo.Municipalities", t => t.Municipality_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Town_Id)
                .Index(t => t.Municipality_Id);
            
            CreateTable(
                "dbo.Municipalities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Municipality_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipalities", t => t.Municipality_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Municipality_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.Visits", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Visits", "Family_Id", c => c.Guid());
            CreateIndex("dbo.Visits", "Family_Id");
            AddForeignKey("dbo.Visits", "Family_Id", "dbo.Families", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "Visit_Id", "dbo.Visits");
            DropForeignKey("dbo.Visits", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Children", "Father_Id", "dbo.FamilyMembers");
            DropForeignKey("dbo.FamilyMembers", "Nurse_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Municipality_Id", "dbo.Municipalities");
            DropForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities");
            DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Children", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Families", "AssignedNurse_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Visits", new[] { "Family_Id" });
            DropIndex("dbo.Towns", new[] { "Municipality_Id" });
            DropIndex("dbo.Towns", new[] { "IsDeleted" });
            DropIndex("dbo.Municipalities", new[] { "IsDeleted" });
            DropIndex("dbo.Addresses", new[] { "Municipality_Id" });
            DropIndex("dbo.Addresses", new[] { "Town_Id" });
            DropIndex("dbo.Addresses", new[] { "IsDeleted" });
            DropIndex("dbo.FamilyMembers", new[] { "Visit_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Nurse_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Address_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "IsDeleted" });
            DropIndex("dbo.Children", new[] { "Father_Id" });
            DropIndex("dbo.Children", new[] { "Family_Id" });
            DropIndex("dbo.Children", new[] { "IsDeleted" });
            DropIndex("dbo.Families", new[] { "AssignedNurse_Id" });
            DropIndex("dbo.Families", new[] { "IsDeleted" });
            DropColumn("dbo.Visits", "Family_Id");
            DropColumn("dbo.Visits", "Type");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Towns");
            DropTable("dbo.Municipalities");
            DropTable("dbo.Addresses");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Children");
            DropTable("dbo.Families");
            RenameIndex(table: "dbo.Visits", name: "IX_VisitingNurse_Id", newName: "IX_Nurse_Id");
            RenameColumn(table: "dbo.Visits", name: "VisitingNurse_Id", newName: "Nurse_Id");
        }
    }
}
