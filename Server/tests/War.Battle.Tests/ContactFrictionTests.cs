using War.BattleServer;
using System.Numerics;

internal static class ContactFrictionTests
{
    internal static int Run()
    {
        int count=0;
        void Check(bool value){if(!value)throw new Exception("Friction constraint boundary failed.");count++;}
        DroneNormalPoint Point(float x,float separation=0)=>new(new Vector3(x,0,0),Vector3.UnitY,separation);
        var material=new ContactMaterial(.6f,.4f,0);
        var cache=new ContactFrictionCache(Vector3.Zero,Quaternion.Identity,Vector3.UnitY,new[]{Vector3.Zero,Vector3.UnitX},false);
        Check(cache.CanReuse(Vector3.Zero,Quaternion.Identity,.999f,.025f));
        Check(ReferenceEquals(cache.Grow(Vector3.Zero,Quaternion.Identity,new[]{Point(0),Point(1)},.025f,.04f),cache));
        Check(cache.Grow(Vector3.Zero,Quaternion.Identity,new[]{Point(0),Point(3)},.025f,.04f).Anchors[1].MapWorld==new Vector3(3,0,0));
        var one=new ContactFrictionCache(Vector3.Zero,Quaternion.Identity,Vector3.UnitY,new[]{Vector3.Zero},false);
        var grown=one.Grow(Vector3.UnitX*.1f,Quaternion.Identity,new[]{Point(1)},.025f,.04f);
        Check(grown.Anchors.Count==2&&grown.Anchors[0]==one.Anchors[0]&&grown.Anchors[1].MapWorld==Vector3.UnitX);
        Check(cache.CanReuse(Vector3.UnitX*.1f,Quaternion.Identity,.999f,.025f));
        Check(!cache.CanReuse(Vector3.UnitY*.025f,Quaternion.Identity,.999f,.025f));
        Check(!cache.CanReuse(Vector3.Zero,Quaternion.CreateFromAxisAngle(Vector3.UnitX,.1f),.999f,.025f));
        Check(!new ContactFrictionCache(Vector3.Zero,Quaternion.Identity,Vector3.UnitY,new[]{Vector3.Zero},true)
            .CanReuse(Vector3.Zero,Quaternion.Identity,.999f,.025f));
        var correlated=ContactFrictionPatches.Correlate(new[]{new MaterialContact(Point(0),material),
            new MaterialContact(Point(1) with{Normal=Vector3.UnitX},material),new MaterialContact(Point(2),material)},.99f);
        Check(correlated.Length==2&&correlated[0].Contacts.Select(c=>c.Point.X).SequenceEqual(new[]{2f,0f}));
        Check(ContactFrictionPatches.Correlate(new[]{new MaterialContact(Point(0),material),
            new MaterialContact(Point(1),material with{Restitution=.1f})},.99f).Length==2);
        Check(ContactFrictionPatches.Correlate(new[]{new MaterialContact(Point(0),material),
            new MaterialContact(Point(1),material)},1).Single().Contacts.Count==2);
        Check(ContactFrictionAnchors.Select(Array.Empty<DroneNormalPoint>(),.1f,.04f).Length==0);
        Check(ContactFrictionAnchors.Select(new[]{Point(0,.04f)},.1f,.04f).Length==0);
        Check(ContactFrictionAnchors.Select(new[]{Point(0),Point(.1f)},.1f,.04f).Length==1);
        Check(ContactFrictionAnchors.Select(new[]{Point(0),Point(1),Point(2)},.1f,.04f)
            .SequenceEqual(new[]{Vector3.Zero,new Vector3(2,0,0)}));
        Check(ContactFrictionAnchors.Select(new[]{Point(0),Point(1),Point(-2)},.1f,.04f)
            .SequenceEqual(new[]{new Vector3(-2,0,0),Vector3.UnitX}));
        Check(ContactNormalConstraint.Solve(0,-4,.5f,0,10)==new ContactNormalStep(2,2));
        Check(ContactNormalConstraint.Solve(2,8,.5f,0,10)==new ContactNormalStep(0,-2));
        Check(ContactNormalConstraint.Solve(2,0,1,3,4)==new ContactNormalStep(4,2));
        Check(ContactNormalConstraint.Solve(2,0,1,0,4)==new ContactNormalStep(2,0));
        Check(ContactNormalConstraint.Solve(0,-4,1,0,0)==new ContactNormalStep(0,0));
        foreach(float invalid in new[]{float.NaN,float.PositiveInfinity,-1f})
        {
            try{ContactNormalConstraint.Solve(invalid,0,1,0,10);
                throw new Exception("Invalid previous contact impulse accepted.");}
            catch(InvalidDataException){count++;}
        }
        Check(ContactFrictionBasis.Prepare(Vector3.UnitY,Vector3.Zero)==new FrictionTangents(Vector3.UnitZ,Vector3.UnitX));
        Check(ContactFrictionBasis.Prepare(Vector3.UnitX,Vector3.Zero)==new FrictionTangents(Vector3.UnitY,Vector3.UnitZ));
        Check(ContactFrictionBasis.Prepare(Vector3.UnitY,Vector3.UnitX)==new FrictionTangents(Vector3.UnitX,-Vector3.UnitZ));
        Check(ContactFrictionBasis.Prepare(Vector3.UnitY,new Vector3(.2f,9,0)).First==Vector3.UnitZ);
        foreach(var normal in new[]{Vector3.UnitZ,Vector3.Normalize(Vector3.One),Vector3.Normalize(new Vector3(-2,1,-3))})
        {
            var tangents=ContactFrictionBasis.Prepare(normal,new Vector3(.5f,-.3f,.7f));
            Check(Math.Abs(Vector3.Dot(normal,tangents.First))<.00001f&&
                Math.Abs(Vector3.Dot(normal,tangents.Second))<.00001f&&
                Math.Abs(Vector3.Dot(tangents.First,tangents.Second))<.00001f&&
                Math.Abs(tangents.First.Length()-1)<.00001f&&Math.Abs(tangents.Second.Length()-1)<.00001f);
        }
        Check(ContactFrictionConstraint.Solve(0,-6,0,0,1,10,.6f,.4f)==new ContactFrictionStep(6,6,false));
        Check(ContactFrictionConstraint.Solve(0,-7,0,0,1,10,.6f,.4f)==new ContactFrictionStep(4,4,true));
        Check(ContactFrictionConstraint.Solve(0,7,0,0,1,10,.6f,.4f)==new ContactFrictionStep(-4,-4,true));
        Check(ContactFrictionConstraint.Solve(3,0,0,0,1,0,.6f,.4f)==new ContactFrictionStep(0,-3,true));
        Check(ContactFrictionConstraint.Solve(2,4,1,3,.5f,10,.6f,.4f)==new ContactFrictionStep(-1,-3,false));
        foreach(float invalid in new[]{float.NaN,float.PositiveInfinity,-1f})
        {
            try{ContactFrictionConstraint.Solve(0,0,0,0,1,invalid,.6f,.4f);
                throw new Exception("Invalid normal impulse accepted.");}
            catch(InvalidDataException){count++;}
        }
        return count;
    }
}
