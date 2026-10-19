using System.Numerics;

namespace War.BattleServer;

/// <summary>Recovered visibility flags; viewport projection, clip clocks and culling remain caller-owned.</summary>
internal sealed class SoldierAnimationVisibilityState
{
    private const double MinimumViewportCoordinate = -0.1;
    private const double MaximumViewportCoordinate = 1.1;
    private bool _isControllerEnabled;

    internal bool IsInScreen { get; private set; } = true;
    internal bool IsForced { get; private set; }
    internal bool IsAnimationEnabled { get; private set; } = true;

    internal void Reset(Vector2 viewport)
    {
        ValidateViewport(viewport);
        IsInScreen = true;
        IsAnimationEnabled = true;
        IsForced = false;
        ApplyScreenCheck(viewport);
        // The original Reset performs the screen check using its previous enabled state.
        _isControllerEnabled = true;
    }

    internal void ReactivateComponent(Vector2 viewport)
    {
        ValidateViewport(viewport);
        IsInScreen = true;
        IsAnimationEnabled = true;
        ApplyScreenCheck(viewport);
    }

    internal void CheckScreen(Vector2 viewport)
    {
        ValidateViewport(viewport);
        ApplyScreenCheck(viewport);
    }

    internal void ForceInScreen()
    {
        IsForced = true;
        IsInScreen = true;
        IsAnimationEnabled = true;
    }

    internal void Pause()
    {
        IsAnimationEnabled = false;
        _isControllerEnabled = false;
    }

    internal void Resume()
    {
        IsAnimationEnabled = true;
        _isControllerEnabled = true;
    }

    internal void Stop()
    {
        // Clip stopping belongs to the animation mixer; this state retains the source visibility flags only.
        Pause();
    }

    private void ApplyScreenCheck(Vector2 viewport)
    {
        if (!_isControllerEnabled || IsForced)
        {
            return;
        }
        // The recovered method widens float coordinates before comparing with double literals.
        bool isOutside = (double)viewport.X < MinimumViewportCoordinate ||
            (double)viewport.X > MaximumViewportCoordinate || (double)viewport.Y < MinimumViewportCoordinate ||
            (double)viewport.Y > MaximumViewportCoordinate;
        if (isOutside && IsInScreen)
        {
            IsInScreen = false;
            IsAnimationEnabled = false;
        }
        else if (!isOutside && !IsInScreen)
        {
            IsInScreen = true;
            IsAnimationEnabled = true;
        }
    }

    private static void ValidateViewport(Vector2 viewport)
    {
        if (!float.IsFinite(viewport.X) || !float.IsFinite(viewport.Y))
        {
            throw new InvalidDataException("Animation visibility requires a finite host viewport projection.");
        }
    }
}
