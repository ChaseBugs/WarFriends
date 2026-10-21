namespace War.BattleServer.Transport.Control;

public static class WorkerControlPolicy
{
    public const int MaximumBodyBytes = 65536;
    public const int ReconnectBodyBytes = 1024;
    public const int CancellationBodyBytes = 256;
    public const int ResultPollBodyBytes = 16;
    public const int ResultReferenceBodyBytes = 256;
    public const string MatchDomain = "war/match/control/v1/";
    public const string ResultPollDomain = "war/result/poll/v1/";
    public const string ResultFindDomain = "war/result/find/v1/";
    public const string ResultAckDomain = "war/result/ack/v1/";
}
