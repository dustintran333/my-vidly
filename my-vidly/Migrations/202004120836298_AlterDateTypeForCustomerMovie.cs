namespace my_vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDateTypeForCustomerMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(maxLength: 50));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "BirthDay", c => c.String(maxLength: 10));
        }
    }
}
