using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuickVid
{
  /// <summary>
  /// Interaction logic for VideoPlayerWPF.xaml
  /// </summary>
  public partial class VideoPlayerWPF : UserControl, IVideoDocker
  {

    public delegate void MediaReadyEventHandler(object sender, MediaReadyArgs e);
    public event MediaReadyEventHandler OnMediaReady;
    private bool userIsDraggingSlider = false;
    private ThumbNailGrabber thumbNailGrabber;

    public VideoPlayerWPF()
    {
      InitializeComponent();
      mePlayer.MediaOpened += MePlayer_MediaOpened;
      volumeSlider.ValueChanged += VolumeSlider_ValueChanged;
      volumeSlider.Maximum = 1;
      volumeSlider.Interval = 1;
      positionsSlider.ValueChanged += PositionsSlider_ValueChanged;
      positionsSlider.MouseEnter += PositionsSlider_MouseEnter;
      positionsSlider.MouseLeftButtonDown += PositionsSlider_MouseLeftButtonDown;
      positionsSlider.MouseLeave += PositionsSlider_MouseLeave;
      MyToolTip.MouseLeftButtonDown += MyToolTip_MouseLeftButtonDown;
      mePlayer.ScrubbingEnabled = true;
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += timer_Tick;
      timer.Start();
    }

    private void MyToolTip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      MyToolTip.IsOpen = false;
      PositionsSlider_MouseLeftButtonDown(sender, e);
    }


    private void PositionsSlider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      MyToolTip.IsOpen = false;
      int second = PositionAt(e);
      positionsSlider.Value = second;
    }

    private void PositionsSlider_MouseLeave(object sender, MouseEventArgs e)
    {
      MyToolTip.IsOpen = false;

    }

    private void PositionsSlider_MouseEnter(object sender, MouseEventArgs e)
    {
    //  double yPos = (int)(e.GetPosition(positionsSlider).Y);
    //  if (yPos < (positionsSlider.ActualHeight / 2))
       // return; // only do this if the mouse position is above the center
      if (thumbNailGrabber != null)
      {
        //MyFirstPopupTextBlock.Text = "hi";
        MyToolTip.PlacementTarget = mePlayer;// positionsSlider;
        MyToolTip.Placement = PlacementMode.Center;//MousePoint;
                                                     //        MyToolTip.IsOpen = false;
        MyToolTip.IsOpen = true;
        int second = PositionAt(e);
        //if (second < thumbnails.Count)
        {

          ThumbnailImage.Source = thumbNailGrabber.GetThumbNail(new TimeSpan(0, 0, 0, second, 0)).Source;
          //ThumbnailImage.Source = thumbnails[second].Source;
          //MyPanel.Children.RemoveRange(0, 1);
          //MyPanel.Children.Add(thumbnails[second]);
        }
      }
    }

    private int PositionAt(MouseEventArgs e)
    {
      double scale = positionsSlider.ActualWidth / (double)positionsSlider.Maximum;
      int second = (int)(e.GetPosition(positionsSlider).X / scale);
      return second;
    }

    private void PositionsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      
      mePlayer.Position = TimeSpan.FromSeconds(e.NewValue);
      e.Handled = true;
     
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
      {
        positionsSlider.Minimum = 0;
        positionsSlider.Maximum =  mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
        positionsSlider.Value = mePlayer.Position.TotalSeconds;
      }
    }

    private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      mePlayer.Volume =  e.NewValue;
    }

    private void MePlayer_MediaOpened(object sender, RoutedEventArgs e)
    {
      if (OnMediaReady != null)
        OnMediaReady(this,new MediaReadyArgs(mePlayer.NaturalDuration));
      positionsSlider.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
    }

    public string URL
    {
      get   { return  mePlayer.Source.ToString();  }

      set
      {
        mePlayer.Source = new Uri(value);
        mePlayer.Play();
        mePlayer.Volume = 0;
        thumbNailGrabber = new ThumbNailGrabber(value);
      }
    }

    public double Duration()
    {
      if (mePlayer.Source != null && mePlayer.NaturalDuration.HasTimeSpan)
        return mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
      else
        return 0;
    }

    public double Volume
    {
      get  { return mePlayer.Volume;   }
      set  { volumeSlider.Value = value;  }
    }

    public void Pause()
    {
      mePlayer.Pause();
    }

    public void SetPosition(int time)
    {
      mePlayer.Position = new TimeSpan(0, time, 0);
    }

    public class MediaReadyArgs : EventArgs
    {
      private readonly Duration duration;
      // Constructor. 
      public MediaReadyArgs(Duration duration)
      {
        this.duration = duration;
      }

      // Properties. 
      public Duration DurationInfo
      {
        get { return duration; }
      }
    }

  }
}
