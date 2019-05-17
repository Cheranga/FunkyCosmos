namespace FunkyCosmos.Extensions
{
    public static class BusinessExtensions
    {
        public static bool Validate(this IValidatable validatable)
        {
            return validatable != null && validatable.IsValid();
        }
    }
}