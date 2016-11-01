namespace ChildhoodMinistry.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class GenericRep : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Childhoods", "Adress", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "Patronymic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Children", "Patronymic", c => c.String());
            AlterColumn("dbo.Children", "Surname", c => c.String());
            AlterColumn("dbo.Children", "Name", c => c.String());
            AlterColumn("dbo.Childhoods", "Adress", c => c.String());
        }
    }
}
