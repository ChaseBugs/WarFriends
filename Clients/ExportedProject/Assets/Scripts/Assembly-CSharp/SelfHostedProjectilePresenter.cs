using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Presentation only. The Worker owns trajectory, collision and damage; these
// objects contain copied recovered meshes and visual trail scripts, with no
// gameplay, collision, damage or Photon scripts.
public sealed class SelfHostedProjectilePresenter : MonoBehaviour
{
	private sealed class Visual
	{
		public readonly GameObject Root;
        public LineTrailRenderer Trail;
        public bool AirShotEvent;
        public Vector3 End;
        public float Speed;
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
			if (state.Kind != "grenade" && state.Kind != "grenade-molotov" && state.Kind != "heavy-turret-bullet" &&
                state.Kind != "drone-bullet" && state.Kind != "drone-fake-bullet" &&
                state.Kind != "helicopter-bullet" && state.Kind != "helicopter-fake-bullet") continue;
			present.Add(state.ProjectileId);
			Visual visual;
			if (!active.TryGetValue(state.ProjectileId, out visual))
			{
				visual = Create(state.OwnerPlayerId, state.ProjectileId, state.Kind);
				active.Add(state.ProjectileId, visual);
			}
			visual.Root.transform.position = new Vector3(state.X, state.Y, state.Z);
			Vector3 velocity = new Vector3(state.VelocityX, state.VelocityY, state.VelocityZ);
			if (velocity.sqrMagnitude > 0.000001f && visual.Trail == null)
                visual.Root.transform.rotation = IsAirShot(state.Kind) ?
                    Quaternion.LookRotation(-velocity.normalized) * Quaternion.AngleAxis(-90f, Vector3.up) : Quaternion.LookRotation(velocity.normalized);
			if (IsAirShot(state.Kind) && visual.Trail == null && velocity.sqrMagnitude > 0.000001f)
                ConfigureAirTrail(visual, state.Kind.StartsWith("helicopter-"),
                    state.Kind.EndsWith("fake-bullet"), false, velocity.magnitude);
		}
		List<ulong> stale = new List<ulong>();
		foreach (KeyValuePair<ulong, Visual> pair in active)
			if (!present.Contains(pair.Key) && !pair.Value.AirShotEvent) stale.Add(pair.Key);
		foreach (ulong id in stale) Remove(id);
	}

	public void ApplyEvent(MatchEvent item)
	{
		if (item != null &&
            ((item.Kind == MatchEventKind.DroneFired && item.DroneShot != null) ||
             (item.Kind == MatchEventKind.HelicopterFired && item.HelicopterShot != null)))
        {
            bool helicopter = item.Kind == MatchEventKind.HelicopterFired;
            bool fake = helicopter ? item.HelicopterShot.Fake : item.DroneShot.Fake;
            bool shield = helicopter ? item.HelicopterShot.Shield : item.DroneShot.Shield;
            float speed = helicopter ? item.HelicopterShot.Speed : item.DroneShot.Speed;
            Vector3 muzzle = helicopter
                ? new Vector3(item.HelicopterShot.MuzzleX, item.HelicopterShot.MuzzleY, item.HelicopterShot.MuzzleZ)
                : new Vector3(item.DroneShot.MuzzleX, item.DroneShot.MuzzleY, item.DroneShot.MuzzleZ);
            string kind = helicopter ? (fake ? "helicopter-fake-bullet" : "helicopter-bullet")
                : (fake ? "drone-fake-bullet" : "drone-bullet");
            Visual visual;
            if (!active.TryGetValue(item.ProjectileId, out visual))
            {
                visual = Create(item.ActorId, item.ProjectileId, kind);
                active.Add(item.ProjectileId, visual);
                visual.Root.transform.position = muzzle;
                Vector3 direction = visual.Root.transform.position - new Vector3(item.X, item.Y, item.Z);
                if (direction.sqrMagnitude > 0.000001f)
                    visual.Root.transform.rotation = Quaternion.LookRotation(direction) * Quaternion.AngleAxis(-90f, Vector3.up);
            }
            ConfigureAirTrail(visual, helicopter, fake, shield, speed);
            Vector3 delta = new Vector3(item.X, item.Y, item.Z) - muzzle;
            if (delta.magnitude > 50f) delta = delta.normalized * 50f;
            visual.AirShotEvent = true;
            visual.End = muzzle + delta * 2f;
            visual.Speed = speed;
            return;
        }
		if (item == null || item.Kind != MatchEventKind.Impact ||
			(item.Reason != "grenade" && item.Reason != "grenade-molotov" && item.Reason != "heavy-turret" && item.Reason != "drone" && item.Reason != "helicopter" && item.Reason != "helicopter-gunner")) return;
        if (item.Reason == "drone" || item.Reason == "helicopter")
        {
            Visual droneVisual;
            if (active.TryGetValue(item.ProjectileId, out droneVisual) && droneVisual.AirShotEvent)
            {
                // Firing and impact can arrive in one reliable batch. Finish the
                // cosmetic path at the host impact instead of erasing it unseen.
                droneVisual.End = new Vector3(item.X, item.Y, item.Z);
                return;
            }
        }
		Remove(item.ProjectileId);
		if (item.Reason == "heavy-turret" || item.Reason == "drone" || item.Reason == "helicopter" ||
			item.Reason == "helicopter-gunner") return;
		Explosion.PlayEffects(item.Reason == "grenade-molotov" ? Explosion.ExplosionType.Molotov : Explosion.ExplosionType.Medium,
			new Vector3(item.X, item.Y, item.Z));
	}
    private void Update()
    {
        var finished = new List<ulong>();
        foreach (var pair in active)
        {
            Visual visual = pair.Value;
            if (!visual.AirShotEvent) continue;
            // Cosmetic fallback between host snapshots; no local hit testing.
            visual.Root.transform.position = Vector3.MoveTowards(visual.Root.transform.position,
                visual.End, visual.Speed * Time.deltaTime);
            if (visual.Root.transform.position == visual.End) finished.Add(pair.Key);
        }
        foreach (ulong id in finished) Remove(id);
    }
    private static bool IsAirShot(string kind)
    {
        return kind.StartsWith("drone-") || kind.StartsWith("helicopter-");
    }

    private static void ConfigureAirTrail(Visual visual, bool helicopter, bool fake, bool shield, float speed)
    {
        ObjectPoolDatabase pool = Singleton<ObjectPoolDatabase>.instance;
        Drone drone = pool == null ? null : pool.drone;
        Helicopter air = pool == null ? null : pool.helicopter;
        Weapon weapon = helicopter ? (air == null || air.turret == null || air.turret.batchedWeapon == null
                ? null : air.turret.batchedWeapon.weapon)
            : (drone == null || drone.weapon == null ? null : drone.weapon.weapon);
        BulletSetup setup = weapon == null ? null : weapon.ammoSetup as BulletSetup;
        if (setup == null || speed <= 0 || Camera.main == null || visual.Root.GetComponent<MeshFilter>() == null)
            throw new System.InvalidOperationException("Air shot trail lacks recovered setup, camera or mesh.");
        if (visual.Trail == null) { visual.Trail = visual.Root.AddComponent<LineTrailRenderer>(); visual.Trail.Reset(); }
        visual.Trail.SetWidth(fake ? setup.GetTrailFakeWidth() : setup.GetTrailWidth());
        visual.Trail.trailLength = setup.GetTrailSize() * (fake ? 1f : 2f);
        visual.Trail.disapearTime = setup.GetTrailSize() / speed;
        string sprite = fake ? setup.fakeShotTexture : shield ? setup.shieldShotTexture : setup.realShotTexture;
        if (!string.IsNullOrEmpty(sprite)) visual.Trail.SetSprite(sprite);
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
        if (kind == "drone-bullet" || kind == "drone-fake-bullet")
        {
            Drone drone = Singleton<ObjectPoolDatabase>.instance == null ? null : Singleton<ObjectPoolDatabase>.instance.drone;
            bullet = drone != null && drone.weapon != null && drone.weapon.weapon != null &&
                drone.weapon.weapon.bulletPrefab != null ? drone.weapon.weapon.bulletPrefab.gameObject : null;
        }
		if (kind == "helicopter-bullet" || kind == "helicopter-fake-bullet")
		{
			Helicopter air = Singleton<ObjectPoolDatabase>.instance == null ? null : Singleton<ObjectPoolDatabase>.instance.helicopter;
			Weapon airWeapon = air == null || air.turret == null || air.turret.batchedWeapon == null
				? null : air.turret.batchedWeapon.weapon;
			bullet = airWeapon == null || airWeapon.bulletPrefab == null ? null : airWeapon.bulletPrefab.gameObject;
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
