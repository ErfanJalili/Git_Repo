using Music.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Domain.Entities
{
    public class Music : Entity
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }

}
