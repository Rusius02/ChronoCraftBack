﻿using Application.UseCases.User.dto;
using Application.Utils;
using Infrastructure.SqlServer.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User
{
    public class UseCaseModifyUser
    {
        //Initialization of our repository
        private readonly IUserRepository _userRepository;
        public UseCaseModifyUser(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        /*Method that will modify an User using an InputDTO given to it as an argument
        and that will return a boolean to tell us if it has been modified*/
        public bool Execute(InputDtoUpdateUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);
            var userFromDB = _userRepository.Update(userFromDto);
            return Mapper.GetInstance().Map<bool>(userFromDB);
        }
    }
}
