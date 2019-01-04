namespace Katalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dwa : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BazaFilmów", newName: "BazaFilmies");
            CreateTable(
                "dbo.BazaKsiążki",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tytuł = c.String(),
                        Autor = c.String(),
                        Wydawnictwo = c.String(),
                        DataWydania = c.DateTime(nullable: false),
                        Gatunek = c.String(),
                        SłowaKlucze = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BazaMuzykas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tytuł = c.String(),
                        Autor = c.String(),
                        Wytwórnia = c.String(),
                        DataPremiery = c.DateTime(nullable: false),
                        Gatunek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BazaFilmówWypożyczenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imię = c.String(),
                        Nazwisko = c.String(),
                        Tytuł = c.String(),
                        DataWypozyczenia = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BazaKsiążekWypożyczenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imię = c.String(),
                        Nazwisko = c.String(),
                        Tytuł = c.String(),
                        DataWypozyczenia = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BazaMuzykiWypożyczenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imię = c.String(),
                        Nazwisko = c.String(),
                        Tytuł = c.String(),
                        DataWypozyczenia = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BazaMuzykiWypożyczenie");
            DropTable("dbo.BazaKsiążekWypożyczenie");
            DropTable("dbo.BazaFilmówWypożyczenie");
            DropTable("dbo.BazaMuzykas");
            DropTable("dbo.BazaKsiążki");
            RenameTable(name: "dbo.BazaFilmies", newName: "BazaFilmów");
        }
    }
}
