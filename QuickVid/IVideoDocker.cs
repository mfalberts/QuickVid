﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickVid
{
  interface IVideoDocker
  {
    string URL { get; set; }
    double Volume { get; set; }
    void Pause();
  }
}
