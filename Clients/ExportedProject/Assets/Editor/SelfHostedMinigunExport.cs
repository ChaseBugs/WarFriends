using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Read-only source export for the recovered non-reloadable minigun.
public static class SelfHostedMinigunExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_MINIGUN_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_MINIGUN_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity";
        var scene=EditorSceneManager.OpenScene(source);var roots=scene.GetRootGameObjects();
        const string layerSource="Assets/GameObject/GlobalStorage.prefab";
        var layers=AssetDatabase.LoadAssetAtPath<GameObject>(layerSource).GetComponentsInChildren<TagsAndLayers>(true).Single();
        var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
        var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
        var setup=levels.GetComponentsInChildren<MinigunLevelsSetup>(true).Single();
        var sourceComponent=setup.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().FullName=="Google2u.LMG_Minigun");
        int index=setup.indexInWeaponInventory;
        if(index<0||index>=inventory.allWeapons.Count)throw new InvalidOperationException("Invalid minigun index.");
        var controller=inventory.allWeapons[index] as PlayerMinigunWeapon;
        var weapon=controller==null?null:controller.GetComponent<Weapon>();var gun=weapon as Gun;
        var bullet=weapon==null?null:weapon.GetComponent<BulletSetup>();
        if(sourceComponent==null||controller==null||gun==null||bullet==null||weapon.spawnPoint==null||weapon.bulletPrefab==null||controller.motor==null)
            throw new InvalidOperationException("Incomplete minigun binding.");
        string prefab=AssetDatabase.GetAssetPath(weapon.bulletPrefab),guid;long fileId;
        if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out guid,out fileId))
            throw new InvalidOperationException("Missing minigun projectile identity.");
        var row=new {id=sourceComponent.GetType().FullName,inventoryIndex=index,setupPath=PathOf(setup.transform),
            playerWeaponType=controller.GetType().FullName,weaponType=weapon.GetType().FullName,weaponPath=PathOf(weapon.transform),
            muzzlePath=PathOf(weapon.spawnPoint),muzzlePosition=V(weapon.spawnPoint.position),muzzleRotation=Q(weapon.spawnPoint.rotation),
            shotOffset=V(gun.shotOffset),waitTime=controller.waitTime,serializedCoolDown=controller.coolDown,
            lockTimeAfterBurst=controller.lockTimeAfterBurst,firstShotWaitTime=controller.firstShotWaitTime,
            motorPath=PathOf(controller.motor.transform),motorType=controller.motor.GetType().FullName,
            fast=gun.fastBullet,friendKill=weapon.friendKill,shotType=(int)weapon.shotType,
            ignoreLayersMask=weapon.ignoreLayersMask,animationFamily=(int)weapon.weaponType,
            reloadable=weapon.reloadableWeapon,infiniteAmmo=weapon.infiniteAmmo,
            serializedSpeed=bullet.speed,speedMultiplier=bullet.speedMultiplayer,checkDistance=bullet.checkDistance,
            criticalMultiplier=(float)bullet.criticalAmount,bulletType=weapon.bulletPrefab.GetType().FullName,
            bulletSource=prefab,bulletGuid=guid,bulletFileId=fileId,bulletSha256=Hash(prefab)};
        File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source=source,sha256=Hash(source),
            playerPath=PathOf(player.transform),alliesBulletMask=(int)layers.alliesBulletMask,
            enemiesBulletMask=(int)layers.enemiesBulletMask,layerSource=layerSource,layerSha256=Hash(layerSource),weapon=row},Formatting.Indented));
        Debug.Log("MINIGUN_EXPORT_PASSED id="+row.id+" index="+index);EditorApplication.Exit(0);
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}
