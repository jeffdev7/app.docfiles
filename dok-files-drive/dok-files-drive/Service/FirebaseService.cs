using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Storage.V1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dok_files_drive.Service
{
    public class FirebaseService
    {
        private readonly IFirebaseClient _client;
        private readonly IFirebaseConfig _config;
        private readonly string _firebaseStorageBaseUrl = "gs://login-dok.appspot.com";
        private readonly string _bucketName = "login-dok.appspot.com";
        private static string apiKey = "AIzaSyDR1TwOlNWsVApoqYKXENEOQVq_C2sCR8M";
        static string signInEndpoint = "signInWithPassword";
        private string signUpUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}";
        private string signInUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:{signInEndpoint}?key={apiKey}";

        public FirebaseService()
        {
            _config = new FirebaseConfig
            {
                AuthSecret = "p70aUXDWGneKL478O5LJaNpshiiVfurHUChP2ZQD",
                BasePath = "https://login-dok-default-rtdb.firebaseio.com/"
            };
            _client = new FireSharp.FirebaseClient(_config);
        }

        public async Task<string> SignUpWithEmailAndPasswordAsync(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}",
                    System.Text.Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(signUpUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);
                    string localId = json["localId"].Value<string>();

                    return localId;
                }
                else
                {
                    string errorMessage = "";
                    var errorContent = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(errorContent);
                    JArray errorDetails = (JArray)json["error"]["errors"];

                    foreach (JObject errorDetail in errorDetails)
                    {
                        errorMessage = (string)errorDetail["message"];
                    }

                    if (errorMessage.Contains("INVALID_EMAIL"))
                        MessageBox.Show("Insira um email válido.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    else if (errorMessage.Contains("WEAK_PASSWORD"))
                        MessageBox.Show("Insira uma senha maior do que 6 caracteres.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    else
                        MessageBox.Show($"Error: {errorContent}");

                    return null;
                }
            }
        }
        public async Task<string> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(
                    $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}",
                    System.Text.Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(signInUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);
                    string localId = json["localId"].Value<string>();

                    return localId;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Email ou senha incorretos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {errorContent}");
                    return null;
                }
            }
        }
        public FirebaseResponse SetData(string path, object data)
        {
            return _client.Set(path, data);
        }
        public FirebaseResponse GetData(string path)
        {
            return _client.Get(path);
        }
        public string UploadPdfToStorage(string pdfFilePath, string storagePath)
        {
            try
            {
                string destinationPath = $"{_bucketName}/{storagePath}";
                string storageUrl = $"{_firebaseStorageBaseUrl}/{destinationPath}";

                var storage = StorageClient.Create();

                using (var fileStream = File.OpenRead(pdfFilePath))
                {
                    var storageObject = storage.UploadObject(_bucketName, storagePath, null, fileStream);

                    string uploadedFileUrl = $"https://storage.googleapis.com/{_bucketName}/{storagePath}";
                    return uploadedFileUrl;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading PDF to Firebase Storage: " + ex.Message);
                return null;
            }
        }
        public List<string> ListFilesInStorage(string folderPath)
        {
            List<string> fileNames = new List<string>();

            try
            {
                var storage = StorageClient.Create();

                var objects = storage.ListObjects(_bucketName, folderPath);

                foreach (var storageObject in objects)
                {
                    fileNames.Add(storageObject.Name);
                }
            }
            catch (Google.GoogleApiException ex)
            {
                Console.WriteLine("Error listing files in Firebase Storage: " + ex.Message);
            }

            return fileNames;
        }
        public string GetFileUrl(string fileName)
        {
            try
            {
                var storage = StorageClient.Create();
                var storageObject = storage.GetObject(_bucketName, fileName);

                return storageObject.MediaLink;
            }
            catch (Google.GoogleApiException ex)
            {
                Console.WriteLine("Error getting file URL from Firebase Storage: " + ex.Message);
                return null;
            }
        }
    }
}
