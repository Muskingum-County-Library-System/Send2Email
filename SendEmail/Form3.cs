using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Cryptography;

namespace SendEmail
{
    public partial class Form3 : Form
    {
        /*
         * Form3 is the configuration window for Send2Email
         */

        #region UI

        //Default info in the info textbox
        string defaultInfo = "Helpful information about each section will display here when you hover over a textbox with your mouse.";

        public Form3() //Automatically generated codeblock
        {
            InitializeComponent();
            SetInfoBox(defaultInfo);
            FillData();
        }

        //This will set the info textbox's contents when you hover over an input field
        private void SetInfoBox(string input)
        {
            infoBox.Text = input;
        }

        //Fill the input fields with the data from the config file
        public void FillData()
        {
            hostTB.Text = Program.smtp_host;
            portTB.Text = Program.smtp_port.ToString();
            emailTB.Text = Program.smtp_user;
            passwordTB.Text = Program.smtp_pass;

            fromTB.Text = Program.mail_from;
            subjectTB.Text = Program.mail_subject;
            bodyTB.Text = Program.mail_body;
            deliveryTB.Text = Program.mail_delivery;

            extensionsTB.Text = Program.file_extensions;
        }

        //Detects when mouse hovers over an input field and calls SetInfoBox() with updated info text
        private void HoverInfo(object sender, EventArgs e)
        {
            TextBox holder = (TextBox)sender; //Hold onto the sender event that triggered HoverInfo()
            string holdName = holder.Name; //Get the name of the sender that triggered HoverInfo()
            string output;

            switch (holdName) //Switch through the possible input fields and sets the output to the correct values
            {
                case "hostTB":
                    output = "SMTP Host: SMTP Host. At the time of creation, we utalize Google's SMTP server located at smtp.google.com";
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
                case "deliveryTB":
                    output = "Mail Delivery: is the message that will appear on screen once the user has successfully emailed themselves";
                    break;
                case "extensionsTB":
                    output = "File Extensions: This determines the types of files that will be scraped from the Pictures folder.\r\nSeparate each entry with a comma, you do not need to include the period for any extensions.\r\nDefaults: jpg, jpeg, png, gif, bmp, tif, pdf";
                    break;
                default:
                    output = defaultInfo;
                    break;
            }

            SetInfoBox(output); //Send the output text to the info textbox
        }

        #endregion

        #region Save/Load Configuration

        //Save the configuration data, will overwrite existing settings
        private void SaveConfig(object sender, EventArgs e)
        {
            string cfg_host = hostTB.Text;
            string string_cfg_port = portTB.Text;
            string cfg_user = emailTB.Text;
            string cfg_pass = passwordTB.Text;

            string cfg_from = fromTB.Text;
            string cfg_subject = subjectTB.Text;
            string cfg_body = bodyTB.Text;
            string cfg_delivery = deliveryTB.Text;

            string cfg_extensions = extensionsTB.Text;

            int cfg_port = Int32.Parse(string_cfg_port);

            //Create a JSON object with the configuration data
            Config cfg = new Config(cfg_host, cfg_port, cfg_user, cfg_pass, cfg_from, cfg_subject, cfg_body, cfg_delivery, cfg_extensions);

            //Serialize the JSON data so it can be written to a text file
            string[] json = { JsonConvert.SerializeObject(cfg, Formatting.Indented) };

            //Write Config file to Program.appPath (default is Appdata/Local/Send2Email)
            WriteFile(json, Program.configName, Program.configFileExt);
        }


        public static bool LoadConfig() //Boolean method, returns true or false to whatever called LoadConfig
        {
            //Config filepath
            string cfg = Program.appPath + "/" + Program.configFileName;

            //Check if config file exists
            bool cExist = File.Exists(cfg);

            if (!cExist) //If a config doesn't exist
            {
                return false; //Return false for LoadConfig boolean
            }
            else //Config file does exist
            {
                //Create an array to store the configuration file line by line
                string[] cfgFile = ReadFile("cfg", "json");
                string cfgData = ConvertStringArray(cfgFile);

                //Get the first line of our configuration

                Config config = JsonConvert.DeserializeObject<Config>(cfgData);

                Program.smtp_host = config.SMTP_Host;
                Program.smtp_port = config.SMTP_Port;
                Program.smtp_user = config.SMTP_User;
                Program.smtp_pass = config.SMTP_Pass;

                Program.mail_from = config.Mail_From;
                Program.mail_body = config.Mail_Body;
                Program.mail_subject = config.Mail_Subject;
                Program.mail_delivery = config.Mail_Delivery;

                Program.file_extensions = config.File_Extensions;

                return true;
            }
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
         * data as a single string rather than an array of string data*/
        public static string ConvertStringArray(string[] input)
        {
            string output = "";
            foreach (string line in input) //Loop through input and append it to the end of output
            {
                output += line;
            }

            return output;
        }

        #region JSON Config
        /* Sources 
         * https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
         * https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm
         */
        public class Config
        {
            public string SMTP_Host { get; set; }
            public int SMTP_Port { get; set; }
            public string SMTP_User { get; set; }
            public string SMTP_Pass { get; set; }

            public string Mail_From { get; set; }
            public string Mail_Subject { get; set; }
            public string Mail_Body { get; set; }
            public string Mail_Delivery { get; set; }

            public string File_Extensions { get; set; }

            public Config(string smtp_host, int smtp_port, string smtp_user, string smtp_pass, string mail_from, string mail_subject, string mail_body, string mail_delivery, string file_extensions)
            {
                SMTP_Host = smtp_host;
                SMTP_Port = smtp_port;
                SMTP_User = smtp_user;
                SMTP_Pass = smtp_pass;

                Mail_From = mail_from;
                Mail_Subject = mail_subject;
                Mail_Body = mail_body;
                Mail_Delivery = mail_delivery;

                File_Extensions = file_extensions;
            }
        }

        #endregion

        #endregion


    }
}
