using System;
using System.IO;
using System.Windows.Controls;
using DotImaging;

namespace QuickVid
{
  public class ThumbNailGrabber : IDisposable
  {

    VideoCaptureBase reader;
    public ThumbNailGrabber(string url)
    {
      reader = new FileCapture(url);
      reader.Open();
    }
    ~ThumbNailGrabber()
    {
      Dispose(false);
    }
    public Image GetThumbNail(long frame)
    {
      reader.Seek(frame, SeekOrigin.Begin);
      IImage iimage = reader.Read();
      Bgra<byte>[,] bmp = iimage.ToBgra();
      Image image = new Image();
      image.Source = bmp.ToBitmapSource();
      return image;
    }

    public Image GetThumbNail(TimeSpan ts)
    {
      long frame = (long)(reader.FrameRate * ts.TotalSeconds);
      return GetThumbNail(frame);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          if (reader != null)
            reader.Close();
          reader = null;
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~ThumbNailGrabber() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }
    #endregion
  }
}
