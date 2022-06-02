using System.Net.Http.Headers;
using NotiSendDotNet.Models.Requests;
using NotiSendDotNet.Models.Responses;
using Refit;

namespace NotiSendDotNet;

//https://notisend.ru/dev/email/api/#email
[Headers("Accept: application/json", "Content-Type: application/json")]
public interface INotiSendClient
{
    [Post("/v1/email/messages")]
    Task<SendEmailResponse> SendEmail(SendEmailRequest request);

    public static INotiSendClient Create(
        string authToken,
        string host = "https://api.notisend.ru" //https://api-reserve.msndr.net
    )
    {
        if (authToken == null) throw new ArgumentNullException(nameof(authToken));
        var httpClient = new HttpClient(new AuthHeaderHandler(authToken))
        {
            BaseAddress = new Uri(host)
        };
        return RestService.For<INotiSendClient>(httpClient);
    }

    private class AuthHeaderHandler : DelegatingHandler
    {
        private readonly string _token;

        public AuthHeaderHandler(string token) : base(new HttpClientHandler())
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}