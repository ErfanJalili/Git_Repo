using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.Settings
{
    public interface IApiSettings
    {
        string BaseAddress { get; set; }
        string MusicPath { get; set; }
        string ArtistPath { get; set; }
      
    }
}
