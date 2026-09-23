namespace War.BattleServer;

internal enum RifleCoverPhase { Idle, Uncovering, Firing, Hiding }
internal sealed record RifleClipSelection(string Name,double Seconds,float Speed,bool Loop);
internal sealed record RifleClipLayer(RifleClipSelection Clip,float Weight);
internal sealed record RifleAnimationTransition(RifleClipSelection From,RifleClipSelection To,float FadeSeconds,
    string? QueuedClip=null,bool QueuedCrossFade=false);

// Normal-time-scale default rifle branch of SoldierAnimationController.
// Produces playback instructions; a cross-fade still needs bone-space blending.
internal sealed class RifleCoverTimeline
{
    private readonly PlayerPoseCatalog poses;
    private double now, position, hideDeadline;
    private bool right;
    private RifleClipLayer[] fadingFrom=[];
    private double fadeStarted;
    private const float UncoverFade=.02f;
    private readonly string suffix;
    private readonly string idleClip;
    private readonly bool bazooka;
    public RifleCoverPhase Phase { get; private set; }
    public string RunClip { get; }
    public RifleCoverTimeline(PlayerPoseCatalog poses,int animationFamily=0)
    {
        this.poses=poses;
        bazooka=animationFamily==2;
        suffix=animationFamily switch {0=>"3",2=>"",4=>"_minigun",5=>"_pistol",7 or 15=>"_shotgun",9=>"_qbz",10=>"_sniper",13=>"_qbz2",_=>throw new InvalidDataException("Unsupported weapon animation family.")};
        RunClip=animationFamily switch {0=>"run",2=>"bazooka_run",4=>"minigun_run",5=>"pistol_run",7 or 15=>"shotgunner_run",9=>"qbz_run",10=>"sniper_run",13=>"qbz2_run",_=>throw new InvalidDataException("Unsupported weapon run family.")};
        idleClip=animationFamily switch {2=>"bazooka_idle",4=>"minigun_idle",10=>"sniper_idle",_=>"idle"};
        _=poses.Duration(RunClip);
        foreach(string name in bazooka?new[]{"bazooka_uncover_right","bazooka_uncover_left","bazooka_shoot_right","bazooka_shoot_left"}:
            new[] {"player_look_right"+suffix,"player_look_left"+suffix,"player_fire_right"+suffix,"player_fire_left"+suffix,"player_right_coverBack"+suffix,"player_left_coverBack"+suffix})
            _=poses.Duration(name);
    }
    private string Look => bazooka ? (right?"bazooka_uncover_right":"bazooka_uncover_left") : right ? "player_look_right"+suffix : "player_look_left"+suffix;
    private string Fire => bazooka ? (right?"bazooka_shoot_right":"bazooka_shoot_left") : right ? "player_fire_right"+suffix : "player_fire_left"+suffix;
    private string Hide => bazooka ? idleClip : right ? "player_right_coverBack"+suffix : "player_left_coverBack"+suffix;
    public RifleClipSelection Selection => Phase switch
    {
        RifleCoverPhase.Idle => new(idleClip,position,1,true),
        RifleCoverPhase.Uncovering => new(Look,position,4,false),
        RifleCoverPhase.Firing => new(Fire,position,1,false),
        _ => new(Hide,position,1,false)
    };
    public double HidingWait => Phase==RifleCoverPhase.Hiding ? poses.Duration(Look)/4d*(position/poses.Duration(Hide)) : 1;
    // SoldierAnimationController.uncoverLength always reads the default clip.
    public double UncoverWait => poses.Duration("player_look_right3")*.25d;
    public void ResetToIdle()
    {
        Phase=RifleCoverPhase.Idle;position=0;hideDeadline=0;fadingFrom=[];right=false;fadeStarted=now;
    }
    public IReadOnlyList<RifleClipLayer> Layers
    {
        get
        {
            if (fadingFrom.Length>0 && now-fadeStarted<UncoverFade)
            {
                float weight=(float)((now-fadeStarted)/UncoverFade);
                return fadingFrom.Select(l=>new RifleClipLayer(l.Clip with { Seconds=l.Clip.Seconds+(now-fadeStarted)*l.Clip.Speed },l.Weight*(1-weight)))
                    .Append(new RifleClipLayer(Selection,weight)).ToArray();
            }
            if (Phase!=RifleCoverPhase.Hiding) return [new(Selection,1)];
            var blend=QueuedCrossFade.Sample(position,poses.Duration(Hide));
            return [new(Selection,1-blend.IncomingWeight),new(new(idleClip,blend.IncomingSeconds,1,true),blend.IncomingWeight)];
        }
    }

