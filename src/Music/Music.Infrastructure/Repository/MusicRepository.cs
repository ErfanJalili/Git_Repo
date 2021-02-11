using Microsoft.EntityFrameworkCore;
using Music.Domain.Repositories;
using Music.Domain.Repositories.Base;
using Music.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infrastructure.Repository
{
    public class MusicRepository :Repository.Base.Repository<Music.Domain.Entities.Music> ,IMusicRepository
    {
        public MusicRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.Music> FindMusicById(int id)
        {
            var result = await _dbContext.Musics.Include(m=>m.Artist).SingleOrDefaultAsync(m => m.Id == id);
            return  result;
        }

        public async Task<IEnumerable<Domain.Entities.Music>> GetAllMusicAsync()
        {
            var result = await _dbContext.Musics.Include(m => m.Artist).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Domain.Entities.Music>> GetMusicByArtistName(string userName)
        {
          var result = await _dbContext.Musics.Include(m => m.Artist).Where(a => a.Artist.Name.Contains(userName)).ToListAsync();
            return result ;
        }

       
    }
}
