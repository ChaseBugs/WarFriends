using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SelfHostedSniperExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_SNIPER_OUTPUT");if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_SNIPER_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity",layerSource="Assets/GameObject/GlobalStorage.prefab";
        var scene=EditorSceneManager.OpenScene(source);var roots=scene.GetRootGameObjects();
        var layers=AssetDatabase.LoadAssetAtPath<GameObject>(layerSource).GetComponentsInChildren<TagsAndLayers>(true).Single();
        var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
        var rows=new List<object>();
        foreach(var setup in levels.GetComponentsInChildren<SniperRifleLevelsSetup>(true))
        {
            var sourceComponent=setup.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().Namespace=="Google2u");string id=sourceComponent.GetType().FullName;
            int index=setup.indexInWeaponInventory;var controller=inventory.allWeapons[index] as PlayerZoomOnTouchWeapon;
            var weapon=controller==null?null:controller.GetComponent<Weapon>();var gun=weapon as OneShotRifle;var bullet=weapon==null?null:weapon.GetComponent<BulletSetup>();
            if(!id.StartsWith("Google2u.SniperRifle_",StringComparison.Ordinal)||controller==null||gun==null||bullet==null||weapon.spawnPoint==null||weapon.bulletPrefab==null)
                throw new InvalidOperationException("Incomplete sniper binding "+id);
            string prefab=AssetDatabase.GetAssetPath(weapon.bulletPrefab),guid;long fileId;if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out guid,out fileId))throw new InvalidOperationException("Missing sniper projectile identity.");
            rows.Add(new{id=id,inventoryIndex=index,setupPath=PathOf(setup.transform),playerWeaponType=controller.GetType().FullName,weaponType=weapon.GetType().FullName,
                weaponPath=PathOf(weapon.transform),muzzlePath=PathOf(weapon.spawnPoint),shotOffset=V(gun.shotOffset),firstShotWaitTime=controller.firstShotWaitTime,
                zoomTresholdSqrDistance=controller.zoomTresholdSqrDistance,zoomTresholdTime=controller.zoomTresholdTime,serializedFov=controller.fov,scopeNum=controller.scopeNum,
                fast=gun.fastBullet,friendKill=weapon.friendKill,shotType=(int)weapon.shotType,ignoreLayersMask=weapon.ignoreLayersMask,animationFamily=(int)weapon.weaponType,
                reloadable=weapon.reloadableWeapon,infiniteAmmo=weapon.infiniteAmmo,serializedSpeed=bullet.speed,speedMultiplier=bullet.speedMultiplayer,
                checkDistance=bullet.checkDistance,criticalMultiplier=(float)bullet.criticalAmount,bulletType=weapon.bulletPrefab.GetType().FullName,
                bulletSource=prefab,bulletGuid=guid,bulletFileId=fileId,bulletSha256=Hash(prefab)});
        }
        rows=rows.OrderBy(x=>JsonConvert.SerializeObject(x),StringComparer.Ordinal).ToList();if(rows.Count!=8)throw new InvalidOperationException("Unexpected sniper count "+rows.Count);
        File.WriteAllText(output,JsonConvert.SerializeObject(new{client="1.4.0",source=source,sha256=Hash(source),playerPath=PathOf(player.transform),
            alliesBulletMask=(int)layers.alliesBulletMask,enemiesBulletMask=(int)layers.enemiesBulletMask,layerSource=layerSource,layerSha256=Hash(layerSource),weaponCount=rows.Count,weapons=rows},Formatting.Indented));
        Debug.Log("SNIPER_EXPORT_PASSED weapons="+rows.Count);EditorApplication.Exit(0);
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
}
