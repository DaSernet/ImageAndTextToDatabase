namespace ImageAndTextToDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Missinginfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artworks", "Medrskinfo", c => c.String());
            AddColumn("dbo.Artworks", "Seedpodsinfo", c => c.String());
            AddColumn("dbo.Artworks", "Coordinates", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Artworks", "Coordinates");
            DropColumn("dbo.Artworks", "Seedpodsinfo");
            DropColumn("dbo.Artworks", "Medrskinfo");
        }
    }
}