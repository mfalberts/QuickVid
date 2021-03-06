﻿using System;
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
      directoryCombo.SelectedIndexChanged += DirectoryCombo_SelectedIndexChanged;
      directoryCombo.Items.Add(@"V:\iPhoneFormat");
      directoryCombo.SelectedIndex = 0;
//      PopluateFileList();
    }

    private void DirectoryCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
      PopluateFileList(directoryCombo.Items[directoryCombo.SelectedIndex].ToString());
    }

    private void SetListViewColumns()
    {
      ListView lv = listView1;
      lv.Columns.Clear();
      lv.Columns.Add("Name");
      lv.Columns.Add("Date Modified");

    }
    private void PopluateFileList(string directoryName)
    {
      if (Directory.Exists(directoryName) == false)
        return;
      string[] files = Directory.GetFiles(directoryName);
      SetListViewColumns();
      foreach (string file in files)
      {
        ListViewItem lvi = new ListViewItem(new string[] { Path.GetFileName(file), Directory.GetLastWriteTime(file).ToString() });
        
        lvi.Tag = file; // keep the file url on the tag
        listView1.Items.Add(lvi);

      }
      ListView lv = listView1;
      lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
      lv.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].Tag != null)
        if (FileSelected != null)
          FileSelected(this, new FileSelectedArgs((string)listView1.SelectedItems[0].Tag));

    }

    private void selectFolderButton_Click(object sender, EventArgs e)
    {
      if (directoryCombo.SelectedIndex >= 0 && directoryCombo.Items[directoryCombo.SelectedIndex] != null)
        folderBrowserDialog1.SelectedPath = directoryCombo.Items[directoryCombo.SelectedIndex].ToString();

      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {

        string folderName = folderBrowserDialog1.SelectedPath;
        if (directoryCombo.Items.Contains(folderName) == false)
          directoryCombo.Items.Insert(0, folderName);
        directoryCombo.SelectedIndex = 0;
      }
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
