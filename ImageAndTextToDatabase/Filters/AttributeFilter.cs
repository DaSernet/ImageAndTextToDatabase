using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ImageAndTextToDatabase.Repositories;
using System.Linq;
using ImageAndTextToDatabase.Models;

namespace ImageAndTextToDatabase.Filters
{
    static class AttributeFilter
    {
        public static string[] MatchAttribute(String line)
        {
            string[] attributeOptions = { "Acquiredfrom", "Acquisitiondate", "Additionalfeatures", "Artist", "Artistgender", "Artistsg", "Associatefeatures", "Auctions", "Calabashinfo", "Certificate", "Chefferie", "Clan", "Collectedby", "Collectedwhen", "Collection", "Commanditaire", "Comments", "Commgender", "Commonfeatures", "Commsg", "Condition", "Confidential", "Country", "Createdate", "Createdatemax", "Createdatemin", "Creditline", "Depth", "Diameter", "Donationfrom", "Ethnicgroup", "Exhibition", "Features", "Groups", "Gairinfo", "Geight", "Inventory", "Kingdom", "Langgroup", "Length", "Medbeinfo", "Medbkinfo", "Medboinfo", "Medceinfo", "Medclinfo", "Medfeinfo", "Medfiinfo", "Medglinfo", "Medhoinfo", "Medirinfo", "Medium", "Medivinfo", "Medmainfo", "Medotinfo", "Medrainfo", "Medreinfo", "Medseedpodsinfo", "Medshinfo", "Medskinfo", "Medstinfo", "Medwoinfo", "Needbetter", "Objectgender", "Objectname", "Objectnameex", "Objectnamegn", "Objectposture", "Photocopy", "Photographer", "Photoinvnr", "Photoprov", "Pigmentinfo", "Provenance", "Public", "Publication", "Raaiid", "Region", "Restoration", "Ritualassoc", "Sitearcheo", "Structuralfeatures", "Tms", "Usage", "Village", "Web", "Weight", "Width", "Workshop", "Workshoplist", "Yaleid", "Id", };
            string[] values = line.Split('=');
            //Our attribute is in values[0]
            //Our data is in values[1]

            //this checks if our string[] contains a match with our attributeOptions[]
            foreach (string attributeOption in attributeOptions)
            {
                if (values[0] == "id")
                {
                    values[0] = "Identifier";
                }
                if (values[0] == "public")
                {
                    values[0] = "Ispublic";
                }

            }
            return values;
        }
    }
}

