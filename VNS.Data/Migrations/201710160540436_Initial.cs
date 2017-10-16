namespace VNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Location = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
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
                        Region = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
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
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Municipality_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipalities", t => t.Municipality_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Municipality_Id);
            
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
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Address_Id = c.Guid(),
                        Family_Id = c.Guid(),
                        Visit_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .ForeignKey("dbo.Visits", t => t.Visit_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Address_Id)
                .Index(t => t.Family_Id)
                .Index(t => t.Visit_Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(),
                        UserName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
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
                        CreatedOn = c.DateTime(nullable: false),
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
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        UserName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                        Family_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Family_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "Visit_Id", "dbo.Visits");
            DropForeignKey("dbo.Visits", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Children", "Father_Id", "dbo.FamilyMembers");
            DropForeignKey("dbo.Children", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.FamilyMembers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Municipality_Id", "dbo.Municipalities");
            DropForeignKey("dbo.Towns", "Municipality_Id", "dbo.Municipalities");
            DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            DropIndex("dbo.Visits", new[] { "Family_Id" });
            DropIndex("dbo.Visits", new[] { "IsDeleted" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "IsDeleted" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Children", new[] { "Father_Id" });
            DropIndex("dbo.Children", new[] { "Family_Id" });
            DropIndex("dbo.Children", new[] { "IsDeleted" });
            DropIndex("dbo.Families", new[] { "IsDeleted" });
            DropIndex("dbo.FamilyMembers", new[] { "Visit_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Address_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "IsDeleted" });
            DropIndex("dbo.Towns", new[] { "Municipality_Id" });
            DropIndex("dbo.Towns", new[] { "IsDeleted" });
            DropIndex("dbo.Municipalities", new[] { "IsDeleted" });
            DropIndex("dbo.Addresses", new[] { "Municipality_Id" });
            DropIndex("dbo.Addresses", new[] { "Town_Id" });
            DropIndex("dbo.Addresses", new[] { "IsDeleted" });
            DropTable("dbo.Visits");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Children");
            DropTable("dbo.Families");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Towns");
            DropTable("dbo.Municipalities");
            DropTable("dbo.Addresses");
        }
    }
}
