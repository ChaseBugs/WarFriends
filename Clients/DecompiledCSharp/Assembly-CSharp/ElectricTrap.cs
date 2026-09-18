using System;
using System.Collections;
using UnityEngine;

public class ElectricTrap : Core_BaseScript
{
	public PhysicsEventsListener trigger;

	public Shield shield;

	public PhotonView photonView;

	public GameObject handle;

	public Renderer electricityRenderer;

	public float electricityEffectPeriod;

	public int electricityEffectFrames;

	public GameObject leftInsulator;

	public GameObject rightInsulator;

	public GameObject effect;

	private DestroyableObject mDestroyableObject;

	private bool mAnimating;

	protected override void Awake()
	{
		base.Awake();
		PhysicsEventsListener physicsEventsListener = trigger;
		physicsEventsListener.onTriggerEnter = (Action<Collider>)Delegate.Combine(physicsEventsListener.onTriggerEnter, new Action<Collider>(TriggerOnTriggerEnter));
	}

	private void TriggerOnTriggerEnter(Collider other)
	{
		if (TagsAndLayers.IsDestroyableObject(other.transform.gameObject))
		{
			DestroyableObject component = other.GetComponent<DestroyableObject>();
			if (component != null && shield.fraction != component.fraction && component.owner is EnemyController && photonView.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, shield, isNetworkCopy: false);
				Explode(component.transform.position);
			}
		}
	}

	private void SetVisibility(bool visible)
	{
		handle.SetActive(visible);
		if (visible)
		{
			handle.transform.localPosition = new Vector3(handle.transform.localPosition.x, (!Singleton<MapManager>.instance.currentMapDef.moveElectricTraps) ? 0.05f : (-0.15f), handle.transform.localPosition.z);
			NavMesh.SamplePosition(leftInsulator.transform.position, out var hit, 10f, 1);
			leftInsulator.transform.position = hit.position;
			NavMesh.SamplePosition(rightInsulator.transform.position, out hit, 10f, 1);
			rightInsulator.transform.position = hit.position;
			effect.transform.localPosition = effect.transform.localPosition.ReplaceY((leftInsulator.transform.localPosition.y + rightInsulator.transform.localPosition.y) / 2f + 0.125f);
			if (!mAnimating)
			{
				mAnimating = true;
				StartCoroutine(Animate());
			}
		}
		else if (mAnimating)
		{
			mAnimating = false;
			StopCoroutine(Animate());
		}
	}

	public void SetTrap(bool visible)
	{
		SetVisibility(visible);
		photonView.RPC("SetTrapRPC", PhotonTargets.Others, visible);
	}

	[PunRPC]
	protected void SetTrapRPC(bool visible)
	{
		SetVisibility(visible);
	}

	protected void Explode(Vector3 position)
	{
		photonView.RPC("ExplodeRPC", PhotonTargets.Others, position);
		ExplodeRPC(position);
	}

	[PunRPC]
	protected void ExplodeRPC(Vector3 position)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, Sounds3DEnum.ElectricalBurst);
		Singleton<HitParticleSystem>.instance.PlayParticle(position, Vector3.up, "electricTrap");
		SetVisibility(visible: false);
	}

	private IEnumerator Animate()
	{
		int currentIndex = UnityEngine.Random.Range(0, electricityEffectFrames);
		float height = 1f / (float)electricityEffectFrames;
		electricityRenderer.material.mainTextureScale = new Vector2(1f, height);
		while (true)
		{
			int num = currentIndex + 1;
			currentIndex = num % electricityEffectFrames;
			electricityRenderer.material.mainTextureOffset = new Vector2(0f, height * (float)currentIndex);
			yield return new WaitForSeconds(electricityEffectPeriod);
		}
	}
}
