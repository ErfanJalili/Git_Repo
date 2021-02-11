using Music.Domain.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.Domain.Repositories
{
    public interface IMusicRepository : IRepository<Music.Domain.Entities.Music>
    {
        Task<IEnumerable<Music.Domain.Entities.Music>> GetMusicByArtistName(string userName);
        Task<IEnumerable<Music.Domain.Entities.Music>> GetAllMusicAsync();
        Task<Music.Domain.Entities.Music> FindMusicById(int id);
    }
}
