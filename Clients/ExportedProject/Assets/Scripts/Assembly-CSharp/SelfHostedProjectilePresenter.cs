using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Presentation only. The Worker owns trajectory, collision and damage; these
// objects contain copied recovered meshes and no gameplay or Photon scripts.
public sealed class SelfHostedProjectilePresenter : MonoBehaviour
{
	private sealed class Visual
	{
		public readonly GameObject Root;
		public Visual(GameObject root) { Root = root; }
	}

	private readonly Dictionary<ulong, Visual> active = new Dictionary<ulong, Visual>();
	private PlayerController local;
	private PlayerController other;

	public void Configure(PlayerController localPlayer, PlayerController otherPlayer)
	{
		local = localPlayer;
		other = otherPlayer;
	}

	public void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null) return;
		HashSet<ulong> present = new HashSet<ulong>();
		foreach (BattleProjectileState state in snapshot.Projectiles)
		{
			if (state.Kind != "grenade" && state.Kind != "grenade-molotov" && state.Kind != "heavy-turret-bullet") continue;
			present.Add(state.ProjectileId);
			Visual visual;
			if (!active.TryGetValue(state.ProjectileId, out visual))
			{
				visual = Create(state.OwnerPlayerId, state.ProjectileId, state.Kind);
				active.Add(state.ProjectileId, visual);
			}
			visual.Root.transform.position = new Vector3(state.X, state.Y, state.Z);
			Vector3 velocity = new Vector3(state.VelocityX, state.VelocityY, state.VelocityZ);
			if (velocity.sqrMagnitude > 0.000001f) visual.Root.transform.rotation = Quaternion.LookRotation(velocity.normalized);
		}
		List<ulong> stale = new List<ulong>();
		foreach (KeyValuePair<ulong, Visual> pair in active)
			if (!present.Contains(pair.Key)) stale.Add(pair.Key);
		foreach (ulong id in stale) Remove(id);
	}

	public void ApplyEvent(MatchEvent item)
	{
		if (item == null || item.Kind != MatchEventKind.Impact ||
			(item.Reason != "grenade" && item.Reason != "grenade-molotov" && item.Reason != "heavy-turret")) return;
		Remove(item.ProjectileId);
		if (item.Reason == "heavy-turret") return;
		Explosion.PlayEffects(item.Reason == "grenade-molotov" ? Explosion.ExplosionType.Molotov : Explosion.ExplosionType.Medium,
			new Vector3(item.X, item.Y, item.Z));
	}

	private Visual Create(string ownerId, ulong projectileId, string kind)
	{
		PlayerController owner = local != null && local.playerProperties != null && local.playerProperties.playerID == ownerId ? local : other;
		WeaponInventory inventory = owner == null ? null : owner.ResolveSelfHostedInventory();
		Weapon weapon = inventory == null || inventory.currentWeapon == null ? null : inventory.currentWeapon.weapon;
		GameObject root = new GameObject("SelfHostedProjectile_" + projectileId);
		GameObject bullet = weapon == null || weapon.bulletPrefab == null ? null : weapon.bulletPrefab.gameObject;
		if (kind == "heavy-turret-bullet")
		{
			HeavyTurret turret = Singleton<ObjectPoolDatabase>.instance == null ? null : Singleton<ObjectPoolDatabase>.instance.heavyTurret;
			if (turret != null && turret.turretWeapon != null && turret.turretWeapon.batchedWeapon != null &&
				turret.turretWeapon.batchedWeapon.weapon != null && turret.turretWeapon.batchedWeapon.weapon.bulletPrefab != null)
				bullet = turret.turretWeapon.batchedWeapon.weapon.bulletPrefab.gameObject;
		}
		if (bullet != null) CopyVisual(bullet.transform, root.transform, true);
		return new Visual(root);
	}

	private static void CopyVisual(Transform source, Transform destination, bool root)
	{
		if (!root)
		{
			destination.localPosition = source.localPosition;
			destination.localRotation = source.localRotation;
			destination.localScale = source.localScale;
		}
		MeshFilter sourceFilter = source.GetComponent<MeshFilter>();
		MeshRenderer sourceRenderer = source.GetComponent<MeshRenderer>();
		if (sourceFilter != null && sourceRenderer != null)
		{
			MeshFilter filter = destination.gameObject.AddComponent<MeshFilter>();
			filter.sharedMesh = sourceFilter.sharedMesh;
			MeshRenderer renderer = destination.gameObject.AddComponent<MeshRenderer>();
			renderer.sharedMaterials = sourceRenderer.sharedMaterials;
			renderer.enabled = sourceRenderer.enabled;
		}
		for (int i = 0; i < source.childCount; i++)
		{
			Transform sourceChild = source.GetChild(i);
			GameObject child = new GameObject(sourceChild.name);
			child.transform.SetParent(destination, false);
			CopyVisual(sourceChild, child.transform, false);
		}
	}

	private void Remove(ulong projectileId)
	{
		Visual visual;
		if (!active.TryGetValue(projectileId, out visual)) return;
		active.Remove(projectileId);
		if (visual.Root != null) DestroyObject(visual.Root);
	}

	private void OnDestroy()
	{
		foreach (Visual visual in active.Values) if (visual.Root != null) DestroyObject(visual.Root);
		active.Clear();
	}

	private static void DestroyObject(GameObject value)
	{
		if (Application.isPlaying) Object.Destroy(value); else Object.DestroyImmediate(value);
	}
}
