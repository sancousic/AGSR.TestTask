namespace AGSR.Patients.Constants
{
    public static class Prefixes
    {
        public const string Equals = "eq";

        public const string NotEquals = "ne";

        public const string GreaterThan = "gt";

        public const string GreaterOrEqueal = "ge";

        public const string LessThan = "lt";

        public const string LessOrEqual = "le";

        public const string StartAfter = "sa";

        public const string EndsBefore = "eb";

        public const string ApproximatelySame = "ap";

        public static IEnumerable<string> ValidPrefixes
            = new[]
            {
                Equals,
                NotEquals,
                GreaterThan,
                LessThan,
                StartAfter,
                GreaterOrEqueal,
                LessOrEqual,
                ApproximatelySame,
                EndsBefore,
            };
    }
}
