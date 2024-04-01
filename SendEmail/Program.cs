using System;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SendEmail
{
     class Program
    {
        #region Global Variables
        //File Explorer Path
        //C:\Users\[USER]\AppData\Local\Send2Email
        public static string appPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Send2Email\\";

        //My Pictures Path
        //C:\Users\[USER]\My Pictures
        public static string picPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        //Variables to be loaded from config file
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
        public static string mail_delivery;
        public static string file_extensions;
        #endregion

        #region Main Method
        [STAThread]
        static void Main() //Main method, this runs as soon as the software is started
        {
            //Set up the basic requirements for a WinForms application
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            bool cont = Form3.LoadConfig(); //Load Configuration method
            if (cont) //If Config exists
            {
                Application.Run(new Form1()); //Open Form1 (Main Window)
            }
            else //If Config Doesn't Exist
            {
                //Display an error message before closing the application
                MessageBox.Show("A critical error has occurred. Configuration file is missing. Send2Email will not function without this configuration file. Please contact IT to resolve this issue.");
                Application.Exit(); //Exit the application
            }
        }
        #endregion

        #region Email Methods

        #region IsValidEmail
        //Checks if the email address entered is valid.
        //Source https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        public static bool IsValidEmail(string email) //Accepts an email string and returns true if email is valid
        {
            if (string.IsNullOrWhiteSpace(email)) //Null strings aren't valid so return false
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

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
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        #endregion

        #region Attachments
        //Checks files in Windows Pictures folder
        //returns filepaths with matching extensions
        public static string[] Attachments()
        {

            string[] extensions;
            List<string> output = new List<string>(); //Holds the output

            try
            {
                extensions = file_extensions.Split(",");
                for (int e = 0; e < extensions.Length; e++)
                {
                    extensions[e] = extensions[e].Trim(' '); //Remove any whitespace
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing extension " + ex + "\r\nUsing default values.\r\njpg, jpeg, png, gif, bmp, tif, pdf");
                string[] fill = { "jpg", "jpeg", "tif", "gif", "bmp", "pdf" };
                extensions = fill;
            }

            string[] files = Directory.GetFiles(picPath); //Get array of all files in Pictures folder

            for (int i = 0; i < files.Length; i++) //Loop through all files
            {
                string file = files[i]; //current file
                for(int j = 0; j < extensions.Length; j++) //Loop through all extensions for each file
                {
                    string footer = file.Substring(file.Length - extensions[j].Length);
                    //If the file ends with an extension from our extensions array
                    if (footer.ToString() == extensions[j].ToString())
                    {
                        output.Add(files[i]); //Add it to the output
                    }
                }

            }

            return output.ToArray(); //Return a list of all attachments
        }

        #endregion

        #region Send Email

        public static void Send(string sendTo) //Send email function. This is where most of the work starts
        {
            string[] getAttachments = Attachments(); //Gets all valid attachment files in Pictures folder

            try
            {
                System.Net.Mail.Attachment attachment; //Create attachment variable
                MailMessage mail = new MailMessage(); //Create mail variable
                SmtpClient SmtpServer = new SmtpClient(smtp_host); //Create SmtpClient

                //Load smtp/email settings from Configuration file
                SmtpServer.Port = smtp_port;
                mail.From = new MailAddress(mail_from);
                mail.Subject = mail_subject;
                mail.Body = mail_body;

                mail.To.Add(sendTo.ToString()); //Get sendTo email from user input

                for(int i = 0; i < getAttachments.Length; i++) //Loop through each attachment
                {
                    attachment = new System.Net.Mail.Attachment(getAttachments[i]); //Set the attachment variable
                    mail.Attachments.Add(attachment); //Attach the new attachment to the email
                }

                SmtpServer.Credentials = new System.Net.NetworkCredential(smtp_user, smtp_pass); //Login to SMTP
                SmtpServer.EnableSsl = true; //Use SSL Encryption

                SmtpServer.Send(mail); //Send our mail variable
                MessageBox.Show(mail_delivery + sendTo); //Popup informs user where the email was sent
            }
            catch (Exception ex) //If the Try fails the catch will output this error message.
            {
                MessageBox.Show("A critical error has occured please contact IT \r\n" + ex.ToString());
            }
        }

        #endregion

        #endregion
    }
}


#region [ARCHIVE]
/* This code is commented out, but it might be 
 * useful if we ever need to work on the software 
 * again in the future, so I've kept it archived. */

#region [ARCHIVE] Encryption, Decryption
/*
//Methods used to encrypt and decrypt a string
//Source https://www.delftstack.com/howto/csharp/encrypt-and-decrypt-a-string-in-csharp/

public static string Encrypt(string input)
{
    try
    {
        string textToEncrypt = input;
        string ToReturn = "";
        byte[] secretkeyByte = { };
        secretkeyByte = System.Text.Encoding.UTF8.GetBytes(key_secret);
        byte[] publickeybyte = { };
        publickeybyte = System.Text.Encoding.UTF8.GetBytes(key_public);
        MemoryStream ms = null;
        CryptoStream cs = null;
        byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            ms = new MemoryStream();
            cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            ToReturn = Convert.ToBase64String(ms.ToArray());
        }
        return ToReturn;
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message, ex.InnerException);
    }
}

static string Decrypt(string input)
{
    try
    {
        string textToDecrypt = input;
        string ToReturn = "";
        byte[] privatekeyByte = { };
        privatekeyByte = System.Text.Encoding.UTF8.GetBytes(key_secret);
        byte[] publickeybyte = { };
        publickeybyte = System.Text.Encoding.UTF8.GetBytes(key_public);
        MemoryStream ms = null;
        CryptoStream cs = null;
        byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
        inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            ms = new MemoryStream();
            cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            ToReturn = encoding.GetString(ms.ToArray());
        }
        return ToReturn;
    }
    catch (Exception ae)
    {
        throw new Exception(ae.Message, ae.InnerException);
    }
}
*/
#endregion

#region [ARCHIVE] Encrypt/Decrypt Files
/*
public static void WriteEncryptedFile(string[] data, string fileName, string fileExtension)
{

    string temp = "";
    string file = fileName + "." + fileExtension;

    // Write the string array to a new file named "WriteLines.txt".
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(appPath, file)))
    {
        foreach (string line in data)
        {
            temp = Encrypt(line);
        }
        outputFile.WriteLine(temp);
    }
}

public static string[] ReadEncryptedFile(string fileName, string fileExtension)
{
    string temp = "";
    string file = fileName + "." + fileExtension;

    string[] lines = System.IO.File.ReadAllLines(Path.Combine(appPath, file));
    string[] output = new string[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
        temp = Decrypt(lines[i]);
        output[i] = temp;
    }

    return output;
}

*/
#endregion

#region [ARCHIVE] Keygen 
/*
//Used origonally do generate public and secret keys
public static string GenerateKey(int length)
{
    //Random
    Random rand = new Random();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
}
*/
#endregion

#endregion