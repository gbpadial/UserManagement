using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Errors;

public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}
