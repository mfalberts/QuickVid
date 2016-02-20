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
	public partial class VideoDockWindow : DockContent
	{
		public VideoDockWindow()
		{
			InitializeComponent();
			axWindowsMediaPlayer1.uiMode = "full";
			axWindowsMediaPlayer1.stretchToFit = true;
      InitialSettings();
     // WebBrowser youtubePlayer = new WebBrowser();
		//	this.Controls.Add(youtubePlayer);
		//	youtubePlayer.Dock = DockStyle.Fill;
		//	string url = @"<iframe id='ytplayer' type='text/html' width='640' height='390'
		//									src='http://www.youtube.com/embed/HLj0aLPLsys?autoplay=1'
		//								frameborder='0'/>".Replace("'", "\"");
		//	youtubePlayer.Navigate("file:///V:/iPhoneFormat/Scene_3.mp4");
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

		public int Volume
		{
			get { return axWindowsMediaPlayer1.settings.volume;  }
			set { axWindowsMediaPlayer1.settings.volume = value;  }
		}
		private void InitialSettings()
		{
			axWindowsMediaPlayer1.settings.rate = 1;
			axWindowsMediaPlayer1.settings.volume = 0;
		}
	}
}
