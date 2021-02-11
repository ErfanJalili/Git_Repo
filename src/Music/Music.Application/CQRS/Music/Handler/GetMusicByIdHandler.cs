using MediatR;
using Music.Application.CQRS.Music.Mappper;
using Music.Application.CQRS.Music.Query;
using Music.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application.CQRS.Music.Handler
{
    public class GetMusicByIdHandler : IRequestHandler<GetMusicByIdQuery, MusicResponse>
    {
        private readonly IMusicRepository _musicRepository;
        public GetMusicByIdHandler(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository ?? throw new ArgumentNullException(nameof(musicRepository));
        }
        public async Task<MusicResponse> Handle(GetMusicByIdQuery request, CancellationToken cancellationToken)
        {
            var music = await _musicRepository.FindMusicById(request.Id);
            var response= MusicMapper.Mapper.Map<MusicResponse>(music);
            return response;
        }
    }
}
