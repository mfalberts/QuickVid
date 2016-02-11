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
using WeifenLuo.WinFormsUI.Docking;

namespace QuickVid
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
//			SizeChanged += MainForm_SizeChanged;
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			axWindowsMediaPlayer1.uiMode = "full";
			axWindowsMediaPlayer1.stretchToFit = true;
			axWindowsMediaPlayer2.uiMode = "none";
			axWindowsMediaPlayer2.stretchToFit = true;
			dockPanel1.Documents[0]
			axWindowsMediaPlayer1.Show(dockPanel1, DockState.Document);
			PopluateFileList();
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//test comment...
		}

		private void PopluateFileList()
		{
			string[] files = Directory.GetFiles(@"v:\iPhoneFormat");
			foreach (string file in files)
			{
				listView1.Items.Add(file);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count >0  && listView1.SelectedItems[0].Text != null)
				axWindowsMediaPlayer1.URL = listView1.SelectedItems[0].Text;
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
			ListViewItem lvi = e.Item;
			if (lvi != null)
			{
				axPreviewPlayer.URL = lvi.Text;
				axPreviewPlayer.uiMode = "none";
				axPreviewPlayer.settings.rate = 5;
				axPreviewPlayer.settings.volume = 0; 
			}

		}
	}
}
