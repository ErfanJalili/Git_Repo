using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application
{
    public class DeleteMusicCommand :IRequest<MusicResponse>
    {
        public int Id { get; set; }
        
    }
}
