namespace ImageAndTextToDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missingcolumns2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artworks", "Categoryofobject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artworks", "Categoryofobject");
        }
    }
}
