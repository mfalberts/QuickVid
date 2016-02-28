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
    private bool AutoMute { get; set; }
		public MainForm()
		{
			InitializeComponent();
			ReuseActiveDockWindow = reuseActiveWindowMenuItem.Checked;
      AutoMute = autoMuteMenuItem.Checked;
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}
		

		private void MainForm_Load(object sender, EventArgs e)
		{
      DirectoryPane dp = new DirectoryPane();
      dp.FileSelected += DirectoryPaneFileSelected;
      dp.Show(dockPanel2, DockState.Document);
		}

    private void DirectoryPaneFileSelected(object sender, FileSelectedArgs e)
    {
      string fileName = e.URL;
      if (ReuseActiveDockWindow == false || LastActiveVideoDockerWindow == null)
      {
        //VideoDocker videoDocker = new VideoDocker();
        VideoDockerWPF videoDocker = new VideoDockerWPF();
        videoDocker.Show(dockPanel1, DockState.Document);
        videoDocker.URL = fileName;
      }
      else
      {
        LastActiveVideoDockerWindow.URL = fileName;
      }

    }


    private List<IVideoDocker> AllDockWindows()
    {
      WeifenLuo.WinFormsUI.Docking.DockPanel dockPane = (WeifenLuo.WinFormsUI.Docking.DockPanel)dockPanel1;
      List<IVideoDocker> list = new List<IVideoDocker>();
      foreach (DockPane dp in dockPane.Panes)
      {
        foreach (DockContent dc in dp.Contents)
          if (dc is IVideoDocker)
          {
            IVideoDocker vdw = dc as IVideoDocker;
            list.Add(vdw);
          }
      }
      return list;

    }




    private void PlayAll()
    {
      AllDockWindows().ForEach(x => x.Play());
    }
    private void PauseAll()
    {
      AllDockWindows().ForEach(x => x.Pause());
    }

    private void MuteAll()
    {
      AllDockWindows().ForEach(x => x.Volume = 0);
    }

    private void ArrangeAll()
    {
      List<IVideoDocker> videoWindows = AllDockWindows();

      List<DockPane> panes = new List<DockPane>();
      foreach (DockPane dp in dockPanel1.Panes)
        if (dp.ActiveContent is IVideoDocker)
          panes.Add(dp);
      List<DockContent> contents = new List<DockContent>();

      foreach (DockPane dp in panes)
        foreach (DockContent dc in dp.Contents)
          contents.Add(dc);

       int cnt = 0;
        foreach (DockContent dc in contents)
        {
          if (cnt == 0)
            dc.DockTo(dockPanel1, DockStyle.Fill);
          if (cnt == 1)
            dc.DockTo(dockPanel1, DockStyle.Right);
          if (cnt == 2)
            dc.DockTo(dockPanel1, DockStyle.Bottom);
          if (cnt == 3)
            dc.DockTo(dockPanel1, DockStyle.Right);
          cnt++;
        }

    }


    private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
    {
      if (AutoMute == true)
      {
        WeifenLuo.WinFormsUI.Docking.DockPanel dockPane = (WeifenLuo.WinFormsUI.Docking.DockPanel)sender;
        IVideoDocker videoDockWindow = dockPane.ActiveDocument as IVideoDocker;
        double lastVolume = 0;
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
		}

		private void reuseActiveWindowMenuItem_Click(object sender, EventArgs e)
		{
			ReuseActiveDockWindow = reuseActiveWindowMenuItem.Checked;
		}

    private void autoMuteMenuItem_Click(object sender, EventArgs e)
    {
      AutoMute = autoMuteMenuItem.Checked;
    }

    private void pauseAllButton_Click(object sender, EventArgs e)
    {
      PauseAll();
    }

    private void playAllButton_Click(object sender, EventArgs e)
    {
      PlayAll();
    }


    private void muteAllButton_Click_1(object sender, EventArgs e)
    {
      MuteAll(); 
    }

    private void autoArrangeButton_Click(object sender, EventArgs e)
    {
      ArrangeAll();
    }
  }
}
