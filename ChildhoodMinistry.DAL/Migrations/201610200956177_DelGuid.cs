namespace ChildhoodMinistry.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelGuid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Childhoods", "guid");
            DropColumn("dbo.Children", "guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "guid", c => c.String());
            AddColumn("dbo.Childhoods", "guid", c => c.String());
        }
    }
}
