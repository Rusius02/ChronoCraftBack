
using AutoMapper;
using Domain;

namespace Application.Utils
{
    public class Mapper
    {
        private static AutoMapper.Mapper _instance;

        public static AutoMapper.Mapper GetInstance()
        {
            return _instance ??= CreateMapper();
        }

        private static AutoMapper.Mapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Source, Destination
                        
                        //Activity
                        cfg.CreateMap<InputDtoCreateActivity, Activity>();
                        cfg.CreateMap<Activity, OutputDtoCreateActivity>();
                        cfg.CreateMap<Activity, OutputDtoListActivity>();
                        cfg.CreateMap<InputDtoActivity, Activity>();
                        cfg.CreateMap<InputDtoUpdateActivity, Activity>();
                        
                        //Sport
                        cfg.CreateMap<Sport, OutputDtoListSport>();
                        cfg.CreateMap<InputDtoCreateSport, Sport>();
                        cfg.CreateMap<Sport, OutputDtoSport>();
                    

            });
            return new AutoMapper.Mapper(config);
        }
    }
}