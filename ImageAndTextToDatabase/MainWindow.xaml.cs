using ImageAndTextToDatabase.Filters;
using ImageAndTextToDatabase.Functions;
using ImageAndTextToDatabase.Models;
using ImageAndTextToDatabase.Repositories;
using ImageAndTextToDatabase.Validations;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace ImageAndTextToDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IArtworkRepository artworkRepository;
        private IArtworkImageRepository artworkImageRepository;
        public MainWindow()
        {
            InitializeComponent();

            artworkRepository = new EFArtworkRepository();
            artworkImageRepository = new EFArtworkImageRepository();
        }

        public void SendNotification(String Title, String Message)
        {
            Notification notification = new Notification();
            notification.ShowNotification(Title, Message);
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
            Application.Current.Shutdown();
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
                string[] entries = Directory.GetFileSystemEntries(databasePath, "*info_*001.txt", System.IO.SearchOption.AllDirectories);
                //Makes sure our / & \ are correct
                string[] outputStringArray = entries.Select(x => x.Replace(@"\", "/")).ToArray();
                //Writes our entire list to our output file!
                File.WriteAllLines(outputPath, outputStringArray);
                MessageBox.Show("Done");
            }
            else if (DatabaseSelectorComboBox.SelectedIndex == 1)
            {
                string textFile = TextBox_DatabasePath.Text;
                //Reads all our lines in specified text file, then puts this into a list
                string[] filelocations = File.ReadAllLines(textFile);
                //Filters our file extensions
                string[] fileEndsWith = { ".txt", ".TXT" };
                var counter = 0;
                foreach (string filelocation in filelocations)
                {
                    //Filters our file extensions.
                    if (fileEndsWith.Any(x => filelocation.EndsWith(x)))
                    {
                        //Keeps us informed
                        counter++;

                        if (counter % 250 == 0 && counter != 0)
                        {
                            Console.WriteLine("Started processing artwork #" + counter);
                        }
                        //Sends a toast every 5000th artwork that is processed
                        if (counter % 50000 == 0 && counter != 0)
                        {
                            SendNotification("Title", counter + " artworks processed");
                        }

                        Artwork newArtwork = new Artwork();
                        ArtworkImage newArtworkImage = new ArtworkImage();

                        //What Images are we trying to get?
                        String OurImageExtension = ".jpg";

                        //we still need to add all images in our folder to our database
                        string imageLocation = filelocation;

                        //Checks if there is a history file!
                        /*string historyLocation = filelocation;

                        int index = historyLocation.LastIndexOf("/");
                        if (index > 0)
                        {
                            historyLocation = historyLocation.Substring(0, index + 1) + "history.txt"; //+1 to keep the slash.
                        }
                        Console.WriteLine(historyLocation);*/

                        string readText = File.ReadAllText(filelocation);
                        string[] lines = readText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        foreach (string line in lines)
                        {
                            //[0] has our attribute and [1] has our data
                            string[] extractions = AttributeFilter.MatchAttribute(line);
                            if (extractions.Length == 2)
                            {
                                extractions[1] = extractions[1].Trim();
                            } else
                            {
                                Array.Resize(ref extractions, extractions.Length + 1);
                                extractions[extractions.Length - 1] = "new string";
                            }
                            switch (extractions[0])
                            {
                                case "acquiredfrom":
                                    newArtwork.Acquiredfrom = extractions[1];
                                    break;

                                case "acquisitiondate":
                                    newArtwork.Acquisitiondate = extractions[1];
                                    break;

                                case "additionalfeatures":
                                    newArtwork.Additionalfeatures = extractions[1];
                                    break;

                                case "artist":
                                    newArtwork.Artist = extractions[1];
                                    break;

                                case "artistgender":
                                    newArtwork.Artistgender = extractions[1];
                                    break;

                                case "artistsg":
                                    newArtwork.Artistsg = extractions[1];
                                    break;

                                case "associatefeatures":
                                    newArtwork.Associatefeatures = extractions[1];
                                    break;

                                case "auctions":
                                    newArtwork.Auctions = extractions[1];
                                    break;

                                case "calabashinfo":
                                    newArtwork.Calabashinfo = extractions[1];
                                    break;

                                case "certificate":
                                    newArtwork.Certificate = extractions[1];
                                    break;

                                case "chefferie":
                                    newArtwork.Chefferie = extractions[1];
                                    break;

                                case "clan":
                                    newArtwork.Clan = extractions[1];
                                    break;

                                case "collectedby":
                                    newArtwork.Collectedby = extractions[1];
                                    break;

                                case "collectedwhen":
                                    newArtwork.Collectedwhen = extractions[1];
                                    break;

                                case "collection":
                                    newArtwork.Collection = extractions[1];
                                    break;

                                case "commanditaire":
                                    newArtwork.Commanditaire = extractions[1];
                                    break;

                                case "comments":
                                    newArtwork.Comments = extractions[1];
                                    break;

                                case "commgender":
                                    newArtwork.Commgender = extractions[1];
                                    break;

                                case "commonfeatures":
                                    newArtwork.Commonfeatures = extractions[1];
                                    break;

                                case "commsg":
                                    newArtwork.Commsg = extractions[1];
                                    break;

                                case "condition":
                                    newArtwork.Condition = extractions[1];
                                    break;

                                case "confidential":
                                    newArtwork.Confidential = extractions[1];
                                    break;

                                case "country":
                                    newArtwork.Country = extractions[1];
                                    break;

                                case "createdate":
                                    newArtwork.Createdate = extractions[1];
                                    break;

                                case "createdatemax":
                                    newArtwork.Createdatemax = extractions[1];
                                    break;

                                case "createdatemin":
                                    newArtwork.Createdatemin = extractions[1];
                                    break;

                                case "creditline":
                                    newArtwork.Creditline = extractions[1];
                                    break;

                                case "depth":
                                    newArtwork.Depth = extractions[1];
                                    break;

                                case "diameter":
                                    newArtwork.Diameter = extractions[1];
                                    break;

                                case "donationfrom":
                                    newArtwork.Donationfrom = extractions[1];
                                    break;

                                case "ethnicgroup":
                                    newArtwork.Ethnicgroup = extractions[1];
                                    break;

                                case "exhibition":
                                    newArtwork.Exhibition = extractions[1];
                                    break;

                                case "features":
                                    newArtwork.Features = extractions[1];
                                    break;

                                case "groups":
                                    newArtwork.Groups = extractions[1];
                                    break;

                                case "hairinfo":
                                    newArtwork.Hairinfo = extractions[1];
                                    break;

                                case "height":
                                    newArtwork.Height = extractions[1];
                                    break;

                                case "identifier":
                                    newArtwork.Identifier = extractions[1];
                                    newArtwork.Category = extractions[1].GetUntilOrEmpty();
                                    break;

                                case "inventory":
                                    newArtwork.Inventory = extractions[1];
                                    break;

                                case "kingdom":
                                    newArtwork.Kingdom = extractions[1];
                                    break;

                                case "langgroup":
                                    newArtwork.Langgroup = extractions[1];
                                    break;

                                case "length":
                                    newArtwork.Length = extractions[1];
                                    break;

                                case "medbeinfo":
                                    newArtwork.Medbeinfo = extractions[1];
                                    break;

                                case "medbkinfo":
                                    newArtwork.Medbkinfo = extractions[1];
                                    break;

                                case "medboinfo":
                                    newArtwork.Medboinfo = extractions[1];
                                    break;

                                case "medceinfo":
                                    newArtwork.Medceinfo = extractions[1];
                                    break;

                                case "medclinfo":
                                    newArtwork.Medclinfo = extractions[1];
                                    break;

                                case "medfeinfo":
                                    newArtwork.Medfeinfo = extractions[1];
                                    break;

                                case "medfiinfo":
                                    newArtwork.Medfiinfo = extractions[1];
                                    break;

                                case "medglinfo":
                                    newArtwork.Medglinfo = extractions[1];
                                    break;

                                case "medhoinfo":
                                    newArtwork.Medhoinfo = extractions[1];
                                    break;

                                case "medirinfo":
                                    newArtwork.Medirinfo = extractions[1];
                                    break;

                                case "medium":
                                    newArtwork.Medium = extractions[1];
                                    break;

                                case "medivinfo":
                                    newArtwork.Medivinfo = extractions[1];
                                    break;

                                case "medmainfo":
                                    newArtwork.Medmainfo = extractions[1];
                                    break;

                                case "medotinfo":
                                    newArtwork.Medotinfo = extractions[1];
                                    break;

                                case "medrainfo":
                                    newArtwork.Medrainfo = extractions[1];
                                    break;

                                case "medreinfo":
                                    newArtwork.Medreinfo = extractions[1];
                                    break;

                                case "medseedpodsinfo":
                                    newArtwork.Medseedpodsinfo = extractions[1];
                                    break;

                                case "medshinfo":
                                    newArtwork.Medshinfo = extractions[1];
                                    break;

                                case "medskinfo":
                                    newArtwork.Medskinfo = extractions[1];
                                    break;

                                case "medstinfo":
                                    newArtwork.Medstinfo = extractions[1];
                                    break;

                                case "medwoinfo":
                                    newArtwork.Medwoinfo = extractions[1];
                                    break;

                                case "needbetter":
                                    newArtwork.Needbetter = extractions[1];
                                    break;

                                case "objectgender":
                                    newArtwork.Objectgender = extractions[1];
                                    break;

                                case "objectjanus":
                                    newArtwork.Objectjanus = extractions[1];
                                    break;

                                case "objectname":
                                    newArtwork.Objectname = extractions[1];
                                    break;

                                case "objectnameex":
                                    newArtwork.Objectnameex = extractions[1];
                                    break;

                                case "objectnamegn":
                                    newArtwork.Objectnamegn = extractions[1];
                                    break;

                                case "objectposture":
                                    newArtwork.Objectposture = extractions[1];
                                    break;

                                case "photocopy":
                                    newArtwork.Photocopy = extractions[1];
                                    break;

                                case "photographer":
                                    newArtwork.Photographer = extractions[1];
                                    break;

                                case "photoinvnr":
                                    newArtwork.Photoinvnr = extractions[1];
                                    break;

                                case "photoprov":
                                    newArtwork.Photoprov = extractions[1];
                                    break;

                                case "pigmentinfo":
                                    newArtwork.Pigmentinfo = extractions[1];
                                    break;

                                case "provenance":
                                    newArtwork.Provenance = extractions[1];
                                    break;

                                case "ispublic":
                                    newArtwork.Ispublic = extractions[1];
                                    break;

                                case "publication":
                                    newArtwork.Publication = extractions[1];
                                    break;

                                case "raaiid":
                                    newArtwork.Raaiid = extractions[1];
                                    break;

                                case "region":
                                    newArtwork.Region = extractions[1];
                                    break;

                                case "restoration":
                                    newArtwork.Restoration = extractions[1];
                                    break;

                                case "ritualassoc":
                                    newArtwork.Ritualassoc = extractions[1];
                                    break;

                                case "sitearcheo":
                                    newArtwork.Sitearcheo = extractions[1];
                                    break;

                                case "structuralfeatures":
                                    newArtwork.Structuralfeatures = extractions[1];
                                    break;

                                case "tms":
                                    newArtwork.Tms = extractions[1];
                                    break;

                                case "usage":
                                    newArtwork.Usage = extractions[1];
                                    break;

                                case "village":
                                    newArtwork.Village = extractions[1];
                                    break;

                                case "web":
                                    newArtwork.Web = extractions[1];
                                    break;

                                case "weight":
                                    newArtwork.Weight = extractions[1];
                                    break;

                                case "width":
                                    newArtwork.Width = extractions[1];
                                    break;

                                case "workshop":
                                    newArtwork.Workshop = extractions[1];
                                    break;

                                case "workshoplist":
                                    newArtwork.Workshoplist = extractions[1];
                                    break;

                                case "yaleid":
                                    newArtwork.Yaleid = extractions[1];
                                    break;

                                case "unit":
                                    newArtwork.Unit = extractions[1];
                                    break;

                                case "associatfeatures":
                                    newArtwork.Associatfeatures = extractions[1];
                                    break;

                                case "multiline":
                                    newArtwork.Multiline = extractions[1];
                                    break;

                                case "langsubgroup":
                                    newArtwork.Langsubgroup = extractions[1];
                                    break;

                                case "aquisitiondate":
                                    newArtwork.Aquisitiondate = extractions[1];
                                    break;

                                case "medwoodinfo":
                                    newArtwork.Medwoodinfo = extractions[1];
                                    break;

                                case "reacttmp":
                                    newArtwork.Reacttmp = extractions[1];
                                    break;

                                case "coordinates":
                                    newArtwork.Coordinates = extractions[1];
                                    break;

                                case "medrskinfo":
                                    newArtwork.Medrskinfo = extractions[1];
                                    break;

                                case "seedpodsinfo":
                                    newArtwork.Seedpodsinfo = extractions[1];
                                    break;

                                case "associateferatures":
                                    newArtwork.Associatfeatures = extractions[1];
                                    break;

                                case "":
                                    break;

                                default:
                                    //debugger
                                    
                                    if (extractions[0] != "reactions" && extractions[0] != "ext")
                                    {
                                    Console.WriteLine("error in: " + filelocation);
                                    Console.WriteLine(extractions[0]);
                                    Console.WriteLine(extractions[1]);
                                    }
                                    break;
                            }
                        }
                        artworkRepository.Add(newArtwork);

                        //stores all our images into our artwork
                        imageLocation = imageLocation.Replace("info_", String.Empty);
                        imageLocation = imageLocation.Replace(".txt", OurImageExtension);
                        if (!File.Exists(imageLocation))
                        {
                            Console.WriteLine("Image not found: " + imageLocation);
                        }
                        else
                        {
                            for (int ourImageNumber = 1; File.Exists(imageLocation); ourImageNumber++)
                            {

                                //moving & renaming file
                                string fileName = null;
                                if (imageLocation != null)
                                {
                                    string uploadDir = @"D:\AHDRC Example\Images";
                                    int pos = imageLocation.LastIndexOf("/") + 1;
                                    fileName = Guid.NewGuid().ToString() + "-" + imageLocation.Substring(pos, imageLocation.Length - pos);
                                    string filePath = Path.Combine(uploadDir, fileName);
                                    File.Move(imageLocation, filePath);
                                }

                                switch (ourImageNumber)
                                {
                                    case 1:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 2:
                                            Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                            break;

                                        case 3:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 4:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 5:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 6:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 7:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 8:
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;

                                        case 9:
                                            SendNotification("Artwork #" + counter, "9 Images stored?");
                                        Console.WriteLine(imageLocation);
                                        newArtworkImage.ImageURL = fileName;
                                        newArtworkImage.Artwork = newArtwork;
                                        artworkImageRepository.Add(newArtworkImage);
                                        break;
                                }
                                imageLocation = imageLocation.Replace("-00" + ourImageNumber + OurImageExtension, "-00" + (ourImageNumber + 1) + OurImageExtension);
                            }
                        }
                    }
                }
                SendNotification("Task Complete", "Your file should be ready!");
            }
        }
    }

    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }
}