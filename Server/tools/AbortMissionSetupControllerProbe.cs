using System;

/// <summary>Routes the real GameController start entry into a controlled original mission callback.</summary>
public sealed class AbortMissionSetupControllerProbe : GameControllerDeathMatch
{
    /// <summary>The mission setup callback exercised before map loading is allowed to begin.</summary>
    public Action LoadingStartedAction { get; set; }

    /// <summary>Invokes only the controlled early mission preparation callback.</summary>
    public override void LoadingStarted()
    {
        LoadingStartedAction();
    }
}
