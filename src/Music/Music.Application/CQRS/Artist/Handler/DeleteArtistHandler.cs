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
    public class DeleteArtistHandler : IRequestHandler<DeleteArtistCommand, ArtistResponse>
    {

        private readonly IArtistRepository _artistRepository;

        public DeleteArtistHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<ArtistResponse> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var deleteArtist = await _artistRepository.FindArtistByIdAsync(request.Id);

            if (deleteArtist != null) 
            {
                await _artistRepository.DeleteAsync(deleteArtist);
                var result = Mapper.ArtistMapper.Mapper.Map<ArtistResponse>(deleteArtist);
                return  result;
            }

            throw new NotImplementedException();
        }
    }
}
