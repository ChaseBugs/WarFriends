using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Wires only recovered sound and particle services into an isolated Play Mode scene.</summary>
public sealed class UnityBazookaEffectFixture
{
    private const string RootName = "RecoveredBazookaEffectFixture";
    private const int AudioSourceCount = 4;
    private const int ExplosionParticleIndex = 3;
    private readonly SoundsManager3D _sounds;
    private readonly HitParticleSystem _particles;
    private readonly SpawnPool _pool;

    private UnityBazookaEffectFixture(SoundsManager3D sounds, HitParticleSystem particles)
    {
        _sounds = sounds;
        _particles = particles;
        _pool = particles.spawnPool;
    }

    /// <summary>Preserves source sound entries, AudioSource settings and both source particle lists.</summary>
    public static void PrepareScene()
    {
        PrepareScene(null);
    }

    /// <summary>Allows another native audit to preserve source-only scene dependencies before isolation.</summary>
    public static void PrepareScene(Action<GameObject, Component[]> prepareAdditionalSources)
    {
        var sourceScene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        Component[] components = sourceScene.GetRootGameObjects()
            .SelectMany(sceneRoot => sceneRoot.GetComponentsInChildren<Component>(true)).ToArray();
        SoundsManager3D sourceSounds = components.OfType<SoundsManager3D>().Single();
        HitParticleSystem sourceParticles = components.OfType<HitParticleSystem>().Single();
        GameObject root = new GameObject(RootName);
        root.SetActive(false);
        PrepareAudio(root, sourceSounds);
        PrepareParticles(root, sourceParticles);
        GameObject volume = Child(root, "InactiveVolumeProvider");
        volume.SetActive(false);
        volume.AddComponent<SoundsManager>().data = new SoundsManager.SoundSettingsSerialized();
        GameObject performance = Child(root, "InactiveQualityProvider");
        performance.SetActive(false);
        performance.AddComponent<PerformanceManager>();
        if (prepareAdditionalSources != null)
        {
            prepareAdditionalSources(root, components);
        }

        var emptyScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        Type manager = emptyScene.GetType().Assembly.GetType("UnityEngine.SceneManagement.SceneManager", true);
        manager.GetMethod("MoveGameObjectToScene", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new object[] { root, emptyScene });
        manager.GetMethod("SetActiveScene", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new object[] { emptyScene });
        EditorSceneManager.CloseScene(sourceScene, true);
    }

