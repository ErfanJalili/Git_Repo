using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.Models.Music
{
    public class UpdateMusicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}
