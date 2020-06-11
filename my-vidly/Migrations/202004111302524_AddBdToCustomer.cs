namespace my_vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBdToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDay");
        }
    }
}
