namespace Morali.Application.Common.Results;

public record ResultValue<T>(
    bool Success,
    T? Data,
    Error? Error
);