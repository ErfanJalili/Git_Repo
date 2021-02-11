using Microsoft.EntityFrameworkCore;
using Music.Domain.Entities;
using Music.Domain.Repositories.Base;
using Music.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infrastructure.Repository
{
    public class ArtistRepository : Repository.Base.Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Artist> FindArtistByIdAsync(int id)
        {
            var artist = await _dbContext.Artists.SingleOrDefaultAsync(a => a.Id == id);

            return artist;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            var allArtists = await _dbContext.Artists.ToListAsync();
            return allArtists;
        }

        public async Task<Artist> GetArtistByName(string artistName)
        {
            var artist = await _dbContext.Artists.SingleOrDefaultAsync(a => a.Name == artistName);
           
            return artist;
        }
    }
}
