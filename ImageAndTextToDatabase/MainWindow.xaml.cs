using Microsoft.Win32;
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
using ImageAndTextToDatabase.Filters;

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
                //Checks if our textboxes are configured correctly.
                PathValidations.Validations(TextBox_DatabasePath.Text, TextBox_OutputPath.Text);
                //Creates a text file called first.txt in our output directory.
                string outputPath = TextBox_OutputPath.Text + "First.txt";
                string databasePath = TextBox_DatabasePath.Text;
                //Grabs every file found in our directory and puts it in a list called entries
                string[] entries = Directory.GetFileSystemEntries(databasePath, "*", System.IO.SearchOption.AllDirectories);
                //Writes our entire list to our output file!
                File.WriteAllLines(outputPath, entries);
                MessageBox.Show("Done");
            }
            else if (DatabaseSelectorComboBox.SelectedIndex == 1)
            {
                string textFile = TextBox_DatabasePath.Text;
                //Reads all our lines in specified text file, then puts this into a list
                string[] filelocations = File.ReadAllLines(textFile);
                //Filters our file extensions
                string[] fileEndsWith = { ".jpeg", ".JPEG", ".jpg", ".JPG", ".txt", ".TXT" };
                foreach (string filelocation in filelocations)
                {
                    //Filters our file extensions.
                    if (fileEndsWith.Any(x => filelocation.EndsWith(x)))
                    {
                        string readText = File.ReadAllText(filelocation);
                        string[] lines = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        foreach (string line in lines)
                        {
                            AttributeFilter.MatchAttribute(line);
                            Console.WriteLine(line);
                        }
                    }
                }
                MessageBox.Show("Done");
            }
        }

        private void BrowseFolderDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            if (DatabaseSelectorComboBox.SelectedIndex == 0)
            {
                using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    selectedFile = dialog.SelectedPath + @"\";
                }
            }
            else if (DatabaseSelectorComboBox.SelectedIndex == 1)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == true)
                {
                    selectedFile = openFileDialog1.FileName;
                }
            }
            TextBox_DatabasePath.Text = selectedFile.Replace(@"\", "/");
        }

        private void BrowseFolderOutputButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                selectedFile = dialog.SelectedPath + @"\";
            }
            TextBox_OutputPath.Text = selectedFile.Replace(@"\", "/");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
