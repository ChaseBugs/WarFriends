using System.Numerics;

namespace War.BattleServer;

public sealed record ClientBattleEvent(ulong Sequence,string Kind,ulong EntityId,Vector3 Position);

public static class ClientBattleEventValidator
{
    public static void Validate(ClientBattleEvent eventData)
    {
        if(eventData==null||eventData.Sequence==0||eventData.Sequence>10_000_000||
           string.IsNullOrWhiteSpace(eventData.Kind)||eventData.Kind.Length>64||eventData.EntityId==0||
           !PlayerHitbox.Finite(eventData.Position))throw new InvalidDataException("Invalid Client battle event.");
        if (!(eventData.Kind.StartsWith("spawn:",StringComparison.Ordinal) ||
              eventData.Kind.StartsWith("despawn:",StringComparison.Ordinal) ||
              eventData.Kind.StartsWith("objective:",StringComparison.Ordinal) ||
              eventData.Kind.StartsWith("effect:",StringComparison.Ordinal) ||
              eventData.Kind is "spawn" or "despawn" or "objective" or "effect" or "shot" or "impact" or "death" or "terminal" or "overtime"))
            throw new InvalidDataException("Unsupported Client battle event kind.");
    }
}
