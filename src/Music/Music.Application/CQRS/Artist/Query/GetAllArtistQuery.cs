using MediatR;
using Music.Application.CQRS.Artist.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Artist.Query
{
    public class GetAllArtistQuery :IRequest<IEnumerable<ArtistResponse>>
    {
    }
}
