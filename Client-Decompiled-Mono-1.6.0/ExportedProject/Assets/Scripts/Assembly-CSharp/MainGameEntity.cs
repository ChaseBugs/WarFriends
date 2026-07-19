using System;
using UnityEngine;

public abstract class MainGameEntity : PoolableObject, NKMKCCDCHCL, KMHCMCBGFFC
{
	public PhotonView LAADDLGBFIG;

	private float EABBCBAMLIL;

	public HudObjectIndicator KJMFJFCDEDH;

	public CardIconIndicator cardIconIndicator { get; private set; }

	public virtual DestroyableObject destroyableObj
	{
		get
		{
			return null;
		}
	}

	public bool isRevengeKill
	{
		get
		{
			return Time.time < EABBCBAMLIL;
		}
	}

	public abstract GHPGNELIDBM fraction { get; set; }

	public abstract KMHCMCBGFFC owner { get; set; }

	public abstract int power { get; set; }

	public bool isAlive { get; set; }

	public abstract event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed;

	protected override void Awake()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		cardIconIndicator.KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		StopAllCoroutines();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.Show(false);
		}
		EABBCBAMLIL = 0f;
		isAlive = true;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if (KJMFJFCDEDH != null && EABBCBAMLIL != 0f)
		{
			EABBCBAMLIL = 0f;
			KJMFJFCDEDH.Show(false);
		}
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.Reset();
		}
	}

	protected void CDCOFHGPJHN(float KBJEOEEOEFG)
	{
		InvokeAfter(CDCOFHGPJHN, KBJEOEEOEFG);
	}

	protected void CDCOFHGPJHN()
	{
		if (LAADDLGBFIG != null)
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
			if (KJMFJFCDEDH != null)
			{
				KJMFJFCDEDH.Show("game-revenge-indicator", true, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			}
			EABBCBAMLIL = Time.time + 5f;
		}
	}

	protected virtual void Update()
	{
		if (Time.time > EABBCBAMLIL && EABBCBAMLIL != 0f)
		{
			EABBCBAMLIL = 0f;
			if (KJMFJFCDEDH != null)
			{
				KJMFJFCDEDH.Show("game-revenge-indicator", false, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			}
		}
	}
}
