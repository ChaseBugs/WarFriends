using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class ChatAbusePopUpList : Core_BaseScript
{
	[FormerlySerializedAs("MMEGODHLFKO")]
	[Header("List")]
	public UIPopupListSameSelect GJHAIDKBCEA;

	[FormerlySerializedAs("MHOPKAHDGMN")]
	[Header("Area For Click")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("LKCEBLCCCJB")]
	[Header("Default Text")]
	public UILabel MOEPFKFFNGJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<string, UILabel> ANJALJMFIIG;

	private bool DOMMHFEJDBE;

	private float OENJPMPLNPB;

	public event Action<string, UILabel> OnSelect
	{
		add
		{
			Action<string, UILabel> action = ANJALJMFIIG;
			Action<string, UILabel> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string, UILabel> action = ANJALJMFIIG;
			Action<string, UILabel> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void KPFACFFNOLE(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	[SpecialName]
	public void LDGLBLEKICA(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DEFMKJOIBLH(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void GJDDOCFEBEM(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	[SpecialName]
	public void OMJABMDGBPB(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void LJFFDAHEOFM()
	{
		GJHAIDKBCEA.enabled = true;
		GJHAIDKBCEA.textLabel.enabled = true;
		EONDJGHJNKF(GJNGLPOBFJI: false);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	public void ABCBGCNEOOK()
	{
		GJHAIDKBCEA.enabled = false;
		GJHAIDKBCEA.textLabel.enabled = true;
		DLHGJADIAFP(GJNGLPOBFJI: false);
		MOEPFKFFNGJ.gameObject.SetActive(value: false);
	}

	protected override void Awake()
	{
		base.Awake();
		ResetToDefault();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KNPLFMLLAFB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KNPLFMLLAFB));
		UIPopupListSameSelect gJHAIDKBCEA = GJHAIDKBCEA;
		gJHAIDKBCEA.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(gJHAIDKBCEA.onSelectionChange, new UIPopupList.OnSelectionChange(DNIMMBMLKOG));
		UIPopupListSameSelect gJHAIDKBCEA2 = GJHAIDKBCEA;
		gJHAIDKBCEA2.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(gJHAIDKBCEA2.onSelectionChange, new UIPopupList.OnSelectionChange(DNIMMBMLKOG));
		UIPopupListSameSelect gJHAIDKBCEA3 = GJHAIDKBCEA;
		gJHAIDKBCEA3.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Remove(gJHAIDKBCEA3.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(CHPECODAIJK));
		UIPopupListSameSelect gJHAIDKBCEA4 = GJHAIDKBCEA;
		gJHAIDKBCEA4.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Combine(gJHAIDKBCEA4.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(CHPECODAIJK));
	}

	private void KNPLFMLLAFB(GameObject KHAHPAKDIKE)
	{
		DOMMHFEJDBE = true;
		if (!GJHAIDKBCEA.enabled)
		{
			GJHAIDKBCEA.enabled = true;
		}
		GJHAIDKBCEA.textLabel.enabled = false;
		DLHGJADIAFP(GJNGLPOBFJI: false);
		MOEPFKFFNGJ.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public void CKPEGHOMNOM(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void ILGHJIGLFCB(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void DNIMMBMLKOG(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	protected void IDPOHKDKDNL()
	{
		if (GJHAIDKBCEA.isOpen && DOMMHFEJDBE)
		{
			OENJPMPLNPB = Time.realtimeSinceStartup;
		}
		if (!GJHAIDKBCEA.isOpen && DOMMHFEJDBE && Time.realtimeSinceStartup - OENJPMPLNPB > 1288f)
		{
			DOMMHFEJDBE = false;
			GJHAIDKBCEA.textLabel.enabled = false;
			HPEBINJKAEF(GJNGLPOBFJI: true);
		}
		if (GJHAIDKBCEA.isOpen)
		{
			DEJHENGBGFJ(GJNGLPOBFJI: true);
		}
	}

	private void NPBBJPPPMNO(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	[SpecialName]
	public void FKNOEHIHEGB(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void MBLNAGJLLDH(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void HGIHFOCCIHF(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void HIKJNLMJBBM(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	public void MEADAEGFMGC()
	{
		GJHAIDKBCEA.enabled = false;
		GJHAIDKBCEA.textLabel.enabled = false;
		DLHGJADIAFP(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public void KCDOLGGNNCM(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void KBDNHGAAACB(bool GJNGLPOBFJI)
	{
		NJEAMAHEMHP.enabled = GJNGLPOBFJI;
	}

	private void MGDEOOIDOGO(GameObject KHAHPAKDIKE)
	{
		DOMMHFEJDBE = false;
		if (!GJHAIDKBCEA.enabled)
		{
			GJHAIDKBCEA.enabled = false;
		}
		GJHAIDKBCEA.textLabel.enabled = true;
		DLHGJADIAFP(GJNGLPOBFJI: false);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	private void JBFILFECDEK(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	public void ResetToDefault()
	{
		GJHAIDKBCEA.enabled = false;
		GJHAIDKBCEA.textLabel.enabled = false;
		DLHGJADIAFP(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public void NCAALLNBCOH(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FNCGAGECHFP(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void CIECFDGFGEJ()
	{
		GJHAIDKBCEA.enabled = true;
		GJHAIDKBCEA.textLabel.enabled = true;
		EONDJGHJNKF(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: false);
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		LJFFDAHEOFM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EPNIMLAJBFB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EPNIMLAJBFB));
		UIPopupListSameSelect gJHAIDKBCEA = GJHAIDKBCEA;
		gJHAIDKBCEA.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(gJHAIDKBCEA.onSelectionChange, new UIPopupList.OnSelectionChange(DNIMMBMLKOG));
		UIPopupListSameSelect gJHAIDKBCEA2 = GJHAIDKBCEA;
		gJHAIDKBCEA2.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(gJHAIDKBCEA2.onSelectionChange, new UIPopupList.OnSelectionChange(KPFACFFNOLE));
		UIPopupListSameSelect gJHAIDKBCEA3 = GJHAIDKBCEA;
		gJHAIDKBCEA3.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Remove(gJHAIDKBCEA3.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(MBLNAGJLLDH));
		UIPopupListSameSelect gJHAIDKBCEA4 = GJHAIDKBCEA;
		gJHAIDKBCEA4.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Combine(gJHAIDKBCEA4.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(KDACGIPEBBH));
	}

	private void EONDJGHJNKF(bool GJNGLPOBFJI)
	{
		NJEAMAHEMHP.enabled = GJNGLPOBFJI;
	}

	protected void GPLKEOAHFJI()
	{
		if (GJHAIDKBCEA.isOpen && DOMMHFEJDBE)
		{
			OENJPMPLNPB = Time.realtimeSinceStartup;
		}
		if (!GJHAIDKBCEA.isOpen && DOMMHFEJDBE && Time.realtimeSinceStartup - OENJPMPLNPB > 1290f)
		{
			DOMMHFEJDBE = false;
			GJHAIDKBCEA.textLabel.enabled = false;
			HPEBINJKAEF(GJNGLPOBFJI: false);
		}
		if (GJHAIDKBCEA.isOpen)
		{
			HPEBINJKAEF(GJNGLPOBFJI: true);
		}
	}

	private void DANMIGDMLAJ(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void PPGMDBNFDPE(GameObject KHAHPAKDIKE)
	{
		DOMMHFEJDBE = true;
		if (!GJHAIDKBCEA.enabled)
		{
			GJHAIDKBCEA.enabled = true;
		}
		GJHAIDKBCEA.textLabel.enabled = false;
		EONDJGHJNKF(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	private void HPEBINJKAEF(bool GJNGLPOBFJI)
	{
		NJEAMAHEMHP.enabled = GJNGLPOBFJI;
	}

	public void HOOCGHGLLFE()
	{
		GJHAIDKBCEA.enabled = true;
		GJHAIDKBCEA.textLabel.enabled = true;
		HPEBINJKAEF(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public void FOLDMPOMCBE(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		HNNCHPPGJBI();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPGMDBNFDPE));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KNPLFMLLAFB));
		UIPopupListSameSelect gJHAIDKBCEA = GJHAIDKBCEA;
		gJHAIDKBCEA.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(gJHAIDKBCEA.onSelectionChange, new UIPopupList.OnSelectionChange(GJDDOCFEBEM));
		UIPopupListSameSelect gJHAIDKBCEA2 = GJHAIDKBCEA;
		gJHAIDKBCEA2.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(gJHAIDKBCEA2.onSelectionChange, new UIPopupList.OnSelectionChange(DNIMMBMLKOG));
		UIPopupListSameSelect gJHAIDKBCEA3 = GJHAIDKBCEA;
		gJHAIDKBCEA3.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Remove(gJHAIDKBCEA3.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(JKCEAEPKHLF));
		UIPopupListSameSelect gJHAIDKBCEA4 = GJHAIDKBCEA;
		gJHAIDKBCEA4.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Combine(gJHAIDKBCEA4.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(JKCEAEPKHLF));
	}

	protected void EKPBOMOMMFB()
	{
		if (GJHAIDKBCEA.isOpen && DOMMHFEJDBE)
		{
			OENJPMPLNPB = Time.realtimeSinceStartup;
		}
		if (!GJHAIDKBCEA.isOpen && DOMMHFEJDBE && Time.realtimeSinceStartup - OENJPMPLNPB > 1238f)
		{
			DOMMHFEJDBE = true;
			GJHAIDKBCEA.textLabel.enabled = true;
			DLHGJADIAFP(GJNGLPOBFJI: true);
		}
		if (GJHAIDKBCEA.isOpen)
		{
			KBDNHGAAACB(GJNGLPOBFJI: true);
		}
	}

	public void HNNCHPPGJBI()
	{
		GJHAIDKBCEA.enabled = false;
		GJHAIDKBCEA.textLabel.enabled = false;
		KBDNHGAAACB(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public void KNHJOJHMPAJ(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void PDKLGKEPAOB()
	{
		GJHAIDKBCEA.enabled = true;
		GJHAIDKBCEA.textLabel.enabled = true;
		HPEBINJKAEF(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	protected void AAABJNBFLEG()
	{
		if (GJHAIDKBCEA.isOpen && DOMMHFEJDBE)
		{
			OENJPMPLNPB = Time.realtimeSinceStartup;
		}
		if (!GJHAIDKBCEA.isOpen && DOMMHFEJDBE && Time.realtimeSinceStartup - OENJPMPLNPB > 1033f)
		{
			DOMMHFEJDBE = true;
			GJHAIDKBCEA.textLabel.enabled = true;
			EONDJGHJNKF(GJNGLPOBFJI: false);
		}
		if (GJHAIDKBCEA.isOpen)
		{
			DLHGJADIAFP(GJNGLPOBFJI: false);
		}
	}

	private void FOJIMDBJAOA(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	[SpecialName]
	public void MKFOAHIIONI(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MJFLJLDPNLD(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void HFBMNOHAAKK()
	{
		GJHAIDKBCEA.enabled = false;
		GJHAIDKBCEA.textLabel.enabled = false;
		DLHGJADIAFP(GJNGLPOBFJI: false);
		MOEPFKFFNGJ.gameObject.SetActive(value: false);
	}

	private void JKCEAEPKHLF(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void KKMGDKNNOKI(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void BFJFDMJICHO(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void NBPEAGNJJKG(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void KDACGIPEBBH(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		MEADAEGFMGC();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDAPKHCNFPC));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EPNIMLAJBFB));
		UIPopupListSameSelect gJHAIDKBCEA = GJHAIDKBCEA;
		gJHAIDKBCEA.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(gJHAIDKBCEA.onSelectionChange, new UIPopupList.OnSelectionChange(KKMGDKNNOKI));
		UIPopupListSameSelect gJHAIDKBCEA2 = GJHAIDKBCEA;
		gJHAIDKBCEA2.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(gJHAIDKBCEA2.onSelectionChange, new UIPopupList.OnSelectionChange(DNIMMBMLKOG));
		UIPopupListSameSelect gJHAIDKBCEA3 = GJHAIDKBCEA;
		gJHAIDKBCEA3.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Remove(gJHAIDKBCEA3.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(HGIHFOCCIHF));
		UIPopupListSameSelect gJHAIDKBCEA4 = GJHAIDKBCEA;
		gJHAIDKBCEA4.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Combine(gJHAIDKBCEA4.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(NBPEAGNJJKG));
	}

	private void GDAPKHCNFPC(GameObject KHAHPAKDIKE)
	{
		DOMMHFEJDBE = true;
		if (!GJHAIDKBCEA.enabled)
		{
			GJHAIDKBCEA.enabled = true;
		}
		GJHAIDKBCEA.textLabel.enabled = true;
		HPEBINJKAEF(GJNGLPOBFJI: false);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public void KMNABIENMPM(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DLEOAICFFPD(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void BKEHEAILAOC(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void CHPECODAIJK(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	[SpecialName]
	public void ILDLFFNGBLN(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MLBJKHLKDKL(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MLBHPJEICFO(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void POGGBCHFCDA(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void KJHALDAFKOP(string MGDGFBCJINH)
	{
		if (ANJALJMFIIG != null)
		{
			ANJALJMFIIG(MGDGFBCJINH, GJHAIDKBCEA.textLabel);
		}
	}

	private void EPNIMLAJBFB(GameObject KHAHPAKDIKE)
	{
		DOMMHFEJDBE = false;
		if (!GJHAIDKBCEA.enabled)
		{
			GJHAIDKBCEA.enabled = false;
		}
		GJHAIDKBCEA.textLabel.enabled = false;
		DEJHENGBGFJ(GJNGLPOBFJI: true);
		MOEPFKFFNGJ.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public void BAJAGGECBIB(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DLHGJADIAFP(bool GJNGLPOBFJI)
	{
		NJEAMAHEMHP.enabled = GJNGLPOBFJI;
	}

	private void DEJHENGBGFJ(bool GJNGLPOBFJI)
	{
		NJEAMAHEMHP.enabled = GJNGLPOBFJI;
	}

	protected void Update()
	{
		if (GJHAIDKBCEA.isOpen && DOMMHFEJDBE)
		{
			OENJPMPLNPB = Time.realtimeSinceStartup;
		}
		if (!GJHAIDKBCEA.isOpen && DOMMHFEJDBE && Time.realtimeSinceStartup - OENJPMPLNPB > 0.2f)
		{
			DOMMHFEJDBE = false;
			GJHAIDKBCEA.textLabel.enabled = true;
			DLHGJADIAFP(GJNGLPOBFJI: true);
		}
		if (GJHAIDKBCEA.isOpen)
		{
			DLHGJADIAFP(GJNGLPOBFJI: false);
		}
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
		PDKLGKEPAOB();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPGMDBNFDPE));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EPNIMLAJBFB));
		UIPopupListSameSelect gJHAIDKBCEA = GJHAIDKBCEA;
		gJHAIDKBCEA.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(gJHAIDKBCEA.onSelectionChange, new UIPopupList.OnSelectionChange(POGGBCHFCDA));
		UIPopupListSameSelect gJHAIDKBCEA2 = GJHAIDKBCEA;
		gJHAIDKBCEA2.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(gJHAIDKBCEA2.onSelectionChange, new UIPopupList.OnSelectionChange(BFJFDMJICHO));
		UIPopupListSameSelect gJHAIDKBCEA3 = GJHAIDKBCEA;
		gJHAIDKBCEA3.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Remove(gJHAIDKBCEA3.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(KDACGIPEBBH));
		UIPopupListSameSelect gJHAIDKBCEA4 = GJHAIDKBCEA;
		gJHAIDKBCEA4.AAECOJFKADO = (UIPopupListSameSelect.CHPECODAIJK)Delegate.Combine(gJHAIDKBCEA4.AAECOJFKADO, new UIPopupListSameSelect.CHPECODAIJK(JKCEAEPKHLF));
	}

	[SpecialName]
	public void DANCNMDAHNO(Action<string, UILabel> IDEBKDPMPGM)
	{
		Action<string, UILabel> action = ANJALJMFIIG;
		Action<string, UILabel> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ANJALJMFIIG, (Action<string, UILabel>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
