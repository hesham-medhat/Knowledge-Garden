using AutoMapper;
using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataEntities.AutoMapper
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
