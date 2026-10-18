using System;
using UnityEngine;

/// <summary>Moves a copied source snapPoint without enabling recovered weapon, physics or Photon components.</summary>
public sealed class SelfHostedGunslingerWeaponAttachment
{
    private readonly Transform _snapPoint;
    private readonly Transform _handSocket;
    private readonly Transform _holsterSocket;
    private readonly GameObject _rigidBody;

    /// <summary>Gets whether the copied weapon is currently attached to the source holster socket.</summary>
    public bool IsHolstered { get; private set; }

    private SelfHostedGunslingerWeaponAttachment(Transform snapPoint, Transform handSocket,
        Transform holsterSocket, GameObject rigidBody)
    {
        _snapPoint = snapPoint;
        _handSocket = handSocket;
        _holsterSocket = holsterSocket;
        _rigidBody = rigidBody;
    }

    /// <summary>Binds the exact source weapon swapper and soldier socket to a script-free visual copy.</summary>
    public static SelfHostedGunslingerWeaponAttachment Bind(EnemyController source,
        SelfHostedInfantryWeaponAppearance appearance, SelfHostedInfantryVisual visual)
    {
        if (source == null || appearance == null || appearance.UnitId != "ID_UNIT-GUNSLINGER" ||
            visual == null || visual.Root == null || visual.WeaponRoot == null || appearance.WeaponPrefab == null ||
            visual.WeaponRoot == appearance.WeaponPrefab.transform ||
            !visual.WeaponRoot.IsChildOf(visual.Root.transform) ||
            visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new ArgumentException("A recovered source and script-free copied weapon visual are required.");
        }

        SoldierParts parts = source.GetComponentInChildren<SoldierParts>(true);
        FakeRigidBodySwapper swapper = appearance.WeaponPrefab.GetComponent<FakeRigidBodySwapper>();
        if (parts == null || parts.coltSnap == null || swapper == null || swapper.snapPoint == null ||
            swapper.NoRigidBodyObject == null || swapper.RigidBodyObject == null)
        {
            throw new InvalidOperationException("Recovered Colt attachment identities are incomplete.");
        }

        Transform rig = visual.Root.transform.Find("Rig");
        Transform weapon = appearance.WeaponPrefab.transform;
        Transform snap = SelfHostedVisualHierarchy.ResolveCopy(weapon, swapper.snapPoint.transform, visual.WeaponRoot);
        Transform hand = SelfHostedVisualHierarchy.ResolveCopy(weapon, swapper.NoRigidBodyObject.transform,
            visual.WeaponRoot);
        Transform rigid = SelfHostedVisualHierarchy.ResolveCopy(weapon, swapper.RigidBodyObject.transform,
            visual.WeaponRoot);
        Transform holster = SelfHostedVisualHierarchy.ResolveCopy(source.transform, parts.coltSnap, rig);
        return new SelfHostedGunslingerWeaponAttachment(snap, hand, holster, rigid.gameObject);
    }

    /// <summary>Applies the source SnapTo(coltSnap) attachment without moving the whole weapon root.</summary>
    public void Holster()
    {
        MoveSnapPoint(_holsterSocket);
        IsHolstered = true;
    }

    /// <summary>Applies source Swap(false), retaining the selected mesh, pivot and model scale.</summary>
    public void Draw()
    {
        if (_rigidBody == null || _handSocket == null)
        {
            throw new InvalidOperationException("The copied weapon attachment has been destroyed.");
        }

        _rigidBody.SetActive(false);
        _handSocket.gameObject.SetActive(true);
        MoveSnapPoint(_handSocket);
        IsHolstered = false;
    }

    private void MoveSnapPoint(Transform destination)
    {
        if (_snapPoint == null || destination == null)
        {
            throw new InvalidOperationException("The copied source snapPoint or destination has been destroyed.");
        }

        _snapPoint.SetParent(destination, false);
        _snapPoint.localPosition = Vector3.zero;
        _snapPoint.localRotation = Quaternion.identity;
        _snapPoint.localScale = Vector3.one;
    }
}
