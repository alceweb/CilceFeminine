namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedas", "Numero", c => c.Int());
            AlterColumn("dbo.Schedas", "DataF", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedas", "DataF", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedas", "Numero", c => c.Int(nullable: false));
        }
    }
}
