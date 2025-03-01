﻿using System;
using System.Windows.Forms;

namespace SendEmail
{
    public partial class Form1 : Form
    {
        /*
         * Form1 is the main window for Send2Email
         */
        #region UI
        public Form1()
        {
            InitializeComponent();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        private void ConfigClick(object sender, EventArgs e)
        {
            this.Hide(); // Hide Form1
            var form2 = new Form2(); // Create Form 2
            form2.Closed += (s, args) => this.Show(); // Attach this.Show() to the Form2.Close() eventhandler, which will show Form1 when Form2 closes.
            form2.Show(); // Show Form2
        }

        private void SendClick(object sender, EventArgs e)
        {
            string email = EmailInput.Text; // Get Email from Text Input
            // Checks if email is valid, this does not check if the email address DOES exist, just if it CAN exist
            if (Program.IsValidEmail(email)) // If email is valid
            {
                Program.Send(email); // Sends valid email to Send() function from within Program.cs
            }
            else // If the email is not valid
            {
                // Error Message for invalid email
                MessageBox.Show(email + " is not a valid email address.\r\nPlease enter a valid email address.");
            }
        }
        #endregion

        // Check if enter key is pressed in email address input
        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // If enter key pressed run the SendClick() function
            {
                SendClick(sender, e);
            }
        }
    }
}
