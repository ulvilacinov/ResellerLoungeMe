using ResellerLoungeMe.Core.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Utilities
{
    public class ActionInvoker : IActionInvoker
    {
        public async Task<HttpResponseMessage> Invoke(Func<Task<HttpResponseMessage>> function, params object[] args)
        {
            HttpResponseMessage result;
            result =await function.Invoke();
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
