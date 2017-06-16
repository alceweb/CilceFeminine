namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class giornoetemp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DettaglioSchedas", "Giorno", c => c.Int());
            AlterColumn("dbo.DettaglioSchedas", "Temperatura", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DettaglioSchedas", "Temperatura", c => c.Double(nullable: false));
            AlterColumn("dbo.DettaglioSchedas", "Giorno", c => c.Int(nullable: false));
        }
    }
}
