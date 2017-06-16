namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prima : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DettaglioSchedas",
                c => new
                    {
                        DettaglioScheda_Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Giorno = c.Int(nullable: false),
                        Temperatura = c.Double(nullable: false),
                        Scheda_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DettaglioScheda_Id)
                .ForeignKey("dbo.Schedas", t => t.Scheda_Id, cascadeDelete: true)
                .Index(t => t.Scheda_Id);
            
            CreateTable(
                "dbo.Schedas",
                c => new
                    {
                        Scheda_Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        DataI = c.DateTime(nullable: false),
                        DataF = c.DateTime(nullable: false),
                        Uid = c.String(),
                    })
                .PrimaryKey(t => t.Scheda_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioSchedas", "Scheda_Id", "dbo.Schedas");
            DropIndex("dbo.DettaglioSchedas", new[] { "Scheda_Id" });
            DropTable("dbo.Schedas");
            DropTable("dbo.DettaglioSchedas");
        }
    }
}
