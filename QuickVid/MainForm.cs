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
		private VideoDockWindow LastActiveDockWindow { get; set; } 
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
      dp.FileSelected += DirectoryPaneFileSelected;
      dp.Show(dockPanel1, DockState.DockRight);
		}

    private void DirectoryPaneFileSelected(object sender, FileSelectedArgs e)
    {
      string fileName = e.URL;
      if (UseActiveDockWindow == false || LastActiveDockWindow == null)
      {
        VideoDockWindow videoDocker = new VideoDockWindow();
        videoDocker.Show(dockPanel1, DockState.Document);
        videoDocker.URL = fileName;
      }
      else
      {
        LastActiveDockWindow.URL = fileName;
      }

    }

    private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//test comment...
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
			VideoDockWindow videoDockWindow = dockPane.ActiveDocument as VideoDockWindow;
			int lastVolume = 0;
			if (LastActiveDockWindow != null)
			{ 
				lastVolume = LastActiveDockWindow.Volume;
        LastActiveDockWindow.Volume = 0;
			}
			LastActiveDockWindow = videoDockWindow;
			if (videoDockWindow != null)
			{
        videoDockWindow.Volume = lastVolume;
			}
		}

		private void replaceActiveWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UseActiveDockWindow = !UseActiveDockWindow;
		}
	}
}
