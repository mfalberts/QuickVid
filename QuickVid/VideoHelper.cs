using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QuickVid
{
	public class ThumbNailGrabber
	{

    public delegate void ThumbNailReadyEventHandler(object sender, ThumbNailReadyEventArgs e);
    public event ThumbNailReadyEventHandler OnMediaReady;
    private Queue<TimeSpan> _positionsToThumbnail = new Queue<TimeSpan>();

    public class ThumbNailReadyEventArgs : EventArgs
    {
      private readonly List<Image> images;

      // Constructor. 
      public ThumbNailReadyEventArgs(List<Image> imgages)
      {
        this.images = imgages;
      }

      // Properties. 
      public List<Image> Thumbnails
      {
        get { return images; }
      }
    }


    public Image Thumbnail
    {
      get; set;
    }

    public void CaptureBitMaps(string url)
    {
      MediaPlayer mediaPlayer = new MediaPlayer();
      mediaPlayer.MediaOpened += Mp_MediaOpened;
      mediaPlayer.ScrubbingEnabled = true;

      mediaPlayer.Open(new Uri(url));
      mediaPlayer.Changed += MediaPlayer_Changed;
      mediaPlayer.Position = TimeSpan.FromSeconds(0);
      mediaPlayer.SpeedRatio = 1;
//      mediaPlayer.Play();
      mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;

    }

    private void MediaPlayer_MediaEnded(object sender, EventArgs e)
    {
      if (OnMediaReady != null)
        OnMediaReady(this, new ThumbNailReadyEventArgs(images));
      int second = 0;
      foreach (Image img in images)
      {

        JpegBitmapEncoder jpg = new JpegBitmapEncoder();
        jpg.Frames.Add(BitmapFrame.Create((RenderTargetBitmap)img.Source));
        using (Stream stm = File.Create(@"c:\\scratch\\" + second.ToString() + ".jpg"))
          jpg.Save(stm);
        second++;
      }

    }

    List<Image> images = new List<Image>();

    private void MediaPlayer_Changed(object sender, EventArgs e)
    {

      // If still processing the file (i.e., not done)...
//      if (GetProcessing(this))
      {
        // Capture the current frame
        CaptureCurrentFrame(false);
      }
      /*
      MediaPlayer mediaPlayer = sender as MediaPlayer;
//      mediaPlayer.Position = TimeSpan.FromSeconds(second);
      Image myImage = new Image();
      DrawingVisual drawingVisual = new DrawingVisual();
      DrawingContext drawingContext = drawingVisual.RenderOpen();
      drawingContext.DrawVideo(mediaPlayer, new Rect(0, 0, 160, 105));
      drawingContext.Close();
      RenderTargetBitmap bmp = new RenderTargetBitmap(160, 105, 1 / 200, 1 / 200, PixelFormats.Pbgra32);
      bmp.Render(drawingVisual);

      myImage.Source = bmp;
      images.Add(myImage);
      */
    }

    private void Mp_MediaOpened(object sender, EventArgs e)
    {
      int interval = 10;
      MediaPlayer mediaPlayer = sender as MediaPlayer;

      int totalSeconds = (int)mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
      int numberFramesToThumbnail = (int)(totalSeconds / interval); 
      uint[] framePixels;
      uint[] previousFramePixels;
      framePixels = new uint[mediaPlayer.NaturalVideoWidth * mediaPlayer.NaturalVideoHeight];
      previousFramePixels = new uint[framePixels.Length];

      // Enqueue a position for each frame (at the center of each of the N segments)
      for (int i = 0; i < numberFramesToThumbnail; i++)
      {
        _positionsToThumbnail.Enqueue(TimeSpan.FromSeconds((((2 * i) + 1) * totalSeconds) / (2 * numberFramesToThumbnail)));
      }

      // Capture the first frame as a baseline
      RenderBitmapAndCapturePixels(mediaPlayer, previousFramePixels);

      // Seek to the first thumbnail position
      SeekToNextThumbnailPosition();

    }

    private void SeekToNextThumbnailPosition(MediaPlayer mediaPlayer)
    {
      // If more frames remain to capture...
      if (0 < _positionsToThumbnail.Count)
      {
        // Seek to next position and start watchdog timer
        mediaPlayer.Position = _positionsToThumbnail.Dequeue();
        _watchdogTimer.Start();
      }
      else
      {
        // Done; close media file and stop processing
        mediaPlayer.Close();
        //framePixels = null;
        //previousFramePixels = null;
        SetProcessing(this, false);
      }
    }

    private ImageSource RenderBitmapAndCapturePixels(MediaPlayer mediaPlayer, uint[] pixels)
    {
      // Render the current frame into a bitmap
      var drawingVisual = new DrawingVisual();
      var renderTargetBitmap = new RenderTargetBitmap(mediaPlayer.NaturalVideoWidth, mediaPlayer.NaturalVideoHeight, 96, 96, PixelFormats.Default);
      using (var drawingContext = drawingVisual.RenderOpen())
      {
        drawingContext.DrawVideo(mediaPlayer, new Rect(0, 0, mediaPlayer.NaturalVideoWidth, mediaPlayer.NaturalVideoHeight));
      }
      renderTargetBitmap.Render(drawingVisual);

      // Copy the pixels to the specified location
      renderTargetBitmap.CopyPixels(pixels, mediaPlayer.NaturalVideoWidth * 4, 0);

      // Return the bitmap
      return renderTargetBitmap;
    }
  }
}
