using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpQuery.Contracts.Query
{
    public interface IRequestBuilder
    {
        HttpRequestMessage Build();
    }
}
