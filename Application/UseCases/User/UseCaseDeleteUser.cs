using Application.Utils;
using Infrastructure.SqlServer.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User
{
    public class UseCaseDeleteUser : IDelete<InputDtoUser>
    {
        private readonly IUserRepository _userRepository;
        public UseCaseDeleteUser(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        public bool Execute(InputDtoUser dto)
        {
            var activityFromDto = Mapper.GetInstance().Map<Domain.User>(dto);
            var activityFromDB = _userRepository.Delete(activityFromDto);
            return Mapper.GetInstance().Map<bool>(activityFromDB);
        }
    }
}
