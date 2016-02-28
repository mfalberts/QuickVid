using WeifenLuo.WinFormsUI.Docking;

namespace QuickVid
{
  interface IVideoDocker
  {
    string URL { get; set; }
    double Volume { get; set; }
    void Pause();
    void Play();
    DockContent DockContent { get; }

  }
}
