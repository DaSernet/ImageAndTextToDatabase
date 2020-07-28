using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FileHierachy2database.Validations
{
    class PathValidations
    {
        public static void Validations(String DatabasePath, String OutputPath)
        {
            string message = "";
            if (String.IsNullOrEmpty(DatabasePath))
            {
                message = "Database path empty";
            }

            if (String.IsNullOrEmpty(OutputPath))
            {
                message = "Output path empty";
            }

            if (DatabasePath == OutputPath)
            {
                message = "Paths matching";
            }

            if (!String.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error");
            }
        }
    }
}
