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
		}
		public string URL
		{
			get { return axWindowsMediaPlayer1.URL;  }
			set { axWindowsMediaPlayer1.URL = value;  InitialSettings();  }
		}

		private void InitialSettings()
		{
			Text = "Now Playing... " + axWindowsMediaPlayer1.URL;
			axWindowsMediaPlayer1.settings.rate = 15;
			axWindowsMediaPlayer1.settings.volume = 0;
		}
	}
}
