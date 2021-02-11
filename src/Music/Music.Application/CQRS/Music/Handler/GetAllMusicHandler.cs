using MediatR;
using Music.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application.CQRS.Music.Query
{
    public class GetAllMusicHandler : IRequestHandler<GetAllMusicQuery, IEnumerable<MusicResponse>>
    {
        private readonly IMusicRepository _musicRepository;
        public GetAllMusicHandler(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository ?? throw new ArgumentNullException(nameof(musicRepository));
        }
        public async Task<IEnumerable<MusicResponse>> Handle(GetAllMusicQuery request, CancellationToken cancellationToken)
        {
            var musics = await _musicRepository.GetAllMusicAsync();
            var mapping= Mappper.MusicMapper.Mapper.Map<IEnumerable<MusicResponse>>(musics);
            return mapping;
        }
    }
}
