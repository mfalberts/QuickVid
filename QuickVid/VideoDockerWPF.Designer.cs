namespace QuickVid
{
  partial class VideoDockerWPF
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
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.videoPlayerWPF1 = new QuickVid.VideoPlayerWPF();
      this.panel1 = new System.Windows.Forms.Panel();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.volumeTrackBar = new System.Windows.Forms.TrackBar();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 0);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(284, 261);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.videoPlayerWPF1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.trackBar1);
      this.panel1.Controls.Add(this.volumeTrackBar);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 214);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(284, 47);
      this.panel1.TabIndex = 1;
      // 
      // trackBar1
      // 
      this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.trackBar1.Location = new System.Drawing.Point(0, 0);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(239, 45);
      this.trackBar1.TabIndex = 2;
      this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
      // 
      // volumeTrackBar
      // 
      this.volumeTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.volumeTrackBar.Location = new System.Drawing.Point(239, 0);
      this.volumeTrackBar.Maximum = 100;
      this.volumeTrackBar.Name = "volumeTrackBar";
      this.volumeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.volumeTrackBar.Size = new System.Drawing.Size(45, 47);
      this.volumeTrackBar.TabIndex = 3;
      this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
      // 
      // VideoDockerWPF
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.elementHost1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "VideoDockerWPF";
      this.Text = "VideoDockerWPF";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private VideoPlayerWPF videoPlayerWPF1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.TrackBar volumeTrackBar;
  }
}