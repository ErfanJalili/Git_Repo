using Music.Client.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.Models.Music
{
    public class MusicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistModel Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
