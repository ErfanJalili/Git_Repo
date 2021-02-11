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
    public class GetAllArtistHandler : IRequestHandler<GetAllArtistQuery, IEnumerable<ArtistResponse>>
    {
        private readonly IArtistRepository _artistRepository;

        public GetAllArtistHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<ArtistResponse>> Handle(GetAllArtistQuery request, CancellationToken cancellationToken)
        {
            var allArtists = await _artistRepository.GetAllArtistsAsync();

            var result= ArtistMapper.Mapper.Map<IEnumerable<ArtistResponse>>(allArtists);

            return result ;
        }
    }
}