    /// <summary>
    /// Activates actual source service Awakes while avoiding music, storage and retired boot services.
    /// </summary>
    public static UnityBazookaEffectFixture StartServices()
    {
        GameObject root = Resources.FindObjectsOfTypeAll<Transform>()
            .Single(row => row.name == RootName && row.gameObject.scene.IsValid()).gameObject;
        SoundsManager volume = root.transform.Find("InactiveVolumeProvider").GetComponent<SoundsManager>();
        volume.data = new SoundsManager.SoundSettingsSerialized();
        typeof(SoundsManager).GetField("mInstance", BindingFlags.NonPublic | BindingFlags.Static)
            .SetValue(null, volume);
        PerformanceManager performance = root.transform.Find("InactiveQualityProvider")
            .GetComponent<PerformanceManager>();
        performance.performance = Performance.Best;
        typeof(Singleton<PerformanceManager>).GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static)
            .SetValue(null, performance);
        root.SetActive(true);
        SoundsManager3D sounds = root.transform.Find("SourceAudio3D").GetComponent<SoundsManager3D>();
        sounds.LoadNow(Sounds3DEnum.ExplosionMedium);
        sounds.LoadNow(Sounds3DEnum.ExplosionSmall);
        HitParticleSystem particles = root.transform.Find("SourceHitParticles").GetComponent<HitParticleSystem>();
        return new UnityBazookaEffectFixture(sounds, particles);
    }

    /// <summary>The original source increments this cursor only when dispatching an AudioSource.</summary>
    public int AudioCursor
    {
        get
        {
            return (int)typeof(SoundsManager3D).GetField("mCurrentIndex",
                BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_sounds);
        }
    }

    /// <summary>Reports actual spawned source particle roots.</summary>
    public int ParticleCount { get { return _pool.Count; } }

    /// <summary>Injects a recoverable failure after sound dispatch and before particle spawning.</summary>
    public void SuspendParticlePool()
    {
        SetParticlePool(null);
    }

    /// <summary>Restores the same source pool for callback replay.</summary>
    public void ResumeParticlePool()
    {
        SetParticlePool(_pool);
    }

    /// <summary>Checks original clip membership, volume, position and particle activation.</summary>
    public void VerifyEffect(int index, Sounds3DEnum sound, Vector3 position)
    {
        VerifyAudio(index, sound, position);
        VerifyParticle(_pool[index], position);
    }

    /// <summary>Captures the actual latest source spawn even when the pool has reused an earlier effect.</summary>
    public ParticleSystem CaptureLatestEffect(Sounds3DEnum sound, Vector3 position)
    {
        int audioIndex = (AudioCursor + AudioSourceCount - 1) % AudioSourceCount;
        VerifyAudio(audioIndex, sound, position);
        Transform effect = _pool.Last();
        VerifyParticle(effect, position);
        return effect.GetComponent<ParticleSystem>();
    }

    /// <summary>Returns the next cursor in the original bounded AudioSource bank.</summary>
    public int NextAudioCursor(int current)
    {
        return (current + 1) % AudioSourceCount;
    }

    private void VerifyAudio(int index, Sounds3DEnum sound, Vector3 position)
    {
        AudioSource source = _sounds.audioSourcesParent.GetComponentsInChildren<AudioSource>()[index];
        SoundEntry entry = _sounds.SoundEntries.Single(row => row.soundEnum == sound);
        var clips = (AudioClip[])typeof(SoundEntry).GetField("mClips",
            BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry);
        var single = (AudioClip)typeof(SoundEntry).GetField("mClip",
            BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry);
        Require(source.clip != null && (source.clip == single || (clips != null && clips.Contains(source.clip))),
            "The actual AudioSource must select a recovered clip: actual=" + source.clip +
            ", single=" + single + ", alternatives=" + (clips == null ? -1 : clips.Length) +
            ", resource=" + Resources.Load<AudioClip>("Sounds/SFX/game/New/EXPLOSION_MEDIUM") + ".");
        Require(source.transform.position == position && source.spatialBlend == 1f && source.volume == entry.volume,
            "The original 3D sound position and source volume must be preserved.");
    }

    private static void VerifyParticle(Transform effect, Vector3 position)
    {
        Require(Vector3.Distance(effect.position, position + Vector3.up * 0.2f) < 0.0001f,
            "The original particle offset must be preserved.");
        Require(effect.GetComponent<ParticleSystem>().isPlaying,
            "The actual recovered particle system must be started.");
    }

    /// <summary>Observes emitted CPU particles after automatic Unity simulation frames.</summary>
    public bool HasSimulatedParticles()
    {
        return _pool.All(root => root.GetComponentsInChildren<ParticleSystem>(true).Sum(row => row.particleCount) > 0);
    }

    private void SetParticlePool(SpawnPool pool)
    {
        typeof(HitParticleSystem).GetField("mSpawnPool", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(_particles, pool);
    }

    private static void PrepareAudio(GameObject root, SoundsManager3D source)
    {
        SoundsManager3D target = Child(root, "SourceAudio3D").AddComponent<SoundsManager3D>();
        EditorUtility.CopySerialized(source, target);
        GameObject sources = Child(target.gameObject, "AudioSources");
        AudioSource[] original = source.audioSourcesParent.GetComponentsInChildren<AudioSource>(true);
        Require(original.Length >= AudioSourceCount, "The source AudioSource bank is incomplete.");
        for (int index = 0; index < AudioSourceCount; index++)
        {
            AudioSource copy = Child(sources, "Source" + index).AddComponent<AudioSource>();
            EditorUtility.CopySerialized(original[index], copy);
        }

        target.audioSourcesParent = sources;
    }

    private static void PrepareParticles(GameObject root, HitParticleSystem source)
    {
        HitParticleSystem target = Child(root, "SourceHitParticles").AddComponent<HitParticleSystem>();
        EditorUtility.CopySerialized(source, target);
        target.normalSpawnPool = NewPool(target.gameObject, "AuditNormalPool");
        target.metalSpawnPool = NewPool(target.gameObject, "AuditMetalPool");
        Require(
            target.allMetalHitParticlesPrefabs[ExplosionParticleIndex].particleType == HitParticles.ParticleType.Other,
            "The source explosion particle is not a blood effect.");
    }

    private static SpawnPool NewPool(GameObject parent, string name)
    {
        GameObject root = Child(parent, name);
        root.SetActive(false);
        return root.AddComponent<SpawnPool>();
    }

    private static GameObject Child(GameObject parent, string name)
    {
        GameObject child = new GameObject(name);
        child.transform.SetParent(parent.transform, false);
        return child;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
