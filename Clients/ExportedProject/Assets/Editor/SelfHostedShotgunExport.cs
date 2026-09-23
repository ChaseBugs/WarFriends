using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Read-only MainScene evidence for the nine player shotgun variants.
public static class SelfHostedShotgunExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_SHOTGUN_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_SHOTGUN_OUTPUT.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source="Assets/Scenes/MainScene.unity";
            var scene=EditorSceneManager.OpenScene(source);
            var roots=scene.GetRootGameObjects();
            var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
            var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
            var rows=new List<object>();
            foreach(var setup in levels.GetComponentsInChildren<ShotgunLevelsSetup>(true))
            {
                string id=setup.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().Namespace=="Google2u").GetType().FullName;
                if(!id.StartsWith("Google2u.Shotgun_",StringComparison.Ordinal))continue;
                int index=setup.indexInWeaponInventory;
                if(index<0||index>=inventory.allWeapons.Count)throw new InvalidOperationException("Invalid shotgun inventory index "+id);
                var playerWeapon=inventory.allWeapons[index];
                var weapon=playerWeapon.GetComponent<Weapon>();
                var gun=weapon as Gun;
                var shotgun=weapon.GetComponent<ShotGunBulletSetup>();
                var mainBullet=weapon.bulletPrefab as BulletShotGun;
                var definition=setup.baseDefinition as ShotgunLevelDefinition;
                if(gun==null||shotgun==null||mainBullet==null||mainBullet.bulletPrefab==null||definition==null||weapon.spawnPoint==null)
                    throw new InvalidOperationException("Incomplete shotgun binding "+id);
                string mainPath=AssetDatabase.GetAssetPath(mainBullet);
                string pelletPath=AssetDatabase.GetAssetPath(mainBullet.bulletPrefab);
                rows.Add(new {id,setupPath=PathOf(setup.transform),inventoryIndex=index,
                    playerWeaponType=playerWeapon.GetType().FullName,weaponType=weapon.GetType().FullName,
                    weaponPath=PathOf(weapon.transform),muzzlePath=PathOf(weapon.spawnPoint),
                    muzzlePosition=V(weapon.spawnPoint.position),muzzleRotation=Q(weapon.spawnPoint.rotation),
                    shotOffset=V(gun.shotOffset),friendKill=weapon.friendKill,shotType=(int)weapon.shotType,
                    animationFamily=(int)weapon.weaponType,fast=gun.fastBullet,
                    reloadable=weapon.reloadableWeapon,infiniteAmmo=weapon.infiniteAmmo,
                    ignoreLayersMask=weapon.ignoreLayersMask,
                    baseDefinition=new {definition.shotHalfAngle,definition.shotHalfAngleNear,definition.radius,
                        definition.minDamage,definition.maxDamage,definition.speed},
                    setup=new {shotgun.shotHalfAngle,shotgun.shotHalfAngleNear,shotgun.radius,
                        shotgun.minDamage,shotgun.maxDamage,shotgun.hitForceMax,shotgun.flatY,
                        shotgun.shotOnlyMainBullet,shotgun.bulletSpeed,shotgun.checkDistance,
                        speedMultiplier=shotgun.speedMultiplayer,criticalMultiplier=(float)shotgun.criticalAmount},
                    mainBulletType=mainBullet.GetType().FullName,mainBulletSource=mainPath,mainBulletSha256=Hash(mainPath),
                    pelletType=mainBullet.bulletPrefab.GetType().FullName,pelletSource=pelletPath,pelletSha256=Hash(pelletPath)});
            }
            if(rows.Count!=9)throw new InvalidOperationException("Expected nine shotguns, found "+rows.Count);
            File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source,sha256=Hash(source),
                playerPath=PathOf(player.transform),weapons=rows},Formatting.Indented));
            Debug.Log("SHOTGUN_EXPORT_PASSED weapons="+rows.Count);
        }
        finally
        {
            if(previous.Any(s=>s.isLoaded&&s.isActive)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}
