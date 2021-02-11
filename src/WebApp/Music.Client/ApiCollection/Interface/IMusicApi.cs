using Music.Client.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.ApiCollection.Interface
{
    public interface IMusicApi
    {
        Task<IEnumerable<MusicModel>> GetMusicByArtistName(string userName);
        Task<IEnumerable<MusicModel>> GetAllMusicAsync();
        Task<MusicModel> FindMusicById(int id);
        Task<CreateMusicModel> AddMusic(CreateMusicModel model);
        Task<MusicModel> UpdateMusicAsync(UpdateMusicModel model);
        Task<MusicModel> DeleteMusicAsync(DeleteMusicModel model);

    }
}
