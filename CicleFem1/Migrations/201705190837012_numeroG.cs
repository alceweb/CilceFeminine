namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numeroG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedas", "NumeroG", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedas", "NumeroG");
        }
    }
}
