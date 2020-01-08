namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewPropertyConfirm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmPickup", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConfirmPickup");
        }
    }
}
