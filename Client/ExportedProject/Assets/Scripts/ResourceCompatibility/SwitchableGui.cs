using System.Runtime.CompilerServices;
using UnityEngine;

public class SwitchableGui : Core_BaseScript
{
	public enum FNACDLCKFPH
	{
		Fade,
		TweenPosition,
		TeenPositionAndFade,
		DialogSpecial
	}

	[CompilerGenerated]
	private bool _003CBHOLMCBNKAK_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CBOFFBNBNFMA_003Ek__BackingField;

	public bool CMMFNHCOLJM;

	[CompilerGenerated]
	private GuiScreen _003CKAODNLIHBBH_003Ek__BackingField;

	[CompilerGenerated]
	private GuiScreen _003CPPAOCCNDNFO_003Ek__BackingField;

	public GuiScreen FOFDHNKHCPM;

	public float JJAGIONGDOI;

	public float MPNPGBLIBAO;

	[CompilerGenerated]
	private bool _003CKALADHCKMHK_003Ek__BackingField;

	public FNACDLCKFPH MHILPLNFAHI;

	public FNACDLCKFPH OHEHPAPODPB;

	private bool JCABFAJONGO;

	private bool ALABALBKNJC;

	private float CLGFDEBBFLB;

	private bool GDBIHIOFIDA;

	private float KJAFNOHJEKB;

	private Vector3 DILGNFLEPEI;

	protected UIPanel[] JDGJGDICOIE;

	public bool readyToHide
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public bool readyToShowUp
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public GuiScreen previousScreen
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public GuiScreen previousScreenForElementsToHide
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public virtual bool isShowed
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public bool isFullyShowed => false;

	public bool isFullyHidden => false;

	protected virtual void Update()
	{
	}

	protected override void Awake()
	{
	}

	protected virtual void OnEnable()
	{
	}

	public virtual void DoBeforeShowUp()
	{
	}

	public void AnimateShow()
	{
	}

	public virtual void AnimateShow(bool JFAMAODFFPG)
	{
	}

	protected void JMOAKOGGLJH(float NBCFLNHLNDI)
	{
	}

	public virtual void DoAfterShowUp()
	{
	}

	public virtual float FadeIn()
	{
		return 0f;
	}

	public virtual void DoBeforeHide()
	{
	}

	public void AnimateHide()
	{
	}

	public virtual void AnimateHide(bool BPDJNKJINGI)
	{
	}

	protected void BPCDAGAKKCE(float NBCFLNHLNDI)
	{
	}

	public virtual void DoAfterHide()
	{
	}

	public virtual float FadeOut()
	{
		return 0f;
	}

	public virtual void InitEvents()
	{
	}

	public virtual void OnBack()
	{
	}

	public virtual void OnMenu()
	{
	}

	[CompilerGenerated]
	private void DMNFOEICFFC()
	{
	}
}
