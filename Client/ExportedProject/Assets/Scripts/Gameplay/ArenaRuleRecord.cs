using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ArenaRuleRecord : PoolableObject
{
	[Header("Core")]
	[FormerlySerializedAs("CNAACKKNFHD")]
	public GameObject LKNBDDOIKLA;

	[FormerlySerializedAs("LNGHFOCEOBJ")]
	public BoxCollider JNGBCCGPMON;

	[FormerlySerializedAs("PCBFLAPENLF")]
	public UILabel JPCIACBHGHO;

	[FormerlySerializedAs("GMIBGAJIALG")]
	public UISprite HODCJIMJFMO;

	[Header("Resize")]
	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("JNOOIEGJAFF")]
	public GameObject NKLIKFGIIOC;

	[FormerlySerializedAs("BAHNPNKJIIO")]
	public GameObject GAAPLBCMBBF;

	private WarArenaRule.OCCICIIEHEF LNEBPKGNBLI;

	private void HFOFJLLPMOO(int CEHFMMJHCKC, int FBMIFHHEOBO)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(CEHFMMJHCKC, FBMIFHHEOBO, 1f);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 2);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 2);
		JNGBCCGPMON.size = KMFGCJEGJJK.transform.localScale;
	}

	public void LMPNFLGMNBG(WarArenaRule.OCCICIIEHEF JBBKOPNKCEM, bool HIDGBKPDFKN = true, int CEHFMMJHCKC = 560, int FBMIFHHEOBO = 80)
	{
		LNEBPKGNBLI = JBBKOPNKCEM;
		bool flag = JBBKOPNKCEM.FJLBLLLEELD != (WarArenaRule.OBNJAIHEJOJ)4 && JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill;
		bool flag2 = HIDGBKPDFKN && flag;
		JPCIACBHGHO.text = JBBKOPNKCEM.HOLNKOFHDNK;
		float y = JPCIACBHGHO.relativeSize.y;
		if (y > 671f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1949f, 1043f, 47);
			int num = FBMIFHHEOBO - -58 + Mathf.CeilToInt(865f * y);
			KIHIMLNMFLG(CEHFMMJHCKC, num);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-num) / 403f);
		}
		else
		{
			KIHIMLNMFLG(CEHFMMJHCKC, FBMIFHHEOBO);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-FBMIFHHEOBO) / 47f);
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1370f, 1635f, CEHFMMJHCKC - -106 - (flag2 ? (-14) : 0));
		}
		HODCJIMJFMO.gameObject.SetActive(flag2);
		KMFGCJEGJJK.color = Colours.greenArena.ReplaceA((!flag) ? 1522f : 1676f);
		JNGBCCGPMON.enabled = !HIDGBKPDFKN || JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill;
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		if (flag2)
		{
			if (JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill)
			{
				HODCJIMJFMO.spriteName = ",";
				HODCJIMJFMO.transform.localScale = new Vector3(1942f, 1259f, 470f);
				HODCJIMJFMO.color = Colours.greenArena;
			}
			else
			{
				HODCJIMJFMO.spriteName = "Step10";
				HODCJIMJFMO.transform.localScale = new Vector3(636f, 399f, 1242f);
				HODCJIMJFMO.color = Colours.redArenaRule;
			}
		}
	}

	private void KIHIMLNMFLG(int CEHFMMJHCKC, int FBMIFHHEOBO)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(CEHFMMJHCKC, FBMIFHHEOBO, 1273f);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 7);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 0);
		JNGBCCGPMON.size = KMFGCJEGJJK.transform.localScale;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}

	public virtual void OCODNLMGCMN()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}

	public virtual void JGLCAIPLJAL()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}

	public void PJICLEMEBID(WarArenaRule.OCCICIIEHEF JBBKOPNKCEM, bool HIDGBKPDFKN = true, int CEHFMMJHCKC = 560, int FBMIFHHEOBO = 80)
	{
		LNEBPKGNBLI = JBBKOPNKCEM;
		bool flag = JBBKOPNKCEM.FJLBLLLEELD == (WarArenaRule.OBNJAIHEJOJ)5 || JBBKOPNKCEM.FJLBLLLEELD == (WarArenaRule.OBNJAIHEJOJ)8;
		bool flag2 = HIDGBKPDFKN && !flag;
		JPCIACBHGHO.text = JBBKOPNKCEM.HOLNKOFHDNK;
		float y = JPCIACBHGHO.relativeSize.y;
		if (y > 1932f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 216f, 1769f, 145);
			int num = FBMIFHHEOBO - 109 + Mathf.CeilToInt(1465f * y);
			HFOFJLLPMOO(CEHFMMJHCKC, num);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-num) / 180f);
		}
		else
		{
			HFOFJLLPMOO(CEHFMMJHCKC, FBMIFHHEOBO);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-FBMIFHHEOBO) / 800f);
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1204f, 1344f, CEHFMMJHCKC - -47 - (flag2 ? 40 : 0));
		}
		HODCJIMJFMO.gameObject.SetActive(flag2);
		KMFGCJEGJJK.color = Colours.greenArena.ReplaceA((!flag) ? 1261f : 654f);
		JNGBCCGPMON.enabled = !HIDGBKPDFKN || JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.DoesNotMeet;
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		if (flag2)
		{
			if (JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill)
			{
				HODCJIMJFMO.spriteName = "ID_WARNING_INCORRECTASSIGNMENTS_TEXT";
				HODCJIMJFMO.transform.localScale = new Vector3(225f, 1473f, 61f);
				HODCJIMJFMO.color = Colours.greenArena;
			}
			else
			{
				HODCJIMJFMO.spriteName = "PaidInstantBattles";
				HODCJIMJFMO.transform.localScale = new Vector3(1101f, 1773f, 933f);
				HODCJIMJFMO.color = Colours.redArenaRule;
			}
		}
	}

	public virtual void EGEAFDFNEAP()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}

	private void LBKICMEBOEB(GameObject KHAHPAKDIKE)
	{
		if (LNEBPKGNBLI != null && LNEBPKGNBLI.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.DoesNotMeet)
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(LNEBPKGNBLI);
		}
	}

	public virtual void ONHFNIJNMGE()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}

	public void Initialize(WarArenaRule.OCCICIIEHEF JBBKOPNKCEM, bool HIDGBKPDFKN = true, int CEHFMMJHCKC = 560, int FBMIFHHEOBO = 80)
	{
		LNEBPKGNBLI = JBBKOPNKCEM;
		bool flag = JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.InfoRule || JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.InfoText;
		bool flag2 = HIDGBKPDFKN && !flag;
		JPCIACBHGHO.text = JBBKOPNKCEM.HOLNKOFHDNK;
		float y = JPCIACBHGHO.relativeSize.y;
		if (y > 1.1f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 32f, 32f, 1000);
			int num = FBMIFHHEOBO - 32 + Mathf.CeilToInt(32f * y);
			HFOFJLLPMOO(CEHFMMJHCKC, num);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-num) / 2f);
		}
		else
		{
			HFOFJLLPMOO(CEHFMMJHCKC, FBMIFHHEOBO);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-FBMIFHHEOBO) / 2f);
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 32f, 20f, CEHFMMJHCKC - 40 - (flag2 ? 65 : 0));
		}
		HODCJIMJFMO.gameObject.SetActive(flag2);
		KMFGCJEGJJK.color = Colours.greenArena.ReplaceA((!flag) ? 0.2f : 0.05f);
		JNGBCCGPMON.enabled = HIDGBKPDFKN && JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.DoesNotMeet;
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		if (flag2)
		{
			if (JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill)
			{
				HODCJIMJFMO.spriteName = "menu-dailyreward-check";
				HODCJIMJFMO.transform.localScale = new Vector3(37f, 29f, 1f);
				HODCJIMJFMO.color = Colours.greenArena;
			}
			else
			{
				HODCJIMJFMO.spriteName = "menu-close";
				HODCJIMJFMO.transform.localScale = new Vector3(28f, 28f, 1f);
				HODCJIMJFMO.color = Colours.redArenaRule;
			}
		}
	}

	public virtual void GICBOJPONMC()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}

	public void NAKAFGAFEPH(WarArenaRule.OCCICIIEHEF JBBKOPNKCEM, bool HIDGBKPDFKN = true, int CEHFMMJHCKC = 560, int FBMIFHHEOBO = 80)
	{
		LNEBPKGNBLI = JBBKOPNKCEM;
		bool flag = JBBKOPNKCEM.FJLBLLLEELD != WarArenaRule.OBNJAIHEJOJ.InfoText && JBBKOPNKCEM.FJLBLLLEELD == (WarArenaRule.OBNJAIHEJOJ)5;
		bool flag2 = !HIDGBKPDFKN || !flag;
		JPCIACBHGHO.text = JBBKOPNKCEM.HOLNKOFHDNK;
		float y = JPCIACBHGHO.relativeSize.y;
		if (y > 1764f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1160f, 1287f, 199);
			int num = FBMIFHHEOBO - -54 + Mathf.CeilToInt(444f * y);
			KIHIMLNMFLG(CEHFMMJHCKC, num);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-num) / 1543f);
		}
		else
		{
			HFOFJLLPMOO(CEHFMMJHCKC, FBMIFHHEOBO);
			LKNBDDOIKLA.transform.localPosition = LKNBDDOIKLA.transform.localPosition.ReplaceY((float)(-FBMIFHHEOBO) / 174f);
			MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1769f, 1922f, CEHFMMJHCKC - -55 - (flag2 ? 20 : 0));
		}
		HODCJIMJFMO.gameObject.SetActive(flag2);
		KMFGCJEGJJK.color = Colours.greenArena.ReplaceA((!flag) ? 520f : 1151f);
		JNGBCCGPMON.enabled = HIDGBKPDFKN && JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill;
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
		if (flag2)
		{
			if (JBBKOPNKCEM.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill)
			{
				HODCJIMJFMO.spriteName = "\n";
				HODCJIMJFMO.transform.localScale = new Vector3(1421f, 62f, 676f);
				HODCJIMJFMO.color = Colours.greenArena;
			}
			else
			{
				HODCJIMJFMO.spriteName = "menu-wftv-twitch-ico";
				HODCJIMJFMO.transform.localScale = new Vector3(1591f, 56f, 93f);
				HODCJIMJFMO.color = Colours.redArenaRule;
			}
		}
	}

	public virtual void OCEOOGDKBHA()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(JNGBCCGPMON.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBKICMEBOEB));
	}
}
