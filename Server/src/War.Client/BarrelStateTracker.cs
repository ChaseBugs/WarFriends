using System;
using System.Collections.Generic;
using System.Linq;
using War.Protocol;

namespace War.Client
{
    public sealed class BarrelSceneIdentity
    {
        public int ColliderIndex { get; }
        public int GameObjectFileId { get; }
        public BarrelSceneIdentity(int colliderIndex,int gameObjectFileId)
        { ColliderIndex=colliderIndex;GameObjectFileId=gameObjectFileId; }
    }

    public sealed class BarrelViewState
    {
        public int ColliderIndex { get; }
        public int GameObjectFileId { get; }
        public float Health { get; }
        public float MaxHealth { get; }
        public bool Destroyed { get; }
        public uint Revision { get; }
        internal BarrelViewState(BarrelSceneIdentity id,float health,float maximum,bool dead,uint revision)
        { ColliderIndex=id.ColliderIndex;GameObjectFileId=id.GameObjectFileId;
          Health=health;MaxHealth=maximum;Destroyed=dead;Revision=revision; }
    }

    /// <summary>Reconnect projection bound to the pinned map's source identities.
    /// A batch is a complete set of changed rows; omitted rows retain source HP.</summary>
    public sealed class BarrelStateTracker
    {
        private readonly string matchId;
        private readonly string manifestHash;
        private readonly Dictionary<int,BarrelSceneIdentity> identities;
        private Dictionary<int,BarrelViewState> state=new Dictionary<int,BarrelViewState>();
        private float? maximum;
        private ulong stateRevision;
        public BarrelStateTracker(string matchId,string manifestHash,IEnumerable<BarrelSceneIdentity> source)
        {
            if(string.IsNullOrEmpty(matchId) || string.IsNullOrEmpty(manifestHash) || source==null)
                throw new ArgumentException("Missing match barrel identity.");
            var rows=source.ToArray();
            if(rows.Length>10 || rows.Any(x=>x==null || x.ColliderIndex<0 || x.GameObjectFileId<=0) ||
                rows.Select(x=>x.ColliderIndex).Distinct().Count()!=rows.Length ||
                rows.Select(x=>x.GameObjectFileId).Distinct().Count()!=rows.Length)
                throw new ArgumentException("Invalid source barrel identities.");
            this.matchId=matchId;this.manifestHash=manifestHash;
            identities=rows.ToDictionary(x=>x.ColliderIndex);
        }
        public IReadOnlyList<BarrelViewState> Snapshot()=>Array.AsReadOnly(state.Values
            .OrderBy(x=>x.ColliderIndex).ToArray());
        // Apply a reliably ordered event for immediate visuals. A missed revision
        // requires a complete MatchBarrelBatch before later effects are trusted.
        public bool ApplyEvent(MatchEvent item)
        {
            if(item==null || (item.Kind!=MatchEventKind.BarrelDamaged &&
                item.Kind!=MatchEventKind.BarrelDestroyed) || !maximum.HasValue)
                throw new InvalidOperationException("Barrel event needs initialized source authority.");
            BarrelSceneIdentity identity;
            BarrelViewState previous;
            bool dead=item.Kind==MatchEventKind.BarrelDestroyed;
            if(!identities.TryGetValue(item.BarrelColliderIndex,out identity) ||
                !state.TryGetValue(item.BarrelColliderIndex,out previous) ||
                identity.GameObjectFileId!=item.BarrelGameObjectFileId || item.BarrelRevision==0 ||
                float.IsNaN(item.Health) || float.IsInfinity(item.Health) ||
                item.Health>maximum.Value || dead!=(item.Health<=0))
                throw new InvalidOperationException("Barrel event disagrees with source scene.");
            if(item.BarrelRevision<previous.Revision)return false;
            if(item.BarrelRevision==previous.Revision)
            {
                if(previous.Health!=item.Health || previous.Destroyed!=dead)
                    throw new InvalidOperationException("Barrel event conflicts with projected revision.");
                return false;
            }
            if(previous.Revision==uint.MaxValue || item.BarrelRevision!=previous.Revision+1)
                throw new InvalidOperationException("Barrel event revision gap; refresh barrel state.");
            state[item.BarrelColliderIndex]=new BarrelViewState(identity,item.Health,
                maximum.Value,dead,item.BarrelRevision);
            return true;
        }
        public void Apply(MatchBarrelBatch batch)
        {
            if(batch==null || batch.MatchId!=matchId || batch.ManifestHash!=manifestHash ||
                batch.SourceCount!=identities.Count || batch.StateRevision<stateRevision ||
                (identities.Count==0 ? batch.MaxHealth!=0 :
                    float.IsNaN(batch.MaxHealth) || float.IsInfinity(batch.MaxHealth) ||
                    batch.MaxHealth<50 || batch.MaxHealth>56 ||
                    (maximum.HasValue && batch.MaxHealth!=maximum.Value)) ||
                batch.Changed.Count>identities.Count)
                throw new InvalidOperationException("Invalid barrel reconnect batch.");
            var next=identities.ToDictionary(x=>x.Key,x=>
                new BarrelViewState(x.Value,batch.MaxHealth,batch.MaxHealth,false,0));
            var seen=new HashSet<int>();
            foreach(var row in batch.Changed)
            {
                BarrelSceneIdentity identity;
                if(!identities.TryGetValue(row.ColliderIndex,out identity) ||
                    !seen.Add(row.ColliderIndex) || row.GameObjectFileId!=identity.GameObjectFileId ||
                    row.Revision==0 || float.IsNaN(row.Health) || float.IsInfinity(row.Health) ||
                    row.Health>batch.MaxHealth || row.Destroyed!=(row.Health<=0))
                    throw new InvalidOperationException("Barrel row disagrees with source scene.");
                next[row.ColliderIndex]=new BarrelViewState(identity,row.Health,batch.MaxHealth,
                    row.Destroyed,row.Revision);
            }
            foreach(var old in state.Values)
            {
                var updated=next[old.ColliderIndex];
                if(updated.Revision<old.Revision ||
                    (batch.StateRevision==stateRevision && updated.Revision!=old.Revision) ||
                    (updated.Revision==old.Revision &&
                     (updated.Health!=old.Health || updated.Destroyed!=old.Destroyed)))
                    throw new InvalidOperationException("Barrel reconnect state regressed.");
            }
            state=next;maximum=batch.MaxHealth;stateRevision=batch.StateRevision;
        }
    }
}
