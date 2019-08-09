namespace CarRentalMVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
        }
        
        public override void Down()
        {
        }
    }
}
