using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailRequest : IRequest<GetUserByEmailResponse>
    {
        public string Email { get; set; }
    }
}
