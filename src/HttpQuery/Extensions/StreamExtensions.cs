

namespace HttpQuery.Extensions
{
    public static class StreamExtensions
    {
        public static bool IsStreamType(this Type type)
        {
            var streamType = typeof(Stream);
            return type.IsSubclassOf(streamType) || type == streamType;
        }

       
    }
}
