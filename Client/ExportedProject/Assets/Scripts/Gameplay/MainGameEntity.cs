using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class MainGameEntity : PoolableObject, NKMKCCDCHCL, KMHCMCBGFFC
{
	[FormerlySerializedAs("LOAGAOKNAPI")]
	public PhotonView LAADDLGBFIG;

	private float EABBCBAMLIL;

	[FormerlySerializedAs("GPMAFHJICMH")]
	public HudObjectIndicator KJMFJFCDEDH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CardIconIndicator _003CICJCCHGINIH_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CFCIBDHGKAGG_003Ek__BackingField;

	public CardIconIndicator cardIconIndicator
	{
		[CompilerGenerated]
		get
		{
			return _003CICJCCHGINIH_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CICJCCHGINIH_003Ek__BackingField = value;
		}
	}

	public virtual DestroyableObject destroyableObj => null;

	public bool isRevengeKill => Time.time < EABBCBAMLIL;

	public abstract GHPGNELIDBM fraction { get; set; }

	public abstract KMHCMCBGFFC owner { get; set; }

	public abstract int power { get; set; }

	public bool isAlive
	{
		[CompilerGenerated]
		get
		{
			return _003CFCIBDHGKAGG_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CFCIBDHGKAGG_003Ek__BackingField = value;
		}
	}

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
			KJMFJFCDEDH.Show(IDEBKDPMPGM: false);
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
			KJMFJFCDEDH.Show(IDEBKDPMPGM: false);
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
			UnityEngine.Debug.LogError("Main entity without photon view");
		}
	}

	public void SetRevenge()
	{
		if (isAlive)
		{
			if (KJMFJFCDEDH != null)
			{
				KJMFJFCDEDH.Show("game-revenge-indicator", IDEBKDPMPGM: true, HudObjectIndicator.NPPEJJKFCON.InfoIco);
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
				KJMFJFCDEDH.Show("game-revenge-indicator", IDEBKDPMPGM: false, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			}
		}
	}
}
