//using FluentHttpClient.Http;
using System.Globalization;
using System.Net;

namespace HttpQuery.Http
{
    public class CookieParser
    {
        string header;
        int position;
        int length;

        public CookieParser(string header) : this(header, 0)
        {
        }

        public CookieParser(string header, int position)
        {
            this.header = header;
            this.position = position;
            length = header.Length;
        }

        public IEnumerable<Cookie> Parse()
        {
            while (position < length)
            {
                Cookie cookie;
                try
                {
                    cookie = DoParse();
                }
                catch
                {
                    while (position < length && header[position] != ',')
                        position++;
                    position++;
                    continue;
                }
                yield return cookie;
            }
        }

        Cookie DoParse()
        {
            var name = GetCookieName();
            if (position >= length)
                return new Cookie(name, string.Empty);

            var value = string.Empty;
            if (header[position] == '=')
            {
                position++;
                value = GetCookieValue();
            }

            var cookie = new Cookie(name, value);

            if (position >= length)
            {
                return cookie;
            }
            else if (header[position] == ',')
            {
                position++;
                return cookie;
            }
            else if (header[position++] != ';' || position >= length)
            {
                return cookie;
            }

            while (position < length)
            {
                var argName = GetCookieName();
                string argVal = string.Empty;
                if (position < length && header[position] == '=')
                {
                    position++;
                    argVal = GetCookieValue();
                }
                ProcessArg(cookie, argName, argVal);

                if (position >= length)
                    break;
                if (header[position] == ',')
                {
                    position++;
                    break;
                }
                else if (header[position] != ';')
                {
                    break;
                }

                position++;
            }

            return cookie;
        }

        void ProcessArg(Cookie cookie, string name, string val)
        {
            if (name == null || name == string.Empty)
                throw new InvalidOperationException();

            name = name.ToUpper();
            switch (name)
            {
                case "COMMENT":
                    if (cookie.Comment == null)
                        cookie.Comment = val;
                    break;
                case "COMMENTURL":
                    if (cookie.CommentUri == null)
                        cookie.CommentUri = new Uri(val);
                    break;
                case "DISCARD":
                    cookie.Discard = true;
                    break;
                case "DOMAIN":
                    if (cookie.Domain == "")
                        cookie.Domain = val;
                    break;
                case "HTTPONLY":
                    cookie.HttpOnly = true;
                    break;
                case "MAX-AGE": // RFC Style Set-Cookie2
                    if (cookie.Expires == DateTime.MinValue)
                    {
                        try
                        {
                            cookie.Expires = cookie.TimeStamp.AddSeconds(uint.Parse(val));
                        }
                        catch { }
                    }
                    break;
                case "EXPIRES": // Netscape Style Set-Cookie
                    if (cookie.Expires != DateTime.MinValue)
                        break;

                    if (position < length && header[position] == ',' && IsWeekDay(val))
                    {
                        position++;
                        val = val + ", " + GetCookieValue();
                    }

                    cookie.Expires = TryParseCookieExpires(val);
                    break;
                case "PATH":
                    cookie.Path = val;
                    break;
                case "PORT":
                    if (cookie.Port == null)
                        cookie.Port = val;
                    break;
                case "SECURE":
                    cookie.Secure = true;
                    break;
                case "VERSION":
                    try
                    {
                        cookie.Version = (int)uint.Parse(val);
                    }
                    catch { }
                    break;
            }
        }

        string GetCookieName()
        {
            int k = position;
            while (k < length && char.IsWhiteSpace(header[k]))
                k++;

            int begin = k;
            while (k < length && header[k] != ';' && header[k] != ',' && header[k] != '=')
                k++;

            position = k;
            return header.Substring(begin, k - begin).Trim();
        }

        string GetCookieValue()
        {
            if (position >= length)
                return null;

            int k = position;
            while (k < length && char.IsWhiteSpace(header[k]))
                k++;

            int begin;
            if (header[k] == '"')
            {
                int j;
                begin = k++;

                while (k < length && header[k] != '"')
                    k++;

                for (j = ++k; j < length && header[j] != ';' && header[j] != ','; j++)
                    ;
                position = j;
            }
            else
            {
                begin = k;
                while (k < length && header[k] != ';' && header[k] != ',')
                    k++;
                position = k;
            }

            return header.Substring(begin, k - begin).Trim();
        }

        static bool IsWeekDay(string value)
        {
            foreach (string day in weekDays)
            {
                if (value.ToLower().Equals(day))
                    return true;
            }
            return false;
        }

        static string[] weekDays =
            new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun",
                       "monday", "tuesday", "wednesday", "thursday",
                       "friday", "saturday", "sunday" };

        static string[] cookieExpiresFormats =
            new string[] { "r",
                    "ddd, dd'-'MMM'-'yyyy HH':'mm':'ss 'GMT'",
                    "ddd, dd'-'MMM'-'yy HH':'mm':'ss 'GMT'" };

        static DateTime TryParseCookieExpires(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DateTime.MinValue;

            for (int i = 0; i < cookieExpiresFormats.Length; i++)
            {
                try
                {
                    DateTime cookieExpiresUtc = DateTime.ParseExact(value, cookieExpiresFormats[i], CultureInfo.InvariantCulture);

                    //convert UTC/GMT time to local time
                    cookieExpiresUtc = DateTime.SpecifyKind(cookieExpiresUtc, DateTimeKind.Utc);
                    return TimeZone.CurrentTimeZone.ToLocalTime(cookieExpiresUtc);
                }
                catch { }
            }

            //If we can't parse Expires, use cookie as session cookie (expires is DateTime.MinValue)
            return DateTime.MinValue;
        }
    }
}
