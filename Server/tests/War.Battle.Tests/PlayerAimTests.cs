using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class PlayerAimTests
{
    internal static int RunUnityReference(string path)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(path));
        var root=document.RootElement;
        float dt=root.GetProperty("interval").GetSingle();
        int checks=0;
        Quaternion Q(JsonElement e)=>new(e[0].GetSingle(),e[1].GetSingle(),e[2].GetSingle(),e[3].GetSingle());
        void Rotation(Quaternion actual,Quaternion expected)
        {
            if (1-Math.Abs(Quaternion.Dot(actual,expected))>.000001f) throw new Exception("Unity procedural aim quaternion mismatch.");
            checks++;
        }
        foreach (var row in root.GetProperty("rows").EnumerateArray())
        {
            var d=row.GetProperty("direction"); var direction=new Vector3(d[0].GetSingle(),d[1].GetSingle(),d[2].GetSingle());
            var parent=Q(row.GetProperty("parent"));
            var body=new PlayerAimState { LookBack=false }; body.LookAt(direction,parent,0); body.Advance(dt,dt,parent);
            Rotation(body.BodyRotation,Q(row.GetProperty("body")));
            var upper=new PlayerAimState(); upper.LookUpper(direction,parent,0); upper.Advance(dt,dt,parent);
            if (Math.Abs(upper.UpperAngle-row.GetProperty("upperAngle").GetSingle())>.0001f) throw new Exception("Unity signed upper aim mismatch.");
            checks++;
            Rotation(upper.BodyRotation,Q(row.GetProperty("excessBody")));
            if (upper.UpperOverride.HasValue) Rotation(upper.UpperOverride.Value,Q(row.GetProperty("upperRotation")));
        }
        return checks;
    }
    internal static int Run()
    {
        int count=0;
        void Check(bool ok,string message) { if (!ok) throw new Exception(message); count++; }
        void Reject(Action action) { try { action(); } catch (InvalidDataException) { count++; return; } throw new Exception("Invalid aim accepted."); }
        var identity=Quaternion.Identity;
        var aim=new PlayerAimState { LookBack=false };
        aim.LookAt(Vector3.UnitX,identity,0);
        aim.Advance(.1,.1f,identity);
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,aim.BodyRotation),Vector3.UnitX)<.00001f,"body looks along source direction");
        aim.Advance(.5,.1f,identity);
        Check(Math.Abs(Quaternion.Dot(identity,aim.BodyRotation))<.8f,"deadline equality retains direction");
        aim.Advance(.6,.1f,identity);
        Check(Math.Abs(Quaternion.Dot(identity,aim.BodyRotation))<.8f,"expiry frame rotates before reset");
        aim.Advance(.7,.1f,identity);
        Check(Math.Abs(Quaternion.Dot(identity,aim.BodyRotation))>.99999f,"following frame returns to identity");
        aim=new PlayerAimState(); aim.LookAt(Vector3.UnitX,identity,0); aim.Advance(.1,.1f,identity);
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,aim.BodyRotation),-Vector3.UnitX)<.00001f,"look-back reverses direction");
        aim=new PlayerAimState(); aim.LookUpper(Vector3.UnitX,identity,0); aim.Advance(.1,.1f,identity);
        Check(Math.Abs(aim.UpperAngle+70)<.0001f,"signed upper aim capped at minus seventy");
        Check(Vector3.Distance(Vector3.Transform(Vector3.UnitZ,aim.BodyRotation),new Vector3(MathF.Sin(MathF.PI/9),0,MathF.Cos(MathF.PI/9)))<.00001f,"excess angle rotates body");
        Check(aim.UpperOverride.HasValue,"upper-body local X override emitted");
        aim.Advance(.25,.1f,identity); Check(aim.UpperAngle==-70,"upper deadline equality");
        aim.Advance(.26,.1f,identity); Check(aim.UpperAngle==-70,"upper expiry after interpolation");
        aim.Advance(.3,.1f,identity); Check(aim.UpperAngle==0 && aim.UpperOverride==null,"expired upper aim leaves sampled animation rotation");
        aim.SetUpper(.5f); aim.Advance(.4,.1f,identity); Check(aim.UpperOverride==null,"sub-degree set disables procedural override");
        aim.SetUpper(30); aim.Disabled=true; aim.Advance(.5,.1f,identity); Check(aim.UpperAngle==30 && aim.UpperOverride==null,"disabled look preserves state without bone write");
        Reject(()=>aim.Advance(.4,.1f,identity)); Reject(()=>aim.Advance(double.NaN,.1f,identity));
        Reject(()=>aim.LookUpper(Vector3.Zero,identity,.5)); Reject(()=>aim.SetUpper(float.NaN));
        Reject(()=>aim.LookAt(Vector3.UnitX,new Quaternion(),.5));
        return count;
    }
}
