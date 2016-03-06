using System;
using System.IO;
using System.Windows.Controls;
using DotImaging;
using System.Windows.Media.Imaging;

namespace QuickVid
{
  public class ThumbNailGrabber : IDisposable
  {

    VideoCaptureBase reader;
    public ThumbNailGrabber(string url)
    {
      try
      {
        reader = new FileCapture(url);
        reader.Open();
      } catch (Exception ex)
      {
        ExceptionMessage = ex.Message;
      }
    }
    ~ThumbNailGrabber()
    {
      Dispose(true);
    }

    public long Frames()
    {
      if (reader == null) return 0;
      return reader.Length;

    }

    public BitmapSource GetThumbNailSource(long frame)
    {
      if (reader == null) return null;
      reader.Seek(frame, SeekOrigin.Begin);
      IImage iimage = reader.Read();
      Bgra<byte>[,] bmp = iimage.ToBgra();
      return bmp != null ? bmp.ToBitmapSource() : null;


    }


    public BitmapSource GetThumbNail(TimeSpan ts)
    {
      if (reader == null) return null;
      long frame = (long)(reader.FrameRate * ts.TotalSeconds);
      return GetThumbNailSource(frame);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    public string ExceptionMessage { get; private set; }

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
