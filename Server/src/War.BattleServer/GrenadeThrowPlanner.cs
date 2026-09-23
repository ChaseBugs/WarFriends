using System.Numerics;

namespace War.BattleServer;

internal sealed record GrenadeThrowPlan(Vector3 Target,bool Right,float ClampedHoldSeconds,float ClampedSwipeDistance);

internal static class GrenadeThrowPlanner
{
    internal static GrenadeThrowPlan Plan(GrenadeBinding binding,Vector3 playerPosition,Quaternion coverRotation,
        Vector3 swipeStart,Vector3 swipeEnd,float heldSeconds)
    {
        if(binding==null||binding.SwipeInput==null||!PlayerHitbox.Finite(playerPosition)||
           !PlayerHitbox.Finite(swipeStart)||!PlayerHitbox.Finite(swipeEnd)||!float.IsFinite(heldSeconds))
            throw new InvalidDataException("Grenade swipe requires finite source authority.");
        var input=binding.SwipeInput;var delta=swipeEnd-swipeStart;float rawDistance=delta.Length();
        if(!float.IsFinite(rawDistance)||rawDistance<=input.DistanceThreshold)
            throw new InvalidDataException("Grenade swipe did not cross the source threshold.");
        float time=Math.Clamp(heldSeconds,input.MinThrowTime,input.MaxThrowTime);
        float distance=Math.Clamp(rawDistance,input.MinDistance,input.MaxDistance);
        float strength=Math.Clamp(distance/time*input.ThrowFactor,input.MinDistanceShot,input.MaxDistanceShot);
        var direction=Vector3.Normalize(delta);var target=playerPosition+direction*strength;
        var planar=target-playerPosition;planar.Y=0;
        if(planar.LengthSquared()<1e-10f||!PlayerHitbox.Finite(target))throw new InvalidDataException("Invalid grenade throw direction.");
        var forward=Vector3.Transform(Vector3.UnitZ,coverRotation);
        if(Vector3.Dot(-forward,Vector3.Normalize(target-playerPosition))<=MathF.Cos(95*MathF.PI/180))
            throw new InvalidDataException("Grenade swipe is outside the recovered firing arc.");
        bool right=Vector3.Dot(Vector3.UnitY,Vector3.Cross(forward,planar))>0;
        return new(target,right,time,distance);
    }
}
