namespace Morali.Application.Common.Responses;

public record PaginatedResponse<T>(
    IEnumerable<T> Items,
    int Page,
    int Limit,
    int TotalPages,
    int TotalItems
);