using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResellerLoungeMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Utilities
{
    public class ActionInvoker : IActionInvoker
    {
        public HttpResponseMessage Invoke(Func<HttpResponseMessage> function, params object[] args)
        {
            HttpResponseMessage result;
            result = function.Invoke();
            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return result;
                default:
                    throw new Exception(result.Content.ReadAsStringAsync().Result);
            }
        }


    }
}
