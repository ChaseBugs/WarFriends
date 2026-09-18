using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using War.Protocol;

namespace War.Client
{
    // Portable .NET Standard 2.0; no Unity or Photon dependency.
    public sealed class BackendClient : IDisposable
    {
        private readonly HttpClient http;
        public BackendClient(Uri endpoint, bool allowLocalHttp = false)
        {
            if (endpoint.Scheme != "https" && !(allowLocalHttp && endpoint.Scheme == "http" && endpoint.IsLoopback))
                throw new ArgumentException("HTTPS required, except explicitly enabled loopback development.");
            http = new HttpClient { BaseAddress = endpoint, Timeout = TimeSpan.FromSeconds(15), MaxResponseContentBufferSize = 65536 };
        }
        public Task<AccountSession> RegisterAsync(RegisterRequest request, CancellationToken ct) => Send("v1/accounts/register", request, null, AccountSession.Parser, ct);
        public Task<AccountSession> LoginAsync(LoginRequest request, CancellationToken ct) => Send("v1/accounts/login", request, null, AccountSession.Parser, ct);
        public Task<PlayerProfile> PlayerAsync(string token, CancellationToken ct) => Send("v1/player", null, token, PlayerProfile.Parser, ct);
        public Task<ConnectionGrant> ConnectAsync(string token, CancellationToken ct) => Send("v1/network/connect", new ConnectionRequest { Protocol = "war.v1" }, token, ConnectionGrant.Parser, ct);
        private async Task<T> Send<T>(string path, IMessage body, string token, MessageParser<T> parser, CancellationToken ct) where T : IMessage<T>
        {
            using (var request = new HttpRequestMessage(body == null ? HttpMethod.Get : HttpMethod.Post, path))
            {
                if (body != null) { request.Content = new ByteArrayContent(body.ToByteArray()); request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf"); }
                if (token != null) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await http.SendAsync(request, ct).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode) throw new HttpRequestException("Backend status " + (int)response.StatusCode);
                    return parser.ParseFrom(await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false));
                }
            }
        }
        public void Dispose() { http.Dispose(); }
    }
}
