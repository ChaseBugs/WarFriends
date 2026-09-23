namespace War.BattleServer;

internal sealed record BarrelMutation(int ColliderIndex,int GameObjectFileId,float Health,float MaxHealth,
    bool Destroyed,uint Revision);

/// <summary>Scene-master-authored barrel instances, initially inert until explosion authority is live.</summary>
internal sealed class BarrelMatchSimulation
{
    private sealed record Entry(BarrelSceneBinding Binding,BarrelLifecycle Lifecycle);
    private readonly Dictionary<int,Entry> byCollider;
    private readonly RecoveredBattleMap map;
    private readonly BarrelOverlapOrderCatalog overlap;
    internal int SceneMasterLevel { get; }
    internal BarrelMatchSimulation(RecoveredBattleMap map,BarrelSceneCatalog catalog,
        BarrelSourcePolicy policy,BarrelOverlapOrderCatalog overlap,MatchManifest manifest)
    {
        this.map=map;this.overlap=overlap;
        if(manifest.SceneMasterPlayerId==null)throw new InvalidDataException("Missing scene master.");
        var master=manifest.Players.Single(p=>p.PlayerId==manifest.SceneMasterPlayerId);
        SceneMasterLevel=master.PlayerLevel ?? throw new InvalidDataException("Missing scene-master level.");
        byCollider=catalog.ForMap(map).ToDictionary(b=>b.ColliderIndex,
            b=>new Entry(b,new BarrelLifecycle(policy,SceneMasterLevel,b)));
    }
    internal IReadOnlyList<BarrelMutation> Snapshot()=>Array.AsReadOnly(byCollider.Values
        .OrderBy(e=>e.Binding.ColliderIndex)
        .Select(e=>new BarrelMutation(e.Binding.ColliderIndex,e.Binding.GameObjectFileId,
            e.Lifecycle.Health,e.Lifecycle.MaxHealth,e.Lifecycle.Destroyed,e.Lifecycle.Revision)).ToArray());
    internal bool ColliderEnabled(int colliderIndex)=>!byCollider.TryGetValue(colliderIndex,out var entry) ||
        !entry.Lifecycle.Destroyed;
    internal bool Contains(int colliderIndex)=>byCollider.ContainsKey(colliderIndex);
    internal int RuntimeLayer(int colliderIndex,int serializedLayer)=>
        byCollider.ContainsKey(colliderIndex) ? 8 : serializedLayer;
    internal IReadOnlyList<int> ExplosionTargets(int barrelColliderIndex)=>
        overlap.Targets(map,barrelColliderIndex);
    internal int MaximumEventsPerProjectile=>
        4+byCollider.Keys.Sum(index=>overlap.Targets(map,index).Count)+2*byCollider.Count;
    internal BarrelChainPlan PreviewShotChain(int barrelColliderIndex,float confirmedDamage)=>
        BarrelChainPlanner.Plan(map,overlap,Snapshot(),barrelColliderIndex,confirmedDamage);
    internal BarrelChainPlan PreviewDamageChain(int barrelColliderIndex,float confirmedDamage,BarrelChainCause cause)=>
        BarrelChainPlanner.Plan(map,overlap,Snapshot(),barrelColliderIndex,confirmedDamage,cause);
    // Recompute against current authority so a stale/mutated preview cannot
    // publish. Call only after all player, event and terminal effects are ready.
    internal void CommitPlannedChain(int barrelColliderIndex,float confirmedDamage,BarrelChainPlan plan,
        BarrelChainCause cause=BarrelChainCause.Shot)
    {
        ArgumentNullException.ThrowIfNull(plan);
        var expected=PreviewDamageChain(barrelColliderIndex,confirmedDamage,cause);
        if(!plan.OrderedEffects.SequenceEqual(expected.OrderedEffects) ||
           !plan.Barrels.SequenceEqual(expected.Barrels) ||
           !plan.OtherTargets.SequenceEqual(expected.OtherTargets))
            throw new InvalidDataException("Stale or altered barrel chain preview.");
        var next=new Dictionary<int,(float Health,bool Destroyed,uint Revision)>();
        foreach(var step in expected.OrderedEffects.Where(x=>x.Health.HasValue))
        {
            var before=next.TryGetValue(step.ColliderIndex,out var prior)
                ? prior : byCollider.TryGetValue(step.ColliderIndex,out var entry)
                    ? (entry.Lifecycle.Health,entry.Lifecycle.Destroyed,entry.Lifecycle.Revision)
                    : throw new InvalidDataException("Unknown barrel chain transition.");
            if(before.Revision==uint.MaxValue || !float.IsFinite(step.Health!.Value) ||
               step.Destroyed!=(step.Health.Value<=0))
                throw new InvalidDataException("Invalid barrel chain transition.");
            next[step.ColliderIndex]=(step.Health.Value,step.Destroyed,before.Revision+1);
        }
        foreach(var row in next)
            byCollider[row.Key].Lifecycle.CommitProjected(row.Value.Health,row.Value.Destroyed,row.Value.Revision);
    }
}
