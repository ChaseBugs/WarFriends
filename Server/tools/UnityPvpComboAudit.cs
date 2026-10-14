using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class UnityPvpComboAudit
{
    [Serializable] private sealed class Step
    {
        public int timeBits;
        public int streak;
        public int comboFlag;
    }
    [Serializable] private sealed class Case
    {
        public string name;
        public Step[] steps;
    }
    [Serializable] private sealed class Result
    {
        public int version = 1;
        public string unityVersion;
        public string managerSha256;
        public string skillSha256;
        public Case[] cases;
    }

    public static void Run()
    {
        string path = Environment.GetEnvironmentVariable("WAR_PVP_COMBO_OUTPUT");
        if (string.IsNullOrEmpty(path)) throw new Exception("Set WAR_PVP_COMBO_OUTPUT.");
        string[] names = { "ordinary", "boundary", "same_frame", "large_clock", "adjacent_large", "paused_clock" };
        float[][] clocks = {
            new[] { 0f, .2f, .4f, .6f },
            new[] { 1f, 1f + .9f, 2f, 2.899f },
            new[] { 2f, 2f, 2f, 2f },
            new[] { 16777216f, 16777216f, 16777216f },
            new[] { 16777215f, 16777215f, 16777216f },
            new[] { 5f, 5f, 5f, 5.9f }
        };
        var cases = new List<Case>();
        for (int index = 0; index < clocks.Length; index++)
        {
            var source = new SourceComboReference();
            var steps = new List<Step>();
            foreach (float time in clocks[index])
            {
                SourceComboClock.time = time;
                var skill = new SkillShot();
                source.RecieveKill(ref skill);
                steps.Add(new Step {
                    timeBits = BitConverter.ToInt32(BitConverter.GetBytes(time), 0),
                    streak = source.Streak, comboFlag = (int)skill.type
                });
            }
            cases.Add(new Case { name = names[index], steps = steps.ToArray() });
        }
        var result = new Result {
            unityVersion = Application.unityVersion,
            managerSha256 = SourceComboProvenance.ManagerHash,
            skillSha256 = SourceComboProvenance.SkillHash,
            cases = cases.ToArray()
        };
        File.WriteAllText(path, JsonUtility.ToJson(result, true).Replace("\r\n", "\n") + "\n", new UTF8Encoding(false));
        Debug.Log("PVP_COMBO_SOURCE PASS: 22 original-method Mono samples");
    }
}
