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
using DotImaging;

namespace QuickVid
{
  public class ThumbNailGrabber
  {

    public delegate void ThumbNailReadyEventHandler(object sender, ThumbNailReadyEventArgs e);
    public event ThumbNailReadyEventHandler OnMediaReady;
    List<Image> images = new List<Image>();

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
      var reader = new FileCapture(url);
      reader.Open();
      long len = reader.Length;
      Bgr<byte>[,] buffer = null;
      long position  = 0;
      long fps = (long)(reader.Length / 23.0);// reader.FrameRate();
      while (position+1 < reader.Length)
      {
          Image i2 = new Image();
        IImage image2 = reader.Read();
          Bgra<byte>[,] bmp = image2.ToBgra();
          //bmp.Save(@"c:\scratch\" + cnt.ToString()+ ".bmp");
          i2.Source = bmp.ToBitmapSource();
          images.Add(i2);
          reader.Seek(fps, SeekOrigin.Current);
        position = reader.Position;
        //  var byteArray = new byte[image2.Width * image2.Height];
        //  System.Runtime.InteropServices.Marshal.Copy(image2.ImageData, byteArray, 0, image2.Width * image2.Height);
        //  BitmapSource bmp2 = BitmapSource.Create(image2.Width, image2.Height, 1 / 200, 1 / 200, PixelFormats.Pbgra32,
        //   null, byteArray, image2.Width);
        //  i2.Source = bmp2;
      }
      /*
      reader.ReadTo(ref buffer);
      IImage iimg = reader.Read();
      iimg.ToBgra().
      var frame = reader.ReadAs<Bgr<byte>>();
      Image image = new Image();
      image= frame;
      DrawingVisual drawingVisual = new DrawingVisual();
      DrawingContext drawingContext = drawingVisual.RenderOpen();
      drawingContext.DrawImage(frame, new Rect(0, 0, 160, 105));
      drawingContext.DrawVideo(frame, new Rect(0, 0, 160, 105));
      drawingContext.Close();
      RenderTargetBitmap bmp = new RenderTargetBitmap(160, 105, 1 / 200, 1 / 200, PixelFormats.Pbgra32);
      bmp.Render(drawingVisual);

      myImage.Source = bmp;
      */
      reader.Close();
      if (OnMediaReady != null)
        OnMediaReady(this, new ThumbNailReadyEventArgs(images));
    }
  }
}
