namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertychangeonemployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "SearchDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "SearchDate");
        }
    }
}
