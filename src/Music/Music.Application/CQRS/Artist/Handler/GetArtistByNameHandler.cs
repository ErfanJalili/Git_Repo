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
    public class GetArtistByNameHandler : IRequestHandler<GetArtistByNameQuery, ArtistResponse>
    {
        private readonly IArtistRepository _artistRepository;
        public GetArtistByNameHandler(IArtistRepository artistRepository)
        {
            _artistRepository=artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
        }
        public async Task<ArtistResponse> Handle(GetArtistByNameQuery request, CancellationToken cancellationToken)
        {
           var artist = await _artistRepository.GetArtistByName(request.UserName);

           var result = ArtistMapper.Mapper.Map<ArtistResponse>(artist);

           return result;
        }
    }
}
