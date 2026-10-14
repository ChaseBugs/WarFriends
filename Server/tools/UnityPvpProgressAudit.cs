using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class UnityPvpProgressAudit
{
    [Serializable] private sealed class Sample
    {
        public string name;
        public int initialBits, points, ratioBits, multiplierBits, deltaBits;
        public bool running;
        public int gainBits, afterBits, bonuses, opponentGainBits, opponentAfterBits, opponentBonuses;
    }
    [Serializable] private sealed class Result
    {
        public int version = 1;
        public string unityVersion, managerSha256;
        public Sample[] samples;
    }
    private static int Bits(float value) { return BitConverter.ToInt32(BitConverter.GetBytes(value), 0); }
    private static Sample Observe(string name, float initial, int points, float ratio,
        float multiplier, float delta, bool running)
    {
        Singleton<KillStreakManager>.instance = new KillStreakManager();
        var source = new SourceScoreReference();
        source.SetProgress(initial, initial);
        source.killStreakScoreRatio = ratio;
        source.bonusMultiplier = multiplier;
        source.bonusMultiplierEnemy = multiplier;
        var definition = new SkillShotManager.SkillShotItemDefinition {skillShotType=SkillShot.SkillShotType.Kill, points=points};
        source.AddSkillshot(definition, PlayerController.currentPlayer);
        source.AddSkillshot(definition, Singleton<GameController>.instance.opponent);
        var sample = new Sample { name=name, initialBits=Bits(initial), points=points,
            ratioBits=Bits(ratio), multiplierBits=Bits(multiplier), deltaBits=Bits(delta), running=running,
            gainBits=Bits(source.killStreakProgress), opponentGainBits=Bits(source.killStreakProgressOpponent) };
        source.Frame(delta, running);
        sample.afterBits=Bits(source.killStreakProgress);
        sample.opponentAfterBits=Bits(source.killStreakProgressOpponent);
        sample.bonuses=Singleton<KillStreakManager>.instance.localBonuses;
        sample.opponentBonuses=Singleton<KillStreakManager>.instance.opponentBonuses;
        return sample;
    }
    public static void Run()
    {
        string path = Environment.GetEnvironmentVariable("WAR_PVP_PROGRESS_OUTPUT");
        if (string.IsNullOrEmpty(path)) throw new Exception("Set WAR_PVP_PROGRESS_OUTPUT.");
        var samples = new List<Sample> {
            Observe("ordinary", 0f, 46, .75f, 1f, 1f/30f, true),
            Observe("booster", .1f, 46, .75f, 1.25f, .016666668f, true),
            Observe("blocker", 20f, 106, .75f, 0f, .5f, true),
            Observe("no_crates", 0f, 106, 0f, 1f, .5f, true),
            Observe("exact_threshold", 100f, 0, .75f, 1f, 0f, true),
            Observe("above_threshold", 100.00001f, 0, .75f, 1f, 0f, true),
            Observe("decay_before_threshold", 100.01f, 0, .75f, 1f, .1f, true),
            Observe("one_bonus_only", 350f, 0, .75f, 1f, 0f, true),
            Observe("paused", 350f, 46, .75f, 1f, 1f, false),
            Observe("clamp_zero", .01f, 0, .75f, 1f, 1f, true),
            Observe("large_progress", 16777216f, 46, .75f, 1.25f, 1f/30f, true),
            Observe("fractional_multiplier", .00001f, 19, .75f, .8f, .1234567f, true),
            Observe("subnormal_decay", float.Epsilon, 0, .75f, 1f, float.Epsilon, true)
        };
        var result = new Result {unityVersion=Application.unityVersion,
            managerSha256=SourceScoreProvenance.ManagerHash, samples=samples.ToArray()};
        File.WriteAllText(path, JsonUtility.ToJson(result,true).Replace("\r\n","\n")+"\n",new UTF8Encoding(false));
        Debug.Log("PVP_PROGRESS_SOURCE PASS: " + samples.Count + " original-method Mono samples");
    }
}
