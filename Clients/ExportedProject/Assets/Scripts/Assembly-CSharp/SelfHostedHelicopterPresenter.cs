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
        public GameObject Gunner;
        public GameObject GunnerAnimationRoot;
        public AnimationClip GunnerIdle;
        public float GunnerSeconds;
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
    private EnemyController enemySource;
    private SoldierBehaviour gunnerBehaviour;

    public void Configure(Helicopter prefab,EnemyController enemy,SoldierBehaviour behaviour)
    { source=prefab;enemySource=enemy;gunnerBehaviour=behaviour; }

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
            if(row.HelicopterGunnerMaxHealth>0)
            {
                if(visual.Gunner==null)visual.Gunner=CreateGunner(visual);
                visual.Gunner.SetActive(row.HelicopterGunnerHealth>0);
                if(row.HelicopterGunnerHealth>0)
                {
                    visual.GunnerSeconds=(row.PositionTick-row.HelicopterGunnerSpawnTick)/30f;
                    SampleGunner(visual,visual.GunnerSeconds);
                }
            }
            else if(visual.Gunner!=null)visual.Gunner.SetActive(false);
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

    private GameObject CreateGunner(Visual visual)
    {
        if(enemySource==null||enemySource.meshChanger==null||gunnerBehaviour==null||
            gunnerBehaviour.cardSoldierVisuals==null||gunnerBehaviour.cardSoldierVisuals.Count!=1||
            source.enemyPointVehicle==null)
            throw new InvalidOperationException("Recovered Helicopter gunner sources are absent.");
        var style=gunnerBehaviour.cardSoldierVisuals[0];
        style.LoadModel();
        if(style.modelMeshRenderer==null||style.modelMeshRenderer.sharedMesh==null||
            style.helmetMesh==null)
            throw new InvalidOperationException("Recovered Assaulter gunner meshes are absent.");
        var seat=visual.Root.GetComponentsInChildren<Transform>(true);
        Transform seatCopy=null;
        foreach(var part in seat)
            if(part.name==source.enemyPointVehicle.transform.name){seatCopy=part;break;}
        if(seatCopy==null)throw new InvalidOperationException("Recovered Helicopter seat is absent.");
        var root=new GameObject("SelfHostedGunner");
        root.transform.SetParent(seatCopy,false);
        var map=new Dictionary<Transform,Transform>();
        Copy(enemySource.transform,root.transform,true,map);
        root.transform.localPosition=Vector3.zero;
        root.transform.localRotation=Quaternion.identity;
        root.transform.localScale=Vector3.one;
        var sourceSkin=enemySource.meshChanger.skinnedMeshRenderer;
        if(sourceSkin==null||sourceSkin.bones==null)
            throw new InvalidOperationException("Recovered gunner skeleton is absent.");
        var skin=map[sourceSkin.transform].gameObject.AddComponent<SkinnedMeshRenderer>();
        skin.sharedMesh=style.modelMeshRenderer.sharedMesh;
        skin.sharedMaterials=style.modelMeshRenderer.sharedMaterials;
        var bones=new Transform[sourceSkin.bones.Length];
        for(int i=0;i<bones.Length;i++)bones[i]=map[sourceSkin.bones[i]];
        skin.bones=bones;
        skin.rootBone=map[sourceSkin.rootBone];
        skin.localBounds=sourceSkin.localBounds;
        skin.updateWhenOffscreen=sourceSkin.updateWhenOffscreen;
        var helmet=enemySource.meshChanger.helmet;
        if(helmet==null||helmet.NoRigidBodyObject==null||helmet.RigidBodyObject==null)
            throw new InvalidOperationException("Recovered gunner helmet rig is absent.");
        var fixedHelmet=helmet.NoRigidBodyObject.GetComponent<MeshFilter>();
        var looseHelmet=helmet.RigidBodyObject.GetComponent<MeshFilter>();
        if(fixedHelmet==null||looseHelmet==null)
            throw new InvalidOperationException("Recovered gunner helmet filters are absent.");
        map[fixedHelmet.transform].GetComponent<MeshFilter>().sharedMesh=style.helmetMesh;
        map[looseHelmet.transform].GetComponent<MeshFilter>().sharedMesh=style.helmetMesh;
        if(enemySource.meshChanger.powerband!=null)
            map[enemySource.meshChanger.powerband.transform].gameObject.SetActive(false);
        if(enemySource.soldierParts!=null&&enemySource.soldierParts.shadow!=null)
            map[enemySource.soldierParts.shadow.transform].gameObject.SetActive(false);
        var animation=enemySource.GetComponentInChildren<Animation>(true);
        if(animation==null||animation.GetClip("idle_1")==null)
            throw new InvalidOperationException("Recovered gunner idle clip is absent.");
        visual.GunnerIdle=animation.GetClip("idle_1");
        visual.GunnerAnimationRoot=map[animation.transform].gameObject;
        return root;
    }

    private static void SampleGunner(Visual visual,float seconds)
    {
        if(visual.Gunner==null||!visual.Gunner.activeSelf||visual.GunnerIdle==null)return;
        visual.GunnerIdle.SampleAnimation(visual.GunnerAnimationRoot,
            Mathf.Repeat(seconds,visual.GunnerIdle.length));
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
        {
            SampleRotors(visual,visual.RotorSeconds+
                Mathf.Max(0f,Time.unscaledTime-visual.SampledAt));
            SampleGunner(visual,visual.GunnerSeconds+
                Mathf.Max(0f,Time.unscaledTime-visual.SampledAt));
        }
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
