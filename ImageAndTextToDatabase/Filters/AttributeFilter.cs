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
            string[] values = line.Split('=');

            int counter = 0;
            int counterMatch;
            string attributeName;
            foreach (string attributeOption in attributeOptions)
            {
                if (values[0] == attributeOption)
                {
                    counterMatch = counter;
                    attributeName = values[0];
                    Console.WriteLine(counterMatch);
                    Console.WriteLine(attributeName);
                }
                counter++;
            }
        }
    }
}

