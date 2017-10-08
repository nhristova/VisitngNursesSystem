namespace VNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonNullableDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Municipalities", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Towns", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FamilyMembers", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Families", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Children", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Visits", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Children", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Families", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.FamilyMembers", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Towns", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Municipalities", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Addresses", "CreatedOn", c => c.DateTime());
        }
    }
}
