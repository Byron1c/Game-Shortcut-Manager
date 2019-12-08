namespace Game_Shortcut_Manager
{
    partial class frmFindURL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindURL));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.Service = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.olvResults = new BrightIdeasSoftware.ObjectListView();
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPriceUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvAppId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(59, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(191, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(256, 38);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(52, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(405, 211);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Service
            // 
            this.Service.AutoSize = true;
            this.Service.Location = new System.Drawing.Point(12, 9);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(41, 13);
            this.Service.TabIndex = 4;
            this.Service.Text = "Search";
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Steam"});
            this.comboBox1.Location = new System.Drawing.Point(59, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "Steam";
            // 
            // olvResults
            // 
            this.olvResults.AllColumns.Add(this.olvName);
            this.olvResults.AllColumns.Add(this.olvPriceUSD);
            this.olvResults.AllColumns.Add(this.olvAppId);
            this.olvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvResults.CellEditUseWholeCell = false;
            this.olvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvPriceUSD,
            this.olvAppId});
            this.olvResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvResults.HideSelection = false;
            this.olvResults.Location = new System.Drawing.Point(15, 66);
            this.olvResults.Name = "olvResults";
            this.olvResults.Size = new System.Drawing.Size(465, 136);
            this.olvResults.TabIndex = 6;
            this.olvResults.UseCompatibleStateImageBehavior = false;
            this.olvResults.View = System.Windows.Forms.View.Details;
            this.olvResults.SelectedIndexChanged += new System.EventHandler(this.olvResults_SelectedIndexChanged);
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.FillsFreeSpace = true;
            this.olvName.Text = "Name";
            this.olvName.Width = 292;
            // 
            // olvPriceUSD
            // 
            this.olvPriceUSD.AspectName = "PriceUSD";
            this.olvPriceUSD.Text = "Price (USD)";
            this.olvPriceUSD.Width = 97;
            // 
            // olvAppId
            // 
            this.olvAppId.AspectName = "AppId";
            this.olvAppId.Text = "AppId";
            this.olvAppId.Width = 72;
            // 
            // frmFindURL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 246);
            this.Controls.Add(this.olvResults);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Service);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFindURL";
            this.Text = "frmFindURL";
            this.Load += new System.EventHandler(this.frmFindURL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label Service;
        private System.Windows.Forms.ComboBox comboBox1;
        private BrightIdeasSoftware.ObjectListView olvResults;
        internal BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvPriceUSD;
        private BrightIdeasSoftware.OLVColumn olvAppId;
    }
}