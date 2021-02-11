using MediatR;
using Music.Application.CQRS.Music.Query;

using Music.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application.CQRS.Music.Handler
{
    public class GetMusicByArtistNameHandler : IRequestHandler<GetMusicByArtistNameQuery, IEnumerable<MusicResponse>>
    {
        private readonly IMusicRepository _musicRepository;
        public GetMusicByArtistNameHandler(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository ?? throw new ArgumentNullException(nameof(musicRepository));
        }
        public async Task<IEnumerable<MusicResponse>> Handle(GetMusicByArtistNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _musicRepository.GetMusicByArtistName(request.UserName);

            if (result != null)
            {
                var musicList= Mappper.MusicMapper.Mapper.Map<IEnumerable<MusicResponse>>(result); 
                return musicList;
            }
            else 
            {
                return null;
            }

           

            
        }
    }
}
