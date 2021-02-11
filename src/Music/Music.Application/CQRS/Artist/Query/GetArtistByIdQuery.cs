using MediatR;
using Music.Application.CQRS.Artist.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Artist.Query
{
    public class GetArtistByIdQuery : IRequest<ArtistResponse>
    {
        public int Id { get; set; }

        public GetArtistByIdQuery(int id)
        {
            Id = id;
        }
    }
}
