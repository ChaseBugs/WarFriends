using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public static class SelfHostedDroneWeaponExport
{
    public static void Run()
    {
        try
        {
            string output=Environment.GetEnvironmentVariable("WAR_DRONE_WEAPON_OUTPUT");
            if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_DRONE_WEAPON_OUTPUT.");
            string sourcePath="Assets/GameObject/dronePrototype.prefab";
            var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(sourcePath);var drone=prefab.GetComponent<Drone>();
            var batch=drone.weapon;var gun=(Gun)batch.weapon;var setup=(BulletSetup)gun.ammoSetup;
            var local=prefab.transform.InverseTransformPoint(gun.spawnPoint.position);
            var localRotation=Quaternion.Inverse(prefab.transform.rotation)*gun.spawnPoint.rotation;
            var probes=new[]{Quaternion.identity,Quaternion.Euler(12,35,-7),Quaternion.Euler(-35,150,70),Quaternion.Euler(80,-100,-45)}.Select(q=>
            {
                var origin=new Vector3(2,3,4);
                // Apply the root pose through Unity's transform hierarchy without gameplay components.
                GameObject root=new GameObject("DroneWeaponPoseProbe");
                try
                {
                    root.transform.position=origin;root.transform.rotation=q;
                    return new{position=V(origin),rotation=Q(q),muzzle=V(root.transform.TransformPoint(local)+gun.shotOffset)};
                }
                finally{UnityEngine.Object.DestroyImmediate(root);}
            }).ToArray();
            string guid;long projectile;
            if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(gun.bulletPrefab,out guid,out projectile))throw new InvalidOperationException("Projectile identity absent.");
            string projectilePath=AssetDatabase.GetAssetPath(gun.bulletPrefab);
            var result=new{version=1,source=sourcePath,sha256=Digest(sourcePath),droneComponentFileId=Id(drone),
                batchedComponentFileId=Id(batch),weaponComponentFileId=Id(gun),weaponType=gun.GetType().Name,
                cadence=(float)gun.cadence,fakeShotDispersion=batch.fakeShotDispersion,spawnTransformFileId=Id(gun.spawnPoint),
                restSpawnPosition=V(local),restSpawnRotation=Q(localRotation),restSpawnScale=V(gun.spawnPoint.lossyScale),
                shotOffset=V(gun.shotOffset),infiniteAmmo=gun.infiniteAmmo,reloadableWeapon=gun.reloadableWeapon,
                friendKill=gun.friendKill,fastBullet=gun.fastBullet,ignoreLayersMask=gun.ignoreLayersMask,
                projectileFileId=projectile,projectileGuid=guid,projectileSource=projectilePath,projectileSha256=Digest(projectilePath),projectileSetup=new{componentFileId=Id(setup),speed=setup.speed,checkDistance=setup.checkDistance,
                fakeSpeedFactor=setup.fakeSpeedFactor,speedMultiplayer=setup.speedMultiplayer,criticalProbability=(float)setup.criticalProbability,
                criticalAmount=(float)setup.criticalAmount,serializedDamage=(float)setup.damageAmount,poisonTime=setup.poisonTime,poisonRatio=setup.poisonRatio},probes=probes};
            File.WriteAllText(output,JsonConvert.SerializeObject(result,Formatting.Indented)+"\n");
            Debug.Log("DRONE_WEAPON_EXPORT_PASSED probes="+probes.Length);EditorApplication.Exit(0);
        }
        catch(Exception e){Debug.LogError(e);EditorApplication.Exit(1);}
    }
    private static long Id(UnityEngine.Object value){string guid;long id;if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(value,out guid,out id))throw new InvalidOperationException("Weapon component ID absent.");return id;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
    private static string Digest(string path){using(var hash=SHA256.Create())return string.Concat(hash.ComputeHash(File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Application.dataPath),path))).Select(b=>b.ToString("x2")));}
}
