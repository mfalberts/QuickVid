using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
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
      positionsSlider.PreviewMouseLeftButtonDown += PositionsSlider_PreviewMouseLeftButtonDown;
      positionsSlider.MouseLeave += PositionsSlider_MouseLeave;
      positionsSlider.MouseMove += PositionsSlider_MouseMove;
      
      MyToolTip.MouseLeftButtonDown += MyToolTip_MouseLeftButtonDown;
      playButton.Click += PlayButton_Click;
      pauseButton.Click += PauseButton_Click;
      muteButton.Click += MuteButton_Click;
      mePlayer.ScrubbingEnabled = true;

      DispatcherTimer positionTimer = new DispatcherTimer();
      positionTimer.Interval = TimeSpan.FromSeconds(1);
      positionTimer.Tick += timer_Tick;
      positionTimer.Start();
    }

    private void PositionsSlider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      MyToolTip.IsOpen = false;
      PositionsSlider_MouseLeftButtonDown(sender, e);
    }

    private void MuteButton_Click(object sender, RoutedEventArgs e)
    {
      mePlayer.Volume = 0;
    }

    private void PauseButton_Click(object sender, RoutedEventArgs e)
    {
      mePlayer.Pause();
    }

    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
      mePlayer.Play();
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

    private void PositionsSlider_MouseMove(object sender, MouseEventArgs e)
    {
      if (thumbNailGrabber != null)
      {
        //MyFirstPopupTextBlock.Text = "hi";
        // fix up size to be proportional to window size
        ThumbnailImage.Width = ThumbnailImage.Height = Math.Max(meBorder.ActualHeight,meBorder.ActualWidth) * 0.25;
        double width =  Math.Max(meBorder.ActualHeight,meBorder.ActualWidth) * 0.25;
        MyToolTip.PlacementRectangle = new Rect(0, meBorder.ActualHeight - width*2, width, width);
        MyToolTip.PlacementTarget = meBorder;// positionsSlider;
        MyToolTip.Placement = PlacementMode.Bottom;//MousePoint;
        //MyToolTip.VerticalOffset = ThumbnailImage.Height * -1 * 1.25;
        MyToolTip.HorizontalOffset = Math.Max(0, e.MouseDevice.GetPosition(positionsSlider).X);
        MyToolTip.IsOpen = true;
        bool ismc = IsMouseCaptured;
        int second = PositionAt(e);
        ThumbnailImage.Source = thumbNailGrabber.GetThumbNail(new TimeSpan(0, 0, 0, second, 0));
      }
    }

    private void PositionsSlider_MouseEnter(object sender, MouseEventArgs e)
    {
      PositionsSlider_MouseMove(sender, e);
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
    public void Play()
    {
      mePlayer.Play();
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
