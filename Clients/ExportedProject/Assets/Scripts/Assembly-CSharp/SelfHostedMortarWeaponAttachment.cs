using System;

using UnityEngine;

/// <summary>Preserves recovered Mortar snap-point behavior without activating weapon or Photon components.</summary>
public sealed class SelfHostedMortarWeaponAttachment : IDisposable
{
    private const int PrimaryWeaponIndex = 0;
    private const float UnitTransformTolerance = 0.001f;
    private readonly Transform _snapPoint;
    private readonly Transform _handSocket;
    private readonly Transform _lifetimeRoot;
    private readonly GameObject _rigidBody;
    private bool _isDisposed;

    /// <summary>Gets whether the copied snap point currently retains a detached world pose.</summary>
    public bool IsDetached { get; private set; }

    private SelfHostedMortarWeaponAttachment(Transform snapPoint, Transform handSocket,
        Transform lifetimeRoot, GameObject rigidBody)
    {
        _snapPoint = snapPoint;
        _handSocket = handSocket;
        _lifetimeRoot = lifetimeRoot;
        _rigidBody = rigidBody;
    }

    /// <summary>Binds source identities after ordinary appearance and held-state restoration.</summary>
    public static SelfHostedMortarWeaponAttachment Bind(Weapon source,
        SelfHostedInfantryWeaponSet weapons, GameObject lifetimeRoot)
    {
        if (!(source is Mortar) || weapons == null || weapons.Roots.Count != 1 || lifetimeRoot == null ||
            !weapons.Roots[PrimaryWeaponIndex].transform.IsChildOf(lifetimeRoot.transform) ||
            lifetimeRoot.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new ArgumentException("A recovered Mortar and its script-free ordinary inventory are required.");
        }
        FakeRigidBodySwapper swapper = source.GetComponent<FakeRigidBodySwapper>();
        if (swapper == null || swapper.snapPoint == null || swapper.NoRigidBodyObject == null ||
            swapper.RigidBodyObject == null ||
            weapons.ResolveSource(PrimaryWeaponIndex, source.transform) != weapons.Roots[PrimaryWeaponIndex].transform)
        {
            throw new InvalidOperationException("Mortar attachment lost its source swapper identities.");
        }
        return new SelfHostedMortarWeaponAttachment(
            weapons.ResolveSource(PrimaryWeaponIndex, swapper.snapPoint.transform),
            weapons.ResolveSource(PrimaryWeaponIndex, swapper.NoRigidBodyObject.transform),
            lifetimeRoot.transform,
            weapons.ResolveSource(PrimaryWeaponIndex, swapper.RigidBodyObject.transform).gameObject);
    }

    /// <summary>Preserves the current world pose exactly as the source SetParent call does.</summary>
    public void Detach()
    {
        EnsureUsable();
        if (IsDetached)
        {
            return;
        }
        _snapPoint.SetParent(null, true);
        IsDetached = true;
    }

    /// <summary>Restores a validated host capture without depending on the receiver's current hand pose.</summary>
    public void ApplyWorldPose(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        EnsureUsable();
        float length = rotation.x * rotation.x + rotation.y * rotation.y +
            rotation.z * rotation.z + rotation.w * rotation.w;
        if (!Finite(position.x) || !Finite(position.y) || !Finite(position.z) ||
            !Finite(rotation.x) || !Finite(rotation.y) || !Finite(rotation.z) || !Finite(rotation.w) ||
            Mathf.Abs(length - 1f) > UnitTransformTolerance || !Finite(scale.x) || !Finite(scale.y) || !Finite(scale.z) ||
            Mathf.Abs(scale.x - 1f) > UnitTransformTolerance || Mathf.Abs(scale.y - 1f) > UnitTransformTolerance ||
            Mathf.Abs(scale.z - 1f) > UnitTransformTolerance)
        {
            throw new ArgumentException("A finite source-unit Mortar world transform is required.");
        }
        _snapPoint.SetParent(null, true);
        _snapPoint.position = position;
        _snapPoint.rotation = rotation;
        _snapPoint.localScale = scale;
        IsDetached = true;
    }

    /// <summary>Applies source Swap(false), restoring the source hand with its identity local pose.</summary>
    public void RestoreHand()
    {
        EnsureUsable();
        _rigidBody.SetActive(false);
        _handSocket.gameObject.SetActive(true);
        _snapPoint.SetParent(_handSocket, false);
        _snapPoint.localPosition = Vector3.zero;
        _snapPoint.localRotation = Quaternion.identity;
        _snapPoint.localScale = Vector3.one;
        IsDetached = false;
    }

    /// <summary>Returns detached geometry to its owner before the owner destroys the copied actor.</summary>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }
        if (_snapPoint != null && IsDetached)
        {
            if (_lifetimeRoot != null)
            {
                _snapPoint.SetParent(_lifetimeRoot, true);
            }
            else if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(_snapPoint.gameObject);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(_snapPoint.gameObject);
            }
        }
        IsDetached = false;
        _isDisposed = true;
    }

    private void EnsureUsable()
    {
        if (_isDisposed || _snapPoint == null || _handSocket == null || _rigidBody == null || _lifetimeRoot == null)
        {
            throw new InvalidOperationException("The copied Mortar attachment has been disposed or destroyed.");
        }
    }

    private static bool Finite(float value)
    {
        return !float.IsNaN(value) && !float.IsInfinity(value);
    }
}
