using Microsoft.EntityFrameworkCore;
using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Infrastructure.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Music.Domain.Entities.Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public MusicDbContext(DbContextOptions<MusicDbContext> options ) : base(options)
        {

        }
    }
}
