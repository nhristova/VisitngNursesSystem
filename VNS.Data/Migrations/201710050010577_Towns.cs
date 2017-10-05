namespace VNS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Towns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Municipalities", "Region", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Municipalities", "Region");
        }
    }
}
