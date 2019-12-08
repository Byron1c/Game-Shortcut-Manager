namespace Game_Shortcut_Manager
{
    partial class frmAbout
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbDonateQRCode = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.llCompany = new System.Windows.Forms.LinkLabel();
            this.llName = new System.Windows.Forms.LinkLabel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pbDonate = new System.Windows.Forms.PictureBox();
            this.pbFacebook = new System.Windows.Forms.PictureBox();
            this.pbEmail = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblDonationSuggestion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateQRCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFacebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDonateQRCode
            // 
            this.pbDonateQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDonateQRCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonateQRCode.Image = ((System.Drawing.Image)(resources.GetObject("pbDonateQRCode.Image")));
            this.pbDonateQRCode.InitialImage = null;
            this.pbDonateQRCode.Location = new System.Drawing.Point(414, 103);
            this.pbDonateQRCode.Name = "pbDonateQRCode";
            this.pbDonateQRCode.Size = new System.Drawing.Size(100, 100);
            this.pbDonateQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDonateQRCode.TabIndex = 209;
            this.pbDonateQRCode.TabStop = false;
            this.toolTip1.SetToolTip(this.pbDonateQRCode, "Donate QR Code");
            this.pbDonateQRCode.Click += new System.EventHandler(this.pbDonateQRCode_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(168, 118);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(224, 85);
            this.txtDescription.TabIndex = 208;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // llCompany
            // 
            this.llCompany.AutoSize = true;
            this.llCompany.BackColor = System.Drawing.Color.Transparent;
            this.llCompany.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llCompany.Location = new System.Drawing.Point(222, 89);
            this.llCompany.Name = "llCompany";
            this.llCompany.Size = new System.Drawing.Size(51, 13);
            this.llCompany.TabIndex = 206;
            this.llCompany.TabStop = true;
            this.llCompany.Text = "Company";
            this.llCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCompany_LinkClicked);
            // 
            // llName
            // 
            this.llName.AutoSize = true;
            this.llName.BackColor = System.Drawing.Color.Transparent;
            this.llName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llName.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llName.Location = new System.Drawing.Point(165, 14);
            this.llName.Name = "llName";
            this.llName.Size = new System.Drawing.Size(163, 15);
            this.llName.TabIndex = 205;
            this.llName.TabStop = true;
            this.llName.Text = "Game Shortcut Manager";
            this.llName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llName_LinkClicked);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(222, 64);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(51, 13);
            this.lblCopyright.TabIndex = 204;
            this.lblCopyright.Text = "Copyright";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(222, 39);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 203;
            this.lblVersion.Text = "Version";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(165, 89);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 202;
            this.label18.Text = "Company";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(165, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 201;
            this.label19.Text = "Copyright";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(174, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 200;
            this.label20.Text = "Version";
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.BackgroundImage")));
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbIcon.ErrorImage = null;
            this.pbIcon.InitialImage = null;
            this.pbIcon.Location = new System.Drawing.Point(12, 12);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(125, 125);
            this.pbIcon.TabIndex = 198;
            this.pbIcon.TabStop = false;
            this.toolTip1.SetToolTip(this.pbIcon, "Visit Website");
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            // 
            // pbDonate
            // 
            this.pbDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonate.Image = ((System.Drawing.Image)(resources.GetObject("pbDonate.Image")));
            this.pbDonate.InitialImage = null;
            this.pbDonate.Location = new System.Drawing.Point(405, 30);
            this.pbDonate.Name = "pbDonate";
            this.pbDonate.Size = new System.Drawing.Size(121, 63);
            this.pbDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDonate.TabIndex = 207;
            this.pbDonate.TabStop = false;
            this.toolTip1.SetToolTip(this.pbDonate, "Donate Via PayPal");
            this.pbDonate.Click += new System.EventHandler(this.pbDonate_Click);
            // 
            // pbFacebook
            // 
            this.pbFacebook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFacebook.Image = ((System.Drawing.Image)(resources.GetObject("pbFacebook.Image")));
            this.pbFacebook.InitialImage = null;
            this.pbFacebook.Location = new System.Drawing.Point(12, 160);
            this.pbFacebook.Name = "pbFacebook";
            this.pbFacebook.Size = new System.Drawing.Size(135, 43);
            this.pbFacebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFacebook.TabIndex = 211;
            this.pbFacebook.TabStop = false;
            this.toolTip1.SetToolTip(this.pbFacebook, "Visit Strangetimez Software on Facebook");
            this.pbFacebook.Click += new System.EventHandler(this.pbFacebook_Click);
            // 
            // pbEmail
            // 
            this.pbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEmail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbEmail.BackgroundImage")));
            this.pbEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEmail.ErrorImage = null;
            this.pbEmail.InitialImage = null;
            this.pbEmail.Location = new System.Drawing.Point(338, 30);
            this.pbEmail.Name = "pbEmail";
            this.pbEmail.Size = new System.Drawing.Size(54, 54);
            this.pbEmail.TabIndex = 212;
            this.pbEmail.TabStop = false;
            this.toolTip1.SetToolTip(this.pbEmail, "Contact Strangetimez Software via Email");
            this.pbEmail.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(420, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 213;
            this.label1.Text = "Please Donate";
            // 
            // lblDonationSuggestion
            // 
            this.lblDonationSuggestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonationSuggestion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDonationSuggestion.Location = new System.Drawing.Point(9, 216);
            this.lblDonationSuggestion.Name = "lblDonationSuggestion";
            this.lblDonationSuggestion.Size = new System.Drawing.Size(517, 103);
            this.lblDonationSuggestion.TabIndex = 214;
            this.lblDonationSuggestion.Text = "Please consider donating if you find this application useful, and it has improved" +
    " your work, or saved you time. Whatever you can afford would be appreicated.\r\n\r\n" +
    "Thank you :)";
            this.lblDonationSuggestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 334);
            this.Controls.Add(this.lblDonationSuggestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbEmail);
            this.Controls.Add(this.pbFacebook);
            this.Controls.Add(this.pbDonateQRCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.llCompany);
            this.Controls.Add(this.llName);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.pbDonate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAbout";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About Game Shortcut Manager";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateQRCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFacebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.LinkLabel llCompany;
        private System.Windows.Forms.LinkLabel llName;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pbIcon;
        internal System.Windows.Forms.PictureBox pbDonateQRCode;
        internal System.Windows.Forms.PictureBox pbDonate;
        internal System.Windows.Forms.PictureBox pbFacebook;
        private System.Windows.Forms.PictureBox pbEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblDonationSuggestion;
    }
}