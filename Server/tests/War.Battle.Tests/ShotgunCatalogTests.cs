using System.Numerics;
using War.BattleServer;

internal static class ShotgunCatalogTests
{
    internal static int Run(string contentDirectory)
    {
        int checks=0;
        void Check(bool condition,string reason) { if(!condition)throw new Exception(reason);checks++; }
        var catalog=ShotgunCatalog.Load(Path.Combine(contentDirectory,"shotgun-content-manifest.json"));
        Check(catalog.WeaponCount==9 && catalog.StageCount==464,"complete recovered shotgun package");
        var id="Google2u.Shotgun_SPAS";
        var binding=catalog.Binding(id);
        var stage=catalog.Stage(id,0);
        Check(stage.ClipSize==8 && stage.ReserveAmmo==18 && Math.Abs(stage.ReloadSeconds-4.3f)<.0001f &&
              Math.Abs(stage.CadenceSeconds-.5f)<.0001f,"SPAS stage-zero ammo and timing");
        Check(Math.Abs(stage.MinDamage-22.62f)<.0001f && Math.Abs(stage.MaxDamage-101.8f)<.0001f,
              "SPAS stage-zero damage from upgrade sheet");
        Check(binding.Speed==30 && binding.Geometry.NearHalfAngle==50 && binding.Geometry.FarHalfAngle==3 &&
              binding.Geometry.Radius==10,"runtime base definition overrides stale serialized pellet setup");
        var shot=ShotgunShotPlanner.Plan(binding.Rule(stage),Vector3.Zero,new Vector3(0,0,5),
            [new ShotgunCollider("target","enemy",new Vector3(0,0,4),true)]);
        Check(shot.RealPellets.Count==2 && Math.Abs(shot.RealPellets[1].BaseDamage-(stage.MinDamage+(stage.MaxDamage-stage.MinDamage)*.6f))<.0001f,
              "catalog stage feeds source pellet damage");
        int rolls=0;
        var volley=ShotgunVolleyFactory.Prepare(binding,stage,41,"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            Vector3.Zero,new Vector3(0,0,5),10,
            [new ShotgunCollider("target","enemy",new Vector3(0,0,4),true)],
            ()=>rolls++==0 ? 0 : 1,(_,_,_)=>null);
        Check(volley.Count==2 && rolls==2 && volley[0].Flight.Id==41 && volley[1].Flight.Id==42,
              "one fast projectile and independent critical roll per real pellet");
        var offsetPlan=ShotgunShotPlanner.Plan(binding.Rule(stage),binding.ShotOffset,new Vector3(0,0,5),
            [new ShotgunCollider("target","enemy",new Vector3(0,0,4),true)]);
        Check(Math.Abs(volley[0].Damage.Amount-offsetPlan.RealPellets[0].BaseDamage*binding.CriticalMultiplier)<.0001f &&
              Math.Abs(volley[1].Damage.Amount-offsetPlan.RealPellets[1].BaseDamage)<.0001f,
              "only the first pellet received the critical multiplier");
        Check(volley[0].Damage.PlayerCoefficient==stage.PlayerDamageRatio &&
              volley[1].Damage.FriendKill==binding.FriendKill,
              "pellets carry server-owned damage coefficients and fraction rule");
        try
        {
            _=ShotgunVolleyFactory.Prepare(binding,stage,50,"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Vector3.Zero,new Vector3(0,0,5),10,[],()=>float.NaN,(_,_,_)=>null);
            throw new Exception("Invalid host critical roll accepted.");
        }
        catch(InvalidDataException) { checks++; }
        foreach(var (name,count) in new[] {("SPAS",36),("Benelli",26),("Saiga",46),("Striker",56),
                     ("Blackhand",76),("SawnOff",56),("StrikerElite",56),("AA12",66),("SaigaElite",46)})
        {
            string source="Google2u.Shotgun_"+name;
            Check(catalog.Stage(source,count-1).Index==count-1 && catalog.Binding(source).SourceId==source,
                  "full ordered shotgun lane: "+name);
            try { _=catalog.Stage(source,count);throw new Exception("Past-end shotgun level accepted: "+name); }
            catch(InvalidDataException) { checks++; }
        }
        var poses=PlayerPoseCatalog.Load(Path.Combine(contentDirectory,"recovered-player-poses.json"),catalog.SceneRevision);
        poses.AttachShotgunMuzzles(catalog);
        var idle=poses.SampleBlended("idle",0,true,"idle",0,true,0);
        var fire=poses.SampleBlended("player_fire_left_shotgun",.2,false,
            "player_fire_left_shotgun",.2,false,0);
        int animated=0;
        foreach(var bindingRow in catalog.Bindings)
        {
            Check(PlayerHitbox.Finite(bindingRow.ReferenceMuzzlePosition),
                  "serialized shotgun muzzle reference remains diagnostic: "+bindingRow.SourceId);
            var idleMuzzle=idle.Muzzle(bindingRow.SourceId);
            var fireMuzzle=fire.Muzzle(bindingRow.SourceId);
            Check(idleMuzzle.SourcePath==bindingRow.MuzzlePath &&
                  fireMuzzle.SourcePath==bindingRow.MuzzlePath &&
                  PlayerHitbox.Finite(fireMuzzle.Position),"animated shotgun muzzle bound to recovered rig: "+bindingRow.SourceId);
            if(Vector3.Distance(idleMuzzle.Position,fireMuzzle.Position)>.001f)animated++;
            var moved=fire.Place(new Vector3(2,3,4),Quaternion.Identity).Muzzle(bindingRow.SourceId);
            Check(PlayerHitbox.Finite(moved.Position) &&
                  Vector3.Distance(moved.Position,fireMuzzle.Position)>1,
                  "shotgun muzzle follows root placement: "+bindingRow.SourceId);
        }
        Check(animated==9,"all nine shotgun muzzles move under recovered firing animation");
        try {poses.AttachShotgunMuzzles(catalog);throw new Exception("Duplicate shotgun rig binding accepted.");}
        catch(InvalidDataException) {checks++;}
        return checks;
    }
}
