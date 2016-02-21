using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
  /// Interaction logic for VideoPlayerWPF.xaml
  /// </summary>
  public partial class VideoPlayerWPF : UserControl, IVideoDocker
  {

    public delegate void MediaReadyEventHandler(object sender, MediaReadyArgs e);
    public event MediaReadyEventHandler OnMediaReady;

    public VideoPlayerWPF()
    {
      InitializeComponent();
      mePlayer.MediaOpened += MePlayer_MediaOpened;
    }

    private void MePlayer_MediaOpened(object sender, RoutedEventArgs e)
    {
      if (OnMediaReady != null)
       OnMediaReady(this,new MediaReadyArgs(mePlayer.NaturalDuration));
    }

    public string URL
    {
      get   { return  mePlayer.Source.ToString();  }

      set
      {
        mePlayer.Source = new Uri(value);
        mePlayer.Play();
        mePlayer.Volume = 0;
      }
    }

    public double Duration()
    {
      if (mePlayer.Source != null && mePlayer.NaturalDuration.HasTimeSpan)
        return mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
      else
        return 0;
    }

    public int Volume
    {
      get
      {
        return 0;
      }

      set
      {
        mePlayer.Volume = value;
      }
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
