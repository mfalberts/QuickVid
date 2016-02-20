using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace QuickVid
{


  public partial class DirectoryPane : DockContent
  {

    public delegate void FileSelectedEventHandler(object sender, FileSelectedArgs e);
    public event FileSelectedEventHandler FileSelected;

    public DirectoryPane()
    {
      InitializeComponent();
      PopluateFileList();
    }


    private void SetListViewColumns()
    {
      ListView lv = listView1;
      lv.Columns.Clear();
      lv.Columns.Add("Name");
      lv.Columns.Add("Date Modified");
    }
    private void PopluateFileList()
    {
      string[] files = Directory.GetFiles(@"v:\iPhoneFormat");
      SetListViewColumns();
      foreach (string file in files)
      {
        ListViewItem lvi = new ListViewItem(new string[] { Path.GetFileName(file), Directory.GetLastWriteTime(file).ToString() });
        lvi.Tag = file; // keep the file url on the tag
        listView1.Items.Add(lvi);

      }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].Tag != null)
        if (FileSelected != null)
          FileSelected(this, new FileSelectedArgs((string)listView1.SelectedItems[0].Tag));

    }
  }

  public class FileSelectedArgs : EventArgs
  {
    private readonly string url;
    // Constructor. 
    public FileSelectedArgs(string url)
    {
      this.url = url;
    }

    // Properties. 
    public string URL
    {
      get { return url; }
    }
  }

  }
