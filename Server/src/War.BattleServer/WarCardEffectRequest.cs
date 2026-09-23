using System.Numerics;

namespace War.BattleServer;

public readonly record struct WarCardEffectRequest(string CardId,Vector3 Target,float DurationSeconds,int Parameter);

public static class WarCardEffectRequestValidator
{
    public static WarCardEffectDefinition Validate(WarCardEffectRequest request)
    {
        if(!WarCardEffectCatalog.TryGet(request.CardId,out var definition)||!PlayerHitbox.Finite(request.Target)||
           !float.IsFinite(request.DurationSeconds)||request.DurationSeconds<0||request.DurationSeconds>600||
           request.Parameter<0||request.Parameter>100000||
           definition.Kind is WarCardEffectKind.Damage or WarCardEffectKind.Heal or WarCardEffectKind.Shield && request.Parameter<1||
           definition.Kind is WarCardEffectKind.Status or WarCardEffectKind.Modifier && request.DurationSeconds<=0||
           definition.RequiresTarget&&request.Target==Vector3.Zero)
            throw new InvalidDataException("Invalid War Card effect request.");
        return definition;
    }
}
