using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infrastructure.Data
{
    public class MusicDbContextSeed
    {
        public static async Task SeedAsync(MusicDbContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
                orderContext.Database.Migrate();
                //orderContext.Database.EnsureCreated();

                if (!orderContext.Artists.Any())
                {
                    orderContext.Artists.AddRange(GetPreconfiguredArtists());
                    orderContext.Musics.AddRange(GetPreconfiguredMusics());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MusicDbContextSeed>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Artist> GetPreconfiguredArtists()
        {
            return new List<Artist>()
            {
                new Artist() { Name="Tohi" },
                new Artist() {Name="Tatalo"}
            };
        }
        private static IEnumerable<Music.Domain.Entities.Music> GetPreconfiguredMusics()
        {
            return new List<Music.Domain.Entities.Music>()
            {
                new Music.Domain.Entities.Music() {Name="saghi" ,ArtistId=1},
                new Music.Domain.Entities.Music() { Name="dar vaghe",ArtistId=2}
            };
        }
    }
}
