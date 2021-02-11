using Music.Client.ApiCollection.Infrastructure;
using Music.Client.ApiCollection.Interface;
using Music.Client.Models.Music;
using Music.Client.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Music.Client.ApiCollection
{
    public class MusicApi : BaseHttpClientWithFactory, IMusicApi
    {
        private readonly IApiSettings _settings;

        public MusicApi(IHttpClientFactory factory, IApiSettings settings) 
            : base(factory)
        {
            _settings = settings;
        }

        public async Task<CreateMusicModel> AddMusic(CreateMusicModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                             .SetPath(_settings.MusicPath)
                             .AddToPath("create")
                             .HttpMethod(HttpMethod.Post)
                             .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<CreateMusicModel>(message);
        }

        public async Task<MusicModel> DeleteMusicAsync(DeleteMusicModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.MusicPath)
                            .AddToPath("delete")
                            .HttpMethod(HttpMethod.Delete)
                            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<MusicModel>(message);
        }

        public async Task<MusicModel> FindMusicById(int id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.MusicPath)
                               .AddToPath("ById")
                               .AddToPath(id.ToString())
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();
            return await SendRequest<MusicModel>(message);
        }

        public async Task<IEnumerable<MusicModel>> GetAllMusicAsync()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.MusicPath)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();
            var result = await SendRequest<IEnumerable<MusicModel>>(message);
            return result;
        }

        public async Task<IEnumerable<MusicModel>> GetMusicByArtistName(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.MusicPath)
                                .AddToPath("ByName")
                                .AddToPath(userName)
                                //.AddQueryString("userName", userName)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await SendRequest<IEnumerable<MusicModel>>(message);
        }

        public async Task<MusicModel> UpdateMusicAsync(UpdateMusicModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.MusicPath)
                            .AddToPath("Edit")
                            .HttpMethod(HttpMethod.Put)
                            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<MusicModel>(message);
        }
    }
}
