using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application.CQRS.Music.Query
{
    public class GetAllMusicQuery :IRequest<IEnumerable<MusicResponse>>
    {
    }
}
