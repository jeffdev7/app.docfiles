using System;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            Main mainScreen = new Main();
            mainScreen.Show();
            this.Hide();
        }

        private void btnViewFiles_Click(object sender, EventArgs e)
        {
            FilesFromCloud fromCloud = new FilesFromCloud();
            fromCloud.Show();
            this.Hide();
        }
    }
}
