using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>Preserves recovered binding data while keeping original boot and input writers inactive.</summary>
public static class UnityLiveBazookaPlayScene
{
    private const string RootName = "LiveBazookaSourceComponents";

    /// <summary>Builds the disposable scene before Play Mode reloads managed state.</summary>
    public static void Prepare()
    {
        UnityBazookaEffectFixture.PrepareScene(PreserveSources);
    }

    /// <summary>Binds inactive source providers without running legacy boot or combat authority.</summary>
    public static GameObject BindSources()
    {
        GameObject root = Resources.FindObjectsOfTypeAll<Transform>()
            .Single(row => row.name == RootName && row.gameObject.scene.IsValid()).gameObject;
        BindSingleton(root.GetComponentsInChildren<LevelBehaviourManager>(true).Single());
        BindSingleton(root.GetComponentsInChildren<ObjectPoolDatabase>(true).Single());
        GameController controller = root.GetComponentsInChildren<GameController>(true).Single();
        BindSingleton(controller);
        // Typed commands drive this fixture; it does not exercise recovered touch input or game boot.
        typeof(GameController).GetField("mGameIsRunning", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(controller, false);
        return root;
    }

    private static void PreserveSources(GameObject parent, Component[] components)
    {
        GameObject root = new GameObject(RootName);
        root.SetActive(false);
        root.transform.SetParent(parent.transform, false);
        PlayerController original = components.OfType<GameController>().Single().mainPlayerController;
        // Unit and pool references target scene objects, so retain their original graph while boot stays inactive.
        foreach (GameObject source in original.gameObject.scene.GetRootGameObjects())
        {
            if (source != parent)
            {
                source.transform.SetParent(root.transform, false);
            }
        }

        PreserveRig(root, original, "LiveBazookaLeft");
        PreserveRig(root, original, "LiveBazookaRight");
    }

    private static void PreserveRig(GameObject parent, PlayerController original, string name)
    {
        bool wasActive = original.gameObject.activeSelf;
        original.gameObject.SetActive(false);
        GameObject copy = UnityEngine.Object.Instantiate(original.gameObject, parent.transform);
        original.gameObject.SetActive(wasActive);
        copy.name = name;
        copy.SetActive(false);
        foreach (MonoBehaviour behaviour in copy.GetComponentsInChildren<MonoBehaviour>(true))
        {
            behaviour.enabled = false;
        }
    }

    private static void BindSingleton<T>(T source) where T : Core_BaseScript
    {
        if (source == null)
        {
            throw new InvalidOperationException("A recovered Play Mode binding provider is absent.");
        }

        typeof(Singleton<T>).GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static)
            .SetValue(null, source);
    }
}
