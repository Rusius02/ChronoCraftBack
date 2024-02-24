using Application.UseCases.Chrono.dto;
using Application.UseCases.User.dto;
using Application.Utils;
using Infrastructure.SqlServer.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User
{
    public class UseCaseCreateUser : IWriting<OutputDtoCreateUser, InputDtoCreateUser>
    {
        //Initialization of our repository
        private readonly IUserRepository _userRepository;
        public UseCaseCreateUser(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        
        public OutputDtoCreateUser Execute(InputDtoCreateUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);

            var userFromDb = _userRepository.Create(userFromDto);
            return Mapper.GetInstance().Map<OutputDtoCreateUser>(userFromDb);
        }

        
        public bool Execute(InputDtoUpdateUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);
            var userFromDB = _userRepository.Update(userFromDto);
            return Mapper.GetInstance().Map<bool>(userFromDB);
        }
    }
}
