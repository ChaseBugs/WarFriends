using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Read-only source export for the eight recovered PlayerBurstWeapon LMGs.
public static class SelfHostedLmgExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_LMG_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_LMG_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity";
        var scene=EditorSceneManager.OpenScene(source);var roots=scene.GetRootGameObjects();
        const string layerSource="Assets/GameObject/GlobalStorage.prefab";
        var layers=AssetDatabase.LoadAssetAtPath<GameObject>(layerSource).GetComponentsInChildren<TagsAndLayers>(true).Single();
        var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
        var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
        var rows=new List<object>();
        foreach(var setup in levels.GetComponentsInChildren<WeaponLevelsSetup>(true))
        {
            var sourceComponent=setup.GetComponents<MonoBehaviour>().SingleOrDefault(c=>c!=null&&c.GetType().Namespace=="Google2u");
            if(sourceComponent==null)continue;string id=sourceComponent.GetType().FullName;
            if(!id.StartsWith("Google2u.LMG_",StringComparison.Ordinal)||id=="Google2u.LMG_Minigun")continue;
            int index=setup.indexInWeaponInventory;
            if(index<0||index>=inventory.allWeapons.Count)throw new InvalidOperationException("Invalid LMG index "+id);
            var controller=inventory.allWeapons[index] as PlayerBurstWeapon;var weapon=controller==null?null:controller.GetComponent<Weapon>();
            var gun=weapon as Gun;var bullet=weapon==null?null:weapon.GetComponent<BulletSetup>();
            if(controller==null||gun==null||bullet==null||weapon.spawnPoint==null||weapon.bulletPrefab==null)
                throw new InvalidOperationException("Incomplete LMG binding "+id);
            string prefab=AssetDatabase.GetAssetPath(weapon.bulletPrefab),guid;long fileId;
            if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out guid,out fileId))
                throw new InvalidOperationException("Missing LMG projectile identity "+id);
            rows.Add(new {id=id,inventoryIndex=index,setupPath=PathOf(setup.transform),playerWeaponType=controller.GetType().FullName,
                weaponType=weapon.GetType().FullName,weaponPath=PathOf(weapon.transform),muzzlePath=PathOf(weapon.spawnPoint),
                muzzlePosition=V(weapon.spawnPoint.position),muzzleRotation=Q(weapon.spawnPoint.rotation),shotOffset=V(gun.shotOffset),
                burst=controller.burst,lockTimeAfterBurst=controller.lockTimeAfterBurst,firstShotWaitTime=controller.firstShotWaitTime,
                fast=gun.fastBullet,friendKill=weapon.friendKill,shotType=(int)weapon.shotType,
                ignoreLayersMask=weapon.ignoreLayersMask,animationFamily=(int)weapon.weaponType,
                reloadable=weapon.reloadableWeapon,infiniteAmmo=weapon.infiniteAmmo,
                serializedSpeed=bullet.speed,speedMultiplier=bullet.speedMultiplayer,checkDistance=bullet.checkDistance,
                criticalMultiplier=(float)bullet.criticalAmount,bulletType=weapon.bulletPrefab.GetType().FullName,
                bulletSource=prefab,bulletGuid=guid,bulletFileId=fileId,bulletSha256=Hash(prefab)});
        }
        rows=rows.OrderBy(x=>JsonConvert.SerializeObject(x),StringComparer.Ordinal).ToList();
        if(rows.Count!=8)throw new InvalidOperationException("Unexpected LMG count "+rows.Count);
        File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source=source,sha256=Hash(source),
            playerPath=PathOf(player.transform),alliesBulletMask=(int)layers.alliesBulletMask,
            enemiesBulletMask=(int)layers.enemiesBulletMask,layerSource=layerSource,layerSha256=Hash(layerSource),
            weaponCount=rows.Count,weapons=rows},Formatting.Indented));
        Debug.Log("LMG_EXPORT_PASSED weapons="+rows.Count);EditorApplication.Exit(0);
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}
