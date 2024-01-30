using Application.UseCases.Chrono.dto;
using Application.UseCases.User;
using Application.UseCases.User.dto;
using Infrastructure.SqlServer.Repository.User;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly UseCaseCreateUser _useCaseCreateUser;

        public UserController(UseCaseCreateUser useCaseCreateUser, IJwtAuthentificationManager jwtAuthentificationManager)
        {
            _useCaseCreateUser = useCaseCreateUser;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<OutputDtoCreateUser> Create([FromBody] InputDtoCreateUser user)
        {
            /*We call the Execute method of our UseCase and give it a Dto.
             And it will return an OutputDto of Comment.
            And we return the code 201 to notify that the request has been made*/
            return StatusCode(201, _useCaseCreateUser.Execute(user));
        }
    }
}
