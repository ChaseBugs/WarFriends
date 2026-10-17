using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Uses original turret preparation types and serialized visual definitions without combat activation.
/// </summary>
public sealed class UnityInitialTurretFixture : IDisposable
{
    private const BindingFlags StaticFields = BindingFlags.Static | BindingFlags.NonPublic;
    private const BindingFlags InstanceFields = BindingFlags.Instance | BindingFlags.NonPublic;
    private readonly ObjectPoolDatabase _database;
    private readonly SoundsManager3D _sounds;
    private readonly object _previousDatabase;
    private readonly object _previousSounds;
    private readonly object _previousSoundLookup;
    private readonly TurretRockets _previousRocket;
    private readonly HeavyTurret _previousHeavy;
    private readonly GameObject _carriers;
    private readonly List<LevelBehaviour> _levels = new List<LevelBehaviour>();

    /// <summary>Copies source component data and keeps the original turret carriers inactive.</summary>
    public UnityInitialTurretFixture()
    {
        _database = Resources.FindObjectsOfTypeAll<ObjectPoolDatabase>()
            .Single(value => value.gameObject.scene.IsValid());
        _sounds = Resources.FindObjectsOfTypeAll<SoundsManager3D>()
            .Single(value => value.gameObject.scene.IsValid());
        _previousDatabase = typeof(Singleton<ObjectPoolDatabase>).GetField("_instance", StaticFields).GetValue(null);
        _previousSounds = typeof(Singleton<SoundsManager3D>).GetField("_instance", StaticFields).GetValue(null);
        _previousSoundLookup = typeof(SoundsManager3D).GetField("mAllSounds", InstanceFields).GetValue(_sounds);
        _previousRocket = _database.turretRockets;
        _previousHeavy = _database.heavyTurret;
        Require(_previousRocket != null && _previousHeavy != null, "The original turret carriers are missing.");
        _carriers = new GameObject("InactiveOriginalTurretCarriers");
        _carriers.SetActive(false);
        var rocket = UnityEngine.Object.Instantiate(_previousRocket, _carriers.transform);
        var heavy = UnityEngine.Object.Instantiate(_previousHeavy, _carriers.transform);
        rocket.preparedBehaviour = CopyPreparedVisual<TurretRocketsBehaviour>();
        heavy.preparedBehaviour = CopyPreparedVisual<HeavyTurretBehaviour>();
        _database.turretRockets = rocket;
        _database.heavyTurret = heavy;
        typeof(Singleton<ObjectPoolDatabase>).GetField("_instance", StaticFields).SetValue(null, _database);
        typeof(Singleton<SoundsManager3D>).GetField("_instance", StaticFields).SetValue(null, _sounds);
        typeof(SoundsManager3D).GetField("mAllSounds", InstanceFields)
            .SetValue(_sounds, new Dictionary<Sounds3DEnum, SoundsManager3D.SoundEntry3D>());
    }

    /// <summary>Clears only the original opponent card-visual texture caches.</summary>
    public void ClearVisuals()
    {
        foreach (LevelBehaviour level in _levels)
        {
            level.upgradeSlots.NullCardVisuals(false, true);
        }
    }

    /// <summary>Requires cancellation to retain empty texture caches for both actual turret types.</summary>
    public void RequireCleared()
    {
        foreach (LevelBehaviour level in _levels)
        {
            Require(level.upgradeSlots.cardVisuals.All(visual => visual.materialTetxureRed == null),
                "A cancelled original turret loader repopulated visuals: " + level.GetType().Name);
        }
    }

    /// <summary>Requires every nonempty original opponent texture path to resolve through the source loader.</summary>
    public void RequireLoaded()
    {
        foreach (LevelBehaviour level in _levels)
        {
            Require(level.upgradeSlots.cardVisuals.Count > 0, "The source turret has no card visual definitions.");
            int resolved = 0;
            foreach (TechnologyVisualDefinition visual in level.upgradeSlots.cardVisuals)
            {
                if (!string.IsNullOrEmpty(visual.materialTextrePathRed))
                {
                    Require(visual.materialTetxureRed != null,
                        "The original turret texture did not resolve: " + visual.materialTextrePathRed);
                    resolved++;
                }
            }
            Require(resolved > 0, "No original opponent texture path was exercised for " + level.GetType().Name);
            Debug.Log("PASS: source turret visual definitions loaded: " + level.GetType().Name +
                " / " + level.upgradeSlots.GetType().Name + " / " + resolved + " texture rows.");
        }
    }

    /// <summary>Restores source providers and leaves fixture clones inactive.</summary>
    public void Dispose()
    {
        foreach (LevelBehaviour level in _levels)
        {
            level.StopAllCoroutines();
            level.upgradeSlots.StopAllCoroutines();
            level.gameObject.SetActive(false);
        }
        _carriers.SetActive(false);
        _database.turretRockets = _previousRocket;
        _database.heavyTurret = _previousHeavy;
        typeof(SoundsManager3D).GetField("mAllSounds", InstanceFields).SetValue(_sounds, _previousSoundLookup);
        typeof(Singleton<ObjectPoolDatabase>).GetField("_instance", StaticFields).SetValue(null, _previousDatabase);
        typeof(Singleton<SoundsManager3D>).GetField("_instance", StaticFields).SetValue(null, _previousSounds);
    }

    private LevelBehaviour CopyPreparedVisual<T>() where T : LevelBehaviour
    {
        LevelBehaviourManager manager = Resources.FindObjectsOfTypeAll<LevelBehaviourManager>()
            .Single(value => value.gameObject.scene.IsValid());
        int[] counts = manager.levelBehaviours.Select(entry => entry.count).ToArray();
        try
        {
            return CopyVisualComponents(manager.GetPreparedBehaviour<T>());
        }
        finally
        {
            for (int index = 0; index < counts.Length; index++)
            {
                manager.levelBehaviours[index].count = counts[index];
            }
        }
    }

    private LevelBehaviour CopyVisualComponents(LevelBehaviour source)
    {
        Require(source != null && source.upgradeSlots != null, "The original prepared turret behaviour is missing.");
        var root = new GameObject("OriginalTurretVisual_" + source.GetType().Name);
        root.SetActive(false);
        var level = (LevelBehaviour)root.AddComponent(source.GetType());
        var slots = (UpgradeSlots)root.AddComponent(source.upgradeSlots.GetType());
        EditorUtility.CopySerialized(source, level);
        EditorUtility.CopySerialized(source.upgradeSlots, slots);
        level.upgradeSlots = slots;
        _levels.Add(level);
        root.SetActive(true);
        return level;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
