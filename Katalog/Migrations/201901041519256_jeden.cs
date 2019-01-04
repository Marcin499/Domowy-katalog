namespace Katalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jeden : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BazaFilmów",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tytuł = c.String(),
                        Reżyseria = c.String(),
                        Wytwórnia = c.String(),
                        DataPremiery = c.DateTime(nullable: false),
                        Gatunek = c.String(),
                        CzasTrwania = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BazaFilmów");
        }
    }
}
