using System.Net;

namespace UserManagement.Domain.Errors;

public record ErrorDetails(HttpStatusCode StatusCode, string Message);
