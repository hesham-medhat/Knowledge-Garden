using AutoMapper;
using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.AutoMapper
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Flower, FlowerBL>().ReverseMap();
            CreateMap<TempFile, Attachment>();
        }
    }
}
