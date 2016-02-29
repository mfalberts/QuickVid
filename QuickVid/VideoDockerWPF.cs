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

    public double Volume
    {
      get
      {
        return videoPlayerWPF1.Volume;
      }

      set
      {
        videoPlayerWPF1.Volume = value; 
      }
    }

    public void Pause()
    {
      videoPlayerWPF1.Pause();
    }
    public void Play()
    {
      videoPlayerWPF1.Play();
    }

  }
}
