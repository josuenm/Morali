using System.Text.RegularExpressions;

namespace Morali.Extensions;

public class KebabCaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;

        var str = value.ToString();
        if (string.IsNullOrEmpty(str)) return str;

        return Regex.Replace(
                str,
                "([a-z0-9])([A-Z])",
                "$1-$2"
        ).ToLowerInvariant();
    }
}