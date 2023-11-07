using dok_files_drive.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class SignUp : Form
    {
        private FirebaseService _firebaseService;
        public SignUp()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            _firebaseService = new FirebaseService();
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewUser.Text) || string.IsNullOrEmpty(txtPasswordSignUp.Text)
                || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string email = txtNewUser.Text;
                string password = txtPasswordSignUp.Text;

                try
                {
                    string localId = await _firebaseService.SignUpWithEmailAndPasswordAsync(email, password);

                    if (!string.IsNullOrEmpty(localId))
                    {
                        MessageBox.Show("Successfully registered.");
                        this.Hide();
                        Login form = new Login();
                        form.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error registering user: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
