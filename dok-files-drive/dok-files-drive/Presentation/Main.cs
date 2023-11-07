using dok_files_drive.Enum;
using dok_files_drive.Mock;
using dok_files_drive.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class Main : Form
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        private string selectedFilePath;
        private readonly FirebaseService _firebaseService = new FirebaseService();
        private static string pdfPathForConvertion;
        public Main()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            CultureInfo specificCulture = new CultureInfo("pt-BR");
            List<string> languages = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
           .Select(culture => new RegionInfo(culture.Name).DisplayName)
           .Distinct()
           .OrderBy(displayName => displayName)
           .ToList();

            cbmBoxLanguage.DataSource = languages;
            cbmBoxLanguage.SelectedIndex = 30;

            //FileUpload();
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            LocalOrCloud savePlace = new LocalOrCloud();

            if (checkImgOCR.Checked && checkPDFA.Checked)
                MessageBox.Show("Selecione apenas uma opção por vez", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                if (checkImgOCR.Checked)
                    ConvertImageToPdf(selectedFilePath);
                else
                {
                    string extension = checkPDFA.Checked ? "-pdfa.pdf" : "pdf";
                    string outputFilePath = Path.ChangeExtension(selectedFilePath, extension);

                    try
                    {
                        MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
                        MigraDoc.DocumentObjectModel.Section section = document.AddSection();
                        MigraDoc.DocumentObjectModel.Paragraph paragraph = section.AddParagraph();

                        string fileContent = File.ReadAllText(selectedFilePath);
                        paragraph.AddText(fileContent);

                        PdfSharp.Pdf.PdfDocument pdfDocument = new PdfSharp.Pdf.PdfDocument();

                        MigraDoc.Rendering.PdfDocumentRenderer renderer = new MigraDoc.Rendering.PdfDocumentRenderer();
                        renderer.Document = document;
                        renderer.PdfDocument = pdfDocument;

                        renderer.RenderDocument();

                        if (savePlace.ShowDialog() == DialogResult.OK)
                        {
                            int selectedOption = savePlace.SelectedOption;

                            if (selectedOption != (int)EStorage.FIRESTORE)
                            {
                                SaveFileDialog saveFileDialog = new SaveFileDialog();
                                saveFileDialog.Filter = "PDF Files|*.pdf";
                                saveFileDialog.Title = "Save PDF File";

                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    string filePathToBeSaved = saveFileDialog.FileName;
                                    pdfDocument.Save(filePathToBeSaved);
                                    MessageBox.Show(checkPDFA.Checked ? "File converted to PDF/A successfully!"
                                        : "File converted to a standard PDF successfully!");
                                }
                            }
                            else
                            {
                                string pattern = @"[^\\]+$";
                                Match match = Regex.Match(outputFilePath, pattern);
                                string storagePath = "Files/" + match.Value;
                                pdfDocument.Save(outputFilePath);
                                _firebaseService.UploadPdfToStorage(outputFilePath, storagePath);
                                File.Delete(outputFilePath);
                                MessageBox.Show(checkPDFA.Checked ? "File converted to PDF/A successfully!\nAnd saved it to firestore."
                                    : "File converted to a standard PDF successfully!\nAnd saved it to firestore.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else if (selectedFilePath is null)
                MessageBox.Show("Faça o upload de algum arquivo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public string ConvertImageToPdf(string imagePath)
        {
            var ocrengine = new Tesseract.TesseractEngine(@".\tessdata", "eng", Tesseract.EngineMode.Default);
            var imgFromUploadedFile = Tesseract.Pix.LoadFromFile(imagePath);
            var response = ocrengine.Process(imgFromUploadedFile);
            var textFromImage = response.GetText();

            string imageDirectory = Path.GetDirectoryName(imagePath);

            pdfPathForConvertion = Path.Combine(imageDirectory, Path.GetFileNameWithoutExtension(imagePath) + ".pdf");

            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
            PdfSharp.Pdf.PdfPage page = document.AddPage();
            PdfSharp.Drawing.XGraphics graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);

            PdfSharp.Drawing.XFont font = new PdfSharp.Drawing.XFont("Arial", 12);
            PdfSharp.Drawing.XStringFormat format = PdfSharp.Drawing.XStringFormat.TopLeft;
            PdfSharp.Drawing.Layout.XTextFormatter layout = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
            PdfSharp.Drawing.XRect rect = new PdfSharp.Drawing.XRect(50, 50, page.Width - 100, page.Height - 100);

            // Format and add the text (extracted from Tesseract) to the page
            layout.DrawString(textFromImage, font, PdfSharp.Drawing.XBrushes.Black, rect, format);

            document.Save(pdfPathForConvertion);
            document.Close();

            Visualization view = new Visualization();
            view.ShowDialog();

            return pdfPathForConvertion;

        }
        public string GetPdfPath()
        {
            return pdfPathForConvertion;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedFilePath = ofd.FileName;
                lblFileUploaded.Text = selectedFilePath;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void btnSearchDevices_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceManager = new WIA.DeviceManager();
                WIA.DeviceInfo availableScanner = null;

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WIA.WiaDeviceType.ScannerDeviceType)
                        continue;

                    availableScanner = deviceManager.DeviceInfos[i];

                    break;
                }

                if (availableScanner is null)
                    MessageBox.Show($"Nenhum scanner foi encontrado.");
                else
                {
                    var device = availableScanner.Connect();

                    var scannerItem = device.Items[1];
                }
                //test
                IMockScannerInfo mockScanner = new MockScannerInfo();
                listDevices.Items.Add(mockScanner.Name);

            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            IMockScannerInfo mockScanner = new MockScannerInfo();
            try
            {
                var deviceManager = new WIA.DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WIA.WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }

                    listDevices.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                }

                listDevices.Items.Add(mockScanner.Name);
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FileUpload()
        {
            //ofd.Filter = "Text Files|*.txt|All Files|*.*";
            //ofd.Title = "Select a File";

            //Button btnUpload = new Button();
            //btnUpload.Text = "Upload File";
            //btnUpload.Click += btnUpload_Click;
            //Controls.Add(btnUpload);
        }
    }
}