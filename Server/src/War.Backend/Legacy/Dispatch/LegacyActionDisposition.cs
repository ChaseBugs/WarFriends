namespace War.Backend.Legacy.Dispatch;

/// <summary>Separates HTTP admission from the nested RequestBuffer protocol.</summary>
public enum LegacyActionDisposition
{
    Anonymous,
    Authenticated,
    BufferedOnly,
    Closed
}
