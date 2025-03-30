namespace UserManagement.Application.Common.Dtos;

public abstract record PaginatedDto<T>
    where T : class
{
    public int CurrentPage { get; set; }
    public int Size { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / (double)Size);
    public IEnumerable<T> Data { get; set; } = [];
}