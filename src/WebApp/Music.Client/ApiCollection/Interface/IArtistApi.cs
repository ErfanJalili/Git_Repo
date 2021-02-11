
using Music.Client.Models.Artist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.Client.ApiCollection.Interface
{
    public interface IArtistApi
    {
        Task<ArtistModel> GetArtistByName (string artistName);
        Task<ArtistModel> FindArtistByIdAsync(int id);
        Task<IEnumerable<ArtistModel>> GetAllArtistsAsync();
        Task<CreateArtistModel> AddArtist(CreateArtistModel model);
        Task<ArtistModel> UpdateArtistAsync(UpdateArtistModel model);
        Task<ArtistModel> DeleteArtistAsync(DeleteArtistModel model);
    }
}
