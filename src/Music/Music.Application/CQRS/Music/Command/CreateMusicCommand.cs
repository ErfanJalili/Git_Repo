using MediatR;

using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Music.Command
{
    public class CreateMusicCommand :IRequest<MusicResponse>
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}
