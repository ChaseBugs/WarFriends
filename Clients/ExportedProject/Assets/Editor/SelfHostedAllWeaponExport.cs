using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Exports the complete recovered weapon/setup identity graph without running
// account initialization or mutating/saving MainScene.
public static class SelfHostedAllWeaponExport
{
    [Serializable]
    private sealed class WeaponRow
    {
        public string id,setupType,setupPath,playerWeaponType,weaponType,weaponPath,muzzlePath;
        public int inventoryIndex,animationFamily,shotType,ignoreLayersMask;
        public bool reloadable,infiniteAmmo;
        public string[] ammoSetupType,weaponComponents;
        public string bulletType,bulletSource,bulletGuid,bulletSha256;
        public long bulletFileId;
    }
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_ALL_WEAPON_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_ALL_WEAPON_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity";
        var scene=EditorSceneManager.OpenScene(source);
        var roots=scene.GetRootGameObjects();
        var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
        var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
        var rows=new List<WeaponRow>();var ids=new HashSet<string>(StringComparer.Ordinal);
        foreach(var setup in levels.GetComponentsInChildren<WeaponLevelsSetup>(true))
        {
            var sourceComponent=setup.GetComponents<MonoBehaviour>().SingleOrDefault(c=>c!=null && c.GetType().Namespace=="Google2u");
            if(sourceComponent==null)continue;
            string id=sourceComponent.GetType().FullName;
            if(!ids.Add(id))throw new InvalidOperationException("Duplicate weapon source "+id);
            int index=setup.indexInWeaponInventory;
            if(index<0 || index>=inventory.allWeapons.Count)throw new InvalidOperationException("Invalid inventory index "+id);
            var playerWeapon=inventory.allWeapons[index];
            var weapon=playerWeapon==null?null:playerWeapon.GetComponent<Weapon>();
            if(playerWeapon==null || weapon==null)throw new InvalidOperationException("Missing recovered weapon "+id);
            string bulletSource=null,bulletGuid=null,bulletHash=null,bulletType=null;long bulletFileId=0;
            if(weapon.bulletPrefab!=null)
            {
                bulletSource=AssetDatabase.GetAssetPath(weapon.bulletPrefab);bulletType=weapon.bulletPrefab.GetType().FullName;
                if(string.IsNullOrEmpty(bulletSource) || !AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out bulletGuid,out bulletFileId))
                    throw new InvalidOperationException("Missing projectile identity "+id);
                bulletHash=Hash(bulletSource);
            }
            rows.Add(new WeaponRow {id=id,setupType=setup.GetType().FullName,setupPath=PathOf(setup.transform),inventoryIndex=index,
                playerWeaponType=playerWeapon.GetType().FullName,weaponType=weapon.GetType().FullName,
                weaponPath=PathOf(weapon.transform),muzzlePath=weapon.spawnPoint==null?null:PathOf(weapon.spawnPoint),
                animationFamily=(int)weapon.weaponType,reloadable=weapon.reloadableWeapon,infiniteAmmo=weapon.infiniteAmmo,
                shotType=(int)weapon.shotType,ignoreLayersMask=weapon.ignoreLayersMask,
                ammoSetupType=weapon.GetComponents<AmmoSetup>().Select(x=>x.GetType().FullName).OrderBy(x=>x,StringComparer.Ordinal).ToArray(),
                weaponComponents=weapon.GetComponents<MonoBehaviour>().Where(x=>x!=null).Select(x=>x.GetType().FullName).OrderBy(x=>x,StringComparer.Ordinal).ToArray(),
                bulletType=bulletType,bulletSource=bulletSource,bulletGuid=bulletGuid,bulletFileId=bulletFileId,bulletSha256=bulletHash});
        }
        rows=rows.OrderBy(x=>x.id,StringComparer.Ordinal).ToList();
        if(rows.Count!=66)throw new InvalidOperationException("Unexpected recovered weapon count "+rows.Count);
        if(rows.Select(x=>x.inventoryIndex).Distinct().Count()!=66)
            throw new InvalidOperationException("Recovered weapon inventory indexes are not unique.");
        File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source=source,sha256=Hash(source),
            playerPath=PathOf(player.transform),weaponCount=rows.Count,weapons=rows},Formatting.Indented));
        Debug.Log("ALL_WEAPON_EXPORT_PASSED weapons="+rows.Count);
        EditorApplication.Exit(0);
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
}
