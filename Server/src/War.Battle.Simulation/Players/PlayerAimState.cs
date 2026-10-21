using System.Numerics;

namespace War.BattleServer;

// Recovered SoldierAnimationController's procedural Update/LateUpdate state,
// at normal time scale. Does not select/blend animation clips or mutate a rig.
internal sealed class PlayerAimState
{
    private Vector3 lookDirection;
    private Quaternion target = Quaternion.Identity;
    private double bodyDeadline, upperDeadline;
    private bool upperEnabled;
    private float upperTarget;
    private double lastTime;
    public bool LookBack { get; set; } = true;
    public bool Disabled { get; set; }
    public Quaternion BodyRotation { get; private set; } = Quaternion.Identity;
    public float UpperAngle { get; private set; }
    // Null means keep the animation's rotation this frame (the source's >1 gate).
    public Quaternion? UpperOverride { get; private set; }

    public void SetUpper(float value)
    {
        if (!float.IsFinite(value) || Math.Abs(value)>360) throw new InvalidDataException("Invalid upper-body angle.");
        upperTarget=UpperAngle=value; upperEnabled=Math.Abs(value)>=1; upperDeadline=0;
    }
    public void LookAt(Vector3 direction,Quaternion parentRotation,double now,float lookBackSeconds=.45f)
    {
        Validate(now,parentRotation); Direction(direction); Duration(lookBackSeconds);
        Vector3 next=LookBack ? -direction : direction;
        var rotation=LookRotation(next)*Quaternion.Inverse(parentRotation);
        lookDirection=next; target=rotation; bodyDeadline=now+(LookBack ? lookBackSeconds : .5f);
        lastTime=now;
    }
    public void LookUpper(Vector3 direction,Quaternion parentRotation,double now,float seconds=.5f)
    {
        Validate(now,parentRotation); Direction(direction); Duration(seconds);
        Vector3 forward=Vector3.Transform(Vector3.UnitZ,parentRotation);
        float angle=MathF.Atan2(Vector3.Dot(Vector3.UnitY,Vector3.Cross(direction,forward)),Vector3.Dot(direction,forward))*57.29578f;
        upperEnabled=true; upperDeadline=now+.25f; upperTarget=angle;
        if (Math.Abs(angle)>70)
        {
            float excess=angle-MathF.CopySign(70,angle);
            target=Quaternion.CreateFromAxisAngle(Vector3.UnitY,-excess*(MathF.PI/180));
            bodyDeadline=now+(LookBack ? seconds*.5f : seconds);
            upperTarget=MathF.CopySign(70,angle);
        }
        // Source deliberately retains an earlier LookAt direction; Update can
        // recompute target from it. Clearing it here changes the Client behavior.
        lastTime=now;
    }
    public void Advance(double now,float deltaSeconds,Quaternion parentRotation)
    {
        Validate(now,parentRotation);
        if (!float.IsFinite(deltaSeconds) || deltaSeconds is < 0 or > 1) throw new InvalidDataException("Invalid aim delta.");
        lastTime=now; UpperOverride=null;
        if (Disabled) return;
        if (lookDirection.LengthSquared()>0) target=LookRotation(lookDirection)*Quaternion.Inverse(parentRotation);
        BodyRotation=Quaternion.Normalize(Quaternion.Slerp(BodyRotation,target,Math.Clamp(deltaSeconds*10,0,1)));
        // Source expiry is strict and resets AFTER this frame's interpolation.
        if (now>bodyDeadline && bodyDeadline!=0) { target=Quaternion.Identity; lookDirection=Vector3.Zero; }
        if (!upperEnabled) return;
        UpperAngle=UpperAngle+(upperTarget-UpperAngle)*Math.Clamp(deltaSeconds*12,0,1);
        if (Math.Abs(UpperAngle)>1)
        {
            UpperOverride=Quaternion.CreateFromAxisAngle(Vector3.UnitX,UpperAngle*(MathF.PI/180));
            if (now>upperDeadline && upperDeadline!=0) upperTarget=0;
        }
    }
    private void Validate(double now,Quaternion parent)
    {
        if (!double.IsFinite(now) || now<lastTime || now>86400 || !float.IsFinite(parent.LengthSquared()) || Math.Abs(parent.LengthSquared()-1)>.0001f)
            throw new InvalidDataException("Invalid aim clock or parent rotation.");
    }
    private static void Duration(float n) { if (!float.IsFinite(n)||n is < 0 or > 60) throw new InvalidDataException("Invalid aim duration."); }
    private static void Direction(Vector3 n) { if (!PlayerHitbox.Finite(n)||n.LengthSquared()<1e-10f) throw new InvalidDataException("Invalid aim direction."); }
    private static Quaternion LookRotation(Vector3 direction)
    {
        var forward=Vector3.Normalize(direction);
        var right=Vector3.Cross(Vector3.UnitY,forward);
        if (right.LengthSquared()<1e-10f) throw new InvalidDataException("Vertical-only body aim is unsupported.");
        right=Vector3.Normalize(right); var up=Vector3.Cross(forward,right);
        return Quaternion.Normalize(Quaternion.CreateFromRotationMatrix(new Matrix4x4(
            right.X,right.Y,right.Z,0, up.X,up.Y,up.Z,0, forward.X,forward.Y,forward.Z,0, 0,0,0,1)));
    }
}
