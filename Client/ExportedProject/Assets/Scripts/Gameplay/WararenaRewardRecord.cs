using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WararenaRewardRecord : PoolableObject
{
	public enum COLKIFOMJPF
	{
		OpenDialog,
		ChangeUnit
	}

	[Header("Core")]
	[FormerlySerializedAs("HPOCJBBBPOC")]
	public UISprite DAANKCOLJGJ;

	[FormerlySerializedAs("FHKAKFMDAIN")]
	public UILabel HBDKBBHDOFM;

	[FormerlySerializedAs("CCOAFDDKHLH")]
	public UISprite MOAHOPBPMDJ;

	[FormerlySerializedAs("BBCBKJMNPKK")]
	public GameObject DNCJEBDPBNA;

	[FormerlySerializedAs("KCILDAHGAJK")]
	public GameObject PNCFKDMDKAK;

	[FormerlySerializedAs("GHACCDKBOBF")]
	public UISprite NACGOGCPIAH;

	[FormerlySerializedAs("KBDAOIPFIAM")]
	public BoxCollider GOCLCFJNCEO;

	private LevelBehaviour IFFDIHCPKFE;

	private COLKIFOMJPF KBNOLPFGPAC;

	private void AIAMPAIHCFM(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.CPGNJFJHBEB(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.AONPDBAPDOL(IFFDIHCPKFE);
		}
	}

	public virtual void GCNDLBLILAL()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PEDOECHFDPE));
	}

	private void PFFFEEHDPCB(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.AJCILBFBNMK(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public virtual void AEHFNIMENDJ()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
	}

	public void PJICLEMEBID(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.HOLNKOFHDNK;
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 684f : 839f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 478f, 1788f, -49);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.HMJOMKKEPCI();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(311f / MOAHOPBPMDJ.transform.localScale.x, 500f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.FLDHFENFAAI());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.NIKLMCMINDL();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1754f);
				float multiplier2 = 1174f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1311f);
				float multiplier3 = Mathf.Min(731f / NACGOGCPIAH.transform.localScale.x, 1195f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.DEEEPOFDFCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.FCOJEDGLELH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GODLBNNAGJH();
		}
	}

	public virtual void ONHFNIJNMGE()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGAJDANBHOO));
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
	}

	public void MLLKACEGPCM(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.JLEAGFHFKHL();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1089f : 283f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 357f, 918f, -159);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BLJEBHNOAGG();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(104f / MOAHOPBPMDJ.transform.localScale.x, 1017f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.NCHGGFNEPJC);
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BLJEBHNOAGG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1663f);
				float multiplier2 = 1276f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(600f);
				float multiplier3 = Mathf.Min(1291f / NACGOGCPIAH.transform.localScale.x, 1915f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNFMPCIJLED));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BLJEBHNOAGG();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.EDMNIKBBOFP());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.OHFJAJEHKPP();
		}
	}

	public void LOJPGLBLJDF(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.HOLNKOFHDNK;
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1766f : 214f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1142f, 1373f, -160);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(537f / MOAHOPBPMDJ.transform.localScale.x, 339f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HEFIICEFMFB());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPNMILFDLBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(660f);
				float multiplier2 = 620f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(286f);
				float multiplier3 = Mathf.Min(200f / NACGOGCPIAH.transform.localScale.x, 1728f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HMJOMKKEPCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.NHMCEOKJBNI());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JIOMLEMMAAG();
		}
	}

	public virtual void DJDFKKJLHIC()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
	}

	public void FKBIBACPFJE(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.ICCCPOHONAH();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1820f : 685f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1745f, 1207f, 6);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.LOFLIHGMOIK();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(553f / MOAHOPBPMDJ.transform.localScale.x, 1878f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MMLCOBGBMKK());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPNMILFDLBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(365f);
				float multiplier2 = 1722f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1652f);
				float multiplier3 = Mathf.Min(918f / NACGOGCPIAH.transform.localScale.x, 884f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPHOCHGKGEJ));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGAJDANBHOO));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.LOFLIHGMOIK();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.FCOJEDGLELH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.KMJEBOMKLHE();
		}
	}

	public virtual void HLBHDOFFDGN()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAHHJPOMECG));
	}

	public virtual void NBOMCFHBLOF()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNFMPCIJLED));
	}

	private void KEOIOMPEILB(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.KANMLANBLBL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public virtual void NNMGFLHFDGJ()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNFMPCIJLED));
	}

	public void MFMJPBCIHEH(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.LKHNHHJEKEO();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1088f : 1118f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 287f, 1761f, -185);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.DGFFLCOAJEF();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(21f / MOAHOPBPMDJ.transform.localScale.x, 1506f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.LHDFANJACBO());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DGFFLCOAJEF();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(725f);
				float multiplier2 = 908f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(696f);
				float multiplier3 = Mathf.Min(1311f / NACGOGCPIAH.transform.localScale.x, 949f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFFFEEHDPCB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFFFEEHDPCB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.DEEEPOFDFCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MFJNONKKEKE());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GCKBJFNOEJG();
		}
	}

	public void BENAHCDEKCM(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.OJEHNLDPLPD();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1232f : 1390f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1341f, 1515f, 137);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.KCHMDALPMBN;
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1551f / MOAHOPBPMDJ.transform.localScale.x, 404f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.EKADDKEMIMH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.OKEDPLGPKAF();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(816f);
				float multiplier2 = 1609f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(652f);
				float multiplier3 = Mathf.Min(1519f / NACGOGCPIAH.transform.localScale.x, 1428f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AIAMPAIHCFM));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PEDOECHFDPE));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.DGFFLCOAJEF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.PEFLFIIPHMN());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.BEEKAAFKLAB();
		}
	}

	public void HIHAFDPJPKC(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.PJBNJAKIJFP();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 955f : 62f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 783f, 650f, -166);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.DEEEPOFDFCI();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1479f / MOAHOPBPMDJ.transform.localScale.x, 1552f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HEFIICEFMFB());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HMJOMKKEPCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1063f);
				float multiplier2 = 1960f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Left;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(831f);
				float multiplier3 = Mathf.Min(869f / NACGOGCPIAH.transform.localScale.x, 828f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKLEPCIDIDB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IAHHJPOMECG));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HMJOMKKEPCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.NNCLJEHCGCC());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GCKBJFNOEJG();
		}
	}

	public virtual void PNJDBOIFEMF()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAHHJPOMECG));
	}

	private void MOGIJEPNJKF(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.OPPAFPHDKNL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	private void IAHHJPOMECG(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.GONOICLIMKO(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	private void AMCLALIPKEE(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.OPPAFPHDKNL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public void FIDIINBHKDG(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.OJEHNLDPLPD();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1238f : 1620f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 93f, 558f, -199);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1603f / MOAHOPBPMDJ.transform.localScale.x, 667f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.FIBBBELMNEL());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.NIKLMCMINDL();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(559f);
				float multiplier2 = 348f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(16f);
				float multiplier3 = Mathf.Min(846f / NACGOGCPIAH.transform.localScale.x, 372f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PEDOECHFDPE));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KPFNPNEAKEL));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.DEEEPOFDFCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MLPFDBADEBE);
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EBIBNFKOHOE();
		}
	}

	public void BGFKBPMPJIL(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.HOLNKOFHDNK;
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1518f : 1082f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 176f, 1468f, -170);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1151f / MOAHOPBPMDJ.transform.localScale.x, 854f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MLDONFFLJGD());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DGFFLCOAJEF();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(807f);
				float multiplier2 = 735f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1808f);
				float multiplier3 = Mathf.Min(1973f / NACGOGCPIAH.transform.localScale.x, 1270f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPFNPNEAKEL));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKMLPHEAEKI));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.DGFFLCOAJEF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.IGIKGHOMAPH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.MEKOPIPEAEA();
		}
	}

	public virtual void JGLCAIPLJAL()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AIAMPAIHCFM));
	}

	public virtual void HGOBLCPDFCD()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
	}

	private void KPFNPNEAKEL(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.GONOICLIMKO(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	private void PEDOECHFDPE(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.AJCILBFBNMK(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.AONPDBAPDOL(IFFDIHCPKFE);
		}
	}

	public void Initialize(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.HOLNKOFHDNK;
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? (-73f) : (-53f));
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 27f, 20f, 140);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.KCHMDALPMBN;
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(142f / MOAHOPBPMDJ.transform.localScale.x, 126f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.NCHGGFNEPJC);
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.KCHMDALPMBN;
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(-65f);
				float multiplier2 = 144f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(0f);
				float multiplier3 = Mathf.Min(176f / NACGOGCPIAH.transform.localScale.x, 144f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.KCHMDALPMBN;
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MLPFDBADEBE);
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EGAIBJBBOJO;
		}
	}

	private void CKLEPCIDIDB(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.KPDJABMGPDM(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public virtual void DKMEHOEOADL()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGAJDANBHOO));
	}

	public virtual void JHDEIGOECKK()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MOGIJEPNJKF));
	}

	private void BKMLPHEAEKI(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.KANMLANBLBL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public virtual void BOJJAOJLHGH()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNFMPCIJLED));
	}

	public void AFHMOPJGNBM(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.PJBNJAKIJFP();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1043f : 352f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 541f, 187f, 170);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.LOFLIHGMOIK();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(320f / MOAHOPBPMDJ.transform.localScale.x, 1931f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MMLCOBGBMKK());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DEEEPOFDFCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1252f);
				float multiplier2 = 166f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(890f);
				float multiplier3 = Mathf.Min(1873f / NACGOGCPIAH.transform.localScale.x, 1770f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BKMLPHEAEKI));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIAMPAIHCFM));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.OKEDPLGPKAF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MPOJKLJHDGF());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.MNNDLKMJPJH();
		}
	}

	public void KOABMGAPCKP(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.PJBNJAKIJFP();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1071f : 302f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 804f, 1713f, -189);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(658f / MOAHOPBPMDJ.transform.localScale.x, 1379f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MMLCOBGBMKK());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HMJOMKKEPCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(676f);
				float multiplier2 = 432f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(349f);
				float multiplier3 = Mathf.Min(627f / NACGOGCPIAH.transform.localScale.x, 1713f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PEDOECHFDPE));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIAMPAIHCFM));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HNMCKAJOFCG();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MPOJKLJHDGF());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EJLBHLKAAPI();
		}
	}

	public void EPAHIKLPNNB(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.ICCCPOHONAH();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 93f : 1338f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1760f, 400f, -147);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NFDMAHIAPPA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(900f / MOAHOPBPMDJ.transform.localScale.x, 1828f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.PDMFFMJBFEC());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HMJOMKKEPCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1708f);
				float multiplier2 = 282f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1587f);
				float multiplier3 = Mathf.Min(1903f / NACGOGCPIAH.transform.localScale.x, 464f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MOGIJEPNJKF));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IAHHJPOMECG));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HMJOMKKEPCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.IGIKGHOMAPH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JEGBLEKAJNA();
		}
	}

	private void NJGCONEEFOB(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.KANMLANBLBL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.AONPDBAPDOL(IFFDIHCPKFE);
		}
	}

	private void OADPNEOCOAF(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.ShowDialog(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public void IGPOLIPPGBP(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.MFCBBDKHANL();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1416f : 360f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1606f, 1214f, 166);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.DEEEPOFDFCI();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(715f / MOAHOPBPMDJ.transform.localScale.x, 658f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.EKADDKEMIMH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.KCHMDALPMBN;
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(473f);
				float multiplier2 = 1768f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(109f);
				float multiplier3 = Mathf.Min(242f / NACGOGCPIAH.transform.localScale.x, 1005f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MOGIJEPNJKF));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.NFDMAHIAPPA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.GLKODMJINNC());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JECMMPJMKKC();
		}
	}

	public void JMLMMFOCKCN(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.PJBNJAKIJFP();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 324f : 201f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 404f, 138f, 198);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(327f / MOAHOPBPMDJ.transform.localScale.x, 1837f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.IOFMMLGBICH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HMJOMKKEPCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1464f);
				float multiplier2 = 1891f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1200f);
				float multiplier3 = Mathf.Min(1542f / NACGOGCPIAH.transform.localScale.x, 676f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPFNPNEAKEL));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KPFNPNEAKEL));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BPFHJNKBMBA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MLKEJFBJDJJ());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.HHCPNNGEDAI();
		}
	}

	private void NPHOCHGKGEJ(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.KANMLANBLBL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public virtual void LLKBNDHBNAL()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAHHJPOMECG));
	}

	public virtual void MIDOLDHLMAF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFFFEEHDPCB));
	}

	public virtual void FMIHIFHGPMJ()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFFFEEHDPCB));
	}

	public void NDIJBPIDGOF(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.KOGIDBBOJPI();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 799f : 937f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1501f, 1856f, 199);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(490f / MOAHOPBPMDJ.transform.localScale.x, 1302f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.ALIOFGDMFEM());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.NFDMAHIAPPA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(188f);
				float multiplier2 = 1034f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Left;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(259f);
				float multiplier3 = Mathf.Min(796f / NACGOGCPIAH.transform.localScale.x, 1747f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJGCONEEFOB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KPFNPNEAKEL));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BLJEBHNOAGG();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MDFMLFPBPCI());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.IIPKDEOFHNH();
		}
	}

	private void FJDJGAOGEAH(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.AJCILBFBNMK(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	public virtual void FJDJGGMKPDK()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MOGIJEPNJKF));
	}

	public virtual void LDCPPCDDDJM()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
	}

	public void FANFNOPNGBL(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.ICCCPOHONAH();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 405f : 1695f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 1431f, 1167f, 23);
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.HMJOMKKEPCI();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1330f / MOAHOPBPMDJ.transform.localScale.x, 394f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MMLCOBGBMKK());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BLJEBHNOAGG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1957f);
				float multiplier2 = 798f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1358f);
				float multiplier3 = Mathf.Min(762f / NACGOGCPIAH.transform.localScale.x, 1920f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AIAMPAIHCFM));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MOGIJEPNJKF));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HNMCKAJOFCG();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MFJNONKKEKE());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.DCCLACGDMEB();
		}
	}

	public virtual void IMBKPHGHFNI()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPFNPNEAKEL));
	}

	public virtual void GJKANGMPDHL()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGAJDANBHOO));
	}

	public void LMPNFLGMNBG(PHAMEDPLFLO MOEMPHPNBLM, COLKIFOMJPF AGHFHLOHGDC)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		HBDKBBHDOFM.text = MOEMPHPNBLM.FPMGPEMKBOI();
		HBDKBBHDOFM.transform.localPosition = HBDKBBHDOFM.transform.localPosition.ReplaceY((!flag) ? 1331f : 998f);
		MEJMLNDFDBP.COCBCFKJOJE(HBDKBBHDOFM, 368f, 583f, -66);
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPNMILFDLBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1348f / MOAHOPBPMDJ.transform.localScale.x, 1547f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			KBNOLPFGPAC = AGHFHLOHGDC;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.ALIOFGDMFEM());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPFHJNKBMBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(339f);
				float multiplier2 = 586f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(956f);
				float multiplier3 = Mathf.Min(546f / NACGOGCPIAH.transform.localScale.x, 971f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CKLEPCIDIDB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.NIKLMCMINDL();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.IGIKGHOMAPH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.NJKBIAMBMMI();
		}
	}

	public virtual void DCFHLIDIDMN()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGAJDANBHOO));
	}

	private void CGAJDANBHOO(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.OPPAFPHDKNL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(IFFDIHCPKFE);
		}
	}

	private void JNFMPCIJLED(GameObject KHAHPAKDIKE)
	{
		if (KBNOLPFGPAC == COLKIFOMJPF.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.KANMLANBLBL(IFFDIHCPKFE);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.AONPDBAPDOL(IFFDIHCPKFE);
		}
	}

	public virtual void GLMGMOICPFK()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
	}
}
