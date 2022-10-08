﻿namespace ImageAndTextToDatabase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artworks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
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
                    Identifier = c.String(maxLength: 128, fixedLength: true),
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
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Artworks");
        }
    }
}