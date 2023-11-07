using dok_files_drive.Service;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class FilesFromCloud : Form
    {
        private readonly FirebaseService _firebaseService = new FirebaseService();
        public FilesFromCloud()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            listView1.DoubleClick += ListView1_DoubleClick;
        }
        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string fileName = selectedItem.Text;
                ViewFileInBrowser(fileName);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void FilesFromCloud_Load(object sender, EventArgs e)
        {
            DisplayThumbnails();
        }
        public string GetFileUrl(string fileName)
        {
            return _firebaseService.GetFileUrl(fileName);
        }
        private Image LoadDefaultThumbnail()
        {
            return Properties.Resources.pdf_icon;
        }
        private void DisplayThumbnails()
        {
            string folderPath = "Files/";

            var fileNames = _firebaseService.ListFilesInStorage(folderPath);
            int amount = fileNames.Count - 1;
            lblFilesAmount.Text = $"{amount} arquivo(s) encontrado(s)";

            ImageList thumbnailImageList = new ImageList();
            thumbnailImageList.ImageSize = new Size(100, 100);
            thumbnailImageList.Images.Add("shit", Properties.Resources.pdf_icon);

            listView1.LargeImageList = thumbnailImageList;
            listView1.View = View.LargeIcon;

            int imageIndex = 0;

            foreach (var fileName in fileNames)
            {
                ///string cleanName = Regex.Replace(fileName, @"^Files/", "");

                if (imageIndex > 0)
                {
                    Image image = LoadDefaultThumbnail();
                    thumbnailImageList.Images.Add(fileName, image);

                    ListViewItem item = new ListViewItem(fileName);
                    item.ImageKey = "shit";

                    listView1.Items.Add(item);
                }

                imageIndex++;
            }
        }
        public void ViewFileInBrowser(string fileName)
        {
            string fileUrl = _firebaseService.GetFileUrl(fileName);

            if (!string.IsNullOrEmpty(fileUrl))
            {
                try
                {
                    Process.Start(fileUrl);
                    //Anonymous caller does not have storage.objects.get access to the Google Cloud Storage object. Permission 'storage.objects.get' denied on resource (or it may not exist).
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error opening the file in the browser: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File URL is not available.");
            }
        }
    }
}
