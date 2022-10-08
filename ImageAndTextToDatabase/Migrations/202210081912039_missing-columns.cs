namespace ImageAndTextToDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missingcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artworks", "Author", c => c.String());
            AddColumn("dbo.Artworks", "Collections", c => c.String());
            AddColumn("dbo.Artworks", "Date", c => c.String());
            AddColumn("dbo.Artworks", "ISBN", c => c.String());
            AddColumn("dbo.Artworks", "Publisher", c => c.String());
            AddColumn("dbo.Artworks", "Title", c => c.String());
            AddColumn("dbo.Artworks", "Year", c => c.String());
            AddColumn("dbo.Artworks", "Reprints", c => c.String());
            AddColumn("dbo.Artworks", "Datemax", c => c.String());
            AddColumn("dbo.Artworks", "Datemin", c => c.String());
            AddColumn("dbo.Artworks", "medriinfo", c => c.String());
            AddColumn("dbo.Artworks", "Bio2", c => c.String());
            AddColumn("dbo.Artworks", "Biography", c => c.String());
            AddColumn("dbo.Artworks", "Book_about", c => c.String());
            AddColumn("dbo.Artworks", "Born", c => c.String());
            AddColumn("dbo.Artworks", "Dead", c => c.String());
            AddColumn("dbo.Artworks", "First_Name", c => c.String());
            AddColumn("dbo.Artworks", "Full_name", c => c.String());
            AddColumn("dbo.Artworks", "Last_name", c => c.String());
            AddColumn("dbo.Artworks", "Catalogue", c => c.String());
            AddColumn("dbo.Artworks", "City", c => c.String());
            AddColumn("dbo.Artworks", "Commercial", c => c.String());
            AddColumn("dbo.Artworks", "Curator", c => c.String());
            AddColumn("dbo.Artworks", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtworkImages", "ArtworkId", "dbo.Artworks");
            DropIndex("dbo.ArtworkImages", new[] { "ArtworkId" });
            DropColumn("dbo.Artworks", "Location");
            DropColumn("dbo.Artworks", "Curator");
            DropColumn("dbo.Artworks", "Commercial");
            DropColumn("dbo.Artworks", "City");
            DropColumn("dbo.Artworks", "Catalogue");
            DropColumn("dbo.Artworks", "Last_name");
            DropColumn("dbo.Artworks", "Full_name");
            DropColumn("dbo.Artworks", "First_Name");
            DropColumn("dbo.Artworks", "Dead");
            DropColumn("dbo.Artworks", "Born");
            DropColumn("dbo.Artworks", "Book_about");
            DropColumn("dbo.Artworks", "Biography");
            DropColumn("dbo.Artworks", "Bio2");
            DropColumn("dbo.Artworks", "medriinfo");
            DropColumn("dbo.Artworks", "Datemin");
            DropColumn("dbo.Artworks", "Datemax");
            DropColumn("dbo.Artworks", "Reprints");
            DropColumn("dbo.Artworks", "Year");
            DropColumn("dbo.Artworks", "Title");
            DropColumn("dbo.Artworks", "Publisher");
            DropColumn("dbo.Artworks", "ISBN");
            DropColumn("dbo.Artworks", "Date");
            DropColumn("dbo.Artworks", "Collections");
            DropColumn("dbo.Artworks", "Author");
        }
    }
}
