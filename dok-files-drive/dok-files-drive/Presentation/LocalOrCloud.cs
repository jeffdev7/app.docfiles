using dok_files_drive.Enum;
using System;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class LocalOrCloud : Form
    {
        public int SelectedOption { get; private set; }
        public LocalOrCloud()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioLocal.Checked)
            {
                SelectedOption = (int)EStorage.LOCAL;
            }
            else if (radioFirestore.Checked)
            {
                SelectedOption = (int)EStorage.FIRESTORE;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
