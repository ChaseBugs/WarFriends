using System;
using System.Threading;
using System.Threading.Tasks;
using BestHTTP;
using UnityEngine;

/// <summary>Checks the actual recovered URL builder and BestHTTP against the owned offline Backend.</summary>
public static class UnityBackendEndpointAudit
{
    private const int PollDelayMilliseconds = 50;
    private const int RequestTimeoutSeconds = 10;

    /// <summary>Requires the recovered sibling check endpoint to acknowledge through the shared process URL.</summary>
    public static async Task VerifyAsync(string backendUrl, CancellationToken cancellationToken)
    {
        Uri expected = new Uri(new Uri(backendUrl), "index_09_25_2015.php");
        Uri actual = new Uri(new BeanstalkUrlCreator().CreateUrl());
        Require(actual == expected && SelfHostedBackendEndpoint.Resolve().AbsoluteUri == backendUrl,
            "Legacy HTTP and battle SDK do not share the owned Backend endpoint.");
        Uri check = new Uri(actual, "check.php");
        var request = new HTTPRequest(check, HTTPMethods.Post);
        request.Timeout = TimeSpan.FromSeconds(RequestTimeoutSeconds);
        request.ConnectTimeout = TimeSpan.FromSeconds(RequestTimeoutSeconds);
        request.DisableRetry = true;
        request.DisableCache = true;
        try
        {
            request.Send();
            while (request.State <= HTTPRequestStates.Processing)
            {
                HTTPManager.OnUpdate();
                await Task.Delay(PollDelayMilliseconds, cancellationToken);
            }
            Require(request.Exception == null && request.Response != null &&
                request.Response.StatusCode == 200 && request.Response.DataAsText == "ok",
                "The recovered BestHTTP check did not receive the exact offline acknowledgement.");
        }
        finally
        {
            if (request.State <= HTTPRequestStates.Processing)
            {
                request.Abort();
            }
        }

        Debug.Log("UNITY_BACKEND_ENDPOINT_PASSED sharedUrl=True bestHttpCheck=True");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
