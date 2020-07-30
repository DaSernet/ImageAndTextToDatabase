using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ImageAndTextToDatabase.Repositories;
using System.Linq;
using ImageAndTextToDatabase.Models;

namespace ImageAndTextToDatabase.Filters
{
    class AttributeFilter
    {
        public static string[] MatchAttribute(String line)
        {
            string[] attributeOptions = { "acquiredfrom", "acquisitiondate", "additionalfeatures", "artist", "artistgender", "artistsg", "associatefeatures", "auctions", "calabashinfo", "certificate", "chefferie", "clan", "collectedby", "collectedwhen", "collection", "commanditaire", "comments", "commgender", "commonfeatures", "commsg", "condition", "confidential", "country", "createdate", "createdatemax", "createdatemin", "creditline", "depth", "diameter", "donationfrom", "ethnicgroup", "exhibition", "features", "groups", "hairinfo", "height", "id", "inventory", "kingdom", "langgroup", "length", "medbeinfo", "medbkinfo", "medboinfo", "medceinfo", "medclinfo", "medfeinfo", "medfiinfo", "medglinfo", "medhoinfo", "medirinfo", "medium", "medivinfo", "medmainfo", "medotinfo", "medrainfo", "medreinfo", "medseedpodsinfo", "medshinfo", "medskinfo", "medstinfo", "medwoinfo", "needbetter", "objectgender", "objectname", "objectnameex", "objectnamegn", "objectposture", "photocopy", "photographer", "photoinvnr", "photoprov", "pigmentinfo", "provenance", "public", "publication", "raaiid", "region", "restoration", "ritualassoc", "sitearcheo", "structuralfeatures", "tms", "usage", "village", "web", "weight", "width", "workshop", "workshoplist", "yaleid" };
            string[] values = line.Split('=');
            //Our attribute is in values[0]
            //Our data is in values[1]

            int counter = 0;
            int counterMatch;
            string attributeName;
            foreach (string attributeOption in attributeOptions)
            {
                if (values[0] == attributeOption)
                {
                    counterMatch = counter;
                    attributeName = values[0];

                    switch (attributeName)
                    {
                        case "Id":
                            values[0] = "Identifier";
                            break;
                        case "Public": 
                            values[0] = "Ispublic"; 
                            break;
                    }
                }
                counter++;
            }
            return values;
        }
    }
}

