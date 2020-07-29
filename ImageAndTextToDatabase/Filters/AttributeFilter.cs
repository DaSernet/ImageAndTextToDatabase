using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ImageAndTextToDatabase.Filters
{
    class AttributeFilter
    {
        public static void MatchAttribute(String line)
        {
            string[] attributeOptions = { "Auctions", "CollectedBy", "CollectedWhen", "Collection", "Coordinates", "Country", "EthnicGroup", "Exhibition", "Height", "Id" };
        }
    }
}
