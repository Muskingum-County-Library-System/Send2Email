using System;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SendEmail
{
    class Program
    {
        #region Global Variables
        // File Explorer Path
        // C:\Users\[USER]\AppData\Local\Send2Email
        public static string appPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Send2Email\\";

        // My Pictures Path
        // C:\Users\[USER]\My Pictures
        public static string picPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        // Variables to be loaded from config file
        public static string configName = "cfg";
        public static string configFileExt = "json";
        public static string configFileName = configName + "." + configFileExt;

        public static string smtp_host;
        public static int smtp_port;
        public static string smtp_user;
        public static string smtp_pass;
        public static string mail_from;
        public static string mail_subject;
        public static string mail_body;
        public static string file_extensions;
        public static string config_pass;

        // Encryption keys (8 bytes for DES)
        public static string EncryptionKey = "8byteKey";
        
        #endregion

        #region Main Method
        [STAThread]
        static void Main()
        {
            // Set up the basic requirements for a WinForms application
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool cont = Form3.LoadConfig(); // Load Configuration method
            if (cont) // If Config exists
            {
                if (string.IsNullOrEmpty(config_pass)) // Check if password is empty
                {
                    // Run first time setup
                    Application.Run(new Form3());
                }
                else
                {
                    Application.Run(new Form1()); // Open Form1 (Main Window)
                }
            }
            else // If Config Doesn't Exist
            {
                // Display an error message before closing the application
                MessageBox.Show("A critical error has occurred. Configuration file is missing. Send2Email will not function without this configuration file. Please contact IT to resolve this issue.");
                Application.Exit(); // Exit the application
            }
        }
        #endregion

        #region Encryption Methods
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            using (Aes aes = Aes.Create())
            {
                aes.Key = DeriveKey(EncryptionKey);
                aes.GenerateIV(); // Generate a unique IV

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); // Store IV at the start
                    using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cryptoStream))
                    {
                        writer.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }


        public static string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                return string.Empty;

            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = DeriveKey(EncryptionKey);
                byte[] iv = new byte[aes.BlockSize / 8];

                if (cipherTextBytes.Length < iv.Length)
                    return string.Empty; // Prevents IV-related decryption errors

                Array.Copy(cipherTextBytes, iv, iv.Length); // Extract stored IV

                using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
                using (var ms = new MemoryStream(cipherTextBytes, iv.Length, cipherTextBytes.Length - iv.Length))
                using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cryptoStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static byte[] DeriveKey(string passphrase)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
            }
        }


        #endregion

        #region Email Methods

        #region IsValidEmail
        // Checks if the email address entered is valid.
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) // Null strings aren't valid so return false
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        #endregion

        #region Attachments
        // Checks files in Windows Pictures folder
        // returns filepaths with matching extensions
        public static string[] Attachments()
        {
            string[] extensions;
            List<string> output = new List<string>(); // Holds the output

            try
            {
                extensions = file_extensions.Split(",");
                for (int e = 0; e < extensions.Length; e++)
                {
                    extensions[e] = extensions[e].Trim(' '); // Remove any whitespace
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing extension " + ex + "\r\nUsing default values.\r\njpg, jpeg, png, gif, bmp, tif, pdf");
                string[] fill = { "jpg", "jpeg", "tif", "gif", "bmp", "pdf" };
                extensions = fill;
            }

            string[] files = Directory.GetFiles(picPath); // Get array of all files in Pictures folder

            for (int i = 0; i < files.Length; i++) // Loop through all files
            {
                string file = files[i]; // current file
                for (int j = 0; j < extensions.Length; j++) // Loop through all extensions for each file
                {
                    string footer = file.Substring(file.Length - extensions[j].Length);
                    // If the file ends with an extension from our extensions array
                    if (footer.ToString() == extensions[j].ToString())
                    {
                        output.Add(files[i]); // Add it to the output
                    }
                }
            }

            return output.ToArray(); // Return a list of all attachments
        }
        #endregion

        #region Send Email
        public static void Send(string sendTo)
        {
            string[] getAttachments = Attachments(); // Gets all valid attachment files in Pictures folder

            try
            {
                System.Net.Mail.Attachment attachment; // Create attachment variable
                MailMessage mail = new MailMessage(); // Create mail variable
                SmtpClient SmtpServer = new SmtpClient(smtp_host); // Create SmtpClient

                // Load smtp/email settings from Configuration file
                SmtpServer.Port = smtp_port;
                mail.From = new MailAddress(mail_from);
                mail.Subject = mail_subject;
                mail.Body = mail_body;

                mail.To.Add(sendTo.ToString()); // Get sendTo email from user input

                for (int i = 0; i < getAttachments.Length; i++) // Loop through each attachment
                {
                    attachment = new System.Net.Mail.Attachment(getAttachments[i]); // Set the attachment variable
                    mail.Attachments.Add(attachment); // Attach the new attachment to the email
                }

                SmtpServer.Credentials = new System.Net.NetworkCredential(smtp_user, Program.Decrypt(smtp_pass)); // Login to SMTP
                SmtpServer.EnableSsl = true; // Use SSL Encryption

                SmtpServer.Send(mail); // Send our mail variable
                MessageBox.Show("Your scans have been sent to " + sendTo); // Popup informs user where the email was sent
            }
            catch (Exception ex) // If the Try fails the catch will output this error message.
            {
                MessageBox.Show("A critical error has occured please contact IT \r\n" + ex.ToString());
            }
        }
        #endregion

        #endregion
    }
}
