using System;
using UnityEngine;

public class WarArenaSmallRewardRecord : PoolableObject
{
	[Header("Core")]
	public UISprite DAANKCOLJGJ;

	public UISprite MOAHOPBPMDJ;

	public GameObject DNCJEBDPBNA;

	public GameObject PNCFKDMDKAK;

	public UISprite NACGOGCPIAH;

	public BoxCollider GOCLCFJNCEO;

	private LevelBehaviour IFFDIHCPKFE;

	private void NPHOCHGKGEJ(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.AJCILBFBNMK(IFFDIHCPKFE);
	}

	public virtual void HGOBLCPDFCD()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
	}

	public void HCEJNMJHDJN(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.DGFFLCOAJEF();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(866f / MOAHOPBPMDJ.transform.localScale.x, 662f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HILMFDKACAO());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DEEEPOFDFCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(408f);
				float multiplier2 = 1673f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1523f);
				float multiplier3 = Mathf.Min(1282f / NACGOGCPIAH.transform.localScale.x, 1139f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NHJAJAIOHMI));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.KCHMDALPMBN;
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MFJNONKKEKE());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.IKJOPLKNNOD();
		}
	}

	public virtual void BOJJAOJLHGH()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DCOIKOPBMKO));
	}

	public void NDIJBPIDGOF(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.KCHMDALPMBN;
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(510f / MOAHOPBPMDJ.transform.localScale.x, 1516f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MMLCOBGBMKK());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HNMCKAJOFCG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1887f);
				float multiplier2 = 1511f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(524f);
				float multiplier3 = Mathf.Min(192f / NACGOGCPIAH.transform.localScale.x, 980f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKPBGDGCILD));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BPFHJNKBMBA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.IGIKGHOMAPH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JEGBLEKAJNA();
		}
	}

	public virtual void PNJDBOIFEMF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
	}

	public void BDMNPDBOCGN(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1257f / MOAHOPBPMDJ.transform.localScale.x, 1884f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.IOFMMLGBICH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPNMILFDLBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1412f);
				float multiplier2 = 757f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(621f);
				float multiplier3 = Mathf.Min(1389f / NACGOGCPIAH.transform.localScale.x, 1104f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFFFEEHDPCB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HMJOMKKEPCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.EDMNIKBBOFP());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GDFMIHIBBDK();
		}
	}

	public virtual void IPKNMFLEMLE()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MOJHHFCEJJI));
	}

	public void CHOLKMFKINL(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(760f / MOAHOPBPMDJ.transform.localScale.x, 1299f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.KOILBOEFNPA());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.LOFLIHGMOIK();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1843f);
				float multiplier2 = 1911f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1427f);
				float multiplier3 = Mathf.Min(218f / NACGOGCPIAH.transform.localScale.x, 1951f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HMJOMKKEPCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.GLKODMJINNC());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.DCCLACGDMEB();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
	}

	private void KEOIOMPEILB(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.OPPAFPHDKNL(IFFDIHCPKFE);
	}

	public virtual void NOJLGJDAMMK()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DCOIKOPBMKO));
	}

	public void FPPLMOLHGFD(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(953f / MOAHOPBPMDJ.transform.localScale.x, 1401f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.PDMFFMJBFEC());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HNMCKAJOFCG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1526f);
				float multiplier2 = 568f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(874f);
				float multiplier3 = Mathf.Min(853f / NACGOGCPIAH.transform.localScale.x, 893f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ADBFNOAJKBK));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFDCPFANCBG));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.NFDMAHIAPPA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MDFMLFPBPCI());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JIOMLEMMAAG();
		}
	}

	public virtual void KNBIJEBLMGK()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
	}

	public void JMPLLJLLPHK(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BLJEBHNOAGG();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1085f / MOAHOPBPMDJ.transform.localScale.x, 1321f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.FLDHFENFAAI());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.OKEDPLGPKAF();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(506f);
				float multiplier2 = 774f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(483f);
				float multiplier3 = Mathf.Min(1587f / NACGOGCPIAH.transform.localScale.x, 247f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CDKODIKBCLB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BPFHJNKBMBA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MPOJKLJHDGF());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EBIBNFKOHOE();
		}
	}

	public virtual void BNFHNJOPJCK()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
	}

	public void JMLMMFOCKCN(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.HNMCKAJOFCG();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1197f / MOAHOPBPMDJ.transform.localScale.x, 1289f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.FLDHFENFAAI());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BLJEBHNOAGG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1296f);
				float multiplier2 = 1092f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1854f);
				float multiplier3 = Mathf.Min(988f / NACGOGCPIAH.transform.localScale.x, 1902f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NHJAJAIOHMI));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.OKEDPLGPKAF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.FCOJEDGLELH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JECMMPJMKKC();
		}
	}

	private void JFGPFCBECJN(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public void AJEGOKKKLOL(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1901f / MOAHOPBPMDJ.transform.localScale.x, 692f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.CIIKNLIACDK());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HNMCKAJOFCG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1704f);
				float multiplier2 = 1723f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1354f);
				float multiplier3 = Mathf.Min(1168f / NACGOGCPIAH.transform.localScale.x, 1102f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.DEEEPOFDFCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.EDMNIKBBOFP());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JIOMLEMMAAG();
		}
	}

	public void Initialize(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
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

	private void DCOIKOPBMKO(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.KPDJABMGPDM(IFFDIHCPKFE);
	}

	private void PFFFEEHDPCB(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.OPPAFPHDKNL(IFFDIHCPKFE);
	}

	public virtual void DCFHLIDIDMN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDOACNPLMPJ));
	}

	public virtual void OEMOOAENMHN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFDCPFANCBG));
	}

	private void OADPNEOCOAF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void LLKBNDHBNAL()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JFGPFCBECJN));
	}

	private void AKPBGDGCILD(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.OPPAFPHDKNL(IFFDIHCPKFE);
	}

	private void CDKODIKBCLB(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.KPDJABMGPDM(IFFDIHCPKFE);
	}

	public void PPLIBOAJOCA(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPNMILFDLBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1263f / MOAHOPBPMDJ.transform.localScale.x, 384f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.PDMFFMJBFEC());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPNMILFDLBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1128f);
				float multiplier2 = 471f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(263f);
				float multiplier3 = Mathf.Min(1881f / NACGOGCPIAH.transform.localScale.x, 671f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NHJAJAIOHMI));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BLJEBHNOAGG();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.PEFLFIIPHMN());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GODLBNNAGJH();
		}
	}

	public void ACJCGDPGNAN(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.DGFFLCOAJEF();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(731f / MOAHOPBPMDJ.transform.localScale.x, 1588f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.GGMIKJFNHEG());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPFHJNKBMBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1568f);
				float multiplier2 = 526f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1966f);
				float multiplier3 = Mathf.Min(1247f / NACGOGCPIAH.transform.localScale.x, 143f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MOJHHFCEJJI));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.LOFLIHGMOIK();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MPOJKLJHDGF());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.BEEKAAFKLAB();
		}
	}

	private void ADBFNOAJKBK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.AECEEHEJBEE(IFFDIHCPKFE);
	}

	public void MPFPHNBAIKD(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NFDMAHIAPPA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1887f / MOAHOPBPMDJ.transform.localScale.x, 591f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.BEFDANMJFHO());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BPNMILFDLBA();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1187f);
				float multiplier2 = 1227f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1716f);
				float multiplier3 = Mathf.Min(1002f / NACGOGCPIAH.transform.localScale.x, 660f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CDKODIKBCLB));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.NIKLMCMINDL();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MLKEJFBJDJJ());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EJLBHLKAAPI();
		}
	}

	private void MOJHHFCEJJI(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.CPGNJFJHBEB(IFFDIHCPKFE);
	}

	public virtual void PCDBEEACOKN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ADBFNOAJKBK));
	}

	public override void OBCAIFMOPPA()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
	}

	public void FJLJLDNCBBD(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BLJEBHNOAGG();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1149f / MOAHOPBPMDJ.transform.localScale.x, 1438f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.MLDONFFLJGD());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DEEEPOFDFCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1432f);
				float multiplier2 = 1437f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1047f);
				float multiplier3 = Mathf.Min(663f / NACGOGCPIAH.transform.localScale.x, 1810f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MOJHHFCEJJI));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NPHOCHGKGEJ));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.HMJOMKKEPCI();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.FCOJEDGLELH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.JIOMLEMMAAG();
		}
	}

	public virtual void LAJKINDAEEO()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NHJAJAIOHMI));
	}

	private void NHJAJAIOHMI(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.CPGNJFJHBEB(IFFDIHCPKFE);
	}

	private void LCDBDNDPIIH(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.AECEEHEJBEE(IFFDIHCPKFE);
	}

	public void MLLKACEGPCM(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.HNMCKAJOFCG();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1634f / MOAHOPBPMDJ.transform.localScale.x, 414f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HMLHCODMGLH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.LOFLIHGMOIK();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(925f);
				float multiplier2 = 915f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1787f);
				float multiplier3 = Mathf.Min(673f / NACGOGCPIAH.transform.localScale.x, 721f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NPHOCHGKGEJ));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BPFHJNKBMBA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MDFMLFPBPCI());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.MNNDLKMJPJH();
		}
	}

	public void AFHMOPJGNBM(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1432f / MOAHOPBPMDJ.transform.localScale.x, 1408f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.GGMIKJFNHEG());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.NIKLMCMINDL();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(489f);
				float multiplier2 = 64f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(328f);
				float multiplier3 = Mathf.Min(747f / NACGOGCPIAH.transform.localScale.x, 1752f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JFGPFCBECJN));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CDKODIKBCLB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.NFDMAHIAPPA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.NHMCEOKJBNI());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EJLBHLKAAPI();
		}
	}

	public virtual void KJDECEJDGHF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
	}

	public void PBEFOOADBPG(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1198f / MOAHOPBPMDJ.transform.localScale.x, 720f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HHDJHDFDHIB());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HNMCKAJOFCG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(541f);
				float multiplier2 = 1424f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1440f);
				float multiplier3 = Mathf.Min(681f / NACGOGCPIAH.transform.localScale.x, 1874f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFDCPFANCBG));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.LOFLIHGMOIK();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.GLKODMJINNC());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.EJLBHLKAAPI();
		}
	}

	public void MFFEFILOKMG(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC != null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.NIKLMCMINDL();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1987f / MOAHOPBPMDJ.transform.localScale.x, 903f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.NCHGGFNEPJC);
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.LOFLIHGMOIK();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Top;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(355f);
				float multiplier2 = 199f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Bottom;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1794f);
				float multiplier3 = Mathf.Min(226f / NACGOGCPIAH.transform.localScale.x, 462f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LCDBDNDPIIH));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEOIOMPEILB));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.OKEDPLGPKAF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.FCOJEDGLELH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GODLBNNAGJH();
		}
	}

	public void BGFKBPMPJIL(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.OKEDPLGPKAF();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1857f / MOAHOPBPMDJ.transform.localScale.x, 226f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.NCHGGFNEPJC);
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.BLJEBHNOAGG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(418f);
				float multiplier2 = 1539f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(855f);
				float multiplier3 = Mathf.Min(1840f / NACGOGCPIAH.transform.localScale.x, 1858f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPHOCHGKGEJ));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKPBGDGCILD));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BPNMILFDLBA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.EDMNIKBBOFP());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.IKJOPLKNNOD();
		}
	}

	private void FJDJGAOGEAH(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.GONOICLIMKO(IFFDIHCPKFE);
	}

	public void OMGCKCFKDJM(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.HMJOMKKEPCI();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(557f / MOAHOPBPMDJ.transform.localScale.x, 1251f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HEFIICEFMFB());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.NIKLMCMINDL();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopLeft;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(89f);
				float multiplier2 = 1761f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Right;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1035f);
				float multiplier3 = Mathf.Min(1432f / NACGOGCPIAH.transform.localScale.x, 1513f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DCOIKOPBMKO));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JFGPFCBECJN));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.OKEDPLGPKAF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.FCOJEDGLELH());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.HHCPNNGEDAI();
		}
	}

	private void PFDCPFANCBG(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.CPGNJFJHBEB(IFFDIHCPKFE);
	}

	public void MFMJPBCIHEH(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(!flag2 && !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.KCHMDALPMBN;
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(392f / MOAHOPBPMDJ.transform.localScale.x, 71f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.IOFMMLGBICH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DEEEPOFDFCI();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.Center;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(649f);
				float multiplier2 = 1030f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1488f);
				float multiplier3 = Mathf.Min(100f / NACGOGCPIAH.transform.localScale.x, 341f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKFKJECOHIC));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKPBGDGCILD));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.OKEDPLGPKAF();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MLKEJFBJDJJ());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.OHFJAJEHKPP();
		}
	}

	private void MKFKJECOHIC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.GONOICLIMKO(IFFDIHCPKFE);
	}

	public virtual void FMIHIFHGPMJ()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DCOIKOPBMKO));
	}

	private void DDOACNPLMPJ(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<EliteUnitPreviewDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public void LMPNFLGMNBG(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO == null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.OKEDPLGPKAF();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(759f / MOAHOPBPMDJ.transform.localScale.x, 1841f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.EKADDKEMIMH());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.DGFFLCOAJEF();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1555f);
				float multiplier2 = 994f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(172f);
				float multiplier3 = Mathf.Min(1483f / NACGOGCPIAH.transform.localScale.x, 1350f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKPBGDGCILD));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ADBFNOAJKBK));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.BLJEBHNOAGG();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MPOJKLJHDGF());
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.NJKBIAMBMMI();
		}
	}

	public void HEGPFIGACED(PHAMEDPLFLO MOEMPHPNBLM)
	{
		ONFFKNJJJGC oNFFKNJJJGC = MOEMPHPNBLM as ONFFKNJJJGC;
		JPEPKDGPCAO jPEPKDGPCAO = MOEMPHPNBLM as JPEPKDGPCAO;
		bool flag = oNFFKNJJJGC == null;
		bool flag2 = jPEPKDGPCAO != null;
		DAANKCOLJGJ.gameObject.SetActive(flag2 || !flag);
		MOAHOPBPMDJ.gameObject.SetActive(flag2);
		DNCJEBDPBNA.SetActive(flag);
		if (flag2)
		{
			MOAHOPBPMDJ.spriteName = jPEPKDGPCAO.BPFHJNKBMBA();
			MOAHOPBPMDJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1779f / MOAHOPBPMDJ.transform.localScale.x, 1359f / MOAHOPBPMDJ.transform.localScale.x);
			MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			IFFDIHCPKFE = oNFFKNJJJGC.ACLDFHJKBLI;
			PNCFKDMDKAK.SetActive(oNFFKNJJJGC.HEFIICEFMFB());
			NACGOGCPIAH.spriteName = oNFFKNJJJGC.HNMCKAJOFCG();
			NACGOGCPIAH.MakePixelPerfect();
			if (IFFDIHCPKFE.isSoldier)
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.BottomRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(375f);
				float multiplier2 = 1778f / NACGOGCPIAH.transform.localScale.y;
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				NACGOGCPIAH.pivot = UIWidget.Pivot.TopRight;
				NACGOGCPIAH.transform.localPosition = NACGOGCPIAH.transform.localPosition.ReplaceY(1004f);
				float multiplier3 = Mathf.Min(255f / NACGOGCPIAH.transform.localScale.x, 1281f / NACGOGCPIAH.transform.localScale.y);
				NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPNEOCOAF));
			UIEventListener uIEventListener2 = UIEventListener.Get(GOCLCFJNCEO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFDCPFANCBG));
		}
		else
		{
			DAANKCOLJGJ.spriteName = MOEMPHPNBLM.NFDMAHIAPPA();
			DAANKCOLJGJ.MakePixelPerfect();
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(MOEMPHPNBLM.MLPFDBADEBE);
			DAANKCOLJGJ.transform.localRotation = MOEMPHPNBLM.GLLPEFCECKF();
		}
	}

	public virtual void GCNDLBLILAL()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPHOCHGKGEJ));
	}

	public virtual void HOCPBJGFEON()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(GOCLCFJNCEO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJDJGAOGEAH));
	}
}
