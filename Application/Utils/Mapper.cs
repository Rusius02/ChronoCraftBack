
using Application.UseCases.Chrono.dto;
using Application.UseCases.User.dto;
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
                        
                        //Users
                        cfg.CreateMap<InputDtoCreateUser, User>();
                        cfg.CreateMap<User, OutputDtoCreateUser>();
                        
                        //Sport
                        cfg.CreateMap<Plan, OutputPlanDto>();
                        cfg.CreateMap<InputPlanDto, Plan>();
                    

            });
            return new AutoMapper.Mapper(config);
        }
    }
}