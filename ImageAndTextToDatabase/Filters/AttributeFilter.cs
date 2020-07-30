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

