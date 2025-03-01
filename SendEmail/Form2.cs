﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SendEmail
{
    public partial class Form2 : Form
    {
        /*
         * Form2 is only the password prompt to enter the configuration menu
         */

        // Global Variables
        int wrongCount = 0; // Counts how many times the password is entered incorrectly
        const int LIMIT = 5; // The amount of times a password can be tried before exiting

        public Form2()
        {
            InitializeComponent();
        }

        // Checks the password entered
        private void PassButtonClick(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string decryptedConfigPass = Program.Decrypt(Program.config_pass);
            if (input == decryptedConfigPass)
            {
                this.Hide(); // Hide Form2
                var form3 = new Form3(); // Create Form3
                form3.Closed += (s, args) => this.Close(); // Attach this.Show() to the Form3.Close() eventhandler, which will show Form2 when Form3 closes.
                form3.Show(); // Show Form3
            }
            else
            {
                wrongCount++; // Each time this code is reached the wrong counter increases by 1
                if (wrongCount == LIMIT) // If we've reached the limit
                {
                    Application.Exit(); // Exit the application
                }
                else // If we haven't reached the limit
                {
                    // Inform user the number of password attempts remaining.
                    MessageBox.Show("Incorrect password. " + (LIMIT - wrongCount).ToString() + " attempts remaining.");
                }
            }
        }

        // Check if enter key is pressed in the password text box
        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                PassButtonClick(sender, e);
            }
        }
    }
}
