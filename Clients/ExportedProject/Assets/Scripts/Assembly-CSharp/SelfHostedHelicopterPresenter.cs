using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Script-free recovered Helicopter geometry; the Worker owns flight, crew,
// turret acquisition, collision and damage.
public sealed class SelfHostedHelicopterPresenter : MonoBehaviour
{
    private sealed class Visual
    {
        public GameObject Root;
        public Transform Horizontal;
        public Transform Vertical;
        public Rotor[] Rotors;
        public float RotorSeconds;
        public float SampledAt;
    }
    private sealed class Rotor
    {
        public Transform Target;
        public TweenRotationSpecial Source;
    }

    private readonly Dictionary<ulong,Visual> active=new Dictionary<ulong,Visual>();
    private Helicopter source;

    public void Configure(Helicopter prefab) { source=prefab; }

    public void Apply(IReadOnlyList<BattleArmyEntityState> rows)
    {
        if(rows==null)throw new ArgumentNullException("rows");
        var present=new HashSet<ulong>();
        foreach(var row in rows)
        {
            if(row.UnitId!="ID_UNIT-HELICOPTER")continue;
            if(row.HelicopterRotation==null||row.HelicopterTurretHorizontalLocal==null||
                row.HelicopterTurretVerticalWorld==null)
                throw new InvalidOperationException("Authoritative Helicopter pose is incomplete.");
            present.Add(row.EntityKey);
            Visual visual;
            if(!active.TryGetValue(row.EntityKey,out visual))
            {
                visual=Create(row.EntityKey);
                active.Add(row.EntityKey,visual);
            }
            visual.Root.transform.position=new Vector3(row.X,row.Y,row.Z);
            visual.Root.transform.rotation=Rotation(row.HelicopterRotation);
            visual.Horizontal.localRotation=Rotation(row.HelicopterTurretHorizontalLocal);
            visual.Vertical.rotation=Rotation(row.HelicopterTurretVerticalWorld);
            if(row.PositionTick<row.SpawnTick)
                throw new InvalidOperationException("Helicopter visual tick predates spawn.");
            visual.RotorSeconds=(row.PositionTick-row.SpawnTick)/30f;
            visual.SampledAt=Time.unscaledTime;
            SampleRotors(visual,visual.RotorSeconds);
        }
        var stale=new List<ulong>();
        foreach(var pair in active)if(!present.Contains(pair.Key))stale.Add(pair.Key);
        foreach(ulong key in stale){DestroyVisual(active[key].Root);active.Remove(key);}
    }

    private Visual Create(ulong key)
    {
        if(source==null||source.turret==null||source.turret.jontHorizontal==null||
            source.turret.jointVertical==null)
            throw new InvalidOperationException("Recovered Helicopter visual joints are absent.");
        var root=new GameObject("SelfHostedHelicopter_"+key);
        var map=new Dictionary<Transform,Transform>();
        Copy(source.transform,root.transform,true,map);
        var tweens=source.GetComponentsInChildren<TweenRotationSpecial>(true);
        var rotors=new List<Rotor>();
        foreach(var tween in tweens)
        {
            string name=tween.gameObject.name;
            if(name!="propeller_front"&&name!="propeller_front (1)"&&
                name!="propeller_tail")continue;
            if(tween.style!=UITweener.Style.Loop||tween.method!=UITweener.Method.Linear||
                tween.duration<=0||tween.animationCurve==null)
                throw new InvalidOperationException("Recovered Helicopter rotor tween changed.");
            rotors.Add(new Rotor{Target=map[tween.transform],Source=tween});
        }
        if(rotors.Count!=3)
            throw new InvalidOperationException("Recovered Helicopter requires three rotor tweens.");
        return new Visual{Root=root,Horizontal=map[source.turret.jontHorizontal],
            Vertical=map[source.turret.jointVertical],Rotors=rotors.ToArray()};
    }

    private static void SampleRotors(Visual visual,float seconds)
    {
        foreach(var rotor in visual.Rotors)
        {
            var tween=rotor.Source;
            float phase=seconds/tween.duration;
            phase-=Mathf.Floor(phase);
            float factor=tween.animationCurve.Evaluate(phase);
            float angle=tween.from*(1f-factor)+tween.to*factor;
            rotor.Target.localRotation=Quaternion.AngleAxis(angle,tween.rotationAxis)*
                Quaternion.Euler(tween.baseRotation);
        }
    }

    private void Update()
    {
        foreach(var visual in active.Values)
            SampleRotors(visual,visual.RotorSeconds+
                Mathf.Max(0f,Time.unscaledTime-visual.SampledAt));
    }

    private static Quaternion Rotation(BattleJointRotation value)
    {
        var q=new Quaternion(value.X,value.Y,value.Z,value.W);
        if(float.IsNaN(q.x)||float.IsNaN(q.y)||float.IsNaN(q.z)||float.IsNaN(q.w)||
            Mathf.Abs(q.x*q.x+q.y*q.y+q.z*q.z+q.w*q.w-1f)>.001f)
            throw new InvalidOperationException("Invalid Helicopter visual rotation.");
        return q;
    }

    private static void Copy(Transform from,Transform to,bool root,Dictionary<Transform,Transform> map)
    {
        map.Add(from,to);
        to.localScale=from.localScale;
        if(!root)
        {
            to.localPosition=from.localPosition;
            to.localRotation=from.localRotation;
            to.gameObject.SetActive(from.gameObject.activeSelf);
        }
        var filter=from.GetComponent<MeshFilter>();var renderer=from.GetComponent<MeshRenderer>();
        if(filter!=null&&renderer!=null)
        {
            to.gameObject.AddComponent<MeshFilter>().sharedMesh=filter.sharedMesh;
            var copy=to.gameObject.AddComponent<MeshRenderer>();
            copy.sharedMaterials=renderer.sharedMaterials;
            copy.enabled=renderer.enabled;
            copy.shadowCastingMode=renderer.shadowCastingMode;
            copy.receiveShadows=renderer.receiveShadows;
        }
        for(int i=0;i<from.childCount;i++)
        {
            var child=from.GetChild(i);
            var obj=new GameObject(child.name);
            obj.transform.SetParent(to,false);
            Copy(child,obj.transform,false,map);
        }
    }

    private void OnDestroy()
    {
        foreach(var visual in active.Values)DestroyVisual(visual.Root);
        active.Clear();
    }

    private static void DestroyVisual(GameObject value)
    {
        if(Application.isPlaying)UnityEngine.Object.Destroy(value);
        else UnityEngine.Object.DestroyImmediate(value);
    }
}
