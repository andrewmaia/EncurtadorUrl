using System;
using AutoMapper;
using EncurtadorUrl.Models;
using EncurtadorUrl.DTOS;

namespace Innovativo
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Url,StatsDTO>()
                .ForMember(dto =>dto.Url,m=> m.MapFrom(model=>model.FullUrl));
        }
    }
}


