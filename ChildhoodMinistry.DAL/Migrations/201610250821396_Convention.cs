namespace ChildhoodMinistry.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Convention : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Childhoods", "Adress", c => c.String());
            AlterColumn("dbo.Children", "Name", c => c.String());
            AlterColumn("dbo.Children", "Surname", c => c.String());
            AlterColumn("dbo.Children", "Patronymic", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Children", "Patronymic", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Childhoods", "Adress", c => c.String(nullable: false));
        }
    }
}
