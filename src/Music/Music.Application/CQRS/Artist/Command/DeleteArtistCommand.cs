using MediatR;
using Music.Application.CQRS.Artist.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Artist.Command
{
    public class DeleteArtistCommand :IRequest<ArtistResponse>
    {
        public int Id { get; set; }
    }
}
