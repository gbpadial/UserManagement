using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Commands.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public string Email { get; set; }
    }
}
