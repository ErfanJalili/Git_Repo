using MediatR;
using Music.Application.CQRS.Artist.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Artist.Query
{
    public class GetArtistByNameQuery :IRequest<ArtistResponse>
    {
        public string UserName { get; set; }

        public GetArtistByNameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
