using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.AutoMapper
{
    class BLMapper
    {
        private static IMapper MapperInstance { get; set; } = null;

        private BLMapper()
        {
           // Prevent instantiation of this utility class
        }

        public static IMapper GetMapper()
        {
            if (MapperInstance == null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<AutoMapperProfile>();
                });
                MapperInstance = config.CreateMapper();
            }
            return MapperInstance;
        }

    }
}
