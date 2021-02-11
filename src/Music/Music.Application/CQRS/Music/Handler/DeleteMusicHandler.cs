using MediatR;
using Music.Application.CQRS.Music.Mappper;
using Music.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application.CQRS.Music.Handler
{
    public class DeleteMusicHandler : IRequestHandler<DeleteMusicCommand, MusicResponse>
    {
        private readonly IMusicRepository _musicRepository;
        public DeleteMusicHandler(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository ?? throw new ArgumentNullException(nameof(musicRepository));
        }
        public async Task<MusicResponse> Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
        {
            var deleteMusic = await _musicRepository.FindMusicById(request.Id);
            if (deleteMusic != null)
            {
                await _musicRepository.DeleteAsync(deleteMusic);
                return MusicMapper.Mapper.Map<MusicResponse>(deleteMusic);
            }

            throw new NotImplementedException();
        }
    }
}
