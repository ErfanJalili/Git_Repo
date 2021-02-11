using MediatR;
using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application
{
    public class UpdateMusicCommand :IRequest<MusicResponse>
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ArtistId { get; set; }
    }
}
