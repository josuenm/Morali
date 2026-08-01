namespace Morali.Application.Common.Results;

public record Error(
    string Message,
    Dictionary<string, IEnumerable<string>>? Details
);