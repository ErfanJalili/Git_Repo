using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Music.Query
{
    public class GetMusicByIdQuery : IRequest<MusicResponse>
    {
        public int Id { get; set; }

        public GetMusicByIdQuery(int id)
        {
            Id = id ;
        }
    }
}
