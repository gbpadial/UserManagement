using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagement.Application.Commands.Users.DeleteUser;
using UserManagement.Application.Dtos.Users;
using UserManagement.Application.Queries.Users.GetAllUsers;
using UserManagement.Application.Queries.Users.GetUserByEmail;
using UserManagement.WebUI.Core.Controllers;
using UserManagement.WebUI.Requests.Users;

namespace UserManagement.WebUI.Controllers;

public class UserController(IMediator mediator) : BaseController
{
    /// <summary>
    /// Get all the users with page and size.
    /// </summary>
    /// <param name="page">The page to get</param>
    /// <param name="size">The size to get</param>
    [HttpGet]
    public async Task<ActionResult<GetAllUsersResponse>> GetAll([FromQuery] int page, int size)
    {
        var result = await mediator.Send(new GetAllUsersQuery(page, size));
        return Ok(result);
    }

    /// <summary>
    /// Get a user by its e-mail.
    /// </summary>
    /// <param name="email">The user's e-mail</param>
    [HttpGet("{email}")]
    public async Task<ActionResult<UserDto>> GetByEmail([FromRoute] string email)
    {
        var result = await mediator.Send(new GetUserByEmailQuery(email));
        return Ok(result);
    }

    /// <summary>
    /// Create an user with the given information.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserRequest request)
    {
        var result = await mediator.Send(request.ToCommand());
        return Ok(result);
    }

    /// <summary>
    /// Delete a user by it's Id.
    /// </summary>
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<DeleteUserDto>> Delete([FromRoute] Guid id)
    {
        var result = await mediator.Send(new DeleteUserCommand(id));
        return Ok(result);
    }

    /// <summary>
    /// Update a user with the given information.
    /// </summary>
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<UserDto>> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
    {
        var result = await mediator.Send(request.ToCommand(id));
        return Ok(result);
    }
}