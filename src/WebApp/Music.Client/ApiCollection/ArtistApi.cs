using Music.Client.ApiCollection.Infrastructure;
using Music.Client.ApiCollection.Interface;
using Music.Client.Models.Artist;
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
    public class ArtistApi : BaseHttpClientWithFactory, IArtistApi
    {
        private readonly IApiSettings _settings;

        public ArtistApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            _settings = settings;
        }

        public async Task<CreateArtistModel> AddArtist(CreateArtistModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.ArtistPath)
                            .AddToPath("create")
                            .HttpMethod(HttpMethod.Post)
                            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<CreateArtistModel>(message);
        }

        public async Task<ArtistModel> DeleteArtistAsync(DeleteArtistModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                          .SetPath(_settings.ArtistPath)
                          .AddToPath("delete")
                          .HttpMethod(HttpMethod.Delete)
                          .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<ArtistModel>(message);
        }

        public async Task<ArtistModel> FindArtistByIdAsync(int id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                              .SetPath(_settings.ArtistPath)
                              .AddToPath("ById")
                              .AddToPath(id.ToString())
                              .HttpMethod(HttpMethod.Get)
                              .GetHttpMessage();

            return await SendRequest<ArtistModel>(message);
        }

        public async Task<IEnumerable<ArtistModel>> GetAllArtistsAsync()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                             .SetPath(_settings.ArtistPath)
                             .HttpMethod(HttpMethod.Get)
                             .GetHttpMessage();

            return await SendRequest<IEnumerable<ArtistModel>>(message);
        }

        public async Task<ArtistModel> GetArtistByName(string artistName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                              .SetPath(_settings.ArtistPath)
                              .AddQueryString("userName",artistName)
                              .HttpMethod(HttpMethod.Get)
                              .GetHttpMessage();

            return await SendRequest<ArtistModel>(message);
        }

        public async Task<ArtistModel> UpdateArtistAsync(UpdateArtistModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.ArtistPath)
                            .AddToPath("Edit")
                            .HttpMethod(HttpMethod.Put)
                            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<ArtistModel>(message);
        }
    }
}
