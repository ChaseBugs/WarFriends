using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class UnityPvpSelectionAudit
{
    [Serializable] private sealed class Sample
    {
        public string name;
        public int[] weightBits;
        public int lastIndex,drawBits,queuedIndex,side,totalBits,drawCalls,prefabIndex,sourceIndex;
    }
    [Serializable] private sealed class Result {public int version=1;public string unityVersion,managerSha256;public Sample[] samples;}
    private static int Bits(float value){return BitConverter.ToInt32(BitConverter.GetBytes(value),0);}
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_PVP_SELECTION_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new Exception("Set WAR_PVP_SELECTION_OUTPUT.");
        float[][] tables={new float[]{10,20,30,20,35,35,10,5,25},
            new float[]{0,20,0,20,35,35,10,0,50},new float[]{16.666666f,20,30,20,35,35,10,5,25},new float[9]};
        var samples=new List<Sample>();
        for(int table=0;table<tables.Length;table++)
        foreach(int last in new[]{0,1,8,9}) {
            float total=0;for(int index=0;index<9;index++)if(index!=last)total+=tables[table][index];
            float[] draws={0f,20f,total/2f,total};
            foreach(float draw in draws) {
                if(draw>total)continue;
                var source=new SourceSelectionReference(tables[table],last);
                SourceSelectionDraw.value=draw;SourceSelectionDraw.calls=0;SourceSelectionDraw.total=0;
                var selected=source.Select(new PlayerController{fraction=Fractions.Allies});
                var bits=new int[9];for(int index=0;index<9;index++)bits[index]=Bits(tables[table][index]);
                samples.Add(new Sample{name="weighted-"+table,weightBits=bits,lastIndex=last,drawBits=Bits(draw),queuedIndex=-2,side=1,
                    totalBits=Bits(SourceSelectionDraw.total),drawCalls=SourceSelectionDraw.calls,prefabIndex=selected.prefabIndex,sourceIndex=selected.sourceIndex});
            }
        }
        foreach(int queued in new[]{0,7,-1})
        foreach(int side in new[]{1,2}) {
            var source=new SourceSelectionReference(tables[0],0);source.Enqueue(queued,(Fractions)side);
            SourceSelectionDraw.value=0;SourceSelectionDraw.calls=0;SourceSelectionDraw.total=0;
            var selected=source.Select(new PlayerController{fraction=(Fractions)side});
            var bits=new int[9];for(int index=0;index<9;index++)bits[index]=Bits(tables[0][index]);
            samples.Add(new Sample{name="queued",weightBits=bits,lastIndex=0,drawBits=0,queuedIndex=queued,side=side,
                totalBits=Bits(SourceSelectionDraw.total),drawCalls=SourceSelectionDraw.calls,prefabIndex=selected.prefabIndex,sourceIndex=selected.sourceIndex});
        }
        var result=new Result{unityVersion=Application.unityVersion,managerSha256=SourceSelectionProvenance.ManagerHash,samples=samples.ToArray()};
        File.WriteAllText(output,JsonUtility.ToJson(result,true).Replace("\r\n","\n")+"\n",new UTF8Encoding(false));
        Debug.Log("PVP_SELECTION_SOURCE PASS: "+samples.Count+" original-prefix Mono samples");
    }
}
