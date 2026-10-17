using System;
using System.Reflection;
using UnityEngine;

/// <summary>Wires the recovered obstacle method without earlier idle or corner shot commands.</summary>
public sealed class UnityCoopObstacleOnlyProbe
{
    private const float RoundHideSeconds = 0.5f;
    private readonly SoldierAnimationController _controller;

    /// <summary>Creates an inactive controller without running its lifecycle or other animation branches.</summary>
    public UnityCoopObstacleOnlyProbe(Animation source)
    {
        var holder = new GameObject("InactiveObstacleOnlyController");
        holder.SetActive(false);
        _controller = holder.AddComponent<SoldierAnimationController>();
        _controller.enabled = false;
        FieldInfo animation = typeof(SoldierAnimationController).GetField("mAnimation",
            BindingFlags.Instance | BindingFlags.NonPublic);
        if (animation == null)
        {
            throw new InvalidOperationException("The recovered animation binding is absent.");
        }
        animation.SetValue(_controller, source);
    }

    /// <summary>Invokes only the real obstacle notification at the declared source round parameters.</summary>
    public void NotifyObstacleRound()
    {
        _controller.ShootFromCrawl(RoundHideSeconds, 1f, Weapon.WeaponType.Riffle);
    }
}
