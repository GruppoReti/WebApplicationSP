namespace Kentor.AuthServices.Internal
{
    static class StringHelpers
    {
        public static string NullIfEmpty(this string source)
        {
            if(string.IsNullOrEmpty(source))
            {
                return null;
            }

            return source;
        }
    }
}
