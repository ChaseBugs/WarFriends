using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>Invokes recovered corner animation methods on a disabled, explicitly wired probe controller.</summary>
public sealed class UnityCoopCornerVolleyProbe
{
    private const float InitialHideSeconds = 0.7f;
    private const float RoundHideSeconds = 0.5f;
    private const int CaptureRate = 30;
    private static readonly int[] RoundTicks = { 18, 24, 43 };
    private readonly SoldierAnimationController _controller;
    private readonly bool _isRightSide;
    private readonly MethodInfo _update;
    private int _nextRound;

    /// <summary>Retains real Animation evaluation while isolating source methods from normal gameplay startup.</summary>
    public UnityCoopCornerVolleyProbe(Animation animation, bool isRightSide)
    {
        var holder = new GameObject("InactiveSourceCornerAnimationProbe");
        holder.SetActive(false);
        _controller = holder.AddComponent<SoldierAnimationController>();
        _controller.enabled = false;
        _isRightSide = isRightSide;
        SetField("mAnimation", animation);
        SetField("mEnabled", true);
        SetField("mForceInScreen", true);
        _update = typeof(SoldierAnimationController).GetMethod("Update",
            BindingFlags.Instance | BindingFlags.NonPublic);
        if (_update == null)
        {
            throw new InvalidOperationException("The recovered animation Update is absent.");
        }

        animation.Stop();
        SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
        animation.Play("idle");
        animation["idle"].normalizedTime = 0.5f;
        animation.Sample();
        Shoot(InitialHideSeconds);
    }

    /// <summary>Runs source timer handling before the fixture's scheduled round notifications.</summary>
    public object Advance(float seconds)
    {
        _update.Invoke(_controller, null);
        var events = new List<object>();
        int tick = Mathf.RoundToInt(seconds * CaptureRate);
        while (_nextRound < RoundTicks.Length && tick >= RoundTicks[_nextRound])
        {
            int scheduledTick = RoundTicks[_nextRound];
            Shoot(RoundHideSeconds);
            events.Add(new { kind = "source-shot-notification", scheduledTick, observedTick = tick });
            _nextRound++;
        }

        return new { tick, events };
    }

    /// <summary>Invokes the source per-round animation notification without advancing the observation clock.</summary>
    public void NotifyRound()
    {
        Shoot(RoundHideSeconds);
    }

    private void Shoot(float hideSeconds)
    {
        // The recovered public overload reverses the Boolean before choosing its private CoverSide.
        _controller.ShotFromCover(!_isRightSide, 1f, hideSeconds, false, Weapon.WeaponType.Riffle);
    }

    private void SetField(string name, object value)
    {
        FieldInfo field = typeof(SoldierAnimationController).GetField(name,
            BindingFlags.Instance | BindingFlags.NonPublic);
        if (field == null)
        {
            throw new InvalidOperationException("Missing recovered animation field: " + name);
        }

        field.SetValue(_controller, value);
    }
}
