namespace QuickVid
{
  partial class DirectoryPane
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryPane));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.listView1 = new System.Windows.Forms.ListView();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
      this.panel1 = new System.Windows.Forms.Panel();
      this.directoryCombo = new System.Windows.Forms.ComboBox();
      this.selectFolderButton = new System.Windows.Forms.Button();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 47);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(353, 601);
      this.tabControl1.TabIndex = 3;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.listView1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(345, 575);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // listView1
      // 
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(3, 3);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(339, 569);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.axWindowsMediaPlayer2);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(362, 601);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // axWindowsMediaPlayer2
      // 
      this.axWindowsMediaPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.axWindowsMediaPlayer2.Enabled = true;
      this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(3, 3);
      this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
      this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
      this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(356, 595);
      this.axWindowsMediaPlayer2.TabIndex = 4;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.selectFolderButton);
      this.panel1.Controls.Add(this.directoryCombo);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(353, 47);
      this.panel1.TabIndex = 6;
      // 
      // directoryCombo
      // 
      this.directoryCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.directoryCombo.FormattingEnabled = true;
      this.directoryCombo.Location = new System.Drawing.Point(12, 12);
      this.directoryCombo.Name = "directoryCombo";
      this.directoryCombo.Size = new System.Drawing.Size(287, 21);
      this.directoryCombo.TabIndex = 6;
      // 
      // selectFolderButton
      // 
      this.selectFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.selectFolderButton.Location = new System.Drawing.Point(306, 12);
      this.selectFolderButton.Name = "selectFolderButton";
      this.selectFolderButton.Size = new System.Drawing.Size(24, 23);
      this.selectFolderButton.TabIndex = 7;
      this.selectFolderButton.Text = "...";
      this.selectFolderButton.UseVisualStyleBackColor = true;
      this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
      // 
      // DirectoryPane
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(353, 648);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "DirectoryPane";
      this.Text = "DirectoryPane";
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.TabPage tabPage2;
    private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button selectFolderButton;
    private System.Windows.Forms.ComboBox directoryCombo;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
  }
}