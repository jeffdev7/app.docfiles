using System;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBarSplash.Increment(5);

            if (progressBarSplash.Value == 100)
            {
                timer1.Enabled = false;
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }
    }
}
