using System;
using UnityEngine;

public class WelcomeBackSoldierDialog : GuiElementSingle<WelcomeBackSoldierDialog>, PAIIOKBBHBC
{
	public enum PDPNFKKEKLO
	{
		Gold = 0,
		Cards = 1,
		Warbucks = 2,
		VIP = 3
	}

	[Header("Box1")]
	public UISprite KFHNBKBBAPB;

	public UILabel AMFFHPFKEGL;

	public GameObject BDGINBIEJLJ;

	[Header("Box2")]
	public UISprite ABBOHGNNCHJ;

	public UILabel PKKGPCJKDCI;

	public GameObject IDKIBCLNHIH;

	[Header("Bottom")]
	public UIButton PAFNFBOJFDI;

	private bool JGPLHENLBML;

	private PDPNFKKEKLO OBGFANIMGCN;

	private int MLDALAPJCHM;

	private bool BJMBLPOKPHE;

	private PDPNFKKEKLO HGFCCKAOHON;

	private int GDDDGLPMNAM;

	public void POPMFPMBHIP(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM == null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1006f);
	}

	private void FDKNMLGJBHO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void JNDDOPAAAJM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void IHLGGCNHCDG()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = DANPMGEPFGA(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 512f, 995f, -45);
			FBELELCPHME(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = JHLEJENLGHF(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 333f, 198f, -182);
			MBDKBNOKPJH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	private void FBNPDPDJOBP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void HHLOGFGGHHD()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = MKMJPKKDOND(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 1781f, 801f, -105);
			ELPDIIPHBOK(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = BMOEENAPLOK(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 1065f, 1444f, -143);
			MBDKBNOKPJH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	private void PPAGPEIGBIC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void EOFOMCBDBJN()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = CAAMOOBJIAH(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 512f, 1208f, 17);
			IEAGNJDKPCC(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = KBIEOGBLKLH(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 1462f, 1271f, -37);
			MHMOPNBFOPH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void HGKNCKIKBDC()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = BMOEENAPLOK(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 779f, 1506f, 9);
			IDOGOPIHFNK(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = KBIEOGBLKLH(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 1983f, 960f, -39);
			IEAGNJDKPCC(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void EOFNCJHPHDM()
	{
		NHOCBIKIKOE(PAFNFBOJFDI.gameObject);
	}

	public void ShowDialog(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE != null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public GuiElement FHCDHIADDOM()
	{
		return this;
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	public virtual void HCMELDFOBCP()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = DGENHLFPGIL(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 768f, 1681f, -112);
			MBDKBNOKPJH(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = BMOEENAPLOK(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 214f, 1452f, 11);
			IDOGOPIHFNK(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void OCFOEGJBNCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NHOCBIKIKOE));
	}

	private void IEAGNJDKPCC(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = true;
			JICPCKLPPLD.SetActive(false);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "Cannot show active units on this screen.";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1687f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "\"NaN\"";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1872f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "Shots_Fired";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1610f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(946f);
			break;
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(PAFNFBOJFDI.gameObject);
	}

	public virtual void PLMOAGCCJEB()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = DGENHLFPGIL(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 1940f, 1868f, -80);
			MBDKBNOKPJH(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = JHLEJENLGHF(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 221f, 1179f, 133);
			MBDKBNOKPJH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public void CJNMLPANNPD(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM == null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 991f);
	}

	public virtual void HKFICJFNOPM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
	}

	public virtual void DEJFPFPJKJI()
	{
		GKOHJGFKPAH(PAFNFBOJFDI.gameObject);
	}

	private void LELLEKAMKIG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void BNCDFKGNPII()
	{
		EKFJOFAOPMA(PAFNFBOJFDI.gameObject);
	}

	public override void InitGUIValues()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = BMOEENAPLOK(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 41f, 20f, 200);
			MHMOPNBFOPH(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = BMOEENAPLOK(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 41f, 20f, 200);
			MHMOPNBFOPH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void NHOEHNJICBO()
	{
		FDKNMLGJBHO(PAFNFBOJFDI.gameObject);
	}

	public void KNOIPLLPMMJ(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1083f);
	}

	private void EEPHLAGIICO(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = false;
			JICPCKLPPLD.SetActive(true);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "GetSkuInfo succeeded but productId ";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1933f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "SCARICA";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1174f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "ID_LOGOUT";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(162f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(1199f);
			break;
		}
	}

	private string ICLIOEJCJHD(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array2 = new object[7];
			array2[1] = Colours.stringYellow;
			array2[1] = LDAECKMLONH;
			return Localization.LocalizeFormat("Overtime_Was_Already_Explained", array2);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("UnitID", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("menu-arena-ticket", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
		{
			LDAECKMLONH /= -179;
			Debug.Log("ID_CATEGORY_LOW_SG_PRIMARY" + LDAECKMLONH);
			string keyFormat = ((LDAECKMLONH <= 1) ? "open" : "PlayerVisuals");
			object[] array = new object[4];
			array[1] = Colours.stringGoldTier;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat(keyFormat, array);
		}
		default:
			return string.Empty;
		}
	}

	private string EKPHEADMIGF(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array = new object[0];
			array[1] = Colours.stringYellow;
			array[1] = LDAECKMLONH;
			return Localization.LocalizeFormat("master1", array);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("#PLAYERID# Saving Player Account with PlayerId = ", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("ID_OFFLINE", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
			LDAECKMLONH /= 85;
			Debug.Log("{0}\t\t{1}" + LDAECKMLONH);
			return Localization.LocalizeFormat((LDAECKMLONH <= 0) ? "ID_SALEPERCENTLINE" : "1", Colours.stringGoldTier, LDAECKMLONH, null, null, null, null);
		default:
			return string.Empty;
		}
	}

	private void FOIPHDNFJDK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public GuiElement NFPBFHJINIC()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	private void MBDKBNOKPJH(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = false;
			JICPCKLPPLD.SetActive(false);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "DecalManagerData";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(363f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "dailyLimit";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(952f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "MIN_FPS";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1412f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(764f);
			break;
		}
	}

	public virtual void DOANAOOEAKD()
	{
		FOIPHDNFJDK(PAFNFBOJFDI.gameObject);
	}

	public virtual void EMGHCAHOJNC()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = MKMJPKKDOND(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 1055f, 1705f, 22);
			IEAGNJDKPCC(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = ICLIOEJCJHD(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 1695f, 0f, 72);
			MBDKBNOKPJH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public void CMOEFABLABI(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 490f);
	}

	public virtual void IOLNONPHCMM()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = MKMJPKKDOND(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 1714f, 435f, -176);
			IEAGNJDKPCC(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = EKPHEADMIGF(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 836f, 1773f, 106);
			EHPIJDIDNGE(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void LGOONGGHFPF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void MHMOPNBFOPH(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = false;
			JICPCKLPPLD.SetActive(true);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "menu-gold";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(0.33f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "menu-warbucks";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(0.6f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "menu-hub-multiplayer-vipico";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(0.4f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(3f);
			break;
		}
	}

	public void GONOICLIMKO(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1673f);
	}

	public virtual void BKDELMODAHM()
	{
		NHOCBIKIKOE(PAFNFBOJFDI.gameObject);
	}

	private void PICCJCKNCCF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private string BMOEENAPLOK(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			return Localization.LocalizeFormat("ID_X_CARDS", Colours.stringYellow, LDAECKMLONH);
		case PDPNFKKEKLO.Gold:
			return string.Format("{0}{1}", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("{0}{1}", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
			LDAECKMLONH /= 86400;
			Debug.Log("Vip days = " + LDAECKMLONH);
			return Localization.LocalizeFormat((LDAECKMLONH <= 1) ? "ID_VIP_DAY" : "ID_VIP_DAYS", Colours.stringGoldTier, LDAECKMLONH);
		default:
			return string.Empty;
		}
	}

	public virtual void LBFHGMHJKJC()
	{
		GKOHJGFKPAH(PAFNFBOJFDI.gameObject);
	}

	private void FBELELCPHME(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = false;
			JICPCKLPPLD.SetActive(false);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "menu-army-ammo-ico";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1217f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "reset tutorial";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(339f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "ShootCopyRPC";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1005f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(1849f);
			break;
		}
	}

	private string JHLEJENLGHF(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array2 = new object[4];
			array2[0] = Colours.stringYellow;
			array2[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("Shots_Fired", array2);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("shield_run", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("weapon", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
		{
			LDAECKMLONH /= 36;
			Debug.Log("Cant generate buddy card for weapons: {0}, {1} and type {2}" + LDAECKMLONH);
			string keyFormat = ((LDAECKMLONH <= 0) ? "ID_NA" : "RewardType");
			object[] array = new object[2];
			array[0] = Colours.stringGoldTier;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat(keyFormat, array);
		}
		default:
			return string.Empty;
		}
	}

	private void NHOCBIKIKOE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void MCCJIJKCOOH(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM == null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1329f);
	}

	private void GLJGKJCMAKB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public void OGIEPAIBEJJ(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 752f);
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FOIPHDNFJDK));
	}

	private void EHPIJDIDNGE(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = true;
			JICPCKLPPLD.SetActive(false);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "roomName";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1023f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "special";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(149f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "value";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1098f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(234f);
			break;
		}
	}

	private void ELPDIIPHBOK(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = false;
			JICPCKLPPLD.SetActive(true);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "SHOW WAR ARENA DIALOG!!";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1307f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = "getOpenLogId";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(547f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "Skill";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(309f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(233f);
			break;
		}
	}

	public void EBELHKPCLBI(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM == null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1672f);
	}

	public virtual void NDBAEHKKJMH()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = KGBHFJFCGGE(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 665f, 1727f, 106);
			IEAGNJDKPCC(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = BMOEENAPLOK(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 720f, 1899f, -48);
			MHMOPNBFOPH(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public GuiElement OGIAJOCDPMF()
	{
		return this;
	}

	private void IDOGOPIHFNK(UISprite GMPADNOGGNL, PDPNFKKEKLO FJLBLLLEELD, GameObject JICPCKLPPLD)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
			GMPADNOGGNL.enabled = true;
			JICPCKLPPLD.SetActive(false);
			break;
		case PDPNFKKEKLO.Gold:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "Lcom/google/android/gms/games/snapshot/Snapshots;";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(486f);
			break;
		case PDPNFKKEKLO.Warbucks:
			JICPCKLPPLD.SetActive(false);
			GMPADNOGGNL.spriteName = " ";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(475f);
			break;
		case PDPNFKKEKLO.VIP:
			JICPCKLPPLD.SetActive(true);
			GMPADNOGGNL.spriteName = "Assignment: Destroy Crates in one battle constructor";
			GMPADNOGGNL.MakePixelPerfect();
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(1415f);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.AddY(1801f);
			break;
		}
	}

	private void JJNLDFHEHJL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement MCJFBLKLHPA()
	{
		return this;
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBNPDPDJOBP));
	}

	public virtual void FBDMBKKDEDC()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = KBIEOGBLKLH(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 1332f, 1815f, 73);
			IEAGNJDKPCC(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = EKPHEADMIGF(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 717f, 1853f, 165);
			EHPIJDIDNGE(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNDDOPAAAJM));
	}

	public virtual void JGDJCCIPNHC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNDDOPAAAJM));
	}

	private string BEPHHNINEOG(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array = new object[2];
			array[0] = Colours.stringYellow;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("game-elite-buff", array);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("ID_CATEGORY_LOW_PL_PRIMARY", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("About to show Upgrade Weapon Reminder: ", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
			LDAECKMLONH /= 155;
			Debug.Log("registerConnectionFailedListener" + LDAECKMLONH);
			return Localization.LocalizeFormat((LDAECKMLONH <= 0) ? "{0} {1}" : "BANDS_EMPTY", Colours.stringGoldTier, LDAECKMLONH, null, null, null, null);
		default:
			return string.Empty;
		}
	}

	public void FPFEPCDFBCB(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE != null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 783f);
	}

	private string MKMJPKKDOND(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array = new object[7];
			array[0] = Colours.stringYellow;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("id", array);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("ID_MAXSTAT", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("{0} {1}{2}", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
			LDAECKMLONH /= -149;
			Debug.Log("reloadTime" + LDAECKMLONH);
			return Localization.LocalizeFormat((LDAECKMLONH <= 1) ? ")" : "Player disconected 0001", Colours.stringGoldTier, LDAECKMLONH, null, null, null, null, null);
		default:
			return string.Empty;
		}
	}

	public GuiElement EMJNNILLFIM()
	{
		return this;
	}

	public void FNGFBKPACAN(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 484f);
	}

	public void JGJCIEDEBIK(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1236f);
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
	}

	public void NFFOFBDCHMF(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE != null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM == null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 975f);
	}

	private string KBIEOGBLKLH(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array = new object[5];
			array[0] = Colours.stringYellow;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("Daily_mission_start", array);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("elite", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("com/google/android/gms/common/api/Status", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
			LDAECKMLONH /= -41;
			Debug.Log("Device UNPAUSED at {0}" + LDAECKMLONH);
			return Localization.LocalizeFormat((LDAECKMLONH <= 1) ? "ID_FREE" : "menu-weaponstats-totalammo", Colours.stringGoldTier, LDAECKMLONH, null, null, null, null, null);
		default:
			return string.Empty;
		}
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PICCJCKNCCF));
	}

	private void EKFJOFAOPMA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void GENKPBNDOCB()
	{
		EKFJOFAOPMA(PAFNFBOJFDI.gameObject);
	}

	public GuiElement LGCLDIDHJHB()
	{
		return this;
	}

	public virtual void GMDAPGAECEI()
	{
		NHOCBIKIKOE(PAFNFBOJFDI.gameObject);
	}

	private string KGBHFJFCGGE(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array2 = new object[6];
			array2[1] = Colours.stringYellow;
			array2[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("ID_ERROR_SQUADNAMELONG", array2);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("menu-weapons-tab", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("DailyGoldDay", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
		{
			LDAECKMLONH /= -10;
			Debug.Log("ID_WARNING_NOTENOUGHTLEVEL" + LDAECKMLONH);
			string keyFormat = ((LDAECKMLONH <= 1) ? "ID_SILVERCARD" : "Show Loadout After Create Account");
			object[] array = new object[2];
			array[1] = Colours.stringGoldTier;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat(keyFormat, array);
		}
		default:
			return string.Empty;
		}
	}

	public void PNAFICLOFAB(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE == null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM == null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 613f);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void PFCKKOBABEL()
	{
		FDKNMLGJBHO(PAFNFBOJFDI.gameObject);
	}

	public virtual void MFHJALPPCKI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNIJPDFMGML));
	}

	private string DANPMGEPFGA(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array2 = new object[3];
			array2[1] = Colours.stringYellow;
			array2[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("This notification record cannot be click while in Lobby screen", array2);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("ID_CONFIRM_LANGUAGECHANGE_TEXT", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("On Accept Challenge", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
		{
			LDAECKMLONH /= 42;
			Debug.Log("N" + LDAECKMLONH);
			string keyFormat = ((LDAECKMLONH <= 0) ? "Skill" : "SystemMessage");
			object[] array = new object[6];
			array[1] = Colours.stringGoldTier;
			array[0] = LDAECKMLONH;
			return Localization.LocalizeFormat(keyFormat, array);
		}
		default:
			return string.Empty;
		}
	}

	private string DGENHLFPGIL(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array2 = new object[4];
			array2[1] = Colours.stringYellow;
			array2[1] = LDAECKMLONH;
			return Localization.LocalizeFormat("nextWithdraw", array2);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("gcPassword", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("Action ", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
		{
			LDAECKMLONH /= 54;
			Debug.Log("ID_WARNING_CANTSENDINVITE_TEXT" + LDAECKMLONH);
			string keyFormat = ((LDAECKMLONH <= 1) ? "ID_SILVERPACK" : "visuals: wrong number {0} -{1}");
			object[] array = new object[7];
			array[1] = Colours.stringGoldTier;
			array[1] = LDAECKMLONH;
			return Localization.LocalizeFormat(keyFormat, array);
		}
		default:
			return string.Empty;
		}
	}

	public GuiElement NGOFDGAGECA()
	{
		return this;
	}

	public void IPCIJFBFLHP(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE != null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1529f);
	}

	public GuiElement GMPEFKABFGG()
	{
		return this;
	}

	private void DNIJPDFMGML(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void FOAALJKPPPC()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = ICLIOEJCJHD(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 242f, 1120f, -151);
			EEPHLAGIICO(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = DGENHLFPGIL(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 1414f, 71f, 132);
			IDOGOPIHFNK(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void DMBLJNMGLAH()
	{
		KFHNBKBBAPB.transform.parent.gameObject.SetActive(JGPLHENLBML);
		if (JGPLHENLBML)
		{
			AMFFHPFKEGL.text = CAAMOOBJIAH(OBGFANIMGCN, MLDALAPJCHM);
			MEJMLNDFDBP.COCBCFKJOJE(AMFFHPFKEGL, 933f, 1143f, -128);
			IEAGNJDKPCC(KFHNBKBBAPB, OBGFANIMGCN, BDGINBIEJLJ);
		}
		ABBOHGNNCHJ.transform.parent.gameObject.SetActive(BJMBLPOKPHE);
		if (BJMBLPOKPHE)
		{
			PKKGPCJKDCI.text = ICLIOEJCJHD(HGFCCKAOHON, GDDDGLPMNAM);
			MEJMLNDFDBP.COCBCFKJOJE(PKKGPCJKDCI, 1479f, 530f, -130);
			IEAGNJDKPCC(ABBOHGNNCHJ, HGFCCKAOHON, IDKIBCLNHIH);
		}
		if (KFHNBKBBAPB.transform.parent.gameObject.activeSelf && ABBOHGNNCHJ.transform.parent.gameObject.activeSelf)
		{
			if (AMFFHPFKEGL.transform.localScale.y < PKKGPCJKDCI.transform.localScale.y)
			{
				PKKGPCJKDCI.transform.localScale = AMFFHPFKEGL.transform.localScale;
				PKKGPCJKDCI.transform.localPosition = AMFFHPFKEGL.transform.localPosition;
			}
			else if (AMFFHPFKEGL.transform.localScale.y > PKKGPCJKDCI.transform.localScale.y)
			{
				AMFFHPFKEGL.transform.localScale = PKKGPCJKDCI.transform.localScale;
				AMFFHPFKEGL.transform.localPosition = PKKGPCJKDCI.transform.localPosition;
			}
		}
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PAFNFBOJFDI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GLJGKJCMAKB));
	}

	private string CAAMOOBJIAH(PDPNFKKEKLO FJLBLLLEELD, int LDAECKMLONH)
	{
		switch (FJLBLLLEELD)
		{
		case PDPNFKKEKLO.Cards:
		{
			object[] array2 = new object[0];
			array2[0] = Colours.stringYellow;
			array2[0] = LDAECKMLONH;
			return Localization.LocalizeFormat("ID_NOTIFICATION_WITHDRAWAVAILABLE", array2);
		}
		case PDPNFKKEKLO.Gold:
			return string.Format("Chat Tab: Opening Chat", Colours.stringGoldOld, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.Warbucks:
			return string.Format("Type", Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(LDAECKMLONH));
		case PDPNFKKEKLO.VIP:
		{
			LDAECKMLONH /= -73;
			Debug.Log("Sniper_Tutorial_Played" + LDAECKMLONH);
			string keyFormat = ((LDAECKMLONH <= 0) ? "SquadRank" : "ID_BUTTON_YOU");
			object[] array = new object[4];
			array[1] = Colours.stringGoldTier;
			array[1] = LDAECKMLONH;
			return Localization.LocalizeFormat(keyFormat, array);
		}
		default:
			return string.Empty;
		}
	}

	public void DBHIAKAOBDL(Tuple<PDPNFKKEKLO, int> HEDMDMKICKE, Tuple<PDPNFKKEKLO, int> JLMIHDNHJOM)
	{
		JGPLHENLBML = HEDMDMKICKE != null;
		if (JGPLHENLBML)
		{
			OBGFANIMGCN = HEDMDMKICKE.Value1;
			MLDALAPJCHM = HEDMDMKICKE.Value2;
		}
		BJMBLPOKPHE = JLMIHDNHJOM != null;
		if (BJMBLPOKPHE)
		{
			HGFCCKAOHON = JLMIHDNHJOM.Value1;
			GDDDGLPMNAM = JLMIHDNHJOM.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 500f);
	}
}
