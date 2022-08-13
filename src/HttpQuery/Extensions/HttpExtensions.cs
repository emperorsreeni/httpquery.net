
namespace HttpQuery.Extensions
{
    public static class HttpExtensions
    {
        public static bool IsByteArray(this Type type)
        {
           return type == typeof(byte[]);
        }
    }
}
