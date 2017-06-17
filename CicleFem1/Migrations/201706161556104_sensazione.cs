namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sensazione : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DettaglioSchedas", "Sensazione", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DettaglioSchedas", "Sensazione");
        }
    }
}
