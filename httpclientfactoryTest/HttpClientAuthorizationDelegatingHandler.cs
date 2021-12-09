using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace httpclientfactoryTest
{
    internal class HttpClientAuthorizationDelegatingHandler
        : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccesor;

        public HttpClientAuthorizationDelegatingHandler(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccesor = httpContextAccesor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var servicekeyHeader = _httpContextAccesor.HttpContext
                .Request.Headers["Service-Key"];

            if (!string.IsNullOrEmpty(servicekeyHeader))
            {
                request.Headers.Add("Service-Key", "IlDCyCXLZ40VYvUIn4DLgHlf7GjHtqw5WSfiQtYkW4A=");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}