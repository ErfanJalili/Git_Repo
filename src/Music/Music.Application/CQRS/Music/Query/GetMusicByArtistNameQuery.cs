using MediatR;

using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Music.Query
{
    public class GetMusicByArtistNameQuery :IRequest<IEnumerable<MusicResponse>>
    {
        public string UserName { get; set; }

        public GetMusicByArtistNameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
