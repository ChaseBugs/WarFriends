using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Google.Protobuf;
using War.Protocol;

namespace War.Client
{
    // Portable .NET Standard 2.0; no Unity or Photon dependency.
    public sealed class BackendClient : IDisposable
    {
        private readonly HttpClient http;
        public BackendClient(Uri endpoint, bool allowLocalHttp = false)
            : this(endpoint, new HttpClientHandler(), allowLocalHttp) { }
        public BackendClient(Uri endpoint, HttpMessageHandler handler, bool allowLocalHttp = false)
        {
            if (endpoint.Scheme != "https" && !(allowLocalHttp && endpoint.Scheme == "http" && endpoint.IsLoopback))
                throw new ArgumentException("HTTPS required, except explicitly enabled loopback development.");
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            http = new HttpClient(handler) { BaseAddress = endpoint, Timeout = TimeSpan.FromSeconds(15), MaxResponseContentBufferSize = 65536 };
        }
        public Task<AccountSession> RegisterAsync(RegisterRequest request, CancellationToken ct) => Send("v1/accounts/register", request, null, AccountSession.Parser, ct);
        public Task<AccountSession> LoginAsync(LoginRequest request, CancellationToken ct) => Send("v1/accounts/login", request, null, AccountSession.Parser, ct);
        public Task<PlayerProfile> PlayerAsync(string token, CancellationToken ct) => Send("v1/player", null, token, PlayerProfile.Parser, ct);
        public Task<ConnectionGrant> ConnectAsync(string token, CancellationToken ct) => Send("v1/network/connect", new ConnectionRequest { Protocol = "war.v1" }, token, ConnectionGrant.Parser, ct);
        public Task<MatchConnectionGrant> MatchGrantAsync(string matchId, string token, CancellationToken ct) => Send("v1/battle/grant", new MatchGrantRequest { MatchId = matchId }, token, MatchConnectionGrant.Parser, ct);
        public Task<MatchQueueReply> JoinMatchQueueAsync(string token, CancellationToken ct) => Send("v1/battle/queue/join", new MatchQueueRequest(), token, MatchQueueReply.Parser, ct);
        public Task<MatchQueueReply> CancelMatchQueueAsync(string token, CancellationToken ct) => Send("v1/battle/queue/cancel", new MatchQueueRequest(), token, MatchQueueReply.Parser, ct);
        public async Task<MatchConnectionGrant> FindMatchAsync(string token, TimeSpan timeout, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(token) || timeout < TimeSpan.FromSeconds(5) || timeout > TimeSpan.FromMinutes(5))
                throw new ArgumentException("Matchmaking requires a token and a 5-second to 5-minute timeout.");
            using (var deadline = CancellationTokenSource.CreateLinkedTokenSource(ct))
            {
                deadline.CancelAfter(timeout);
                while (true)
                {
                    var reply = await JoinMatchQueueAsync(token, deadline.Token).ConfigureAwait(false);
                    if (reply.Code == "waiting")
                    {
                        if (reply.MatchId.Length != 0 || reply.PlayerIds.Count != 0)
                            throw new InvalidOperationException("Backend returned invalid waiting matchmaking authority.");
                        await Task.Delay(500, deadline.Token).ConfigureAwait(false);
                        continue;
                    }
                    if (reply.Code != "paired" ||
                        !System.Text.RegularExpressions.Regex.IsMatch(reply.MatchId ?? "", @"\Am[0-9a-f]{32}\z") ||
                        reply.PlayerIds.Count != 2 || reply.PlayerIds.Distinct(StringComparer.Ordinal).Count() != 2 ||
                        reply.PlayerIds.Any(x => !Guid.TryParseExact(x, "N", out _) || x != x.ToLowerInvariant()))
                        throw new InvalidOperationException("Backend returned invalid paired matchmaking authority.");
                    var grant = await MatchGrantAsync(reply.MatchId, token, deadline.Token).ConfigureAwait(false);
                    if (grant.MatchId != reply.MatchId || !reply.PlayerIds.Contains(grant.PlayerId) || grant.SessionKey.Length != 32 || grant.SessionId == 0)
                        throw new InvalidOperationException("Backend returned a grant outside the paired roster.");
                    var views=BattlePlayerViewProjection.Validate(grant);
                    if(!views.Select(x=>x.PlayerId).SequenceEqual(reply.PlayerIds,StringComparer.Ordinal))
                        throw new InvalidOperationException("Backend returned player views outside the paired roster order.");
                    return grant;
                }
            }
        }
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
