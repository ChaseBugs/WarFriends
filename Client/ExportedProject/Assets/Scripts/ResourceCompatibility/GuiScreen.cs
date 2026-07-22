using System;
using System.Runtime.CompilerServices;

public abstract class GuiScreen : SwitchableGui
{
	public enum NPBIGDIGICK
	{
		None,
		Normal,
		League,
		Arena,
		Event
	}

	public enum DLKPELCAGDH
	{
		Classic,
		WithLoyalty
	}

	public bool HJAGKLIEJDI;

	public NPBIGDIGICK GAJABOICKBB;

	public DLKPELCAGDH CNMFIFNJOHL;

	public bool OGEKKJKIIFG;

	public bool EDCBJNBDDIG;

	public bool HAJOFLFGMEH;

	public Background.OLNAGFDIOLI GBMLPBCIHON;

	public bool LAPEIEHDOON;

	[CompilerGenerated]
	private Action PHGDIGAAHNI;

	[CompilerGenerated]
	private Action JLKDBCIFEIE;

	[CompilerGenerated]
	private Action JNOBCHCOPBP;

	[CompilerGenerated]
	private Action DENGLJFFBKE;

	public static Action NPCCKJPLDBP;

	private bool APLGPMJNNLK;

	public virtual bool dialogsEnabled => false;

	public bool showHeaderPart => false;

	public bool showHeaderLeaguePart => false;

	public bool showHeaderDogtagPart => false;

	public bool showHeaderTicketPart => false;

	public bool showHeaderEventPart => false;

	public event Action BeforeShowUp
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action AfterShowUp
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action BeforeHide
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action AfterHide
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public virtual void OnDestroy()
	{
	}

	protected override void OnEnable()
	{
	}

	public override void AnimateShow(bool JFAMAODFFPG)
	{
	}

	private void KKJLCMILIJI(GuiElement EBMECDBHGGG, GuiElement LMGFKKOJNGP)
	{
	}

	public override void DoBeforeShowUp()
	{
	}

	public override void DoAfterShowUp()
	{
	}

	public override void DoBeforeHide()
	{
	}

	public override void DoAfterHide()
	{
	}

	protected abstract void LKNLBIMDMAD();

	public abstract void InitGUIValues();

	protected virtual void FixedUpdate()
	{
	}
}
