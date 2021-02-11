using MediatR;
using Music.Application.CQRS.Artist.Mapper;
using Music.Application.CQRS.Artist.Query;
using Music.Application.CQRS.Artist.Response;
using Music.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application.CQRS.Artist.Handler
{
    public class GetArtistByIdHandler : IRequestHandler<GetArtistByIdQuery, ArtistResponse>
    {
        private readonly IArtistRepository _artistRepository;
        public GetArtistByIdHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
        }

        public async Task<ArtistResponse> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            var artist = await _artistRepository.FindArtistByIdAsync(request.Id);
            var response = ArtistMapper.Mapper.Map<ArtistResponse>(artist);
            return response;
        }
    }
}
