using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Google2u;
using UnityEngine;

public static class UnityPvpBonusAudit
{
    [Serializable] private sealed class Row {public string name;public float probability,arenaProbability;}
    [Serializable] private sealed class Rules
    {
        public float goldLowLevelProbability,cardUnlockLevel,lowAmmoMultiplier,warbucksScalingBase;
        public float grenadeFallbackDamageMinimum,grenadeFallbackDamageMaximum;
        public int rankCount;
    }
    [Serializable] private sealed class Catalog {public Rules rules;public Row[] rows;}
    [Serializable] private sealed class Sample
    {
        public int localDisplayLevel,ownerLevelIndex,goldBonusesCollected;
        public bool arena,friendly,lowAmmo;
        public int[] weightBits;
    }
    [Serializable] private sealed class CurrencySample
    {
        public int recipientLevelIndex;
        public int scaleBits;
        public string amountsSha256;
    }
    [Serializable] private sealed class GrenadeSample
    {
        public int recipientLevelIndex,explosionBits,directBits;
    }
    [Serializable] private sealed class Result
    {
        public int version=2;
        public string unityVersion,codeSha256;
        public Sample[] samples;
        public CurrencySample[] currencySamples;
        public GrenadeSample[] grenadeSamples;
    }
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_PVP_BONUS_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new Exception("Set WAR_PVP_BONUS_OUTPUT.");
        var catalog=JsonUtility.FromJson<Catalog>(File.ReadAllText(Path.Combine(Application.dataPath,"Editor/source-bonus-catalog.json")));
        var variables=Singleton<GameVariables>.instance;
        variables.constants.value=catalog.rules.goldLowLevelProbability;
        variables.cardConstants.value=catalog.rules.cardUnlockLevel;
        variables.bonussesDefinitions.value=catalog.rules.lowAmmoMultiplier;
        var bonuses=new KillStreakBonus[] {new KillStreakBonusAddCredits(),new KillStreakBonus(),new KillStreakBonusAddMoney(),
            new KillStreakBonus(),new KillStreakBonus(),new KillStreakBonus(),new KillStreakBonus(),new KillStreakBonusCard(),new KillStreakBonusAddAmmo()};
        for(int index=0;index<bonuses.Length;index++) {
            var row=catalog.rows[index];bonuses[index].name=row.name;
            Singleton<KillStreakManager>.instance.crates.rows.Add(row.name,new CratesRow{PROBABILITY=row.probability,PROBABILITYARENA=row.arenaProbability});
        }
        var samples=new List<Sample>();
        foreach(int level in new[]{1,5,6,7,8,43})
        foreach(int ownerLevel in new[]{6,7})
        foreach(bool arena in new[]{false,true})
        foreach(bool friendly in new[]{false,true})
        foreach(int gold in new[]{0,3})
        foreach(bool lowAmmo in new[]{false,true}) {
            LevelManager.instance.currentLevel.displayNumber=level;
            PlayerAnalytics.instance.data.goldBonuses=gold;
            var controller=Singleton<GameController>.instance;
            controller.gameType=GameController.GameType.DeathMatch;controller.isWarArena=arena;controller.isRandomMatchMaking=!friendly;
            var owner=new PlayerController();owner.playerProperties.level=ownerLevel;
            owner.weaponInventory.usedWeapons.Add(new PlayerWeapon());
            owner.weaponInventory.usedWeapons.Add(new PlayerWeapon{weapon=new Weapon{hasLowAmmo=lowAmmo}});
            // A third low-ammo weapon must not trigger the first-two override.
            owner.weaponInventory.usedWeapons.Add(new PlayerWeapon{weapon=new Weapon{hasLowAmmo=true}});
            var bits=new int[bonuses.Length];
            for(int index=0;index<bonuses.Length;index++)bits[index]=BitConverter.ToInt32(BitConverter.GetBytes(bonuses[index].GetBonusProbability(owner)),0);
            samples.Add(new Sample{localDisplayLevel=level,ownerLevelIndex=ownerLevel,arena=arena,friendly=friendly,
                goldBonusesCollected=gold,lowAmmo=lowAmmo,weightBits=bits});
        }
        var currencySamples=new CurrencySample[43];
        for(int level=0;level<currencySamples.Length;level++)
        {
            float scale=Mathf.Pow(catalog.rules.warbucksScalingBase,level-3);
            var amountBytes=new byte[1000*4];
            for(int draw=500;draw<1500;draw++)
                BitConverter.GetBytes((int)(scale*(float)draw)).CopyTo(amountBytes,(draw-500)*4);
            string digest;
            using(var hash=SHA256.Create())
                digest=BitConverter.ToString(hash.ComputeHash(amountBytes)).Replace("-","").ToLowerInvariant();
            currencySamples[level]=new CurrencySample{recipientLevelIndex=level,
                scaleBits=BitConverter.ToInt32(BitConverter.GetBytes(scale),0),amountsSha256=digest};
        }
        var grenadeSamples=new GrenadeSample[catalog.rules.rankCount];
        for(int level=0;level<grenadeSamples.Length;level++)
        {
            float progress=(float)level/(float)catalog.rules.rankCount;
            float explosion=Mathf.Lerp(catalog.rules.grenadeFallbackDamageMinimum,
                catalog.rules.grenadeFallbackDamageMaximum,progress);
            float direct=explosion*0.1f;
            grenadeSamples[level]=new GrenadeSample{recipientLevelIndex=level,
                explosionBits=BitConverter.ToInt32(BitConverter.GetBytes(explosion),0),
                directBits=BitConverter.ToInt32(BitConverter.GetBytes(direct),0)};
        }
        var result=new Result{unityVersion=Application.unityVersion,codeSha256=SourceBonusProvenance.CodeHash,
            samples=samples.ToArray(),currencySamples=currencySamples,
            grenadeSamples=grenadeSamples};
        File.WriteAllText(output,JsonUtility.ToJson(result,true).Replace("\r\n","\n")+"\n",new UTF8Encoding(false));
        Debug.Log("PVP_BONUS_SOURCE PASS: "+samples.Count+" original-method Mono contexts, 43000 Unity Mathf.Pow rewards, "+grenadeSamples.Length+" grenade damage ranks");
    }
}
