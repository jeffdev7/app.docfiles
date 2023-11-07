using dok_files_drive.Enum;
using dok_files_drive.Service;
using Patagames.Pdf.Net.Controls.WinForms;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class Visualization : Form
    {
        private readonly Main main = new Main();
        private readonly LocalOrCloud savePlace = new LocalOrCloud();
        private readonly FirebaseService _firebaseService = new FirebaseService();
        private int selectedOption;
        private string file;
        public Visualization()
        {
            InitializeComponent();
        }

        private void Visualization_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            file = main.GetPdfPath();

            pdfViewer.LoadDocument(file);

            PdfViewer pdfView = new PdfViewer();
            Controls.Add(pdfView);
        }

        private void btnFinishDigitalization_Click(object sender, EventArgs e)
        {
            file = main.GetPdfPath();
            if (savePlace.ShowDialog() == DialogResult.OK)
            {
                selectedOption = savePlace.SelectedOption;

                if (selectedOption != (int)EStorage.FIRESTORE)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Save PDF File";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputFilePath = saveFileDialog.FileName;

                        File.Copy(file, outputFilePath);
                        pdfViewer.CloseDocument();
                        Controls.Remove(pdfViewer);
                        File.Delete(file);
                        this.Hide();
                        MessageBox.Show("File saved locally.");
                    }
                }
                else
                {
                    string pattern = @"[^\\]+$";
                    Match match = Regex.Match(file, pattern);
                    string storagePath = "Files/" + match.Value;

                    _firebaseService.UploadPdfToStorage(file, storagePath);
                    pdfViewer.CloseDocument();
                    Controls.Remove(pdfViewer);
                    File.Delete(file);
                    this.Hide();
                    MessageBox.Show("File successfully saved to firebase!");
                }
            }
        }
    }
}
