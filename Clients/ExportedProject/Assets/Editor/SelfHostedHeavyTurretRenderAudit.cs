using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedHeavyTurretRenderAudit
{
	public static void Run()
	{
		GameObject owner = null;
		try
		{
			GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/HeavyTurret.prefab");
			HeavyTurret source = prefab == null ? null : prefab.GetComponent<HeavyTurret>();
			Require(source != null, "recovered HeavyTurret prefab");
			MeshFilter[] expected = source.GetComponentsInChildren<MeshFilter>(true);
			Require(expected.Length >= 4, "recovered mesh filters, found " + expected.Length);
			owner = new GameObject("SelfHostedHeavyTurretRenderAudit");
			var presenter = owner.AddComponent<SelfHostedHeavyTurretPresenter>(); presenter.Configure(source);
			var snapshot = new MatchSnapshot(); snapshot.HeavyTurrets.Add(new BattleHeavyTurretState
			{
				EntityId=81,RequestId="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",OwnerPlayerId="11111111111111111111111111111111",
				OwnerFraction=1,SlotComponentFileId=3417,X=2,Y=3,Z=4,Health=90,MaxHealth=100,Damage=25,
				BatchMinimum=3,BatchMaximum=6,ShootMinimum=2,ShootMaximum=4,RealShotProbability=1,AttackPhase="cooldown"
			});
			presenter.Apply(snapshot); GameObject visual=GameObject.Find("SelfHostedHeavyTurret_81");
			Require(visual!=null&&visual.transform.position==new Vector3(2,3,4),"authoritative position");
			MeshFilter[] actual=visual.GetComponentsInChildren<MeshFilter>(true);
			Require(actual.Length==expected.Length&&actual.Select(x=>x.sharedMesh).SequenceEqual(expected.Select(x=>x.sharedMesh)),"recovered mesh identities");
			Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length==0&&visual.GetComponentsInChildren<Collider>(true).Length==0&&
				visual.GetComponentsInChildren<Rigidbody>(true).Length==0,"script-free visual");
			snapshot.HeavyTurrets[0].Health=40;presenter.Apply(snapshot);
			Require(GameObject.Find("SelfHostedHeavyTurret_81")!=null,"damage snapshot retention");
			presenter.ApplyEvent(new MatchEvent{Kind=MatchEventKind.HeavyTurretDestroyed,ProjectileId=81,X=2,Y=3,Z=4});
			Require(GameObject.Find("SelfHostedHeavyTurret_81")==null,"destruction event removal");
			snapshot.HeavyTurrets[0].EntityId=82;presenter.Apply(snapshot);presenter.Apply(new MatchSnapshot());
			Require(GameObject.Find("SelfHostedHeavyTurret_82")==null,"snapshot reconciliation");
			Debug.Log("UNITY_HEAVY_TURRET_RENDER_PASSED meshes="+expected.Length+" scriptFree=True eventRemoval=True snapshotRemoval=True");
			EditorApplication.Exit(0);
		}
		catch(Exception exception){Debug.LogError(exception);EditorApplication.Exit(1);}
		finally{if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);}
	}
	private static void Require(bool value,string name){if(!value)throw new InvalidOperationException("Heavy Turret render audit failed: "+name);}
}
