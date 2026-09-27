namespace War.BattleServer;

internal readonly record struct ContactNormalStep(float Impulse,float Delta);

// Prepared scalar contact update; manifold generation and error preparation
// belong to the caller. Velocity uses the solver's initial-state delta convention.
internal static class ContactNormalConstraint
{
    internal static ContactNormalStep Solve(float previous,float normalVelocity,float velocityMultiplier,
        float preparedError,float maximumImpulse)
    {
        if(!float.IsFinite(previous)||previous<0||!float.IsFinite(maximumImpulse)||maximumImpulse<0||
           previous>maximumImpulse||!float.IsFinite(normalVelocity)||
           !float.IsFinite(velocityMultiplier)||velocityMultiplier<=0||
           !float.IsFinite(preparedError))
            throw new InvalidDataException("Invalid normal contact constraint authority.");
        float correction=preparedError-normalVelocity*velocityMultiplier;
        if(!float.IsFinite(correction))throw new InvalidDataException("Normal constraint arithmetic overflow.");
        float candidate=previous+Math.Max(correction,-previous);
        if(!float.IsFinite(candidate))throw new InvalidDataException("Normal impulse arithmetic overflow.");
        float impulse=Math.Min(candidate,maximumImpulse);
        return new(impulse,impulse-previous);
    }
}
