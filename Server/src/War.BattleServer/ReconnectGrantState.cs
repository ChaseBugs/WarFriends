namespace War.BattleServer;

public sealed class ReconnectGrantState
{
    private static readonly System.Text.RegularExpressions.Regex GrantPattern =
        new(@"\A[a-f0-9]{32}\z", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.CultureInvariant);
    private string? active;
    private string? player;
    private ulong expiry;
    public string Issue(ulong now,ulong lifetime=3600)
    {
        if(now>10_000_000||lifetime is <1 or >100_000)throw new InvalidDataException("Invalid reconnect grant lifetime.");
        player=null;
        active=Guid.NewGuid().ToString("N");expiry=checked(now+lifetime);return active;
    }
    public string Issue(string playerId,ulong now,ulong lifetime=3600)
    {
        if(!Guid.TryParseExact(playerId,"N",out _))throw new InvalidDataException("Invalid reconnect player.");
        var grant=Issue(now,lifetime);player=playerId;return grant;
    }
    public bool Validate(string grant,ulong now)
        =>grant!=null&&GrantPattern.IsMatch(grant)&&active!=null&&
          System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(
              System.Text.Encoding.ASCII.GetBytes(grant), System.Text.Encoding.ASCII.GetBytes(active))&&now<=expiry;
    public bool Validate(string playerId,string grant,ulong now)
        =>Guid.TryParseExact(playerId,"N",out _)&&player==playerId&&Validate(grant,now);
    public void Revoke(){active=null;player=null;expiry=0;}
}
