namespace ChildhoodMinistry.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Children", "ChildhoodId");
            AddForeignKey("dbo.Children", "ChildhoodId", "dbo.Childhoods", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "ChildhoodId", "dbo.Childhoods");
            DropIndex("dbo.Children", new[] { "ChildhoodId" });
        }
    }
}
