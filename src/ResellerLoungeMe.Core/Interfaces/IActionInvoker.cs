using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Interfaces
{
    public interface IActionInvoker
    {
        Task<HttpResponseMessage> InvokeAsync(Func<Task<HttpResponseMessage>> function,  params object[] args);
    }
}
