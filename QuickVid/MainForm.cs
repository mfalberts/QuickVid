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
		private IVideoDocker LastActiveVideoDockerWindow { get; set; } 
		private bool ReuseActiveDockWindow { get; set; }
		public MainForm()
		{
			InitializeComponent();
			ReuseActiveDockWindow = true;
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
      if (ReuseActiveDockWindow == false || LastActiveVideoDockerWindow == null)
      {
        VideoDocker videoDocker = new VideoDocker();
        //VideoDockerWPF videoDocker = new VideoDockerWPF();
        videoDocker.Show(dockPanel1, DockState.Document);
        videoDocker.URL = fileName;
      }
      else
      {
        LastActiveVideoDockerWindow.URL = fileName;
      }

    }

    private void PauseAll()
    {
      foreach (Form child in this.MdiChildren)
      {
        if (child is IVideoDocker)
        {
          IVideoDocker vdw = (IVideoDocker)child;
          vdw.Pause();
        }
      }
      
    }

    			
		private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
		{

			WeifenLuo.WinFormsUI.Docking.DockPanel dockPane = (WeifenLuo.WinFormsUI.Docking.DockPanel)sender;
			IVideoDocker videoDockWindow = dockPane.ActiveDocument as IVideoDocker;
			int lastVolume = 0;
			if (LastActiveVideoDockerWindow != null)
			{ 
				lastVolume = LastActiveVideoDockerWindow.Volume;
        LastActiveVideoDockerWindow.Volume = 0;
			}
			LastActiveVideoDockerWindow = videoDockWindow;
			if (videoDockWindow != null)
			{
        videoDockWindow.Volume = lastVolume;
			}
		}

		private void replaceActiveWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReuseActiveDockWindow = !ReuseActiveDockWindow;
		}
	}
}
