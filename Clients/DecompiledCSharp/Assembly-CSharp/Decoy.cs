using System;
using System.Collections;
using Google2u;
using UnityEngine;

public class Decoy : MainGameEntity
{
	public Renderer bodyRenderer;

	public float toGroundTime;

	public float fromGroundTime;

	public AnimationCurve fromGroundAnimation;

	public AudioClip destroySound;

	private EnemyPointObstacle mEnemyPoint;

	private DestroyableObject mDestroyableObject;

	private float mAngle;

	public Fractions mFraction = Fractions.Enemies;

	public override Fractions fraction
	{
		get
		{
			return mFraction;
		}
		set
		{
			mFraction = value;
		}
	}

	public override IFraction owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public override int power
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = base.gameObject.GetComponent<DestroyableObject>();
		mDestroyableObject.OnDamage += OnDamage;
	}

	public void Setup(EnemyPointObstacle enemyPoint)
	{
		mFraction = enemyPoint.fraction;
		mDestroyableObject.owner = enemyPoint.owner;
		mDestroyableObject.healthbarColor = ((PlayerController.currentPlayer.fraction == mFraction) ? Color.green : Color.red);
		mDestroyableObject.ChangeLayer(mFraction, isFlying: false);
		bodyRenderer.material.mainTexture = ((PlayerController.currentPlayer.fraction == mFraction) ? CardDecoy.mBlueTexture : CardDecoy.mRedTexture);
		PlayerController player = PlayerController.GetPlayer(mFraction);
		float t = (float)player.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
		float maxHealth = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.DecoyHpMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.DecoyHpMax).FLOATVALUE, t);
		mDestroyableObject.maxHealth = maxHealth;
		mDestroyableObject.Refill();
		mEnemyPoint = enemyPoint;
		mEnemyPoint.isFree = false;
		mDestroyableObject.OnDeath -= OnDeath;
		mDestroyableObject.OnDeath += OnDeath;
		photonView.RPC("SetupRPC", PhotonTargets.Others, (byte)fraction);
	}

	[PunRPC]
	protected void SetupRPC(byte fr)
	{
		mFraction = (Fractions)fr;
		mDestroyableObject.healthbarColor = ((PlayerController.currentPlayer.fraction == mFraction) ? Color.green : Color.red);
		mDestroyableObject.ChangeLayer(mFraction, isFlying: false);
		bodyRenderer.material.mainTexture = ((PlayerController.currentPlayer.fraction == mFraction) ? CardDecoy.mBlueTexture : CardDecoy.mRedTexture);
	}

	private void OnDeath(DestroyableObject arg1, DestroyableObject.DamageInfo arg2)
	{
		mDestroyableObject.OnDeath -= OnDeath;
		mEnemyPoint.isFree = true;
		ProcessDeath();
		photonView.RPC("OnDeathRPC", PhotonTargets.Others);
	}

	[PunRPC]
	protected void OnDeathRPC()
	{
		ProcessDeath();
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		bodyRenderer.material.mainTexture = null;
	}

	private void OnDamage(DestroyableObject obj, DestroyableObject.DamageInfo info)
	{
		MonoBehaviour monoBehaviour = info.owner as MonoBehaviour;
		if (monoBehaviour != null && Vector3.Dot(monoBehaviour.transform.position - base.transform.position, base.transform.forward) > 0f)
		{
			StopCoroutine(AnimateHit());
			StartCoroutine(AnimateHit());
		}
	}

	private void ProcessDeath()
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.Play(base.transform.position, destroySound);
		Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position, Vector3.up, "groundBoxHit");
		DestroyPooled();
	}

	private IEnumerator AnimateHit()
	{
		float phase = Mathf.Clamp01(mAngle / 90f);
		phase *= phase;
		while (phase < 1f)
		{
			phase = Mathf.Clamp01(phase + TimeManager.deltaTimeWithoutPauses / toGroundTime);
			SetAngle(90f * Mathf.Sqrt(phase));
			yield return 0;
		}
		phase = 0f;
		while (phase < 1f)
		{
			phase = Mathf.Clamp01(phase + TimeManager.deltaTimeWithoutPauses / fromGroundTime);
			SetAngle(90f * fromGroundAnimation.Evaluate(phase));
			yield return 0;
		}
	}

	private void SetAngle(float angle)
	{
		mAngle = angle;
		bodyRenderer.transform.localRotation = Quaternion.Euler(0f - mAngle, 0f, 0f);
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		SetAngle(0f);
	}

	public override void DestroyPooled(bool changeParentBack)
	{
		base.DestroyPooled(changeParentBack);
		StopCoroutine(AnimateHit());
	}
}
