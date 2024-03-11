namespace AGSR.Patients.Constants;

public static class Prefixes
{
    public const string EqualsPrefix = "eq";

    public const string NotEqualsPrefix = "ne";

    public const string GreaterThanPrefix = "gt";

    public const string GreaterOrEqualsPrefix = "ge";

    public const string LessThanPrefix = "lt";

    public const string LessOrEqualPrefix = "le";

    public const string StartAfterPrefix = "sa";

    public const string EndsBeforePrefix = "eb";

    public const string ApproximatelySamePrefix = "ap";

    public static readonly IEnumerable<string> ValidPrefixes
        = new[]
        {
            EqualsPrefix,
            NotEqualsPrefix,
            GreaterThanPrefix,
            LessThanPrefix,
            StartAfterPrefix,
            GreaterOrEqualsPrefix,
            LessOrEqualPrefix,
            ApproximatelySamePrefix,
            EndsBeforePrefix,
        };
}