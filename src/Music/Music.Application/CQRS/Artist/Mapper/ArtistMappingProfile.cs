using AutoMapper;
using Music.Application.CQRS.Artist.Command;
using Music.Application.CQRS.Artist.Response;
using Music.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Application
{
    public class ArtistMappingProfile : Profile
    {
        public ArtistMappingProfile()
        {
            CreateMap<Artist, CreateArtistCommand>().ReverseMap();
            CreateMap<Artist, ArtistResponse>().ReverseMap();
        }
    }
}
