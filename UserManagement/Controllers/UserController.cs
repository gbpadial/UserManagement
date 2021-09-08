using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Domain.Commands.Users.CreateUser;
using UserManagement.Domain.Commands.Users.DeleteUser;
using UserManagement.Domain.Commands.Users.UpdateUser;
using UserManagement.Domain.Queries.Users.GetAllUsers;
using UserManagement.Domain.Queries.Users.GetUserByEmail;
using UserManagement.Domain.Validations.Users;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices]IMediator mediator, [FromBody]GetAllUsersRequest command)
        {
            GetAllUsersResponse result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getbyemail")]
        public async Task<IActionResult> GetByEmail([FromServices] IMediator mediator, [FromBody]GetUserByEmailRequest command)
        {
            GetUserByEmailResponse result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IMediator mediator, [FromBody]CreateUserRequest command)
        {
            CreateUserResponse result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator, [FromBody] DeleteUserRequest command)
        {
            DeleteUserResponse result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IMediator mediator, [FromBody]UpdateUserRequest command)
        {
            UpdateUserResponse result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
