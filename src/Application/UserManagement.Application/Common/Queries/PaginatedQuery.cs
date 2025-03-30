using MediatR;

namespace UserManagement.Application.Common.Queries;

public abstract record PaginatedQuery<TResponse>(int Page, int Size)
    : IRequest<TResponse>;