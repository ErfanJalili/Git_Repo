using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Repositories.Base
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> GetArtistByName(string artistName);
        Task<Artist> FindArtistByIdAsync(int id);
        Task<IEnumerable< Artist>> GetAllArtistsAsync();
    }
}
