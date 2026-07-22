using System;
using UnityEngine;

namespace WarFriends.Legacy
{
    // Support for the recovered singleton accessors. The AssetRipper-decompiled managers use the
    // pattern `mInstance ?? (mInstance = (T)FindObjectsOfType(typeof(T))[0])`, which throws
    // IndexOutOfRangeException whenever the manager GameObject is not present in the loaded scene
    // (e.g. a battle scene entered without the bootstrap that normally spawns it). The patcher's
    // --guard-singleton-instance pass rewrites that `FindObjectsOfType(type)[0]` into a call here,
    // so a missing manager is lazily created instead of crashing, and downstream callers receive a
    // valid instance instead of a null they would dereference.
    public static class SingletonSupport
    {
        public static UnityEngine.Object FindOrCreate(Type type)
        {
            if (type == null)
            {
                return null;
            }

            UnityEngine.Object[] existing = UnityEngine.Object.FindObjectsOfType(type);
            if (existing != null && existing.Length > 0)
            {
                return existing[0];
            }

            if (typeof(Component).IsAssignableFrom(type))
            {
                GameObject host = new GameObject(type.Name);
                return host.AddComponent(type);
            }

            if (typeof(ScriptableObject).IsAssignableFrom(type))
            {
                return ScriptableObject.CreateInstance(type);
            }

            return null;
        }

        // Safe replacement for `GetComponents/GetComponentsInChildren<T>(...)[0]`. Those accessors
        // (e.g. GameCamera.get_camera indexing a child Camera that no longer exists in the recovered
        // scene) throw IndexOutOfRangeException on an empty result. This returns the first element or
        // null, letting the caller's existing field/return simply stay null instead of crashing.
        public static UnityEngine.Object FirstOrDefault(UnityEngine.Object[] items)
        {
            return items != null && items.Length > 0 ? items[0] : null;
        }

        // NGUI's UIPanel/UIDrawCall run under [ExecuteInEditMode], so opening a scene in the editor
        // triggers UIPanel.LateUpdate -> GetDrawCall, which calls Object.DontDestroyOnLoad on a freshly
        // created draw-call object. DontDestroyOnLoad throws InvalidOperationException outside play mode.
        // The patcher's --guard-dont-destroy-on-load pass routes every DontDestroyOnLoad through here so
        // it is a no-op in edit mode and behaves identically to the original in play mode / builds.
        public static void DontDestroyOnLoadIfPlaying(UnityEngine.Object target)
        {
            if (target != null && Application.isPlaying)
            {
                UnityEngine.Object.DontDestroyOnLoad(target);
            }
        }
    }
}
