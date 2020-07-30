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
using ImageAndTextToDatabase.Repositories;
using ImageAndTextToDatabase.Models;

namespace ImageAndTextToDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IArtworkRepository artworkRepository;

        public MainWindow()
        {
            InitializeComponent();

            artworkRepository = new EFArtworkRepository();
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
                int counter = 0;
                foreach (string filelocation in filelocations)
                {
                    //Filters our file extensions.
                    if (fileEndsWith.Any(x => filelocation.EndsWith(x)))
                    {
                        //Keeps us informed
                        counter++;
                        Console.WriteLine("Started processing artwork #" + counter);

                        string readText = File.ReadAllText(filelocation);
                        string[] lines = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                        Artwork newArtwork = new Artwork();

                        foreach (string line in lines)
                        {
                            //[0] has our attribute and [1] has our data
                            string[] extractions = AttributeFilter.MatchAttribute(line);
                            switch (extractions[0])
                            {
                                case "Acquiredfrom":
                                    newArtwork.Acquiredfrom = extractions[1];
                                    break;
                                case "Acquisitiondate":
                                    newArtwork.Acquisitiondate = extractions[1];
                                    break;
                                case "Additionalfeatures":
                                    newArtwork.Additionalfeatures = extractions[1];
                                    break;
                                case "Artist":
                                    newArtwork.Artist = extractions[1];
                                    break;
                                case "Artistgender":
                                    newArtwork.Artistgender = extractions[1];
                                    break;
                                case "Artistsg":
                                    newArtwork.Artistsg = extractions[1];
                                    break;
                                case "Associatefeatures":
                                    newArtwork.Associatefeatures = extractions[1];
                                    break;
                                case "Auctions":
                                    newArtwork.Auctions = extractions[1];
                                    break;
                                case "Calabashinfo":
                                    newArtwork.Calabashinfo = extractions[1];
                                    break;
                                case "Certificate":
                                    newArtwork.Certificate = extractions[1];
                                    break;
                                case "Chefferie":
                                    newArtwork.Chefferie = extractions[1];
                                    break;
                                case "Clan":
                                    newArtwork.Clan = extractions[1];
                                    break;
                                case "Collectedby":
                                    newArtwork.Collectedby = extractions[1];
                                    break;
                                case "Collectedwhen":
                                    newArtwork.Collectedwhen = extractions[1];
                                    break;
                                case "Collection":
                                    newArtwork.Collection = extractions[1];
                                    break;
                                case "Commanditaire":
                                    newArtwork.Commanditaire = extractions[1];
                                    break;
                                case "Comments":
                                    newArtwork.Comments = extractions[1];
                                    break;
                                case "Commgender":
                                    newArtwork.Commgender = extractions[1];
                                    break;
                                case "Commonfeatures":
                                    newArtwork.Commonfeatures = extractions[1];
                                    break;
                                case "Commsg":
                                    newArtwork.Commsg = extractions[1];
                                    break;
                                case "Condition":
                                    newArtwork.Condition = extractions[1];
                                    break;
                                case "Confidential":
                                    newArtwork.Confidential = extractions[1];
                                    break;
                                case "Country":
                                    newArtwork.Country = extractions[1];
                                    break;
                                case "Createdate":
                                    newArtwork.Createdate = extractions[1];
                                    break;
                                case "Createdatemax":
                                    newArtwork.Createdatemax = extractions[1];
                                    break;
                                case "Createdatemin":
                                    newArtwork.Createdatemin = extractions[1];
                                    break;
                                case "Creditline":
                                    newArtwork.Creditline = extractions[1];
                                    break;
                                case "Depth":
                                    newArtwork.Depth = extractions[1];
                                    break;
                                case "Diameter":
                                    newArtwork.Diameter = extractions[1];
                                    break;
                                case "Donationfrom":
                                    newArtwork.Donationfrom = extractions[1];
                                    break;
                                case "Ethnicgroup":
                                    newArtwork.Ethnicgroup = extractions[1];
                                    break;
                                case "Exhibition":
                                    newArtwork.Exhibition = extractions[1];
                                    break;
                                case "Features":
                                    newArtwork.Features = extractions[1];
                                    break;
                                case "Groups":
                                    newArtwork.Groups = extractions[1];
                                    break;
                                case "Hairinfo":
                                    newArtwork.Hairinfo = extractions[1];
                                    break;
                                case "Height":
                                    newArtwork.Height = extractions[1];
                                    break;
                                case "Identifier":
                                    newArtwork.Identifier = extractions[1];
                                    break;
                                case "Inventory":
                                    newArtwork.Inventory = extractions[1];
                                    break;
                                case "Kingdom":
                                    newArtwork.Kingdom = extractions[1];
                                    break;
                                case "Langgroup":
                                    newArtwork.Langgroup = extractions[1];
                                    break;
                                case "Length":
                                    newArtwork.Length = extractions[1];
                                    break;
                                case "Medbeinfo":
                                    newArtwork.Medbeinfo = extractions[1];
                                    break;
                                case "Medbkinfo":
                                    newArtwork.Medbkinfo = extractions[1];
                                    break;
                                case "Medboinfo":
                                    newArtwork.Medboinfo = extractions[1];
                                    break;
                                case "Medceinfo":
                                    newArtwork.Medceinfo = extractions[1];
                                    break;
                                case "Medclinfo":
                                    newArtwork.Medclinfo = extractions[1];
                                    break;
                                case "Medfeinfo":
                                    newArtwork.Medfeinfo = extractions[1];
                                    break;
                                case "Medfiinfo":
                                    newArtwork.Medfiinfo = extractions[1];
                                    break;
                                case "Medglinfo":
                                    newArtwork.Medglinfo = extractions[1];
                                    break;
                                case "Medhoinfo":
                                    newArtwork.Medhoinfo = extractions[1];
                                    break;
                                case "Medirinfo":
                                    newArtwork.Medirinfo = extractions[1];
                                    break;
                                case "Medium":
                                    newArtwork.Medium = extractions[1];
                                    break;
                                case "Medivinfo":
                                    newArtwork.Medivinfo = extractions[1];
                                    break;
                                case "Medmainfo":
                                    newArtwork.Medmainfo = extractions[1];
                                    break;
                                case "Medotinfo":
                                    newArtwork.Medotinfo = extractions[1];
                                    break;
                                case "Medrainfo":
                                    newArtwork.Medrainfo = extractions[1];
                                    break;
                                case "Medreinfo":
                                    newArtwork.Medreinfo = extractions[1];
                                    break;
                                case "Medseedpodsinfo":
                                    newArtwork.Medseedpodsinfo = extractions[1];
                                    break;
                                case "Medshinfo":
                                    newArtwork.Medshinfo = extractions[1];
                                    break;
                                case "Medskinfo":
                                    newArtwork.Medskinfo = extractions[1];
                                    break;
                                case "Medstinfo":
                                    newArtwork.Medstinfo = extractions[1];
                                    break;
                                case "Medwoinfo":
                                    newArtwork.Medwoinfo = extractions[1];
                                    break;
                                case "Needbetter":
                                    newArtwork.Needbetter = extractions[1];
                                    break;
                                case "Objectgender":
                                    newArtwork.Objectgender = extractions[1];
                                    break;
                                case "Objectname":
                                    newArtwork.Objectname = extractions[1];
                                    break;
                                case "Objectnameex":
                                    newArtwork.Objectnameex = extractions[1];
                                    break;
                                case "Objectnamegn":
                                    newArtwork.Objectnamegn = extractions[1];
                                    break;
                                case "Objectposture":
                                    newArtwork.Objectposture = extractions[1];
                                    break;
                                case "Photocopy":
                                    newArtwork.Photocopy = extractions[1];
                                    break;
                                case "Photographer":
                                    newArtwork.Photographer = extractions[1];
                                    break;
                                case "Photoinvnr":
                                    newArtwork.Photoinvnr = extractions[1];
                                    break;
                                case "Photoprov":
                                    newArtwork.Photoprov = extractions[1];
                                    break;
                                case "Pigmentinfo":
                                    newArtwork.Pigmentinfo = extractions[1];
                                    break;
                                case "Provenance":
                                    newArtwork.Provenance = extractions[1];
                                    break;
                                case "Ispublic":
                                    newArtwork.Ispublic = extractions[1];
                                    break;
                                case "Publication":
                                    newArtwork.Publication = extractions[1];
                                    break;
                                case "Raaiid":
                                    newArtwork.Raaiid = extractions[1];
                                    break;
                                case "Region":
                                    newArtwork.Region = extractions[1];
                                    break;
                                case "Restoration":
                                    newArtwork.Restoration = extractions[1];
                                    break;
                                case "Ritualassoc":
                                    newArtwork.Ritualassoc = extractions[1];
                                    break;
                                case "Sitearcheo":
                                    newArtwork.Sitearcheo = extractions[1];
                                    break;
                                case "Structuralfeatures":
                                    newArtwork.Structuralfeatures = extractions[1];
                                    break;
                                case "Tms":
                                    newArtwork.Tms = extractions[1];
                                    break;
                                case "Usage":
                                    newArtwork.Usage = extractions[1];
                                    break;
                                case "Village":
                                    newArtwork.Village = extractions[1];
                                    break;
                                case "Web":
                                    newArtwork.Web = extractions[1];
                                    break;
                                case "Weight":
                                    newArtwork.Weight = extractions[1];
                                    break;
                                case "Width":
                                    newArtwork.Width = extractions[1];
                                    break;
                                case "Workshop":
                                    newArtwork.Workshop = extractions[1];
                                    break;
                                case "Workshoplist":
                                    newArtwork.Workshoplist = extractions[1];
                                    break;
                                case "Yaleid":
                                    newArtwork.Yaleid = extractions[1];
                                    break;
                                default:
                                    //debugger
                                    Console.WriteLine("error in" + filelocation);
                                    Console.WriteLine(extractions[0]);
                                    Console.WriteLine(extractions[1]);
                                    break;
                            }
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
