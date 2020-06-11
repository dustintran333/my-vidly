namespace my_vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            DropTable("dbo.Class1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Class1",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
