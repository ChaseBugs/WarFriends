using System.Numerics;

namespace War.BattleServer;

// Source TweenRotation.Sample joints at the fixed host rate. Aim endpoints are
// absolute world quaternions; after each sample, the hierarchy stores locals.
internal sealed class HelicopterTurretTweenState
{
    private static readonly Quaternion ParentLocalRotation=new(0,-.7071068f,0,.7071067f);
    private Quaternion horizontalLocal=Quaternion.Identity,verticalLocal=Quaternion.Identity;
    private Quaternion horizontalFrom,horizontalTo,verticalFrom,verticalTo;
    private float elapsed,horizontalDuration,verticalDuration;
    private bool tweening,planned,clipped;
    internal bool Ready=>planned&&!tweening&&!clipped;
    internal bool Turning=>tweening;

    internal HelicopterTurretAimPose Current(Vector3 rootPosition,Quaternion rootRotation)
    {
        var horizontal=Quaternion.Normalize(Parent(rootRotation)*horizontalLocal);
        var vertical=Quaternion.Normalize(horizontal*verticalLocal);
        return HelicopterTurretAim.Place(rootPosition,rootRotation,horizontalLocal,vertical);
    }

    internal int Plan(Vector3 rootPosition,Quaternion rootRotation,Vector3 target)
    {
        var before=Current(rootPosition,rootRotation);
        var next=HelicopterTurretAim.FromCurrent(rootPosition,rootRotation,target,
            before.HorizontalLocalRotation,before.VerticalWorldRotation);
        planned=true;clipped=next.Clipped;
        if(next.Immediate){tweening=false;return 0;}
        horizontalFrom=Quaternion.Normalize(Parent(rootRotation)*horizontalLocal);
        horizontalTo=Quaternion.Normalize(Parent(rootRotation)*next.HorizontalLocalRotation);
        verticalFrom=before.VerticalWorldRotation;
        verticalTo=next.VerticalWorldRotation;
        horizontalDuration=next.AimSeconds;
        verticalDuration=next.VerticalSeconds;
        elapsed=0;tweening=true;
        if(verticalDuration==0)
            verticalLocal=Quaternion.Normalize(Quaternion.Inverse(horizontalFrom)*verticalTo);
        return (int)MathF.Ceiling(horizontalDuration*MatchManifest.TickRate);
    }

    internal void AdvanceTick(Vector3 rootPosition,Quaternion rootRotation)
    {
        if(!tweening)return;
        // Validate placement before changing an authoritative joint.
        Current(rootPosition,rootRotation);
        float nextElapsed=elapsed+1f/MatchManifest.TickRate;
        var horizontal=Quaternion.Normalize(Quaternion.Slerp(horizontalFrom,horizontalTo,
            Ease(nextElapsed/horizontalDuration)));
        var vertical=verticalDuration==0?verticalTo:
            Quaternion.Normalize(Quaternion.Slerp(verticalFrom,verticalTo,
                Ease(nextElapsed/verticalDuration)));
        var localH=Quaternion.Normalize(Quaternion.Inverse(Parent(rootRotation))*horizontal);
        var localV=Quaternion.Normalize(Quaternion.Inverse(horizontal)*vertical);
        HelicopterTurretAim.Place(rootPosition,rootRotation,localH,vertical);
        horizontalLocal=localH;verticalLocal=localV;elapsed=nextElapsed;
        if(elapsed>=horizontalDuration)tweening=false;
    }

    private static Quaternion Parent(Quaternion root)
        =>Quaternion.Normalize(root*ParentLocalRotation);
    private static float Ease(float factor)
    {
        float t=Math.Clamp(factor,0,1);
        return t-MathF.Sin(t*2*MathF.PI)/(2*MathF.PI);
    }
}
