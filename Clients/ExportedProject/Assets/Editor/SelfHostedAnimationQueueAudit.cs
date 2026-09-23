using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class SelfHostedAnimationQueueAudit
{
    private const string Active="WarFriends.AnimationQueueAudit";
    private static Animation animation;
    private static Transform bone;
    private static float started;
    private static readonly List<object> frames=new List<object>();
    static SelfHostedAnimationQueueAudit()
    {
        if (SessionState.GetBool(Active,false)) EditorApplication.update+=Update;
    }
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_ANIMATION_QUEUE_OUTPUT"))) throw new InvalidOperationException("Set WAR_ANIMATION_QUEUE_OUTPUT.");
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(Active,true);
        EditorApplication.isPlaying=true;
    }
    private static void Update()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused) return;
        try
        {
            if (animation==null)
            {
                Time.captureFramerate=30;
                var root=new GameObject("IsolatedLegacyQueueProbe");
                bone=new GameObject("bone").transform; bone.parent=root.transform;
                animation=root.AddComponent<Animation>(); animation.cullingType=AnimationCullingType.AlwaysAnimate;
                var hide=new AnimationClip { legacy=true, wrapMode=WrapMode.Once };
                hide.SetCurve("bone",typeof(Transform),"localPosition.x",AnimationCurve.Linear(0,0,.5f,1));
                var idle=new AnimationClip { legacy=true, wrapMode=WrapMode.Loop };
                idle.SetCurve("bone",typeof(Transform),"localPosition.x",AnimationCurve.Linear(0,10,1,10));
                animation.AddClip(hide,"hide"); animation.AddClip(idle,"idle");
                animation.Play("hide"); animation.CrossFadeQueued("idle"); started=Time.time;
            }
            frames.Add(new { frame=Time.frameCount,seconds=Time.time-started,delta=Time.deltaTime,x=bone.localPosition.x,
                states=animation.Cast<AnimationState>().Select(s=>new { name=s.name,time=s.time,weight=s.weight,enabled=s.enabled }).ToArray() });
            if (Time.time-started<1.2f) return;
            string output=Environment.GetEnvironmentVariable("WAR_ANIMATION_QUEUE_OUTPUT");
            File.WriteAllText(output,JsonConvert.SerializeObject(new { unity=Application.unityVersion, scenario="Play hide(0.5s), CrossFadeQueued idle(default)",frames=frames },Formatting.Indented));
            SessionState.SetBool(Active,false); EditorApplication.update-=Update;
            Debug.Log("ANIMATION_QUEUE_AUDIT_PASSED frames="+frames.Count);
            EditorApplication.Exit(0);
        }
        catch (Exception e)
        {
            SessionState.SetBool(Active,false); EditorApplication.update-=Update;
            Debug.LogException(e); EditorApplication.Exit(1);
        }
    }
}
