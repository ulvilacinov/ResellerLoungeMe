﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Interfaces
{
    public interface IActionInvoker
    {
        Task<HttpResponseMessage> Invoke(Func<Task<HttpResponseMessage>> function,  params object[] args);
    }
}
