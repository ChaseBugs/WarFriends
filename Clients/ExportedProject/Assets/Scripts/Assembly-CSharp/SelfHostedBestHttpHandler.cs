using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BestHTTP;

/// <summary>Uses the Client's BestHTTP transport behind the portable protobuf Backend SDK.</summary>
internal sealed class SelfHostedBestHttpHandler : HttpMessageHandler
{
    private const int MaximumResponseBytes = 65536;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage message, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var sendGate = new object();
        var completion = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
        HTTPMethods method = message.Method == HttpMethod.Get ? HTTPMethods.Get : HTTPMethods.Post;
        if (message.Method != HttpMethod.Get && message.Method != HttpMethod.Post)
        {
            throw new NotSupportedException("The Backend SDK supports GET and POST only.");
        }
        using (var request = new HTTPRequest(message.RequestUri, method,
            (finished, response) => Complete(finished, response, completion)))
        {
            request.DisableCache = true;
            request.DisableRetry = true;
            request.IsCookiesEnabled = false;
            request.MaxRedirects = 0;
            request.Timeout = TimeSpan.FromSeconds(15);
            request.ConnectTimeout = TimeSpan.FromSeconds(15);
            CopyHeaders(message.Headers, request);
            if (message.Content != null)
            {
                request.RawData = await message.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                CopyHeaders(message.Content.Headers, request);
            }
            request.OnProgress = (active, downloaded, length) =>
            {
                if (downloaded > MaximumResponseBytes || length > MaximumResponseBytes)
                {
                    completion.TrySetException(new HttpRequestException("Backend response exceeds its size limit."));
                    active.Abort();
                }
            };
            using (cancellationToken.Register(() =>
            {
                lock (sendGate)
                {
                    completion.TrySetCanceled();
                    request.Abort();
                }
            }))
            {
                lock (sendGate)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    request.Send();
                }
                return await completion.Task.ConfigureAwait(false);
            }
        }
    }

    private static void CopyHeaders(IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers, HTTPRequest request)
    {
        foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
        {
            request.SetHeader(header.Key, string.Join(", ", header.Value));
        }
    }

    private static void Complete(HTTPRequest request, HTTPResponse response,
        TaskCompletionSource<HttpResponseMessage> completion)
    {
        if (request.State != HTTPRequestStates.Finished || response == null)
        {
            completion.TrySetException(new HttpRequestException("Backend request did not complete.", request.Exception));
            return;
        }
        byte[] bytes = response.Data ?? new byte[0];
        if (bytes.Length > MaximumResponseBytes)
        {
            completion.TrySetException(new HttpRequestException("Backend response exceeds its size limit."));
            return;
        }
        var result = new HttpResponseMessage((HttpStatusCode)response.StatusCode)
        {
            Content = new ByteArrayContent(bytes)
        };
        foreach (KeyValuePair<string, List<string>> header in response.Headers)
        {
            // BestHTTP has already removed transfer framing and decompressed the response bytes.
            if (string.Equals(header.Key, "Content-Length", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(header.Key, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(header.Key, "Content-Encoding", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            if (!result.Headers.TryAddWithoutValidation(header.Key, header.Value))
            {
                result.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
        if (!completion.TrySetResult(result))
        {
            result.Dispose();
        }
    }
}
