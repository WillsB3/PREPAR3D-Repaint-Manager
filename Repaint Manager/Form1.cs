using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaint_Manager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnScanAircraft_Click(object sender, EventArgs e)
        {
            scanAircraft();
        }

        private void scanAircraft()
        {
            // Get the aircarft folder
            string simPath = @"C:\Dummy PREPAR3D";
            string aircraftFolder = @"SimObjects\Airplanes";
            string aircraftPath = Path.Combine(simPath, aircraftFolder);
            
            Console.WriteLine("Aircraft folder path:", aircraftPath);

            // Iterate over each subfolder and read each aircraft.cfg
            string[] aircaftDirectories = Directory.GetDirectories(aircraftPath);

            foreach (string subdirectory in aircaftDirectories)
                ProcessAircraft(subdirectory);
        }

        private void ProcessAircraft(string directory)
        {
            Console.WriteLine("Processing aircraft:", directory);

            // Read the aircarft.cfg and find the sim name.
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) {
                Console.WriteLine(file);
                installRepaint(file);
            }  
        }

        private void installRepaint(string path)
        {
            // TODO: Add support for folders

            // Create temporary directory for dealing with files
            string tmpAppDir = Path.Combine(Path.GetTempPath(), @"Repaint Manager");
            string tmpAircraftDir = Path.Combine(tmpAppDir, @"Repaints", Path.GetFileNameWithoutExtension(path));

            // Clean the directory if it already exists
            if (Directory.Exists(tmpAircraftDir))
            {
                Directory.Delete(tmpAircraftDir, true);
            }

            // Extract the repaint 
            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Read))
            {
                archive.ExtractToDirectory(tmpAircraftDir);
            }

            // Find the  files we need
            var textureDir = getTextureDir(tmpAircraftDir);
            var readme = getReadme(tmpAircraftDir);
        }

        private string getTextureDir(string aircraftBaseDir)
        {
            string textureDir= recursiveDirSearch(aircraftBaseDir, @"texture.*");
            Console.WriteLine("Found texture directory at " + textureDir);
            return textureDir;
        }

        private string getReadme(string tmpAircraftDir)
        {
            var files = Directory.EnumerateFiles(tmpAircraftDir, @"readme.*", SearchOption.AllDirectories);
            var readmePath = "";

            foreach (string file in files)
            {
                readmePath = file;
                break;
            }

            return readmePath;
        }

        private string recursiveDirSearch(string path, string dirName)
        {
            var allDirs = Directory.GetDirectories(path);
            var matchingDirs = Directory.GetDirectories(path, dirName);
            var found = "";

            if (matchingDirs.Length == 0)
            {
                // Search each subdir
                foreach (string sd in allDirs)
                {
                    var result = recursiveDirSearch(sd, dirName);
                    if (result != "")
                    {
                        found = result;
                        break;
                    }
                }
            }
            else
            {
                found = matchingDirs[0];
            }
            
            return found;
        }
    }
}
