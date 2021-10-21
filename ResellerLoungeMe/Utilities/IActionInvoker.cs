using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Utilities
{
    public interface IActionInvoker
    {
        HttpResponseMessage Invoke(Func<HttpResponseMessage> function,  params object[] args);
    }
}
