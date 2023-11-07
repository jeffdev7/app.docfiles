using System;
using System.IO;
using System.Windows.Forms;

namespace dok_files_drive
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string key = "login-dok-firebase-adminsdk-v6qz5-d661325854.json";
            var keyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, key);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyPath);

            Application.Run(new Splash());
        }
    }
}