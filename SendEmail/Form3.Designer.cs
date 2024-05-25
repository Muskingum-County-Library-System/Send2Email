
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
            hostTB = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            portTB = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            emailTB = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            passwordTB = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            fromTB = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            subjectTB = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            bodyTB = new System.Windows.Forms.TextBox();
            deliveryTB = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            label15 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            extensionsTB = new System.Windows.Forms.TextBox();
            saveBtn = new System.Windows.Forms.Button();
            panel4 = new System.Windows.Forms.Panel();
            infoBox = new System.Windows.Forms.TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // hostTB
            // 
            hostTB.Location = new System.Drawing.Point(71, 32);
            hostTB.Name = "hostTB";
            hostTB.Size = new System.Drawing.Size(431, 23);
            hostTB.TabIndex = 0;
            hostTB.MouseEnter += HoverInfo;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 1;
            label1.Text = "Host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 15);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // portTB
            // 
            portTB.Location = new System.Drawing.Point(71, 61);
            portTB.Name = "portTB";
            portTB.Size = new System.Drawing.Size(431, 23);
            portTB.TabIndex = 2;
            portTB.MouseEnter += HoverInfo;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(22, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // emailTB
            // 
            emailTB.Location = new System.Drawing.Point(71, 90);
            emailTB.Name = "emailTB";
            emailTB.Size = new System.Drawing.Size(431, 23);
            emailTB.TabIndex = 4;
            emailTB.MouseEnter += HoverInfo;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(1, 122);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // passwordTB
            // 
            passwordTB.Location = new System.Drawing.Point(71, 119);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new System.Drawing.Size(431, 23);
            passwordTB.TabIndex = 6;
            passwordTB.MouseEnter += HoverInfo;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(hostTB);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(portTB);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(emailTB);
            panel1.Controls.Add(passwordTB);
            panel1.Controls.Add(label3);
            panel1.Location = new System.Drawing.Point(12, 13);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(521, 155);
            panel1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(3, 4);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(132, 25);
            label6.TabIndex = 0;
            label6.Text = "SMTP Settings";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(fromTB);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(subjectTB);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(bodyTB);
            panel2.Controls.Add(deliveryTB);
            panel2.Controls.Add(label11);
            panel2.Location = new System.Drawing.Point(12, 174);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(521, 155);
            panel2.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(3, 4);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(121, 25);
            label7.TabIndex = 0;
            label7.Text = "Mail Settings";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 122);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(49, 15);
            label8.TabIndex = 7;
            label8.Text = "Delivery";
            // 
            // fromTB
            // 
            fromTB.Location = new System.Drawing.Point(71, 32);
            fromTB.Name = "fromTB";
            fromTB.Size = new System.Drawing.Size(431, 23);
            fromTB.TabIndex = 0;
            fromTB.MouseEnter += HoverInfo;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(23, 35);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(35, 15);
            label9.TabIndex = 1;
            label9.Text = "From";
            // 
            // subjectTB
            // 
            subjectTB.Location = new System.Drawing.Point(71, 61);
            subjectTB.Name = "subjectTB";
            subjectTB.Size = new System.Drawing.Size(431, 23);
            subjectTB.TabIndex = 2;
            subjectTB.MouseEnter += HoverInfo;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 64);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(46, 15);
            label10.TabIndex = 3;
            label10.Text = "Subject";
            // 
            // bodyTB
            // 
            bodyTB.Location = new System.Drawing.Point(71, 90);
            bodyTB.Name = "bodyTB";
            bodyTB.Size = new System.Drawing.Size(431, 23);
            bodyTB.TabIndex = 4;
            bodyTB.MouseEnter += HoverInfo;
            // 
            // deliveryTB
            // 
            deliveryTB.Location = new System.Drawing.Point(71, 119);
            deliveryTB.Name = "deliveryTB";
            deliveryTB.Size = new System.Drawing.Size(431, 23);
            deliveryTB.TabIndex = 6;
            deliveryTB.MouseEnter += HoverInfo;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(24, 93);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(34, 15);
            label11.TabIndex = 5;
            label11.Text = "Body";
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(extensionsTB);
            panel3.Location = new System.Drawing.Point(12, 335);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(521, 155);
            panel3.TabIndex = 13;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(3, 35);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(63, 15);
            label15.TabIndex = 7;
            label15.Text = "Extensions";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(3, 4);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(150, 25);
            label5.TabIndex = 0;
            label5.Text = "General Settings";
            // 
            // extensionsTB
            // 
            extensionsTB.Location = new System.Drawing.Point(71, 32);
            extensionsTB.Name = "extensionsTB";
            extensionsTB.Size = new System.Drawing.Size(431, 23);
            extensionsTB.TabIndex = 2;
            extensionsTB.MouseEnter += HoverInfo;
            // 
            // saveBtn
            // 
            saveBtn.Location = new System.Drawing.Point(12, 497);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size(521, 23);
            saveBtn.TabIndex = 14;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += SaveConfig;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel4.Controls.Add(infoBox);
            panel4.Location = new System.Drawing.Point(540, 13);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(171, 507);
            panel4.TabIndex = 15;
            // 
            // infoBox
            // 
            infoBox.Location = new System.Drawing.Point(4, 5);
            infoBox.Multiline = true;
            infoBox.Name = "infoBox";
            infoBox.ReadOnly = true;
            infoBox.Size = new System.Drawing.Size(162, 497);
            infoBox.TabIndex = 0;
            // 
            // Form3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(723, 546);
            Controls.Add(panel4);
            Controls.Add(saveBtn);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            Text = "Form3";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fromTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox subjectTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox bodyTB;
        private System.Windows.Forms.TextBox deliveryTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox extensionsTB;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox infoBox;
    }
}