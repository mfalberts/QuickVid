using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// http://www.independent-software.com/weifenluo-dockpanelsuite-tutorial-cookbook/
using WeifenLuo.WinFormsUI.Docking;

namespace QuickVid
{
	public partial class VideoDocker : DockContent, IVideoDocker
	{
		public VideoDocker()
		{
			InitializeComponent();
			axWindowsMediaPlayer1.uiMode = "full";
			axWindowsMediaPlayer1.stretchToFit = true;
      axWindowsMediaPlayer1.settings.setMode("loop", true);
      axWindowsMediaPlayer1.MouseMoveEvent += AxWindowsMediaPlayer1_MouseMoveEvent;
      InitialSettings();
     // WebBrowser youtubePlayer = new WebBrowser();
		//	this.Controls.Add(youtubePlayer);
		//	youtubePlayer.Dock = DockStyle.Fill;
		//	string url = @"<iframe id='ytplayer' type='text/html' width='640' height='390'
		//									src='http://www.youtube.com/embed/HLj0aLPLsys?autoplay=1'
		//								frameborder='0'/>".Replace("'", "\"");
		//	youtubePlayer.Navigate("file:///V:/iPhoneFormat/Scene_3.mp4");
		}

    private void AxWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
    {
      Control control = axWindowsMediaPlayer1.GetChildAtPoint(new Point(e.fX, e.fY));
      Control control1 = axWindowsMediaPlayer1.GetChildAtPoint(new Point(10, 10));
      object ocs = axWindowsMediaPlayer1.GetOcx();
    }


    public string URL
		{
			get { return axWindowsMediaPlayer1.URL;  }
			set
      {
        axWindowsMediaPlayer1.URL = value;
        Text = "Now Playing... " + axWindowsMediaPlayer1.URL;
      }
		}

    public void Pause()
    {
      //axWindowsMediaPlayer1.settings.setMode
    }

    public void Play()
    {
      //axWindowsMediaPlayer1.settings.setMode
    }

    public double Volume
		{
			get { return axWindowsMediaPlayer1.settings.volume;  }
			set { axWindowsMediaPlayer1.settings.volume = (int) value;  }
		}
		private void InitialSettings()
		{
			axWindowsMediaPlayer1.settings.rate = 1;
			axWindowsMediaPlayer1.settings.volume = 0;
		}
	}
}
