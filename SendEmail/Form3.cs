﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace SendEmail
{
    public partial class Form3 : Form
    {
        /*
         * Form3 is the configuration window for Send2Email
         */

        public bool showingSMTPPass = false;
        public bool showingConfigPass = false;

        #region UI

        // Default info in the info textbox
        string defaultInfo = "Helpful information about each section will display here when you hover over a textbox with your mouse.";

        public Form3()
        {
            InitializeComponent();
            SetInfoBox(defaultInfo);
            FillData();
        }

        // This will set the info textbox's contents when you hover over an input field
        private void SetInfoBox(string input)
        {
            infoBox.Text = input;
        }

        // Fill the input fields with the data from the config file
        public void FillData()
        {
            hostTB.Text = Program.smtp_host;
            portTB.Text = Program.smtp_port.ToString();
            emailTB.Text = Program.smtp_user;
            passwordTB.Text = Program.Decrypt(Program.smtp_pass); // Decrypt password for display

            fromTB.Text = Program.mail_from;
            subjectTB.Text = Program.mail_subject;
            bodyTB.Text = Program.mail_body;

            configPasswordTB.Text = Program.Decrypt(Program.config_pass); // Decrypt password for display

            extensionsTB.Text = Program.file_extensions;
        }

        // Detects when mouse hovers over an input field and calls SetInfoBox() with updated info text
        private void HoverInfo(object sender, EventArgs e)
        {
            TextBox holder = (TextBox)sender; // Hold onto the sender event that triggered HoverInfo()
            string holdName = holder.Name; // Get the name of the sender that triggered HoverInfo()

            string output;

            switch (holdName) // Switch through the possible input fields and sets the output to the correct values
            {
                case "hostTB":
                    output = "SMTP Host: SMTP Host. At the time of creation, we utilize Google's SMTP server located at smtp.google.com";
                    break;
                case "portTB":
                    output = "SMTP Port: SMTP Port";
                    break;
                case "emailTB":
                    output = "SMTP Email: The Email Address that is signing into the SMTP server.";
                    break;
                case "passwordTB":
                    output = "SMTP Password: The password to sign into the SMTP server.";
                    break;
                case "fromTB":
                    output = "Mail From: This is the email that will be listed in the 'from' section of the recipients email";
                    break;
                case "subjectTB":
                    output = "Mail Subject: This is what will be put into the subject line of the email";
                    break;
                case "bodyTB":
                    output = "Mail Body: This is what will be put into the body of the email";
                    break;
                case "extensionsTB":
                    output = "File Extensions: This determines the types of files that will be scraped from the Pictures folder.\r\nSeparate each entry with a comma, you do not need to include the period for any extensions.\r\nDefaults: jpg, jpeg, png, gif, bmp, tif, pdf";
                    break;
                case "configPasswordTB":
                    output = "Config Password: The password to access the settings.";
                    break;
                default:
                    output = defaultInfo;
                    break;
            }

            SetInfoBox(output); // Send the output text to the info textbox
        }

        public bool toggleHiddenPW(bool isShowing, TextBox passTextBox)
        {
            isShowing = !isShowing; // Toggle the boolean value
            passTextBox.PasswordChar = isShowing ? '\0' : '●'; // Set ● when enabled, empty when disabled
            return isShowing; // Return updated value
        }

        public void toggleShowConfig(object sender, EventArgs e)
        {
            showingConfigPass = toggleHiddenPW(showingConfigPass, configPasswordTB);
        }

        private void toggleShowSMTP(object sender, EventArgs e)
        {
            showingSMTPPass = toggleHiddenPW(showingSMTPPass, passwordTB);
        }

        #endregion

        #region Save/Load Configuration

        // Save the configuration data, will overwrite existing settings
        private void SaveConfig(object sender, EventArgs e)
        {
            string cfg_host = hostTB.Text;
            string string_cfg_port = portTB.Text;
            string cfg_user = emailTB.Text;
            string cfg_pass = Program.Encrypt(passwordTB.Text); // Encrypt the SMTP password

            string cfg_from = fromTB.Text;
            string cfg_subject = subjectTB.Text;
            string cfg_body = bodyTB.Text;

            string cfg_extensions = extensionsTB.Text;
            string cfg_config_pass = Program.Encrypt(configPasswordTB.Text); // Encrypt the config password

            int cfg_port = Int32.Parse(string_cfg_port);

            // Create a JSON object with the configuration data
            Config cfg = new Config(cfg_host, cfg_port, cfg_user, cfg_pass, cfg_from, cfg_subject, cfg_body, cfg_extensions, cfg_config_pass);

            // Serialize the JSON data so it can be written to a text file
            string[] json = { JsonConvert.SerializeObject(cfg, Formatting.Indented) };

            // Write Config file to Program.appPath (default is Appdata/Local/Send2Email)
            WriteFile(json, Program.configName, Program.configFileExt);

            // Close Form3 and open Form1
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
            LoadConfig(); //Load the new config so that we process any updates the user made.
        }

        public static bool LoadConfig() // Boolean method, returns true or false to whatever called LoadConfig
        {
            // Config filepath in AppData
            string cfgFilePath = Path.Combine(Program.appPath, Program.configFileName);
            // Example config filepath in the bin directory of the project
            string exampleCfgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "example.cfg.json");

            // Check if config file exists in AppData
            bool cExist = File.Exists(cfgFilePath);

            if (!cExist) // If a config doesn't exist
            {
                // Check if example config exists in the bin directory of the project
                if (File.Exists(exampleCfgFilePath))
                {
                    // Ensure the directory exists
                    if (!Directory.Exists(Program.appPath))
                    {
                        Directory.CreateDirectory(Program.appPath);
                    }

                    // Copy the example config to the AppData config file path
                    File.Copy(exampleCfgFilePath, cfgFilePath);
                }
                else
                {
                    // Display an error message before closing the application
                    MessageBox.Show("A critical error has occurred. Example configuration file is missing. Please contact IT to resolve this issue.");
                    return false; // Return false for LoadConfig boolean
                }
            }

            // Create an array to store the configuration file line by line
            string[] cfgFile = ReadFile("cfg", "json");
            string cfgData = ConvertStringArray(cfgFile);

            // Get the first line of our configuration
            Config config = JsonConvert.DeserializeObject<Config>(cfgData);

            Program.smtp_host = config.SMTP_Host;
            Program.smtp_port = config.SMTP_Port;
            Program.smtp_user = config.SMTP_User;
            Program.smtp_pass = config.SMTP_Pass;

            Program.mail_from = config.Mail_From;
            Program.mail_body = config.Mail_Body;
            Program.mail_subject = config.Mail_Subject;

            Program.config_pass = config.Config_Pass;

            Program.file_extensions = config.File_Extensions;

            return true;
        }

        #endregion

        #region Read/Write Files

        // Create a string array with the lines of text
        public static void WriteFile(string[] data, string fileName, string fileExtension)
        {
            string temp = "";
            string file = fileName + "." + fileExtension;

            // Write the string array to a new file named fileName + "." + fileExtension
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Program.appPath, file)))
            {
                foreach (string line in data)
                {
                    temp = line;
                }
                outputFile.WriteLine(temp);
            }
        }

        public static string[] ReadFile(string fileName, string fileExtension)
        {
            string temp = "";
            string file = fileName + "." + fileExtension;

            string[] lines = System.IO.File.ReadAllLines(Path.Combine(Program.appPath, file));
            string[] output = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                temp = lines[i];
                output[i] = temp;
            }

            return output;
        }

        /* Takes a multi-line file and turns it into a single-line string
         * This is really only here because the JSON files are pretty-printed
         * for human readability, but it's much easier to work with the JSON
         * data as a single string rather than an array of string data */
        public static string ConvertStringArray(string[] input)
        {
            string output = "";
            foreach (string line in input) // Loop through input and append it to the end of output
            {
                output += line;
            }

            return output;
        }

        #region JSON Config
        public class Config
        {
            public string SMTP_Host { get; set; }
            public int SMTP_Port { get; set; }
            public string SMTP_User { get; set; }
            public string SMTP_Pass { get; set; }
            public string Mail_From { get; set; }
            public string Mail_Subject { get; set; }
            public string Mail_Body { get; set; }
            public string Config_Pass { get; set; }
            public string File_Extensions { get; set; }
            public string Key_Public { get; set; } // New property

            public Config(string smtp_host, int smtp_port, string smtp_user, string smtp_pass, string mail_from, string mail_subject, string mail_body, string file_extensions, string config_pass)
            {
                SMTP_Host = smtp_host;
                SMTP_Port = smtp_port;
                SMTP_User = smtp_user;
                SMTP_Pass = smtp_pass;

                Mail_From = mail_from;
                Mail_Subject = mail_subject;
                Mail_Body = mail_body;

                File_Extensions = file_extensions;
                Config_Pass = config_pass;
            }
        }
        #endregion

        #endregion
    }
}
