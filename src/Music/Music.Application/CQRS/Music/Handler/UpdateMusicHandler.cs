using MediatR;
using Music.Application.CQRS.Music.Command;
using Music.Application.CQRS.Music.Mappper;
using Music.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application
{
    public class UpdateMusicHandler : IRequestHandler<UpdateMusicCommand, MusicResponse>
    {
        private readonly IMusicRepository _musicRepository;
        public UpdateMusicHandler(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository ?? throw new ArgumentNullException(nameof(musicRepository));
        }
        public async Task<MusicResponse> Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {

            var updateMusic = await _musicRepository.FindMusicById(request.Id);
            updateMusic.Name = request.Name;
            updateMusic.ArtistId = request.ArtistId;
            await _musicRepository.UpdateAsync(updateMusic);
            return MusicMapper.Mapper.Map<MusicResponse>(updateMusic);
        }
    }
}
