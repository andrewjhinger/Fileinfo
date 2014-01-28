using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fileinfo
{
    public partial class FileInfo : Form
    {
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public FileInfo()
        {
            InitializeComponent();
        }



        private void FileInfo_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(findFileButton, "Select File");
            toolTip.SetToolTip(closeButton, "Close Application");
        }

        private bool CheckFileAttribute(System.IO.FileInfo fileInfo, System.IO.FileAttributes fileAttribute)
        {
            return ((fileInfo.Attributes & fileAttribute) == fileAttribute);
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void findFileButton_Click_1(object sender, EventArgs e)
        {
            // Set file dialog defaults.
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select File";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";

            // Display file dialog.
            DialogResult dialogResult = openFileDialog1.ShowDialog();

            // Check if user clicked OK button.
            if (dialogResult == DialogResult.OK)
            {
                string fullFileName = openFileDialog1.FileName;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fullFileName);
                fileNameTextBox.Text = fileInfo.Name;
                pathTextBox.Text = fileInfo.DirectoryName;
                sizeTextBox.Text = fileInfo.Length.ToString();
                if (fileInfo.Length <= 1024)
                { kbSizeTextBox.Text = "1 kb"; }
                else
                { kbSizeTextBox.Text = Convert.ToString(fileInfo.Length / 1024); }
                lastAccessedTextBox.Text = fileInfo.LastAccessTime.ToString(); ;
                createdTextBox.Text = fileInfo.CreationTime.ToString();
                updatedTextBox.Text = fileInfo.LastWriteTime.ToString();
                archiveCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Archive);
                normalCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Normal);
                readOnlyCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.ReadOnly);
                compressedCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Compressed);
                encryptedCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Encrypted);
                systemCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.System);
                hiddenCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Hidden);
                directoryCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Directory);
                temporaryCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Temporary);
                sparseFileCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.SparseFile);
                reparsePointCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.ReparsePoint);
                deviceCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.Device);
                notContentIndexedCheckBox.Checked = CheckFileAttribute(fileInfo, System.IO.FileAttributes.NotContentIndexed);
            }

        }
    }
}

