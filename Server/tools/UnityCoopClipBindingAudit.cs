using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>Records actual source curve bindings so replay diagnostics need not infer partial channels.</summary>
public static class UnityCoopClipBindingAudit
{
    /// <summary>Lists bindings exposed by Unity for the named clips without modifying those clips.</summary>
    public static object Capture(Animation animation, string[] clipNames)
    {
        var clips = new List<object>();
        foreach (string clipName in clipNames)
        {
            AnimationClip clip = animation.GetClip(clipName);
            if (clip == null)
            {
                throw new InvalidOperationException("Missing source binding clip: " + clipName);
            }

            var bindings = AnimationUtility.GetCurveBindings(clip)
                .OrderBy(binding => binding.path, StringComparer.Ordinal)
                .ThenBy(binding => binding.propertyName, StringComparer.Ordinal)
                .Select(binding => new
                {
                    path = binding.path,
                    property = binding.propertyName,
                    type = binding.type.FullName
                }).ToArray();
            clips.Add(new { name = clipName, bindings });
        }

        return clips;
    }
}
