using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SelfHostedBazookaExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_BAZOOKA_OUTPUT");if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_BAZOOKA_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity",layerSource="Assets/GameObject/GlobalStorage.prefab";
        var scene=EditorSceneManager.OpenScene(source);var roots=scene.GetRootGameObjects();
        var layers=AssetDatabase.LoadAssetAtPath<GameObject>(layerSource).GetComponentsInChildren<TagsAndLayers>(true).Single();
        var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
        var rows=new List<object>();
        foreach(var setup in levels.GetComponentsInChildren<WeaponLevelsSetup>(true).Where(x=>x is BazookaLevelsSetup||x is BazookaFangsLevelsSetup))
        {
            var sourceComponent=setup.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().Namespace=="Google2u");string id=sourceComponent.GetType().FullName;
            int index=setup.indexInWeaponInventory;var controller=inventory.allWeapons[index] as PlayerHoldWeapon;
            var weapon=controller==null?null:controller.GetComponent<Weapon>() as Bazooka;var missile=weapon==null?null:weapon.ammoSetup as MissileSetup;
            BazookaLevelDefinition definition=setup is BazookaFangsLevelsSetup ? ((BazookaFangsLevelsSetup)setup).baseDefinition : ((BazookaLevelsSetup)setup).baseDefinition;
            if(!id.StartsWith("Google2u.Bazooka_",StringComparison.Ordinal)||controller==null||weapon==null||missile==null||weapon.spawnPoint==null||weapon.bulletPrefab==null)
                throw new InvalidOperationException("Incomplete bazooka binding "+id);
            string prefab=AssetDatabase.GetAssetPath(weapon.bulletPrefab),guid;long fileId;if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out guid,out fileId))throw new InvalidOperationException("Missing bazooka projectile identity.");
            BazookaFangs fangs=weapon as BazookaFangs;var add=fangs==null?null:fangs.add;var addSetup=add==null?null:add.ammoSetup as MissileSetup;
            if((setup is BazookaFangsLevelsSetup)!=(fangs!=null)||fangs!=null&&(add==null||addSetup==null||add.spawnPoint==null))throw new InvalidOperationException("Incomplete Fangs binding "+id);
            rows.Add(new{id=id,inventoryIndex=index,setupPath=PathOf(setup.transform),playerWeaponType=controller.GetType().FullName,
                weaponType=weapon.GetType().FullName,weaponPath=PathOf(weapon.transform),muzzlePath=PathOf(weapon.spawnPoint),shootOffset=V(weapon.shootOffset),
                holdTime=controller.holdTime,firstShotWaitTime=controller.firstShotWaitTime,animationFamily=(int)weapon.weaponType,
                reloadable=weapon.reloadableWeapon,infiniteAmmo=weapon.infiniteAmmo,friendKill=weapon.friendKill,shotType=(int)weapon.shotType,
                ignoreLayersMask=weapon.ignoreLayersMask,damageToPlayerRatio=setup.damageToPlayerRatio,damageToPlayerRatioOvertime=setup.damageToPlayerRatioOvertime,
                baseDeadRadius=definition.deadRadius,baseHurtRadius=definition.hurtradius,baseSpeed=definition.speed,
                playerBehindShieldRatio=setup.damageToPlayerBehindShieldRatio,criticalMultiplier=(float)missile.criticalAmount,
                explosionCoef=V(missile.exposionCoef),additionalUpForce=missile.additionalUpForce,stopTime=missile.stopTime,
                missileType=(int)missile.missileType,curvedTrajectory=missile.curvedTrajectory,minMaxRotations=new[]{missile.minMaxRotations.x,missile.minMaxRotations.y},
                baseRotationMagnitude=missile.baseRotationMagnitude,rotationProfile=missile.rotationProfile.keys.Select(k=>new[]{k.time,k.value,k.inTangent,k.outTangent}).ToArray(),
                fangShotCount=fangs==null?1:4,fangDelaySeconds=fangs==null?0:.1f,fangMuzzlePath=add==null?null:PathOf(add.spawnPoint),
                bulletType=weapon.bulletPrefab.GetType().FullName,bulletSource=prefab,bulletGuid=guid,bulletFileId=fileId,bulletSha256=Hash(prefab)});
        }
        rows=rows.OrderBy(x=>JsonConvert.SerializeObject(x),StringComparer.Ordinal).ToList();if(rows.Count!=7)throw new InvalidOperationException("Unexpected bazooka count "+rows.Count);
        File.WriteAllText(output,JsonConvert.SerializeObject(new{client="1.4.0",source=source,sha256=Hash(source),playerPath=PathOf(player.transform),
            alliesBulletMask=(int)layers.alliesBulletMask,enemiesBulletMask=(int)layers.enemiesBulletMask,layerSource=layerSource,layerSha256=Hash(layerSource),weaponCount=rows.Count,weapons=rows},Formatting.Indented));
        Debug.Log("BAZOOKA_EXPORT_PASSED weapons="+rows.Count);EditorApplication.Exit(0);
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
}
