using MediatR;
using Music.Application.CQRS.Artist.Command;
using Music.Application.CQRS.Artist.Mapper;
using Music.Application.CQRS.Artist.Response;
using Music.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application
{
    public class CreateArtistHandler : IRequestHandler<CreateArtistCommand, ArtistResponse>
    {
        private readonly IArtistRepository _artistRepository;
        public CreateArtistHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
        }
        public async Task<ArtistResponse> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var newArtist = ArtistMapper.Mapper.Map<Music.Domain.Entities.Artist>(request);

            var result= await _artistRepository.AddAsync(newArtist);

            var response = ArtistMapper.Mapper.Map<ArtistResponse>(result);

            return response;
        }
    }
}
