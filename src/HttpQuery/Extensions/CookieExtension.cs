using System;
using System.Text;

namespace HttpQuery.Extensions
{
    public static class CookieExtension
    {
        private const string COMMENT = "Comment";
        private const string PATH = "Path";
        private const string DOMAIN = "Domain";
        private const string MAX_AGE = "Max-Age";
        private const string SECURE = "Secure";
        private const string HTTP_ONLY = "HttpOnly";
        private const string EXPIRES = "Expires";
        private const string SAME_SITE = "SameSite";
        private const string COOKIE_ATTRIBUTE_SEPARATOR = ";";
        private const string EQUALS = "=";

        public static StringBuilder AddValue(this StringBuilder cookieBuilder, string name, string value)
        {
            cookieBuilder.Append(name);
            if (!string.IsNullOrEmpty(value))
                cookieBuilder.Append(EQUALS)
                    .Append(value);
            return cookieBuilder;
        }
        public static StringBuilder AddComment(this StringBuilder cookieBuilder,string comment)
        {
            if (!string.IsNullOrEmpty(comment))
                cookieBuilder.AddCookieAttribute(COMMENT, comment);
               
            return cookieBuilder;
        }

        public static StringBuilder AddPath(this StringBuilder cookieBuilder, string path)
        {
            if (!string.IsNullOrEmpty(path))
                cookieBuilder.AddCookieAttribute(PATH, path);

            return cookieBuilder;
        }
        public static StringBuilder AddDomain(this StringBuilder cookieBuilder, string domain)
        {
            if (!string.IsNullOrEmpty(domain))
                cookieBuilder.AddCookieAttribute(DOMAIN, domain);

            return cookieBuilder;
        }

        public static StringBuilder AddExpiry(this StringBuilder cookieBuilder, DateTime expiry)
        {
            if (DateTime.MinValue != expiry)
            {
                cookieBuilder.AddCookieAttribute(EXPIRES, expiry.ToUniversalTime().ToString());
            }
            return cookieBuilder;
        }

        public static StringBuilder AddMaxAge(this StringBuilder cookieBuilder, long maxAge)
        {
            if (maxAge != -1)
                cookieBuilder.AddCookieAttribute(MAX_AGE, maxAge.ToString());

            return cookieBuilder;
        }

        public static StringBuilder AddSecure(this StringBuilder cookieBuilder, bool isSecure)
        {
            if (isSecure)
                cookieBuilder.Append(COOKIE_ATTRIBUTE_SEPARATOR)
                    .Append(SECURE);

            return cookieBuilder;
        }
        public static StringBuilder AddHttpOnly(this StringBuilder cookieBuilder, bool isHttpOnly)
        {
            if (isHttpOnly)
                cookieBuilder.Append(COOKIE_ATTRIBUTE_SEPARATOR)
                    .Append(HTTP_ONLY);

            return cookieBuilder;
        }

        public static StringBuilder AddSameSite(this StringBuilder cookieBuilder, string sameSite)
        {
            if (!string.IsNullOrEmpty(sameSite))
                cookieBuilder.AddCookieAttribute(SAME_SITE, sameSite);

            return cookieBuilder;
        }

        private static void AddCookieAttribute(this StringBuilder cookieBuilder, string name,string value)
        {
            cookieBuilder.Append(COOKIE_ATTRIBUTE_SEPARATOR)
                      .Append(name)
                      .Append(EQUALS)
                      .Append(value);
        }
    }
}
