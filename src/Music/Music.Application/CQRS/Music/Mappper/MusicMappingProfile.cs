using AutoMapper;
using Music.Application.CQRS.Music.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Music.Domain.Entities;
using Music.Application;

namespace Music
{
    public class MusicMappingProfile : Profile
    {
        public MusicMappingProfile()
        {
            CreateMap<Music.Domain.Entities.Music, DeleteMusicCommand>().ReverseMap();
            CreateMap<Music.Domain.Entities.Music, UpdateMusicCommand>().ReverseMap();
            CreateMap<Music.Domain.Entities.Music, CreateMusicCommand>().ReverseMap();
            CreateMap<Music.Domain.Entities.Music, MusicResponse>().ReverseMap();
            
        }
    }
}
