using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuickVid
{
  /// <summary>
  /// Interaction logic for FileSelectorWPF.xaml
  /// </summary>
  public partial class FileSelectorWPF : UserControl
  {


    public delegate void FileSelectedEventHandler(object sender, FileSelectedArgs e);
    public event FileSelectedEventHandler FileSelected;
    const int THUMB_FRAME = 35;

    ScrollViewer scrollViewr = new ScrollViewer();
    StackPanel stackPanel = new StackPanel();
    Grid listGrid;
    // test caching images
//    Dictionary<string, Task<ImageSource>> images = new Dictionary<string, Task<ImageSource>>();
    Dictionary<string, ImageSource> images = new Dictionary<string, ImageSource>();

    public FileSelectorWPF()
    {
      InitializeComponent();
      CreateGrid();
      this.SizeChanged += FileSelectorWPF_SizeChanged;

    }

    private void FileSelectorWPF_SizeChanged(object sender, SizeChangedEventArgs e)
    {
  //    throw new NotImplementedException();
    }

    private void CreateGrid()
    {
      listGrid = new Grid();
      listGrid.ShowGridLines = true;
      ColumnDefinition colImage = new ColumnDefinition();
      colImage.Width = new GridLength(1, GridUnitType.Star);
      listGrid.ColumnDefinitions.Add(colImage);

//      ColumnDefinition colName = new ColumnDefinition();
//      colName.Width = new GridLength(200);
//      listGrid.ColumnDefinitions.Add(colName);

      scrollViewr = new ScrollViewer();
      stackPanel = new StackPanel();
      stackPanel.Children.Add(listGrid);
      scrollViewr.Content = stackPanel;
      Content = scrollViewr;

      // setup events
      scrollViewr.ScrollChanged += Sv_ScrollChanged;
    
    }

    

    private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      Image img = (sender as Image);
      if (img != null && FileSelected != null)
        if (FileSelected != null)
          FileSelected(this, new FileSelectedArgs((string)img.Tag));
    }

    private bool IsUserVisible(FrameworkElement element, FrameworkElement container)
    {
      if (!element.IsVisible)
        return false;

      Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
      Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
      return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
      
    }


    private ImageSource LoadThumbnail(Image img, string file)
    {
      if (images.ContainsKey(file))
      {
        img.Source = images[file];
      }
      //else
      //  new Thread(() =>
      //  {
      //    img.Dispatcher.BeginInvoke((Action)(() => img.Source = new ThumbNailGrabber(file).GetThumbNailSource(THUMB_FRAME)));
      //  }).Start();
      return img.Source;
    }



    public async Task<int> LoadAllThumbnails(List<string> files)
    {
      await Task.Run(() =>
      {
        //foreach (string file in files)
        Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 4},
          (file) =>
        {
          BitmapSource bmps = new ThumbNailGrabber(file).GetThumbNailSource(THUMB_FRAME);
          if (bmps != null)  bmps.Freeze();  // this is IMPORTANT for crossing the thread boundary!
          if (images.ContainsKey(file) == false)
            images.Add(file, bmps);
        });
      }
      ).ConfigureAwait(true);  // configureawait?? need to look for all places..
      return 43;

    }

    private void Sv_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
      UpdateThumbnails(true);
    }

    private void UpdateThumbnails(bool OnlyVisible)
    {
      bool elementIsVisible = false;

      foreach (FrameworkElement child in this.listGrid.Children)
      {
        if (child != null)
        {
          elementIsVisible = this.IsUserVisible(child, this.scrollViewr);

          if (OnlyVisible == false || elementIsVisible)
          {
            Image img = child as Image;
            if (img != null && img.Source == null && img.Tag != null)
              img.Source = LoadThumbnail(img, (string)img.Tag);
          }
        }
      }
    }


    public async void SetFileList(List<string> files)
    {
      int row = listGrid.RowDefinitions.Count;
      
      for (int i = row; i < row+files.Count; i++)
      {
        RowDefinition rowDef = new RowDefinition();
        listGrid.RowDefinitions.Add(rowDef);
      }


      foreach (string file in files)
      {
        Image image = new Image();
        image.Stretch = Stretch.Uniform;
        image.Margin = new Thickness(0, 0, 0, 0);
        image.Tag = file;
        image.PreviewMouseLeftButtonDown += Image_PreviewMouseLeftButtonDown;
        image.MouseEnter += Image_MouseEnter;
        image.MouseMove += Image_MouseMove;
        image.MouseLeave += Image_MouseLeave;
        Grid.SetRow(image, row);
        Grid.SetColumn(image, 0);
        listGrid.Children.Add(image);

        TextBlock name = new TextBlock();
        name.Text = System.IO.Path.GetFileName(file);
        name.FontSize = 12;
        name.HorizontalAlignment = HorizontalAlignment.Center;
        name.VerticalAlignment = VerticalAlignment.Top;
        name.Foreground = new SolidColorBrush(Colors.White);
        Grid.SetRow(name, row);
        Grid.SetColumn(name, 0);
        listGrid.Children.Add(name);
        row++;
      }
     await LoadAllThumbnails(files).ConfigureAwait(false);//mfa?? 4/4/2018
     UpdateThumbnails(false);
      //LoadAllThumbnails2(files);      


    }

    private ThumbNailGrabber imageTG = null;

    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
      Image img = sender as Image;

      if (img != null && imageTG != null)
      {
        double fpw =  imageTG.Frames() / img.ActualWidth;
        img.Source = imageTG.GetThumbNailSource((long)(e.GetPosition(img).X * fpw));
      }
    }

    private void Image_MouseLeave(object sender, MouseEventArgs e)
    {
      if (imageTG != null)
        imageTG = null;
    }

    private void Image_MouseEnter(object sender, MouseEventArgs e)
    {
      Image img = sender as Image;
      if (img != null)
      {
        imageTG = new ThumbNailGrabber((string)img.Tag);
        img.Source = imageTG.GetThumbNailSource(200);
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

}
