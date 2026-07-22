using System;

public abstract class GuiElement : SwitchableGui
{
	private sealed class APMGJLEPHIJ
	{
		public float GFPGAOABMDF;

		public float EEFLMFLELLF;

		public GuiElement HNNCIECPFEJ;

		public UITweener.OnFinished KNJLKJEIFEL;

		internal void NILMELCPFCN(UITweener OOJABIFHNJF)
		{
		}

		internal void JJJNFDOLBCE(UITweener DHLCPGGBDBM)
		{
		}
	}

	private sealed class HEIOFGOIOGM
	{
		public float GFPGAOABMDF;

		public UITweener.OnFinished HMDKLHMAHCA;

		internal void NMNFNFCNJAM(UITweener GDPAJADKOPD)
		{
		}
	}

	public UISprite NBIHMPOGHOB;

	private GuiScreen LBGJCACILBC;

	private bool APLGPMJNNLK;

	protected float GMLIBONIJEF;

	public static Action ILBIMFGNEJG;

	public static Action<GuiElement> KJNICPEDGLJ;

	public GuiScreen guiScreen
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool isInFrontOfLoadingDialog => false;

	public virtual bool isInFrontOfWarningDialog => false;

	public virtual bool isGameDialog => false;

	private void OnDestroy()
	{
	}

	protected override void OnEnable()
	{
	}

	protected virtual void KCHBAKEFKIO()
	{
	}

	protected virtual void JONCAIFFPAA()
	{
	}

	protected virtual void BJMJCLNKKMN()
	{
	}

	protected virtual void PLHBCOPMEOG()
	{
	}

	public abstract void InitControls();

	public abstract void InitGUIValues();

	public override void DoBeforeShowUp()
	{
	}

	public override void AnimateShow(bool JFAMAODFFPG)
	{
	}

	private void IMNOPPNCJML(float GFPGAOABMDF)
	{
	}

	public override void AnimateHide(bool BPDJNKJINGI)
	{
	}

	private void CFPCAHOAAEI()
	{
	}
}
