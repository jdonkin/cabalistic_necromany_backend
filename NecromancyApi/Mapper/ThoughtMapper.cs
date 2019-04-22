using AutoMapper;
using NecromancyApi.Models;
using PdqNecromancyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecromancyApi.Mapper
{
    public class ThoughtMapper : Profile
    {
        public ThoughtMapper()
        {
            CreateMap<ServiceThoughtsModel, ApiThoughtsModel>();
        }   
    }
}
