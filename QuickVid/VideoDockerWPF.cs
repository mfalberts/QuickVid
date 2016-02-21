using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace QuickVid
{
  public partial class VideoDockerWPF : DockContent, IVideoDocker
  {
    public VideoDockerWPF()
    {
      InitializeComponent();
      videoPlayerWPF1.OnMediaReady += VideoPlayerWPF1_OnMediaReady;
    }

    private void VideoPlayerWPF1_OnMediaReady(object sender, VideoPlayerWPF.MediaReadyArgs e)
    {
      trackBar1.Maximum = e.DurationInfo.TimeSpan.Minutes;
    }

    public string URL
    {
      get
      {
        return videoPlayerWPF1.URL;
      }

      set
      {
        videoPlayerWPF1.URL = value;
      }
    }

    public int Volume
    {
      get
      {
        return 0;
      }

      set
      {
        return; 
      }
    }

    public void Pause()
    {
      return;
    }

    private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
    {
      videoPlayerWPF1.Volume = volumeTrackBar.Value;
    }

    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {
      videoPlayerWPF1.SetPosition(trackBar1.Value);
    }
  }
}
