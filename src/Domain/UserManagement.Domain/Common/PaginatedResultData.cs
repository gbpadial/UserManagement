using System.Collections.Generic;

namespace UserManagement.Domain.Common;

public struct PaginatedResultData<T>(IEnumerable<T> data, int totalRecords)
{
    public IEnumerable<T> Data { get; set; } = data;
    public int TotalRecords { get; set; } = totalRecords;
}
