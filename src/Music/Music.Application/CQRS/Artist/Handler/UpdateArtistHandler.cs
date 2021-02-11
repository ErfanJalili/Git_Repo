using MediatR;
using Music.Application.CQRS.Artist.Command;
using Music.Application.CQRS.Artist.Response;
using Music.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Application.CQRS.Artist.Handler
{
    public class UpdateArtistHandler : IRequestHandler<UpdateArtistCommand, ArtistResponse>
    {
        private readonly IArtistRepository _artistRepository;

        public UpdateArtistHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<ArtistResponse> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var updateArtist = await _artistRepository.FindArtistByIdAsync(request.Id);
            if (updateArtist != null) 
            {
                updateArtist.Name = request.Name;
                await _artistRepository.UpdateAsync(updateArtist);
                var result = Mapper.ArtistMapper.Mapper.Map<ArtistResponse>(updateArtist);
                return result;
            }
            throw new NotImplementedException();
        }
    }
}
