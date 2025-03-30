using System;

namespace UserManagement.Infra.Common.Exceptions;

public class InfraException(string message) : Exception(message)
{
}
