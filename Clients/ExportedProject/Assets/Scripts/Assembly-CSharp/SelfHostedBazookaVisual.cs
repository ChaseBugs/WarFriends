using System;
using System.Collections.Generic;
using UnityEngine;
using War.Shared;

/// <summary>Copies recovered missile presentation without activating its combat or Photon components.</summary>
public static class SelfHostedBazookaVisual
{
    private const float NormalTrailSize = 0.2f;
    private const float SmallTrailSize = 0.08f;
    private const string VisualResourceName = "SelfHostedPlayerMissileVisual";
    private static readonly Vector3 NormalModelScale = new Vector3(1f, 1f, 1.4f);

    /// <summary>Uses launch identity even when the owner has changed weapons during flight.</summary>
    public static GameObject Create(WeaponInventory inventory, string sourceId, string objectName)
    {
        Weapon weapon = ResolveWeapon(inventory, sourceId);
        Missile source = weapon.bulletPrefab as Missile;
        MissileSetup setup = weapon.ammoSetup as MissileSetup;
        if (source == null || setup == null || source.trail == null || source.particles == null ||
            source.trail.transform != source.transform)
        {
            throw new InvalidOperationException("Recovered player missile presentation is incomplete.");
        }

        GameObject prefab = Resources.Load<GameObject>(VisualResourceName);
        ValidateVisualPrefab(prefab);
        GameObject root = UnityEngine.Object.Instantiate(prefab);
        root.name = objectName;
        try
        {
            ConfigureAppearance(source, setup, root.transform);
            ConfigureTrail(root.GetComponent<TrailRenderer>(), setup.missileType == MissileSetup.MissileType.Small);
            ParticleSystem particles = FindCopy(source, source.particles.gameObject, root.transform)
                .GetComponent<ParticleSystem>();
            particles.Clear();
            particles.Play();
            return root;
        }
        catch
        {
            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(root);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
            throw;
        }
    }

    /// <summary>Resolves the original seven inventory slots without reading currentWeapon.</summary>
    public static Weapon ResolveWeapon(WeaponInventory inventory, string sourceId)
    {
        int index;
        if (!BazookaSourceIdentity.TryGetInventoryIndex(sourceId, out index) || inventory == null ||
            inventory.allWeapons == null || index >= inventory.allWeapons.Count || inventory.allWeapons[index] == null)
        {
            throw new InvalidOperationException(
                "The launch-time bazooka source is absent from the recovered inventory.");
        }

        Weapon weapon = inventory.allWeapons[index].GetComponent<Weapon>();
        if (!(weapon is Bazooka) || !(weapon.bulletPrefab is Missile) || !(weapon.ammoSetup is MissileSetup))
        {
            throw new InvalidOperationException("The recovered bazooka slot has an incompatible weapon or missile.");
        }

        return weapon;
    }

    /// <summary>Matches Missile.TryKill, including visual explosions for harmless M202 missiles.</summary>
    public static Explosion.ExplosionType ExplosionTypeFor(string sourceId)
    {
        int index;
        if (!BazookaSourceIdentity.TryGetInventoryIndex(sourceId, out index))
        {
            throw new InvalidOperationException("Unknown bazooka explosion source.");
        }

        return sourceId == "Google2u.Bazooka_M202" ? Explosion.ExplosionType.Small : Explosion.ExplosionType.Medium;
    }

    private static void ValidateVisualPrefab(GameObject prefab)
    {
        if (prefab == null || prefab.GetComponent<TrailRenderer>() == null)
        {
            throw new InvalidOperationException("The reviewed script-free player missile visual is absent.");
        }

        foreach (Component component in prefab.GetComponentsInChildren<Component>(true))
        {
            Animator animator = component as Animator;
            if (component is Transform || component is MeshFilter || component is MeshRenderer ||
                component is ParticleSystem || component is ParticleSystemRenderer || component is TrailRenderer ||
                (animator != null && animator.runtimeAnimatorController == null))
            {
                continue;
            }

            throw new InvalidOperationException("Missile visual contains an unreviewed component.");
        }
    }

    private static void ConfigureAppearance(Missile source, MissileSetup setup, Transform root)
    {
        bool isSmall = setup.missileType == MissileSetup.MissileType.Small;
        Transform model = FindCopy(source, source.projectileModel, root);
        model.gameObject.SetActive(true);
        model.localScale = NormalModelScale * (isSmall ? 0.5f : 1f);
        FindCopy(source, source.smallParticles, root).gameObject.SetActive(isSmall);
        FindCopy(source, source.bigParticles, root).gameObject.SetActive(!isSmall);
        FindCopy(source, source.burningSmokeParticles, root).gameObject.SetActive(
            setup.missileType == MissileSetup.MissileType.RpgBold);
    }

    private static Transform FindCopy(Missile source, GameObject sourcePart, Transform root)
    {
        if (sourcePart == null)
        {
            throw new InvalidOperationException("A recovered missile visual binding is unassigned.");
        }

        var path = new List<string>();
        Transform current = sourcePart.transform;
        while (current != null && current != source.transform)
        {
            path.Add(current.name);
            current = current.parent;
        }

        if (current != source.transform || path.Count == 0)
        {
            throw new InvalidOperationException("A missile visual binding is outside its source hierarchy.");
        }

        path.Reverse();
        Transform copy = root.Find(string.Join("/", path.ToArray()));
        if (copy == null)
        {
            throw new InvalidOperationException("A copied missile visual binding is absent.");
        }

        return copy;
    }

    private static void ConfigureTrail(TrailRenderer trail, bool isSmall)
    {
        float size = isSmall ? SmallTrailSize : NormalTrailSize;
        trail.startWidth = size;
        trail.endWidth = size;
        trail.time = size;
        trail.autodestruct = false;
    }
}
