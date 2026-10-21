namespace War.LegacyContract.Tests.Recovered;

internal sealed class BeanstalkServerManager
{
    public void SendErrorMessage(Exception error, object? value, string stack) => OracleTrace.ParseErrors++;

    public void ErrorWasReceived(DatabaseAction action) => OracleTrace.Calls.Add("error-received");
}
