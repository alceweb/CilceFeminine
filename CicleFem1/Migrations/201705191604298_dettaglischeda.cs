namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dettaglischeda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DettaglioSchedas", "Ematic", c => c.Int());
            AddColumn("dbo.DettaglioSchedas", "Muco", c => c.Int());
            AddColumn("dbo.DettaglioSchedas", "MucoC", c => c.String());
            AddColumn("dbo.DettaglioSchedas", "Coito", c => c.String());
            AddColumn("dbo.DettaglioSchedas", "UteCon", c => c.String());
            AddColumn("dbo.DettaglioSchedas", "UteInc", c => c.String());
            AddColumn("dbo.DettaglioSchedas", "UteApe", c => c.String());
            AddColumn("dbo.DettaglioSchedas", "UtePos", c => c.String());
            AddColumn("dbo.DettaglioSchedas", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DettaglioSchedas", "Note");
            DropColumn("dbo.DettaglioSchedas", "UtePos");
            DropColumn("dbo.DettaglioSchedas", "UteApe");
            DropColumn("dbo.DettaglioSchedas", "UteInc");
            DropColumn("dbo.DettaglioSchedas", "UteCon");
            DropColumn("dbo.DettaglioSchedas", "Coito");
            DropColumn("dbo.DettaglioSchedas", "MucoC");
            DropColumn("dbo.DettaglioSchedas", "Muco");
            DropColumn("dbo.DettaglioSchedas", "Ematic");
        }
    }
}
