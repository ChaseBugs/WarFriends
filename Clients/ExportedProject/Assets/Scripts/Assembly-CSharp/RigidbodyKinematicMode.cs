using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>Preserves dynamic CCD settings while kinematic bodies use supported discrete collision.</summary>
public static class RigidbodyKinematicMode
{
    private sealed class DynamicCollision
    {
        public CollisionDetectionMode Mode;
    }

    private static readonly ConditionalWeakTable<Rigidbody, DynamicCollision> SavedModes =
        new ConditionalWeakTable<Rigidbody, DynamicCollision>();

    public static void Set(Rigidbody body, bool isKinematic)
    {
        if (isKinematic)
        {
            SavedModes.GetValue(body, key => new DynamicCollision { Mode = key.collisionDetectionMode });
            // Continuous CCD is unsupported for kinematic bodies in the recovered physics path.
            body.collisionDetectionMode = CollisionDetectionMode.Discrete;
            body.isKinematic = true;
            return;
        }

        body.isKinematic = false;
        DynamicCollision saved;
        if (SavedModes.TryGetValue(body, out saved))
        {
            body.collisionDetectionMode = saved.Mode;
        }
    }
}
