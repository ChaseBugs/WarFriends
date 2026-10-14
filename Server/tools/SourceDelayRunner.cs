using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public sealed class SourceDelayRunner : MonoBehaviour
{
    [Serializable] private sealed class Frame {public int offset,timeBits,deltaBits;public bool paused;}
    [Serializable] private sealed class Case
    {
        public string name;
        public int fps,scaleBits,issueTimeBits,issueFrame,callbackTimeBits,callbackFrame,poolFrees;
        public Frame[] frames;
        public int[] callbackOwnerOrder;
    }
    [Serializable] private sealed class Result {public int version=1;public string unityVersion,managerSha256,coreSha256;public Case[] cases;}
    private readonly string[] names={"30fps","60fps","half_speed","double_speed","paused_ten_frames","game_ended_manager_alive","same_frame_two_requests","manager_destroyed"};
    private readonly int[] frameRates={30,60,30,30,30,30,30,30};
    private readonly float[] scales={1f,1f,.5f,2f,1f,1f,1f,1f};
    private readonly List<Case> cases=new List<Case>();
    private readonly List<Frame> frames=new List<Frame>();
    private readonly List<int> callbackOwnerOrder=new List<int>();
    private SourceDelayReference source;
    private Case current;
    private int caseIndex,prepareFrames=2,totalFrames;
    private bool issued,completed;
    private static int Bits(float value){return BitConverter.ToInt32(BitConverter.GetBytes(value),0);}
    private void Start()
    {
        source=gameObject.AddComponent<SourceDelayReference>();
        source.callback=OnCallback;
        PrepareCase();
    }
    private void PrepareCase()
    {
        Time.captureFramerate=frameRates[caseIndex];Time.timeScale=scales[caseIndex];
        current=new Case{name=names[caseIndex],fps=frameRates[caseIndex],scaleBits=Bits(scales[caseIndex])};
        frames.Clear();callbackOwnerOrder.Clear();issued=false;completed=false;prepareFrames=2;ObjectPoolDatabase.networkPool.frees=0;
    }
    private void Update()
    {
        if(++totalFrames>1200)throw new Exception("Original coroutine failed to resume within probe frame bound.");
        if(completed) {
            current.poolFrees=ObjectPoolDatabase.networkPool.frees;current.frames=frames.ToArray();
            current.callbackOwnerOrder=callbackOwnerOrder.ToArray();cases.Add(current);
            caseIndex++;
            if(caseIndex==names.Length){Finish();return;}
            PrepareCase();return;
        }
        if(prepareFrames-->0)return;
        if(!issued) {
            current.issueTimeBits=Bits(Time.time);current.issueFrame=Time.frameCount;issued=true;
            source.GenerateNewBonus(new PlayerController{id=1});
            if(caseIndex==6)source.GenerateNewBonus(new PlayerController{id=2});
        }
        int offset=Time.frameCount-current.issueFrame;
        frames.Add(new Frame{offset=offset,timeBits=Bits(Time.time),deltaBits=Bits(Time.deltaTime),paused=Time.timeScale==0});
        if(caseIndex==4 && offset==10)Time.timeScale=0;
        if(caseIndex==4 && offset==20)Time.timeScale=scales[caseIndex];
        if(caseIndex==5 && offset==5)source.EndGame();
        if(caseIndex==7 && offset==5)Destroy(source);
        if(caseIndex==7 && offset==65)completed=true;
    }
    private void OnCallback(PlayerController owner)
    {
        current.callbackTimeBits=Bits(Time.time);current.callbackFrame=Time.frameCount;
        callbackOwnerOrder.Add(owner.id);completed=callbackOwnerOrder.Count==(caseIndex==6?2:1);
    }
    private void Finish()
    {
        Time.captureFramerate=0;Time.timeScale=1;
        var result=new Result{unityVersion=Application.unityVersion,managerSha256=SourceDelayProvenance.ManagerHash,
            coreSha256=SourceDelayProvenance.CoreHash,cases=cases.ToArray()};
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_PVP_DELAY_OUTPUT"),
            JsonUtility.ToJson(result,true).Replace("\r\n","\n")+"\n",new UTF8Encoding(false));
        Debug.Log("PVP_DELAY_SOURCE PASS: "+cases.Count+" original-coroutine Play Mode cases");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
#endif
    }
}
