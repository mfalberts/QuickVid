﻿namespace QuickVid
{
	partial class MainForm
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
      WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
      WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
      WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
      WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.replaceActiveWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.playerPanel = new System.Windows.Forms.Panel();
      this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
      this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.menuStrip1.SuspendLayout();
      this.playerPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(731, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.replaceActiveWindowToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.openToolStripMenuItem.Text = "&Open";
      // 
      // replaceActiveWindowToolStripMenuItem
      // 
      this.replaceActiveWindowToolStripMenuItem.Checked = true;
      this.replaceActiveWindowToolStripMenuItem.CheckOnClick = true;
      this.replaceActiveWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.replaceActiveWindowToolStripMenuItem.Name = "replaceActiveWindowToolStripMenuItem";
      this.replaceActiveWindowToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.replaceActiveWindowToolStripMenuItem.Text = "Reuse Current Window";
      this.replaceActiveWindowToolStripMenuItem.Click += new System.EventHandler(this.replaceActiveWindowToolStripMenuItem_Click);
      // 
      // playerPanel
      // 
      this.playerPanel.Controls.Add(this.dockPanel1);
      this.playerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.playerPanel.Location = new System.Drawing.Point(0, 24);
      this.playerPanel.Name = "playerPanel";
      this.playerPanel.Size = new System.Drawing.Size(731, 487);
      this.playerPanel.TabIndex = 3;
      // 
      // dockPanel1
      // 
      this.dockPanel1.AllowDrop = true;
      this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
      this.dockPanel1.Location = new System.Drawing.Point(0, 0);
      this.dockPanel1.Name = "dockPanel1";
      this.dockPanel1.Size = new System.Drawing.Size(731, 487);
      dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
      dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
      autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
      tabGradient1.EndColor = System.Drawing.SystemColors.Control;
      tabGradient1.StartColor = System.Drawing.SystemColors.Control;
      tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
      autoHideStripSkin1.TabGradient = tabGradient1;
      autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
      dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
      tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
      tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
      tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
      dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
      dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
      dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
      dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
      tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
      tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
      tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
      dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
      dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
      dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
      tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
      tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
      tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
      dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
      tabGradient5.EndColor = System.Drawing.SystemColors.Control;
      tabGradient5.StartColor = System.Drawing.SystemColors.Control;
      tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
      dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
      dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
      dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
      dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
      tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
      tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
      tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
      tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
      dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
      tabGradient7.EndColor = System.Drawing.Color.Transparent;
      tabGradient7.StartColor = System.Drawing.Color.Transparent;
      tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
      dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
      dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
      dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
      this.dockPanel1.Skin = dockPanelSkin1;
      this.dockPanel1.TabIndex = 0;
      this.dockPanel1.ActiveDocumentChanged += new System.EventHandler(this.dockPanel1_ActiveDocumentChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(731, 511);
      this.Controls.Add(this.playerPanel);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "QuickVid";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.playerPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.Panel playerPanel;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
		private System.Windows.Forms.BindingSource bindingSource1;
		private System.Windows.Forms.ToolStripMenuItem replaceActiveWindowToolStripMenuItem;
	}
}

