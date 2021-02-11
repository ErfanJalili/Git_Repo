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
    public class CreateMusicHandler : IRequestHandler<CreateMusicCommand, MusicResponse>
    {
        private readonly IMusicRepository _musicRepository;
        public CreateMusicHandler(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository ?? throw new ArgumentNullException(nameof(musicRepository));
        }
        public async Task<MusicResponse> Handle(CreateMusicCommand request, CancellationToken cancellationToken)
        {

            var newMusic = MusicMapper.Mapper.Map<Music.Domain.Entities.Music>(request);

            var create = await _musicRepository.AddAsync(newMusic);

            if (create != null)
            {
                var createdMusic = MusicMapper.Mapper.Map<MusicResponse>(newMusic);

                return createdMusic;
            }
            else
            {
                 throw new ApplicationException("Entity Is Not Valid");
            
            }
           
        }
    }
}
