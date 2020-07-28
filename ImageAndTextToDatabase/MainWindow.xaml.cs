﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageAndTextToDatabase.Validations;

namespace ImageAndTextToDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        { 
            if (DatabaseSelectorComboBox.SelectedIndex == 0)
            {
                //checks if our textboxes are configured correctly.
                PathValidations.Validations(TextBox_DatabasePath.Text, TextBox_OutputPath.Text);
                //Creates a text file called first.txt in our output directory.
                string outputPath = TextBox_OutputPath.Text + @"\First.txt";
                //Adds \ to the end of ot path to make it valid for or function.
                string DatabasePath = TextBox_DatabasePath.Text + @"\";
                //Grabs every file found in our directory and puts it in a list called entries
                string[] entries = Directory.GetFileSystemEntries(TextBox_DatabasePath.Text, "*", System.IO.SearchOption.AllDirectories);
                //Writes our entire list to our output file!
                File.WriteAllLines(outputPath, entries);
            }
            else if (DatabaseSelectorComboBox.SelectedIndex == 1)
            {
                
            }
        }

        private void BrowseFolderDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                selectedFile = dialog.SelectedPath;
            }
            TextBox_DatabasePath.Text = selectedFile;
        }

        private void BrowseFolderOutputButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                selectedFile = dialog.SelectedPath;
            }
            TextBox_OutputPath.Text = selectedFile;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
