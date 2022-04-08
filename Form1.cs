using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TiffConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select a PDF file";
            fileDialog.Filter = "PDFfiler (*.pdf)|*.pdf";
           
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFileLabel.Text = fileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if(folderBrowser.ShowDialog() == DialogResult.OK)
            {
                OutputDirLabel.Text = folderBrowser.SelectedPath;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            RadioButton checkedRadiobutton = OutputColorGroup.Controls.OfType<RadioButton>().First(x => x.Checked);
            string outputFile = OutputDirLabel.Text + "\\1.tif";

            ColorSettings colorSettings = new ColorSettings();
            Process convertProcess = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            
            startInfo.FileName = "gswin64c";
            colorSettings.InitSettings(checkedRadiobutton.Text);
            String arguments = String.Format(@"-dBATCH -dNOPAUSE -sDEVICE={0} -sColorConversionStrategy={1}
                                            -r300 -sCompression={2} -sOutputFile={3} {4}",
                                           colorSettings.Device, "UseDeviceIndependentColor", colorSettings.Compression, outputFile,
                                           SelectedFileLabel.Text);
            
            startInfo.Arguments = arguments;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            convertProcess.StartInfo = startInfo;

            // Start the process and wait for process exit.
            convertProcess.Start();
            convertProcess.WaitForExit();
            int exitCode = convertProcess.ExitCode;
            
            // Setup for message box.
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            string message;
            string caption = "Tif conversion status";
            
            // Display the relevant message box based on the exit code of the ghostscript process.
            if (exitCode == 0)
            {
                message = "The file was converted successfully.";
                MessageBox.Show(message, caption, buttons);
            }

            else
            {
                message = "An error occured converting the file.";
                MessageBox.Show(message, caption, buttons);
            }

        }
    }
}
