namespace War.BattleServer;

internal readonly record struct ContactFrictionStep(float Impulse,float Delta,bool Broken);

// Scalar constraint update observed in NVIDIA PhysX 3.4's solveContact.
// Patch anchors, effective mass, ordering and bias are separate required inputs.
internal static class ContactFrictionConstraint
{
    internal static ContactFrictionStep Solve(float previous,float relativeVelocity,float targetVelocity,
        float bias,float velocityMultiplier,float normalImpulse,float staticCoefficient,float dynamicCoefficient)
    {
        foreach(float value in new[]{previous,relativeVelocity,targetVelocity,bias,normalImpulse})
            if(!float.IsFinite(value)||Math.Abs(value)>10000000)
                throw new InvalidDataException("Invalid friction constraint authority.");
        if(normalImpulse<0||!float.IsFinite(velocityMultiplier)||velocityMultiplier<=0||velocityMultiplier>1000000||
           !float.IsFinite(staticCoefficient)||staticCoefficient<0||staticCoefficient>1000||
           !float.IsFinite(dynamicCoefficient)||dynamicCoefficient<0||dynamicCoefficient>staticCoefficient)
            throw new InvalidDataException("Invalid friction material or effective mass.");
        float candidate=previous-(bias-targetVelocity)*velocityMultiplier;
        candidate-=relativeVelocity*velocityMultiplier;
        float staticLimit=staticCoefficient*normalImpulse,dynamicLimit=dynamicCoefficient*normalImpulse;
        bool broken=Math.Abs(candidate)>staticLimit;
        float impulse=broken?Math.Clamp(candidate,-dynamicLimit,dynamicLimit):candidate;
        float delta=impulse-previous;
        if(!float.IsFinite(impulse)||!float.IsFinite(delta))throw new InvalidDataException("Friction constraint overflow.");
        return new(impulse,delta,broken);
    }
}
