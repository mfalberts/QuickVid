using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// http://www.independent-software.com/weifenluo-dockpanelsuite-tutorial-cookbook/
using WeifenLuo.WinFormsUI.Docking;

namespace QuickVid
{
	public partial class MainForm : Form
	{
		private VideoDockWindow ActiveDockWindow { get; set; } 
		private bool UseActiveDockWindow { get; set; }
		public MainForm()
		{
			InitializeComponent();
			UseActiveDockWindow = true;
//			SizeChanged += MainForm_SizeChanged;
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}
		

		private void MainForm_Load(object sender, EventArgs e)
		{
      DirectoryPane dp = new DirectoryPane();
      dp.Show(dockPanel1, DockState.DockRight);
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//test comment...
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		//	if (listView1.SelectedItems.Count >0  && listView1.SelectedItems[0].Tag != null)
		//	{
    //    string fileName = listView1.SelectedItems[0].Tag.ToString();
    //    if (UseActiveDockWindow == false || ActiveDockWindow == null)
		//		{
		//			//axWindowsMediaPlayer1.URL = listView1.SelectedItems[0].Text;
		//			VideoDockWindow videoDocker = new VideoDockWindow();
		//			videoDocker.Show(dockPanel1, DockState.Document);
    //      videoDocker.URL = fileName;
		//		}
		//		else
		//		{
		//			ActiveDockWindow.URL = fileName;
		//		}
    //
		//	}


		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{	}
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{}


		private void listView1_MouseHover(object sender, EventArgs e)
		{
		}

		private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
		{
			//ListViewItem lvi = e.Item;
			//if (lvi != null)
			//{
			//	axPreviewPlayer.URL = lvi.Text;
			//	axPreviewPlayer.uiMode = "none";
			//	axPreviewPlayer.settings.rate = 50;
			//	axPreviewPlayer.settings.volume = 0; 
			//}

		}

		private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
		{

			WeifenLuo.WinFormsUI.Docking.DockPanel dockPane = (WeifenLuo.WinFormsUI.Docking.DockPanel)sender;
			VideoDockWindow videoDockWindow = (VideoDockWindow)dockPane.ActiveDocument;
			int lastVolume = 0;
			if (ActiveDockWindow != null)
			{ 
				lastVolume = ActiveDockWindow.Volume;
				ActiveDockWindow.Volume = 0;
			}
			ActiveDockWindow = videoDockWindow;
			if (ActiveDockWindow != null)
			{ 
				ActiveDockWindow.Volume = lastVolume;
			}
		}

		private void replaceActiveWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UseActiveDockWindow = !UseActiveDockWindow;
		}
	}
}
