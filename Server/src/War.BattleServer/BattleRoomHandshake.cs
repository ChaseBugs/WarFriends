namespace War.BattleServer;

public static class BattleRoomHandshake
{
    private static readonly System.Text.RegularExpressions.Regex MatchPattern = new(@"\A[a-zA-Z0-9_-]{1,64}\z", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.CultureInvariant);
    private static readonly System.Text.RegularExpressions.Regex ManifestPattern = new(@"\A[0-9a-f]{64}\z", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.CultureInvariant);
    public static void Validate(string matchId,string manifestHash,IReadOnlyList<string> players)
    {
        if(!MatchPattern.IsMatch(matchId??"")||
           !ManifestPattern.IsMatch(manifestHash??"")||
           players==null||players.Count!=2||players.Any(x=>!Guid.TryParseExact(x,"N",out _))||
           string.Equals(players[0],players[1],StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException("Invalid Photon-free battle room handshake.");
    }
}
