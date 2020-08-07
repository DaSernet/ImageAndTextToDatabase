using System;

namespace ImageAndTextToDatabase.Filters
{
    internal static class AttributeFilter
    {
        public static string[] MatchAttribute(String line)
        {
            string[] values = line.Split('=');
            //Our attribute is in values[0]
            //Our data is in values[1]

            values[0] = values[0].ToLower();

            if (values[0] == "id")
            {
                values[0] = "identifier";
            }
            if (values[0] == "public")
            {
                values[0] = "ispublic";
            }
            return values;
        }
    }
}