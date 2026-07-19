using System;
using UnityEngine;

public class BroadcastSettingsDialog : GuiElementSingle<BroadcastSettingsDialog>, PAIIOKBBHBC
{
	[Header("-Buttons")]
	public GameObject LJNPCHFCGCN;

	public GameObject CCFFNAKFPPE;

	[Header("-Switches")]
	public SettingsButton FGPKBBFDBNK;

	public SettingsButton GJEPGNEDBBD;

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	private void CKGIIPNBOFK(GameObject KHAHPAKDIKE)
	{
		DebugSettings.microphoneInBroadcast = DebugSettings.microphoneInBroadcast;
		FGPKBBFDBNK.NFAIPALMOON(DebugSettings.microphoneInBroadcast, false);
	}

	private void IKIAKCMEHIH(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = !DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.NMNFNPNPAMC(DebugSettings.cameraInBroadcast, false);
	}

	public GuiElement GMPEFKABFGG()
	{
		return this;
	}

	public virtual void ILCKGHGDDJA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EBHHAANCDMN));
		UIEventListener uIEventListener3 = UIEventListener.Get(FGPKBBFDBNK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NNFBIDDLBAO));
		UIEventListener uIEventListener4 = UIEventListener.Get(GJEPGNEDBBD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ILBMKFLCCPH));
	}

	public virtual void JAIAMFJHDLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHJLOOIDPAO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NCFNPJAPENM));
		UIEventListener uIEventListener3 = UIEventListener.Get(FGPKBBFDBNK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ADODPLKMCLC));
		UIEventListener uIEventListener4 = UIEventListener.Get(GJEPGNEDBBD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NGNHDIAADAD));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	public GuiElement NIFFGPKMBKE()
	{
		return this;
	}

	private void NCFNPJAPENM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			WaitingDialog.ShowDialog("Shots_Fired");
			Recording.GKLCILMOOOG();
		}
	}

	private void IAPEIPGDNNO(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.EIKGDPJEJAL(DebugSettings.cameraInBroadcast);
	}

	private void BHJLOOIDPAO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHJLOOIDPAO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NCFNPJAPENM));
		UIEventListener uIEventListener3 = UIEventListener.Get(FGPKBBFDBNK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NNFBIDDLBAO));
		UIEventListener uIEventListener4 = UIEventListener.Get(GJEPGNEDBBD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IAPEIPGDNNO));
	}

	public GuiElement LHHPBBPPIOE()
	{
		return this;
	}

	private void ADODPLKMCLC(GameObject KHAHPAKDIKE)
	{
		DebugSettings.microphoneInBroadcast = !DebugSettings.microphoneInBroadcast;
		FGPKBBFDBNK.HDFHLAKFNDE(DebugSettings.microphoneInBroadcast);
	}

	private void JEHJLEIHEOK(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			WaitingDialog.NFFOFBDCHMF("Black_market_triggered");
			Recording.GKLCILMOOOG();
		}
	}

	public GuiElement ACPILDHIAKG()
	{
		return this;
	}

	private void NDPLFALGNGP(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = !DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.BMEHDKPGOEM(DebugSettings.cameraInBroadcast, false);
	}

	private void BBPLFGNLNMM(GameObject KHAHPAKDIKE)
	{
		DebugSettings.microphoneInBroadcast = DebugSettings.microphoneInBroadcast;
		FGPKBBFDBNK.JBMNENPHMLB(DebugSettings.microphoneInBroadcast, false);
	}

	private void DIIHLNICOOH(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = !DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.NFAIPALMOON(DebugSettings.cameraInBroadcast, false);
	}

	private void EPGINDJENKI(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = !DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.EGOCFIFGFOJ(DebugSettings.cameraInBroadcast, false);
	}

	private void GACPMJKPPGF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			WaitingDialog.ShowDialog("Local");
			Recording.GDDIIEPOLOL();
		}
	}

	private void ILBMKFLCCPH(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.NEJGDBPMGDH(DebugSettings.cameraInBroadcast, false);
	}

	private void NGNHDIAADAD(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.ACOADFODMKB(DebugSettings.cameraInBroadcast);
	}

	private void JCOHMBIJDOD(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.IKIMOGNDJCN(DebugSettings.cameraInBroadcast, false);
	}

	public virtual void JCJECJKBKGD()
	{
		FGPKBBFDBNK.DGFPOPLMFDO(DebugSettings.microphoneInBroadcast, false);
		GJEPGNEDBBD.KJACFEMIGLE(DebugSettings.cameraInBroadcast, false);
	}

	public virtual void OFCCACPEBHD()
	{
		FGPKBBFDBNK.KFOOJPEOIHP(DebugSettings.microphoneInBroadcast, false);
		GJEPGNEDBBD.HICJHPKIMCC(DebugSettings.cameraInBroadcast, false);
	}

	public virtual void OKMMGFMKJGG()
	{
		FGPKBBFDBNK.KJACFEMIGLE(DebugSettings.microphoneInBroadcast, false);
		GJEPGNEDBBD.IJMNIHBNMFA(DebugSettings.cameraInBroadcast, false);
	}

	public GuiElement JPJGHDKECMA()
	{
		return this;
	}

	private void CCHKIPLNLMK(GameObject KHAHPAKDIKE)
	{
		DebugSettings.cameraInBroadcast = !DebugSettings.cameraInBroadcast;
		GJEPGNEDBBD.HDFHLAKFNDE(DebugSettings.cameraInBroadcast);
	}

	public GuiElement FEJMHFBCGDO()
	{
		return this;
	}

	private void NNFBIDDLBAO(GameObject KHAHPAKDIKE)
	{
		DebugSettings.microphoneInBroadcast = !DebugSettings.microphoneInBroadcast;
		FGPKBBFDBNK.FLCCDHNFJPL(DebugSettings.microphoneInBroadcast, false);
	}

	public virtual void EMGHCAHOJNC()
	{
		FGPKBBFDBNK.EGOCFIFGFOJ(DebugSettings.microphoneInBroadcast, false);
		GJEPGNEDBBD.OPIDMNHBEND(DebugSettings.cameraInBroadcast, false);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EBHHAANCDMN));
		UIEventListener uIEventListener3 = UIEventListener.Get(FGPKBBFDBNK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ADODPLKMCLC));
		UIEventListener uIEventListener4 = UIEventListener.Get(GJEPGNEDBBD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CCHKIPLNLMK));
	}

	public override void InitGUIValues()
	{
		FGPKBBFDBNK.HDFHLAKFNDE(DebugSettings.microphoneInBroadcast, false);
		GJEPGNEDBBD.HDFHLAKFNDE(DebugSettings.cameraInBroadcast, false);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	private void EBHHAANCDMN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			WaitingDialog.ShowDialog("ID_WAITINGFORREPLAYKIT");
			Recording.StartBroadcast();
		}
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JEHJLEIHEOK));
		UIEventListener uIEventListener3 = UIEventListener.Get(FGPKBBFDBNK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NNFBIDDLBAO));
		UIEventListener uIEventListener4 = UIEventListener.Get(GJEPGNEDBBD.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NDPLFALGNGP));
	}

	private void KGKHHGKNJDM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			WaitingDialog.PCBDDAMEPCJ("com.mobcrush.mobcrush");
			Recording.GDDIIEPOLOL();
		}
	}
}
