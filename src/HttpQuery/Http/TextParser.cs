using HttpQuery.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpQuery.Http
{
    public class TextParser : IHttpContentParser
    {
        public async Task<object> ParseAsync<T>(HttpContent content)
        {
            return await content.ReadAsStringAsync();
        }
    }
}
