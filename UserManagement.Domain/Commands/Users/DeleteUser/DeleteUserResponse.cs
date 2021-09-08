using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Commands.Users.DeleteUser
{
    public class DeleteUserResponse
    {
        public bool Deleted { get; set; }
    }
}
