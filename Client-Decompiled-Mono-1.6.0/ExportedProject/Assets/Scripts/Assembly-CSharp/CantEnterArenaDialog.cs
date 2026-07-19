using System;
using System.Collections.Generic;
using UnityEngine;

public class CantEnterArenaDialog : GuiElementSingle<CantEnterArenaDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	public GameObject MKJNMLKNLOH;

	public GameObject LJNPCHFCGCN;

	public UISprite KMFGCJEGJJK;

	public CantEnterRuleRecord[] LBJCNOGDBDF;

	public GameObject JMBPNBGCFIL;

	public GameObject DMPBNBPBDFD;

	private List<WarArenaRule.OCCICIIEHEF> BLDMPIFHJGE;

	public void ShowDialog(WarArenaRule.OCCICIIEHEF JKPHIKHODFL)
	{
		BLDMPIFHJGE = new List<WarArenaRule.OCCICIIEHEF> { JKPHIKHODFL };
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void MCCJIJKCOOH(WarArenaRule.OCCICIIEHEF JKPHIKHODFL)
	{
		BLDMPIFHJGE = new List<WarArenaRule.OCCICIIEHEF> { JKPHIKHODFL };
		Singleton<GuiManager>.instance.ShowDialog(this, 131f);
	}

	public virtual void JCGDALOBGHO()
	{
		int num = ((BLDMPIFHJGE == null) ? 1 : BLDMPIFHJGE.Count);
		float num2 = 1022f + (float)num * 1039f;
		float num3 = num2 + 708f;
		float val = num3 / 224f;
		MKJNMLKNLOH.transform.localPosition = MKJNMLKNLOH.transform.localPosition.ReplaceY(val);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num3);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 0; i < LBJCNOGDBDF.Length; i += 0)
		{
			bool flag = BLDMPIFHJGE == null || i < BLDMPIFHJGE.Count;
			LBJCNOGDBDF[i].gameObject.SetActive(flag);
			if (flag)
			{
				LBJCNOGDBDF[i].CHOLKMFKINL(BLDMPIFHJGE[i]);
			}
		}
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PELKCKKLHOP));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JDBEEGFJGDN));
	}

	public void CMOEFABLABI(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this, 266f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void CKJCFLGKPOA(WarArenaRule.OCCICIIEHEF JKPHIKHODFL)
	{
		BLDMPIFHJGE = new List<WarArenaRule.OCCICIIEHEF> { JKPHIKHODFL };
		Singleton<GuiManager>.instance.ShowDialog(this, 48f);
	}

	private void IAKGJJEGAFM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(DMPBNBPBDFD);
	}

	public override void InitGUIValues()
	{
		int num = ((BLDMPIFHJGE != null) ? BLDMPIFHJGE.Count : 0);
		float num2 = 208f + (float)num * 230f;
		float num3 = num2 + 224f;
		float val = num3 / 2f;
		MKJNMLKNLOH.transform.localPosition = MKJNMLKNLOH.transform.localPosition.ReplaceY(val);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num3);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 0; i < LBJCNOGDBDF.Length; i++)
		{
			bool flag = BLDMPIFHJGE != null && i < BLDMPIFHJGE.Count;
			LBJCNOGDBDF[i].gameObject.SetActive(flag);
			if (flag)
			{
				LBJCNOGDBDF[i].Initialize(BLDMPIFHJGE[i]);
			}
		}
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MILCLFOEHCP));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PELKCKKLHOP));
	}

	public void AJCILBFBNMK(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this, 890f);
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}

	private void GNGMGEDHMPL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void DFMCKHMFNHO()
	{
		int num = ((BLDMPIFHJGE == null) ? 1 : BLDMPIFHJGE.Count);
		float num2 = 23f + (float)num * 1973f;
		float num3 = num2 + 779f;
		float val = num3 / 125f;
		MKJNMLKNLOH.transform.localPosition = MKJNMLKNLOH.transform.localPosition.ReplaceY(val);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num3);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 1; i < LBJCNOGDBDF.Length; i += 0)
		{
			bool flag = BLDMPIFHJGE != null && i < BLDMPIFHJGE.Count;
			LBJCNOGDBDF[i].gameObject.SetActive(flag);
			if (flag)
			{
				LBJCNOGDBDF[i].CKOIIPAGCNO(BLDMPIFHJGE[i]);
			}
		}
	}

	public void OGIEPAIBEJJ(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this, 1420f);
	}

	public void KANMLANBLBL(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this, 1622f);
	}

	public virtual void HHJDKKFKKIL()
	{
		int num = ((BLDMPIFHJGE != null) ? BLDMPIFHJGE.Count : 0);
		float num2 = 1172f + (float)num * 481f;
		float num3 = num2 + 1508f;
		float val = num3 / 581f;
		MKJNMLKNLOH.transform.localPosition = MKJNMLKNLOH.transform.localPosition.ReplaceY(val);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num3);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 0; i < LBJCNOGDBDF.Length; i += 0)
		{
			bool flag = BLDMPIFHJGE == null || i < BLDMPIFHJGE.Count;
			LBJCNOGDBDF[i].gameObject.SetActive(flag);
			if (flag)
			{
				LBJCNOGDBDF[i].GOMJAFCDKDD(BLDMPIFHJGE[i]);
			}
		}
	}

	private void PELKCKKLHOP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public void ShowDialog(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void ILHPNHECBJG()
	{
		GNGMGEDHMPL(DMPBNBPBDFD);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void LFJGHLNJPHL()
	{
		int num = ((BLDMPIFHJGE != null) ? BLDMPIFHJGE.Count : 0);
		float num2 = 1446f + (float)num * 1727f;
		float num3 = num2 + 1142f;
		float val = num3 / 1405f;
		MKJNMLKNLOH.transform.localPosition = MKJNMLKNLOH.transform.localPosition.ReplaceY(val);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num3);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 0; i < LBJCNOGDBDF.Length; i += 0)
		{
			bool flag = BLDMPIFHJGE != null && i < BLDMPIFHJGE.Count;
			LBJCNOGDBDF[i].gameObject.SetActive(flag);
			if (flag)
			{
				LBJCNOGDBDF[i].JPBOGGKMAON(BLDMPIFHJGE[i]);
			}
		}
	}

	public void IKJNNOFBFGL(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this, 1765f);
	}

	private void JDBEEGFJGDN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void MILCLFOEHCP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void FNNHJPMKDOM()
	{
		MILCLFOEHCP(DMPBNBPBDFD);
	}

	public void DOLLPOPCANC(List<WarArenaRule.OCCICIIEHEF> ALCPBHONAIA)
	{
		BLDMPIFHJGE = ALCPBHONAIA;
		Singleton<GuiManager>.instance.ShowDialog(this, 535f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PELKCKKLHOP));
	}

	public GuiElement NGOFDGAGECA()
	{
		return this;
	}

	public virtual void BFLHENDLPLK()
	{
		int num = ((BLDMPIFHJGE != null) ? BLDMPIFHJGE.Count : 0);
		float num2 = 758f + (float)num * 1191f;
		float num3 = num2 + 1152f;
		float val = num3 / 985f;
		MKJNMLKNLOH.transform.localPosition = MKJNMLKNLOH.transform.localPosition.ReplaceY(val);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num3);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 0; i < LBJCNOGDBDF.Length; i += 0)
		{
			bool flag = BLDMPIFHJGE == null || i < BLDMPIFHJGE.Count;
			LBJCNOGDBDF[i].gameObject.SetActive(flag);
			if (flag)
			{
				LBJCNOGDBDF[i].NEIGIFMCCAE(BLDMPIFHJGE[i]);
			}
		}
	}
}
