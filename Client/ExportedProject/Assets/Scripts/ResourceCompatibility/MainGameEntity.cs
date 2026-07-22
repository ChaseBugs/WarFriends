using System;
using System.Runtime.CompilerServices;

public abstract class MainGameEntity : PoolableObject, PHOFJEDENDJ, IBFMOMDLFEP
{
	public PhotonView LOAGAOKNAPI;

	private float LEKPMHOBCLK;

	public HudObjectIndicator GPMAFHJICMH;

	[CompilerGenerated]
	private CardIconIndicator _003CJOFCIFDHGPM_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNBKFAOPCFDG_003Ek__BackingField;

	public CardIconIndicator cardIconIndicator
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public virtual DestroyableObject destroyableObj => null;

	public bool isRevengeKill => false;

	public abstract HPHFGNJPDKN fraction { get; set; }

	public abstract IBFMOMDLFEP owner { get; set; }

	public abstract int power { get; set; }

	public bool isAlive
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public abstract event Action<PHOFJEDENDJ, DestroyableObject.LDOKCBNNLCH> Killed;

	protected override void Awake()
	{
	}

	public override void BeforeInstancied()
	{
	}

	public override void OnInstancied()
	{
	}

	public override void DestroyPooled()
	{
	}

	protected void DCKGOOGNMLG(float GAMFJEOGHJD)
	{
	}

	protected void DCKGOOGNMLG()
	{
	}

	public void SetRevenge()
	{
	}

	protected virtual void Update()
	{
	}
}
