namespace CicleFem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class osservatori : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Osservatoris",
                c => new
                    {
                        Osservatore_Id = c.Int(nullable: false, identity: true),
                        TipoOsservatore = c.String(),
                        Uid = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Osservatore_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Osservatoris", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Osservatoris", new[] { "Id" });
            DropTable("dbo.Osservatoris");
        }
    }
}
