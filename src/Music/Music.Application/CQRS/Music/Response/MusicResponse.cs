using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application
{
    public class MusicResponse
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
