using System;
using UnityEngine;

public abstract class MainGameEntity : PoolableObject, IFraction, IGameMainEntity
{
	public PhotonView photonView;

	private float mRevengeEndTime;

	public HudObjectIndicator hudObjectIndicator;

	public CardIconIndicator cardIconIndicator { get; private set; }

	public bool isRevengeKill => Time.time < mRevengeEndTime;

	public abstract Fractions fraction { get; set; }

	public abstract IFraction owner { get; set; }

	public abstract int power { get; set; }

	public bool isAlive { get; set; }

	public abstract event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	protected override void Awake()
	{
		base.Awake();
		photonView = GetComponent<PhotonView>();
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		cardIconIndicator.hudObjectIndicator = hudObjectIndicator;
		photonView.RebuildCache();
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		StopAllCoroutines();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (hudObjectIndicator != null)
		{
			hudObjectIndicator.Show(value: false);
		}
		mRevengeEndTime = 0f;
		isAlive = true;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if (hudObjectIndicator != null && mRevengeEndTime != 0f)
		{
			mRevengeEndTime = 0f;
			hudObjectIndicator.Show(value: false);
		}
		if (hudObjectIndicator != null)
		{
			hudObjectIndicator.Reset();
		}
	}

	protected void DestroyEntity(float time)
	{
		InvokeAfter(DestroyEntity, time);
	}

	protected void DestroyEntity()
	{
		if (photonView != null)
		{
			if (PhotonNetwork.isMasterClient)
			{
				DestroyPooled();
			}
			else
			{
				DestroyPooled();
			}
		}
		else
		{
			Debug.LogError("Main entity without photon view");
		}
	}

	public void SetRevenge()
	{
		if (isAlive)
		{
			if (hudObjectIndicator != null)
			{
				hudObjectIndicator.Show("game-revenge-indicator", value: true, HudObjectIndicator.IndicatorAnimation.InfoIco);
			}
			mRevengeEndTime = Time.time + 5f;
		}
	}

	protected virtual void Update()
	{
		if (Time.time > mRevengeEndTime && mRevengeEndTime != 0f)
		{
			mRevengeEndTime = 0f;
			if (hudObjectIndicator != null)
			{
				hudObjectIndicator.Show("game-revenge-indicator", value: false, HudObjectIndicator.IndicatorAnimation.InfoIco);
			}
		}
	}
}