    // Call once at the host's animation-update phase; expiry begins hiding on
    // this observed tick, not retrospectively at the deadline between ticks.
    public RifleAnimationTransition? Advance(double time)
    {
        if (!double.IsFinite(time)||time<now||time>86400) throw new InvalidDataException("Invalid cover timeline clock.");
        double elapsed=time-now; now=time;
        if (now-fadeStarted>=UncoverFade) fadingFrom=[];
        position+=elapsed*(Phase==RifleCoverPhase.Uncovering ? 4 : 1);
        if (!bazooka && Phase==RifleCoverPhase.Uncovering && position>=poses.Duration(Look))
        { position=(position-poses.Duration(Look))/4; Phase=RifleCoverPhase.Firing; }
        else if (Phase==RifleCoverPhase.Hiding && position>=poses.Duration(Hide))
        { position=QueuedCrossFade.Sample(position,poses.Duration(Hide)).IncomingSeconds; Phase=RifleCoverPhase.Idle; }
        if (Phase==RifleCoverPhase.Idle) position%=poses.Duration(idleClip);
        if (bazooka && Phase==RifleCoverPhase.Firing && position>=poses.Duration(Fire))
        {Phase=RifleCoverPhase.Idle;position=0;}
        if (Phase==RifleCoverPhase.Firing) position=Math.Min(position,poses.Duration(Fire));
        if (hideDeadline!=0 && time>hideDeadline)
        {
            var from=Selection; hideDeadline=0; Phase=RifleCoverPhase.Hiding; position=0;
            fadingFrom=[];
            return new(from,Selection,0,idleClip,true); // Source Play, then CrossFadeQueued family idle.
        }
        return null;
    }
    // Host must Advance to the command time before applying the instruction.
    // right is the PlayerController.PlayShotAnimation argument, after accounting
    // for the two inversions in its calls to ShotFromCover.
    public RifleAnimationTransition? Shot(bool shootRight)
    {
        var from=Selection;
        var priorLayers=Layers.ToArray();
        bool same=right==shootRight;
        if (!(same && Phase is RifleCoverPhase.Uncovering or RifleCoverPhase.Firing or RifleCoverPhase.Hiding) && priorLayers.Length>=4)
            throw new InvalidDataException("Too many interrupted animation layers.");
        double hidingNormalized=Phase==RifleCoverPhase.Hiding ? position/poses.Duration(Hide) : 0;
        right=shootRight; hideDeadline=now+.4f;
        if (same && Phase==RifleCoverPhase.Uncovering) return null;
        if (same && Phase==RifleCoverPhase.Firing)
        { position=0; fadingFrom=[]; return new(from,Selection,0); }
        if (same && Phase==RifleCoverPhase.Hiding)
        { Phase=RifleCoverPhase.Uncovering; position=(1-hidingNormalized)*poses.Duration(Look); fadingFrom=[]; return new(from,Selection,0,Fire); }
        fadingFrom=priorLayers;fadeStarted=now;
        Phase=RifleCoverPhase.Uncovering; position=0;
        return new(from,Selection,.02f,Fire);
    }

    // PlayerMinigunWeapon.Uncover starts the family look pose while the motor
    // spins, without queuing a shot or the 0.4-second hide deadline.
    public void Uncover(bool shootRight)
    {
        if(Phase==RifleCoverPhase.Uncovering&&right==shootRight)return;
        var prior=Layers.ToArray();right=shootRight;hideDeadline=0;
        fadingFrom=prior;fadeStarted=now;Phase=RifleCoverPhase.Uncovering;position=0;
    }
    public void BeginHide()
    {
        if(Phase==RifleCoverPhase.Idle||Phase==RifleCoverPhase.Hiding)return;
        hideDeadline=0;fadingFrom=[];Phase=RifleCoverPhase.Hiding;position=0;
    }
    public void BazookaShoot(bool shootRight)
    {
        if(!bazooka)throw new InvalidOperationException("Timeline is not bazooka.");
        right=shootRight;hideDeadline=0;fadingFrom=[];Phase=RifleCoverPhase.Firing;position=0;
    }
}
