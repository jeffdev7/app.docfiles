using dok_files_drive.Service;
using FirebaseAdmin.Auth;
using System;
using System.Windows.Forms;

namespace dok_files_drive
{
    public partial class Login : Form
    {
        private FirebaseService _firebaseService;
        public Login()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            SignUp signUpPage = new SignUp();
            this.Hide();
            signUpPage.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                _firebaseService = new FirebaseService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} check your connection");
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("All fields must be field");
            }
            else
            {
                string email = txtUser.Text;
                string password = txtPassword.Text;

                try
                {
                    var auth = FirebaseAuth.DefaultInstance;
                    var user = await _firebaseService.SignInWithEmailAndPasswordAsync(email, password);

                    if (user != null && user != string.Empty)
                    {
                        Home home = new Home();
                        this.Hide();
                        home.ShowDialog();
                    }
                }
                catch (FirebaseAuthException ex)
                {
                    MessageBox.Show("Error signing in: " + ex.Message.ToString());
                }
            }
        }
    }
}
