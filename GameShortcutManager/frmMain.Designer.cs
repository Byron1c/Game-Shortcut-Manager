namespace Game_Shortcut_Manager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.cbFileLocation = new System.Windows.Forms.ComboBox();
            this.txtShortcutPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseShortcutLocation = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseEXE = new System.Windows.Forms.Button();
            this.txtEXEPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveShortcut = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateShortcut = new System.Windows.Forms.Button();
            this.cbPinToTaskbar = new System.Windows.Forms.CheckBox();
            this.cbPinToStartMenu = new System.Windows.Forms.CheckBox();
            this.btnPinTaskbar = new System.Windows.Forms.Button();
            this.btnPinStart = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlWorking = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.cbWindowStyle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShortcutKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnRemoveEntry = new System.Windows.Forms.Button();
            this.olvShortcuts = new BrightIdeasSoftware.ObjectListView();
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvArguments = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvShortcutPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCheckForUpdate = new System.Windows.Forms.CheckBox();
            this.cmShortcuts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openShortcutFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIconFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.pnlWorking.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvShortcuts)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.cmShortcuts.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(549, 10);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(100, 100);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // cbFileLocation
            // 
            this.cbFileLocation.FormattingEnabled = true;
            this.cbFileLocation.Items.AddRange(new object[] {
            "Desktop",
            "Documents",
            "Other"});
            this.cbFileLocation.Location = new System.Drawing.Point(111, 91);
            this.cbFileLocation.Name = "cbFileLocation";
            this.cbFileLocation.Size = new System.Drawing.Size(121, 21);
            this.cbFileLocation.TabIndex = 6;
            this.cbFileLocation.Text = "Other";
            this.cbFileLocation.SelectedIndexChanged += new System.EventHandler(this.cbFileLocation_SelectedIndexChanged);
            // 
            // txtShortcutPath
            // 
            this.txtShortcutPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortcutPath.Location = new System.Drawing.Point(238, 92);
            this.txtShortcutPath.Name = "txtShortcutPath";
            this.txtShortcutPath.Size = new System.Drawing.Size(222, 20);
            this.txtShortcutPath.TabIndex = 7;
            this.txtShortcutPath.Text = "D:\\Temp";
            this.txtShortcutPath.TextChanged += new System.EventHandler(this.txtShortcutPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shortcut Location";
            // 
            // btnBrowseShortcutLocation
            // 
            this.btnBrowseShortcutLocation.BackColor = System.Drawing.Color.Lavender;
            this.btnBrowseShortcutLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseShortcutLocation.Location = new System.Drawing.Point(466, 91);
            this.btnBrowseShortcutLocation.Name = "btnBrowseShortcutLocation";
            this.btnBrowseShortcutLocation.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseShortcutLocation.TabIndex = 8;
            this.btnBrowseShortcutLocation.Text = "Browse";
            this.btnBrowseShortcutLocation.UseVisualStyleBackColor = false;
            this.btnBrowseShortcutLocation.Click += new System.EventHandler(this.btnBrowseShortcutLocation_Click);
            // 
            // txtURL
            // 
            this.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtURL.Location = new System.Drawing.Point(111, 13);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(349, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "steam://rungameid/365670";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "URL";
            // 
            // btnBrowseEXE
            // 
            this.btnBrowseEXE.BackColor = System.Drawing.Color.Lavender;
            this.btnBrowseEXE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseEXE.Location = new System.Drawing.Point(466, 64);
            this.btnBrowseEXE.Name = "btnBrowseEXE";
            this.btnBrowseEXE.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseEXE.TabIndex = 5;
            this.btnBrowseEXE.Text = "Browse";
            this.btnBrowseEXE.UseVisualStyleBackColor = false;
            this.btnBrowseEXE.Click += new System.EventHandler(this.btnBrowseEXE_Click);
            // 
            // txtEXEPath
            // 
            this.txtEXEPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEXEPath.Location = new System.Drawing.Point(111, 65);
            this.txtEXEPath.Name = "txtEXEPath";
            this.txtEXEPath.Size = new System.Drawing.Size(349, 20);
            this.txtEXEPath.TabIndex = 4;
            this.txtEXEPath.Text = "D:\\Games\\Steam\\steamapps\\common\\Game\\game.exe";
            this.txtEXEPath.TextChanged += new System.EventHandler(this.txtEXEPath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Icon";
            // 
            // btnRemoveShortcut
            // 
            this.btnRemoveShortcut.BackColor = System.Drawing.Color.Lavender;
            this.btnRemoveShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveShortcut.Location = new System.Drawing.Point(532, 20);
            this.btnRemoveShortcut.Name = "btnRemoveShortcut";
            this.btnRemoveShortcut.Size = new System.Drawing.Size(128, 23);
            this.btnRemoveShortcut.TabIndex = 17;
            this.btnRemoveShortcut.Text = "Remove Shortcut";
            this.btnRemoveShortcut.UseVisualStyleBackColor = false;
            this.btnRemoveShortcut.Click += new System.EventHandler(this.btnRemoveShortcut_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Manage Shortcuts";
            // 
            // btnCreateShortcut
            // 
            this.btnCreateShortcut.BackColor = System.Drawing.Color.Lavender;
            this.btnCreateShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateShortcut.Location = new System.Drawing.Point(549, 168);
            this.btnCreateShortcut.Name = "btnCreateShortcut";
            this.btnCreateShortcut.Size = new System.Drawing.Size(100, 23);
            this.btnCreateShortcut.TabIndex = 15;
            this.btnCreateShortcut.Text = "Save Shortcut";
            this.btnCreateShortcut.UseVisualStyleBackColor = false;
            this.btnCreateShortcut.Click += new System.EventHandler(this.btnCreateShortcut_Click);
            // 
            // cbPinToTaskbar
            // 
            this.cbPinToTaskbar.AutoSize = true;
            this.cbPinToTaskbar.Location = new System.Drawing.Point(554, 143);
            this.cbPinToTaskbar.Name = "cbPinToTaskbar";
            this.cbPinToTaskbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPinToTaskbar.Size = new System.Drawing.Size(95, 17);
            this.cbPinToTaskbar.TabIndex = 14;
            this.cbPinToTaskbar.Text = "Pin to Taskbar";
            this.cbPinToTaskbar.UseVisualStyleBackColor = true;
            // 
            // cbPinToStartMenu
            // 
            this.cbPinToStartMenu.AutoSize = true;
            this.cbPinToStartMenu.Location = new System.Drawing.Point(541, 121);
            this.cbPinToStartMenu.Name = "cbPinToStartMenu";
            this.cbPinToStartMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPinToStartMenu.Size = new System.Drawing.Size(108, 17);
            this.cbPinToStartMenu.TabIndex = 13;
            this.cbPinToStartMenu.Text = "Pin to Start Menu";
            this.cbPinToStartMenu.UseVisualStyleBackColor = true;
            // 
            // btnPinTaskbar
            // 
            this.btnPinTaskbar.BackColor = System.Drawing.Color.Lavender;
            this.btnPinTaskbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinTaskbar.Location = new System.Drawing.Point(532, 49);
            this.btnPinTaskbar.Name = "btnPinTaskbar";
            this.btnPinTaskbar.Size = new System.Drawing.Size(128, 23);
            this.btnPinTaskbar.TabIndex = 18;
            this.btnPinTaskbar.Text = "Pin to Taskbar";
            this.btnPinTaskbar.UseVisualStyleBackColor = false;
            this.btnPinTaskbar.Click += new System.EventHandler(this.btnManageTaskbar_Click);
            // 
            // btnPinStart
            // 
            this.btnPinStart.BackColor = System.Drawing.Color.Lavender;
            this.btnPinStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinStart.Location = new System.Drawing.Point(532, 78);
            this.btnPinStart.Name = "btnPinStart";
            this.btnPinStart.Size = new System.Drawing.Size(128, 23);
            this.btnPinStart.TabIndex = 19;
            this.btnPinStart.Text = "Pin to Start";
            this.btnPinStart.UseVisualStyleBackColor = false;
            this.btnPinStart.Click += new System.EventHandler(this.btnPinStart_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(111, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(349, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "Blender Shortcut";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Shortcut Name";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Lavender;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(466, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlForm.BackgroundImage")));
            this.pnlForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.pnlWorking);
            this.pnlForm.Controls.Add(this.btnClearForm);
            this.pnlForm.Controls.Add(this.cbWindowStyle);
            this.pnlForm.Controls.Add(this.label8);
            this.pnlForm.Controls.Add(this.label7);
            this.pnlForm.Controls.Add(this.txtShortcutKey);
            this.pnlForm.Controls.Add(this.label6);
            this.pnlForm.Controls.Add(this.txtDescription);
            this.pnlForm.Controls.Add(this.btnCreateShortcut);
            this.pnlForm.Controls.Add(this.btnFind);
            this.pnlForm.Controls.Add(this.pbIcon);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.cbFileLocation);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.txtShortcutPath);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.btnBrowseShortcutLocation);
            this.pnlForm.Controls.Add(this.cbPinToStartMenu);
            this.pnlForm.Controls.Add(this.txtURL);
            this.pnlForm.Controls.Add(this.cbPinToTaskbar);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.txtEXEPath);
            this.pnlForm.Controls.Add(this.btnBrowseEXE);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Location = new System.Drawing.Point(12, 27);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(665, 212);
            this.pnlForm.TabIndex = 22;
            // 
            // pnlWorking
            // 
            this.pnlWorking.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlWorking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWorking.Controls.Add(this.label9);
            this.pnlWorking.Location = new System.Drawing.Point(231, 85);
            this.pnlWorking.Name = "pnlWorking";
            this.pnlWorking.Size = new System.Drawing.Size(200, 40);
            this.pnlWorking.TabIndex = 27;
            this.pnlWorking.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 34);
            this.label9.TabIndex = 0;
            this.label9.Text = "Working";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearForm
            // 
            this.btnClearForm.BackColor = System.Drawing.Color.Lavender;
            this.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearForm.Location = new System.Drawing.Point(466, 168);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(75, 23);
            this.btnClearForm.TabIndex = 12;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = false;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // cbWindowStyle
            // 
            this.cbWindowStyle.FormattingEnabled = true;
            this.cbWindowStyle.Items.AddRange(new object[] {
            "Normal Window",
            "Minimised",
            "Maximised"});
            this.cbWindowStyle.Location = new System.Drawing.Point(111, 170);
            this.cbWindowStyle.Name = "cbWindowStyle";
            this.cbWindowStyle.Size = new System.Drawing.Size(121, 21);
            this.cbWindowStyle.TabIndex = 11;
            this.cbWindowStyle.Text = "Normal Window";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Run";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Shortcut Keys";
            // 
            // txtShortcutKey
            // 
            this.txtShortcutKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortcutKey.Location = new System.Drawing.Point(111, 144);
            this.txtShortcutKey.Name = "txtShortcutKey";
            this.txtShortcutKey.Size = new System.Drawing.Size(121, 20);
            this.txtShortcutKey.TabIndex = 10;
            this.txtShortcutKey.TextChanged += new System.EventHandler(this.txtShortcutKey_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(111, 118);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(349, 20);
            this.txtDescription.TabIndex = 9;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.ForeColor = System.Drawing.Color.DarkRed;
            this.lblResults.Location = new System.Drawing.Point(311, 7);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(67, 13);
            this.lblResults.TabIndex = 28;
            this.lblResults.Text = "[results here]";
            // 
            // pnlList
            // 
            this.pnlList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Controls.Add(this.btnRemoveEntry);
            this.pnlList.Controls.Add(this.olvShortcuts);
            this.pnlList.Controls.Add(this.label4);
            this.pnlList.Controls.Add(this.btnRemoveShortcut);
            this.pnlList.Controls.Add(this.btnPinStart);
            this.pnlList.Controls.Add(this.btnPinTaskbar);
            this.pnlList.Location = new System.Drawing.Point(12, 245);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(665, 152);
            this.pnlList.TabIndex = 23;
            // 
            // btnRemoveEntry
            // 
            this.btnRemoveEntry.BackColor = System.Drawing.Color.Lavender;
            this.btnRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveEntry.Location = new System.Drawing.Point(532, 107);
            this.btnRemoveEntry.Name = "btnRemoveEntry";
            this.btnRemoveEntry.Size = new System.Drawing.Size(128, 23);
            this.btnRemoveEntry.TabIndex = 20;
            this.btnRemoveEntry.Text = "Remove Entry";
            this.btnRemoveEntry.UseVisualStyleBackColor = false;
            this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
            // 
            // olvShortcuts
            // 
            this.olvShortcuts.AllColumns.Add(this.olvName);
            this.olvShortcuts.AllColumns.Add(this.olvArguments);
            this.olvShortcuts.AllColumns.Add(this.olvShortcutPath);
            this.olvShortcuts.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.olvShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvShortcuts.CellEditUseWholeCell = false;
            this.olvShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvArguments,
            this.olvShortcutPath});
            this.olvShortcuts.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvShortcuts.FullRowSelect = true;
            this.olvShortcuts.HideSelection = false;
            this.olvShortcuts.Location = new System.Drawing.Point(7, 20);
            this.olvShortcuts.Name = "olvShortcuts";
            this.olvShortcuts.Size = new System.Drawing.Size(519, 122);
            this.olvShortcuts.TabIndex = 16;
            this.olvShortcuts.UseCompatibleStateImageBehavior = false;
            this.olvShortcuts.View = System.Windows.Forms.View.Details;
            this.olvShortcuts.SelectedIndexChanged += new System.EventHandler(this.olvShortcuts_SelectedIndexChanged);
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.Text = "Name";
            this.olvName.Width = 107;
            // 
            // olvArguments
            // 
            this.olvArguments.AspectName = "Arguments";
            this.olvArguments.Text = "Arguments";
            this.olvArguments.Width = 155;
            // 
            // olvShortcutPath
            // 
            this.olvShortcutPath.AspectName = "ShortcutPath";
            this.olvShortcutPath.FillsFreeSpace = true;
            this.olvShortcutPath.Text = "Shortcut Path";
            this.olvShortcutPath.Width = 200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(689, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.checkForUpdateToolStripMenuItem.Text = "&Check for Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // cbCheckForUpdate
            // 
            this.cbCheckForUpdate.AutoSize = true;
            this.cbCheckForUpdate.BackColor = System.Drawing.Color.White;
            this.cbCheckForUpdate.Location = new System.Drawing.Point(562, 5);
            this.cbCheckForUpdate.Name = "cbCheckForUpdate";
            this.cbCheckForUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCheckForUpdate.Size = new System.Drawing.Size(113, 17);
            this.cbCheckForUpdate.TabIndex = 0;
            this.cbCheckForUpdate.Text = "Check For Update";
            this.cbCheckForUpdate.UseVisualStyleBackColor = false;
            this.cbCheckForUpdate.CheckedChanged += new System.EventHandler(this.cbCheckForUpdate_CheckedChanged);
            // 
            // cmShortcuts
            // 
            this.cmShortcuts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openShortcutFolderToolStripMenuItem,
            this.openIconFolderToolStripMenuItem});
            this.cmShortcuts.Name = "cmShortcuts";
            this.cmShortcuts.Size = new System.Drawing.Size(188, 48);
            // 
            // openShortcutFolderToolStripMenuItem
            // 
            this.openShortcutFolderToolStripMenuItem.Name = "openShortcutFolderToolStripMenuItem";
            this.openShortcutFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openShortcutFolderToolStripMenuItem.Text = "Open &Shortcut Folder";
            this.openShortcutFolderToolStripMenuItem.Click += new System.EventHandler(this.openShortcutFolderToolStripMenuItem_Click);
            // 
            // openIconFolderToolStripMenuItem
            // 
            this.openIconFolderToolStripMenuItem.Name = "openIconFolderToolStripMenuItem";
            this.openIconFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openIconFolderToolStripMenuItem.Text = "Open &Icon Folder";
            this.openIconFolderToolStripMenuItem.Click += new System.EventHandler(this.openIconFolderToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(689, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(27, 17);
            this.tslStatus.Text = "Log";
            this.tslStatus.Click += new System.EventHandler(this.tslStatus_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.cbCheckForUpdate);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Game Shortcut Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlWorking.ResumeLayout(false);
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvShortcuts)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmShortcuts.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.ComboBox cbFileLocation;
        private System.Windows.Forms.TextBox txtShortcutPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseShortcutLocation;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseEXE;
        private System.Windows.Forms.TextBox txtEXEPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveShortcut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateShortcut;
        private System.Windows.Forms.CheckBox cbPinToTaskbar;
        private System.Windows.Forms.CheckBox cbPinToStartMenu;
        private System.Windows.Forms.Button btnPinTaskbar;
        private System.Windows.Forms.Button btnPinStart;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlList;
        private BrightIdeasSoftware.ObjectListView olvShortcuts;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvArguments;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShortcutKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbWindowStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.CheckBox cbCheckForUpdate;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ContextMenuStrip cmShortcuts;
        private System.Windows.Forms.ToolStripMenuItem openShortcutFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIconFolderToolStripMenuItem;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnRemoveEntry;
        private BrightIdeasSoftware.OLVColumn olvShortcutPath;
        private System.Windows.Forms.Panel pnlWorking;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
    }
}

