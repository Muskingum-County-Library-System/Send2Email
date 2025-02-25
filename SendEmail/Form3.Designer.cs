
namespace SendEmail
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showSMTPPassBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.fromTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.subjectTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bodyTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.showConfigPassBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.configPasswordTB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.extensionsTB = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // hostTB
            // 
            this.hostTB.Location = new System.Drawing.Point(71, 32);
            this.hostTB.Name = "hostTB";
            this.hostTB.Size = new System.Drawing.Size(431, 23);
            this.hostTB.TabIndex = 0;
            this.hostTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // portTB
            // 
            this.portTB.Location = new System.Drawing.Point(71, 61);
            this.portTB.Name = "portTB";
            this.portTB.Size = new System.Drawing.Size(431, 23);
            this.portTB.TabIndex = 2;
            this.portTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(71, 90);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(431, 23);
            this.emailTB.TabIndex = 4;
            this.emailTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(71, 119);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '●';
            this.passwordTB.Size = new System.Drawing.Size(357, 23);
            this.passwordTB.TabIndex = 6;
            this.passwordTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.showSMTPPassBtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.hostTB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.portTB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.emailTB);
            this.panel1.Controls.Add(this.passwordTB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 155);
            this.panel1.TabIndex = 11;
            // 
            // showSMTPPassBtn
            // 
            this.showSMTPPassBtn.Location = new System.Drawing.Point(434, 119);
            this.showSMTPPassBtn.Name = "showSMTPPassBtn";
            this.showSMTPPassBtn.Size = new System.Drawing.Size(68, 23);
            this.showSMTPPassBtn.TabIndex = 18;
            this.showSMTPPassBtn.Text = "Show";
            this.showSMTPPassBtn.UseVisualStyleBackColor = true;
            this.showSMTPPassBtn.Click += new System.EventHandler(this.toggleShowSMTP);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "SMTP Settings";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.fromTB);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.subjectTB);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.bodyTB);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(12, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 122);
            this.panel2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mail Settings";
            // 
            // fromTB
            // 
            this.fromTB.Location = new System.Drawing.Point(71, 32);
            this.fromTB.Name = "fromTB";
            this.fromTB.Size = new System.Drawing.Size(431, 23);
            this.fromTB.TabIndex = 0;
            this.fromTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "From";
            // 
            // subjectTB
            // 
            this.subjectTB.Location = new System.Drawing.Point(71, 61);
            this.subjectTB.Name = "subjectTB";
            this.subjectTB.Size = new System.Drawing.Size(431, 23);
            this.subjectTB.TabIndex = 2;
            this.subjectTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Subject";
            // 
            // bodyTB
            // 
            this.bodyTB.Location = new System.Drawing.Point(71, 90);
            this.bodyTB.Name = "bodyTB";
            this.bodyTB.Size = new System.Drawing.Size(431, 23);
            this.bodyTB.TabIndex = 4;
            this.bodyTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Body";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.showConfigPassBtn);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.configPasswordTB);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.extensionsTB);
            this.panel3.Location = new System.Drawing.Point(12, 302);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(521, 95);
            this.panel3.TabIndex = 13;
            // 
            // showConfigPassBtn
            // 
            this.showConfigPassBtn.Location = new System.Drawing.Point(434, 59);
            this.showConfigPassBtn.Name = "showConfigPassBtn";
            this.showConfigPassBtn.Size = new System.Drawing.Size(68, 23);
            this.showConfigPassBtn.TabIndex = 17;
            this.showConfigPassBtn.Text = "Show";
            this.showConfigPassBtn.UseVisualStyleBackColor = true;
            this.showConfigPassBtn.Click += new System.EventHandler(this.toggleShowConfig);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Config PW";
            // 
            // configPasswordTB
            // 
            this.configPasswordTB.Location = new System.Drawing.Point(71, 60);
            this.configPasswordTB.Name = "configPasswordTB";
            this.configPasswordTB.PasswordChar = '●';
            this.configPasswordTB.Size = new System.Drawing.Size(357, 23);
            this.configPasswordTB.TabIndex = 8;
            this.configPasswordTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "Extensions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "General Settings";
            // 
            // extensionsTB
            // 
            this.extensionsTB.Location = new System.Drawing.Point(71, 32);
            this.extensionsTB.Name = "extensionsTB";
            this.extensionsTB.Size = new System.Drawing.Size(431, 23);
            this.extensionsTB.TabIndex = 2;
            this.extensionsTB.MouseEnter += new System.EventHandler(this.HoverInfo);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 403);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(521, 23);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveConfig);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.infoBox);
            this.panel4.Location = new System.Drawing.Point(540, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 413);
            this.panel4.TabIndex = 15;
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(3, 3);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(163, 405);
            this.infoBox.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 440);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "Send2Email Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox hostTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fromTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox subjectTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox bodyTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox extensionsTB;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox configPasswordTB;
        private System.Windows.Forms.Button showSMTPPassBtn;
        private System.Windows.Forms.Button showConfigPassBtn;
    }
}