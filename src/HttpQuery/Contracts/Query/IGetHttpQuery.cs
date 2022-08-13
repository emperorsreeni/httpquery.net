using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpQuery.Contracts.Query
{
    public interface IGetHttpQuery : IHttpQuery
    {
        IHttpQuery Get();
        IHttpQuery Fetch();
        IHttpQuery Read();
    }
}
