﻿using System.Net.Http;
using System.Threading.Tasks;

namespace UserManagement.Core.Http;

public interface IHttpHandler
{
    HttpResponseMessage Get(string url);
    HttpResponseMessage Post(string url, HttpContent content);
    Task<HttpResponseMessage> GetAsync(string url);
    Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
}
