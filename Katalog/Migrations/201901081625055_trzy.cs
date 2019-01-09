namespace Katalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trzy : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BazaKsiążki");
            AlterColumn("dbo.BazaKsiążki", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.BazaKsiążki", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BazaKsiążki");
            AlterColumn("dbo.BazaKsiążki", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BazaKsiążki", "Id");
        }
    }
}
