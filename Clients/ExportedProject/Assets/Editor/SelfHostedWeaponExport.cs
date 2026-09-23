using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Inspect serialized gameplay bindings. Never invokes account/weapon initialization
// and never saves the scene. Muzzles are reference-pose evidence, not live aim poses.
public static class SelfHostedWeaponExport
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_WEAPON_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new InvalidOperationException("Set WAR_WEAPON_OUTPUT.");
        var previous = EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source = "Assets/Scenes/MainScene.unity";
            var scene = EditorSceneManager.OpenScene(source);
            var roots = scene.GetRootGameObjects();
            const string layerSource="Assets/GameObject/GlobalStorage.prefab";
            var layers = AssetDatabase.LoadAssetAtPath<GameObject>(layerSource).GetComponentsInChildren<TagsAndLayers>(true).Single();
            var player = roots.SelectMany(g => g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var inventory = player.GetComponentsInChildren<WeaponInventory>(true).Single();
            var levels = roots.SelectMany(g => g.GetComponentsInChildren<LevelManager>(true)).Single();
            var rows = new List<object>();
            // LevelManager fills its runtime list during Init; inspect attached
            // setup components instead of assuming that list is serialized.
            foreach (var setup in levels.GetComponentsInChildren<WeaponLevelsSetup>(true))
            {
                var rifle = setup as RifleLevelsSetup;
                if (rifle == null) continue;
                string id = setup.GetComponents<MonoBehaviour>().Single(c => c != null && c.GetType().Namespace == "Google2u").GetType().FullName;
                if (!id.StartsWith("Google2u.AssaultRifle_", StringComparison.Ordinal)) continue;
                int index = setup.indexInWeaponInventory;
                if (index < 0 || index >= inventory.allWeapons.Count) throw new InvalidOperationException("Invalid inventory index " + id);
                var playerWeapon = inventory.allWeapons[index];
                var weapon = playerWeapon.GetComponent<Weapon>();
                var gun = weapon as Gun;
                var bullet = weapon.GetComponent<BulletSetup>();
                if (gun == null || bullet == null || weapon.spawnPoint == null || weapon.bulletPrefab == null || rifle.baseDefinition == null)
                    throw new InvalidOperationException("Incomplete rifle binding " + id);
                string prefabPath = AssetDatabase.GetAssetPath(weapon.bulletPrefab), guid; long fileId;
                if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out guid,out fileId))
                    throw new InvalidOperationException("Missing bullet asset identity " + id);
                rows.Add(new { id = id, setupPath = PathOf(setup.transform), inventoryIndex = index,
                    playerWeaponType = playerWeapon.GetType().FullName, weaponType = weapon.GetType().FullName,
                    weaponPath = PathOf(weapon.transform), muzzlePath = PathOf(weapon.spawnPoint),
                    muzzlePosition = V(weapon.spawnPoint.position), muzzleRotation = Q(weapon.spawnPoint.rotation),
                    shotOffset = V(gun.shotOffset), fast = gun.fastBullet, friendKill = weapon.friendKill,
                    shotType = (int)weapon.shotType, ignoreLayersMask = weapon.ignoreLayersMask,
                    animationFamily = (int)weapon.weaponType,
                    reloadable = weapon.reloadableWeapon, infiniteAmmo = weapon.infiniteAmmo,
                    definitionSpeed = rifle.baseDefinition.speed, serializedSpeed = bullet.speed,
                    speedMultiplier = bullet.speedMultiplayer, checkDistance = bullet.checkDistance,
                    criticalMultiplier = (float)bullet.criticalAmount,
                    bulletType = weapon.bulletPrefab.GetType().FullName, bulletSource = prefabPath,
                    bulletGuid = guid, bulletFileId = fileId, bulletSha256 = Hash(prefabPath) });
            }
            if (rows.Count != 11) throw new InvalidOperationException("Unexpected assault rifle count " + rows.Count);
            File.WriteAllText(output,JsonConvert.SerializeObject(new { client = "1.4.0", source = source, sha256 = Hash(source),
                pose = "serialized-reference-only", playerPath = PathOf(player.transform),
                alliesBulletMask=(int)layers.alliesBulletMask,enemiesBulletMask=(int)layers.enemiesBulletMask,
                layerSource=layerSource,layerSha256=Hash(layerSource),
                position = V(player.transform.position), rotation = Q(player.transform.rotation), weapons = rows },Formatting.Indented));
            Debug.Log("WEAPON_EXPORT_PASSED rifles=" + rows.Count);
        }
        finally
        {
            if (previous.Any(s => s.isLoaded && s.isActive) && previous.All(s => !string.IsNullOrEmpty(s.path))) EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static string Hash(string path) { using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant(); }
    private static string PathOf(Transform t) { return t.parent == null ? t.name : PathOf(t.parent) + "/" + t.name; }
    private static float[] V(Vector3 v) { return new[] { v.x,v.y,v.z }; }
    private static float[] Q(Quaternion q) { return new[] { q.x,q.y,q.z,q.w }; }
}
