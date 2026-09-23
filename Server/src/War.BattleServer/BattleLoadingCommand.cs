namespace War.BattleServer;

public enum BattleLoadingCommandKind { Admit, Ready, Cancel }
public readonly record struct BattleLoadingCommand(BattleLoadingCommandKind Kind,string PlayerId,string ManifestHash,string Reason);

public static class BattleLoadingCommandValidator
{
    private static readonly System.Text.RegularExpressions.Regex ManifestPattern = new(@"\A[0-9a-f]{64}\z", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.CultureInvariant);
    public static void Validate(BattleLoadingCommand command)
    {
        if(!Guid.TryParseExact(command.PlayerId,"N",out _))throw new InvalidDataException("Invalid loading command player.");
        if(command.Kind==BattleLoadingCommandKind.Ready&&!ManifestPattern.IsMatch(command.ManifestHash??""))
            throw new InvalidDataException("Invalid loading command manifest.");
        if(command.Kind==BattleLoadingCommandKind.Cancel&&(string.IsNullOrWhiteSpace(command.Reason)||command.Reason.Length>64))
            throw new InvalidDataException("Invalid loading cancellation reason.");
    }
}
