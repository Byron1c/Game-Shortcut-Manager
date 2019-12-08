namespace Game_Shortcut_Manager
{
    partial class frmShowText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowText));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSendError = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblWorking = new System.Windows.Forms.Label();
            this.richText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(363, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(12, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSendError
            // 
            this.btnSendError.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSendError.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSendError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendError.Location = new System.Drawing.Point(188, 270);
            this.btnSendError.Name = "btnSendError";
            this.btnSendError.Size = new System.Drawing.Size(75, 23);
            this.btnSendError.TabIndex = 3;
            this.btnSendError.Text = "Send Error";
            this.btnSendError.UseVisualStyleBackColor = true;
            this.btnSendError.Visible = false;
            this.btnSendError.Click += new System.EventHandler(this.btnSendError_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(12, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(426, 24);
            this.lblHeading.TabIndex = 4;
            this.lblHeading.Text = "Show Text Heading";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDetails
            // 
            this.lblDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(12, 38);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(426, 36);
            this.lblDetails.TabIndex = 5;
            this.lblDetails.Text = "Show Text Details";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWorking
            // 
            this.lblWorking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblWorking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWorking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.ForeColor = System.Drawing.Color.Black;
            this.lblWorking.Location = new System.Drawing.Point(118, 160);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Padding = new System.Windows.Forms.Padding(3);
            this.lblWorking.Size = new System.Drawing.Size(210, 25);
            this.lblWorking.TabIndex = 6;
            this.lblWorking.Text = "Working... Please Wait";
            this.lblWorking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWorking.Visible = false;
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richText.Location = new System.Drawing.Point(12, 77);
            this.richText.Name = "richText";
            this.richText.ReadOnly = true;
            this.richText.Size = new System.Drawing.Size(426, 187);
            this.richText.TabIndex = 0;
            this.richText.Text = "";
            // 
            // frmShowText
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 305);
            this.Controls.Add(this.lblWorking);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnSendError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.richText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Latest Changes";
            this.Load += new System.EventHandler(this.frmShowText_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RichTextBox richText;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSendError;
        internal System.Windows.Forms.Label lblHeading;
        internal System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblWorking;
    }
}