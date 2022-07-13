namespace ImageAndTextToDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artworks", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artworks", "Category");
        }
    }
}
