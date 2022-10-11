namespace ImageAndTextToDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreation2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtworkImages",
                c => new
                    {
                        ArtworkImageId = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        ImageSize = c.String(),
                        ArtworkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtworkImageId)
                .ForeignKey("dbo.Artworks", t => t.ArtworkId, cascadeDelete: true)
                .Index(t => t.ArtworkId);
            
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        ArtworkId = c.Int(nullable: false, identity: true),
                        Acquiredfrom = c.String(),
                        Acquisitiondate = c.String(),
                        Additionalfeatures = c.String(),
                        Artist = c.String(),
                        Artistgender = c.String(),
                        Artistsg = c.String(),
                        Associatefeatures = c.String(),
                        Auctions = c.String(),
                        Calabashinfo = c.String(),
                        Certificate = c.String(),
                        Chefferie = c.String(),
                        Clan = c.String(),
                        Collectedby = c.String(),
                        Collectedwhen = c.String(),
                        Collection = c.String(),
                        Commanditaire = c.String(),
                        Comments = c.String(),
                        Commgender = c.String(),
                        Commonfeatures = c.String(),
                        Commsg = c.String(),
                        Condition = c.String(),
                        Confidential = c.String(),
                        Country = c.String(),
                        Createdate = c.String(),
                        Createdatemax = c.String(),
                        Createdatemin = c.String(),
                        Creditline = c.String(),
                        Depth = c.String(),
                        Diameter = c.String(),
                        Donationfrom = c.String(),
                        Ethnicgroup = c.String(),
                        Exhibition = c.String(),
                        Features = c.String(),
                        Groups = c.String(),
                        Hairinfo = c.String(),
                        Height = c.String(),
                        Identifier = c.String(),
                        Inventory = c.String(),
                        Kingdom = c.String(),
                        Langgroup = c.String(),
                        Length = c.String(),
                        Medbeinfo = c.String(),
                        Medbkinfo = c.String(),
                        Medboinfo = c.String(),
                        Medceinfo = c.String(),
                        Medclinfo = c.String(),
                        Medfeinfo = c.String(),
                        Medfiinfo = c.String(),
                        Medglinfo = c.String(),
                        Medhoinfo = c.String(),
                        Medirinfo = c.String(),
                        Medium = c.String(),
                        Medivinfo = c.String(),
                        Medmainfo = c.String(),
                        Medotinfo = c.String(),
                        Medrainfo = c.String(),
                        Medreinfo = c.String(),
                        Medseedpodsinfo = c.String(),
                        Medshinfo = c.String(),
                        Medskinfo = c.String(),
                        Medrskinfo = c.String(),
                        Medstinfo = c.String(),
                        Medwoinfo = c.String(),
                        Needbetter = c.String(),
                        Objectgender = c.String(),
                        Objectjanus = c.String(),
                        Objectname = c.String(),
                        Objectnameex = c.String(),
                        Objectnamegn = c.String(),
                        Objectposture = c.String(),
                        Photocopy = c.String(),
                        Photographer = c.String(),
                        Photoinvnr = c.String(),
                        Photoprov = c.String(),
                        Pigmentinfo = c.String(),
                        Provenance = c.String(),
                        Ispublic = c.String(),
                        Publication = c.String(),
                        Raaiid = c.String(),
                        Region = c.String(),
                        Restoration = c.String(),
                        Ritualassoc = c.String(),
                        Sitearcheo = c.String(),
                        Structuralfeatures = c.String(),
                        Tms = c.String(),
                        Usage = c.String(),
                        Village = c.String(),
                        Web = c.String(),
                        Weight = c.String(),
                        Width = c.String(),
                        Workshop = c.String(),
                        Workshoplist = c.String(),
                        Yaleid = c.String(),
                        Unit = c.String(),
                        Associatfeatures = c.String(),
                        Multiline = c.String(),
                        Langsubgroup = c.String(),
                        Aquisitiondate = c.String(),
                        Medwoodinfo = c.String(),
                        Reacttmp = c.String(),
                        Seedpodsinfo = c.String(),
                        Coordinates = c.String(),
                        Category = c.String(),
                        Author = c.String(),
                        Collections = c.String(),
                        Date = c.String(),
                        ISBN = c.String(),
                        Publisher = c.String(),
                        Title = c.String(),
                        Year = c.String(),
                        Reprints = c.String(),
                        Datemax = c.String(),
                        Datemin = c.String(),
                        medriinfo = c.String(),
                        Bio2 = c.String(),
                        Biography = c.String(),
                        Book_about = c.String(),
                        Born = c.String(),
                        Dead = c.String(),
                        First_Name = c.String(),
                        Full_name = c.String(),
                        Last_name = c.String(),
                        Catalogue = c.String(),
                        City = c.String(),
                        Commercial = c.String(),
                        Curator = c.String(),
                        Location = c.String(),
                        Categoryofobject = c.String(),
                    })
                .PrimaryKey(t => t.ArtworkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtworkImages", "ArtworkId", "dbo.Artworks");
            DropIndex("dbo.ArtworkImages", new[] { "ArtworkId" });
            DropTable("dbo.Artworks");
            DropTable("dbo.ArtworkImages");
        }
    }
}
