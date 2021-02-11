using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Music.Application;
using Music.Application.Common.PipelineBehaviours;
using Music.Application.CQRS.Artist.Command;
using Music.Application.CQRS.Music.Command;
using Music.Domain.Repositories;
using Music.Domain.Repositories.Base;
using Music.Infrastructure.Data;
using Music.Infrastructure.Repository;
using Music.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Music.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region SqlServer Dependencies

            //// use in-memory database
            //services.AddDbContext<OrderContext>(c =>
            //    c.UseInMemoryDatabase("OrderConnection"));

            // use real database
            services.AddDbContext<MusicDbContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("MusicConnection")), ServiceLifetime.Singleton); // we made singleton this in order to resolve in mediatR when consuming Rabbit

            #endregion

            #region Project Dependencies

            // Add Infrastructure Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IMusicRepository), typeof(MusicRepository));
            services.AddScoped(typeof(IArtistRepository), typeof(ArtistRepository));
            services.AddTransient<IMusicRepository, MusicRepository>(); // we made transient this in order to resolve in mediatR when consuming Rabbit

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add MediatR
            services.AddMediatR(typeof(CreateMusicCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateMusicCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteMusicCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateArtistCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateArtistCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteArtistCommand).GetTypeInfo().Assembly);

            //Domain Level Validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Music.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
