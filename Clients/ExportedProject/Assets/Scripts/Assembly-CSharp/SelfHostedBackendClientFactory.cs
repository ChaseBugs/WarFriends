using System;
using BestHTTP;
using War.Client;

/// <summary>Creates Backend clients on the Unity thread with one explicit HTTP transport choice.</summary>
public static class SelfHostedBackendClientFactory
{
    public static BackendClient Create(Uri endpoint, bool allowLoopbackHttp)
    {
        // BestHTTP creates its update component here, before SDK continuations use worker threads.
        HTTPManager.Setup();
        if (!HTTPUpdateDelegator.IsCreated)
        {
            throw new InvalidOperationException("Initialize Backend transport on the Unity thread.");
        }
        var handler = new SelfHostedBestHttpHandler();
        try
        {
            return new BackendClient(endpoint, handler, allowLoopbackHttp);
        }
        catch
        {
            handler.Dispose();
            throw;
        }
    }
}
