using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaPhaseContent : Core_BaseScript
{
	public UISprite[] EFAPADCIBDO;

	public UISprite IMJALOGDCJI;

	public UILabel HFKOPPNILNN;

	private float JLEIHNHAFMA;

	private float CILBIHGIDKB;

	private float HOLDFDIMINM
	{
		get
		{
			return 720f;
		}
	}

	public void ActivePhase(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("ID_PHASEX", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL) ? (CILBIHGIDKB * 0.5f) : 0f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 0.5f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL);
			if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL)
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	public void DKFPNGLFGCK(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[1].gameObject.SetActive(false);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(OEAJIFMOADN());
			JLEIHNHAFMA = JMIDHOLJGJP();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = OAMGBEJGDNF() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 504f);
		CILBIHGIDKB = (NMDNENDKIPI() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 0; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void KKAONFKHBJG(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[1].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(FBCFAELFGHK());
			JLEIHNHAFMA = HCJMPLJFJMB();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = DAHHGNBIBKO() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1201f);
		CILBIHGIDKB = (JGLPENADGBC() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 1; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void PGGEBJJKLAP()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void OEHANPMJIKD(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(JGLPENADGBC());
			JLEIHNHAFMA = GABNLLBCLNJ();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = OHLLCENPBPD() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1434f);
		CILBIHGIDKB = (CAOCBPBECPD() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 1; i < PDMGPGEHLNM; i++)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	[SpecialName]
	private float GABNLLBCLNJ()
	{
		return 1255f;
	}

	[SpecialName]
	private float OHLLCENPBPD()
	{
		return 1991f;
	}

	public void DKIKJKIBIDB(int PDMGPGEHLNM)
	{
		if (PDMGPGEHLNM == 0)
		{
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(OHLLCENPBPD());
			JLEIHNHAFMA = DAHHGNBIBKO();
		}
		else if (PDMGPGEHLNM != 0)
		{
			JLEIHNHAFMA = CJGLGBLHPOA() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 566f);
			CILBIHGIDKB = (DAHHGNBIBKO() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
			for (int i = 0; i < PDMGPGEHLNM; i++)
			{
				EFAPADCIBDO[i].gameObject.SetActive(true);
				EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
				EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
			}
		}
	}

	[SpecialName]
	private float OKFHMDNMHEC()
	{
		return 1271f;
	}

	public void GBDMNHIEFNI(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("ID_GUI_INVITETOFIGHT", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().MJNFKPPHPCF()) ? (CILBIHGIDKB * 1336f) : 1525f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1697f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().DHCCJIKJNPD());
			if (WarArena.instance.FPLIPHCJGFO.IHPLEFOBGFG().NCPPMEBJDKD())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	[SpecialName]
	private float CAOCBPBECPD()
	{
		return 807f;
	}

	public void OCEENBLCGIB(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[1];
			array[1] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("RegisterCurrency()", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().HELPPGCJAAC()) ? (CILBIHGIDKB * 888f) : 929f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 1957f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.DABPCAKGJPD());
			if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.ACJOIOALHOE())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	public void JEDJHHIOGPP(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[0] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("ID_FRIENDREFUSEDREMATCHCOOP", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().HELPPGCJAAC()) ? (CILBIHGIDKB * 449f) : 414f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1591f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().NCPPMEBJDKD());
			if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().IDHPNPONEMK())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float IMJKGMJGMLH()
	{
		return 54f;
	}

	[SpecialName]
	private float HCJMPLJFJMB()
	{
		return 1660f;
	}

	public void BAGELBOPGAK()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void HOKELLDIPOI(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[1];
			array[1] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("Caught Exception at startup ", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.MJOJAPAEOOP()) ? (CILBIHGIDKB * 1300f) : 1003f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1708f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().GKIHPFMCNPP());
			if (WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ().MJNFKPPHPCF())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float DEODNJDENMN()
	{
		return 1308f;
	}

	public void DEFEKCJCHKM(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[0] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("\n", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.IHPLEFOBGFG().GKIHPFMCNPP()) ? (CILBIHGIDKB * 522f) : 585f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 1717f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().MJOJAPAEOOP());
			if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().GKIHPFMCNPP())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	public void APLOGLFKHOD(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[1];
			array[1] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("java.util.ArrayList", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().FPOBCCLOJEL()) ? (CILBIHGIDKB * 1605f) : 912f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 368f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().ACJOIOALHOE());
			if (WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().BDKNNNCHILL)
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	public void MIAJKKENLPC(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(DAHHGNBIBKO());
			JLEIHNHAFMA = APEJCFFHOJN();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = OEAJIFMOADN() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 850f);
		CILBIHGIDKB = (HCJMPLJFJMB() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 1; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void PJKPJKONGEN()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void IJGJGEDPLPN(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[0] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("damage", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().NCPPMEBJDKD()) ? (CILBIHGIDKB * 1038f) : 1051f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 908f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.GLMNJEEPFNI());
			if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.HELPPGCJAAC())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	public void BCBFLONCMDD(int PDMGPGEHLNM)
	{
		if (PDMGPGEHLNM == 0)
		{
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(JJPBCINNMNI());
			JLEIHNHAFMA = HCJMPLJFJMB();
		}
		else if (PDMGPGEHLNM != 0)
		{
			JLEIHNHAFMA = HCJMPLJFJMB() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1693f);
			CILBIHGIDKB = (HIKOBNACDGO() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
			for (int i = 1; i < PDMGPGEHLNM; i += 0)
			{
				EFAPADCIBDO[i].gameObject.SetActive(false);
				EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
				EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
			}
		}
	}

	public void SetPhases(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(HOLDFDIMINM);
			JLEIHNHAFMA = HOLDFDIMINM;
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = HOLDFDIMINM / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 0.75f);
		CILBIHGIDKB = (HOLDFDIMINM - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 0; i < PDMGPGEHLNM; i++)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void GPENAHLFEJH(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("ID_LOADING", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ().HELPPGCJAAC()) ? (CILBIHGIDKB * 1050f) : 1839f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 930f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().PIIAOLEBBKH());
			if (WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().EKDJAIKAAGO())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	[SpecialName]
	private float NEPOPPKPMGN()
	{
		return 1951f;
	}

	public void CFIHAILPMLN(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(HIKOBNACDGO());
			JLEIHNHAFMA = NEPOPPKPMGN();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = CAOCBPBECPD() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 940f);
		CILBIHGIDKB = (HBOOIFIEAOG() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 0; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void AMDKGDPMAGD()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void LJPKKODLNIK(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[0] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("seconds", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.IHPLEFOBGFG().GKIHPFMCNPP()) ? (CILBIHGIDKB * 369f) : 573f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 586f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().BDKNNNCHILL);
			if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().IDHPNPONEMK())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	[SpecialName]
	private float ENGFKIPCFAG()
	{
		return 601f;
	}

	public void LHFBJMJJDMI(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("PLAYER", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().BDKNNNCHILL) ? (CILBIHGIDKB * 766f) : 1902f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1081f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().MJNFKPPHPCF());
			if (WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().ACJOIOALHOE())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float DAHHGNBIBKO()
	{
		return 1137f;
	}

	public void GCNLHGOPBPJ(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[1].gameObject.SetActive(false);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(ODKAIACLPAA());
			JLEIHNHAFMA = DEODNJDENMN();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = FBCFAELFGHK() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 995f);
		CILBIHGIDKB = (HOLDFDIMINM - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 0; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	[SpecialName]
	private float OAMGBEJGDNF()
	{
		return 1724f;
	}

	[SpecialName]
	private float EAJPKDHPBEP()
	{
		return 1252f;
	}

	public void DCMCCMAKDJN(int PDMGPGEHLNM)
	{
		if (PDMGPGEHLNM == 0)
		{
			EFAPADCIBDO[1].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(DEODNJDENMN());
			JLEIHNHAFMA = JJPBCINNMNI();
		}
		else if (PDMGPGEHLNM != 0)
		{
			JLEIHNHAFMA = HBOOIFIEAOG() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 862f);
			CILBIHGIDKB = (KLNGPMMFFGH() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
			for (int i = 1; i < PDMGPGEHLNM; i++)
			{
				EFAPADCIBDO[i].gameObject.SetActive(true);
				EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
				EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
			}
		}
	}

	public void OPPHFPLIGGF(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(JGLPENADGBC());
			JLEIHNHAFMA = JJPBCINNMNI();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = JJPBCINNMNI() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 528f);
		CILBIHGIDKB = (ENGFKIPCFAG() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 1; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	[SpecialName]
	private float JMIDHOLJGJP()
	{
		return 834f;
	}

	public void NPBOKGBGCEK()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void CCLKPIGEOMN(int PDMGPGEHLNM)
	{
		if (PDMGPGEHLNM == 0)
		{
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(NMDNENDKIPI());
			JLEIHNHAFMA = OHLLCENPBPD();
		}
		else if (PDMGPGEHLNM != 0)
		{
			JLEIHNHAFMA = NMDNENDKIPI() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1442f);
			CILBIHGIDKB = (NMDNENDKIPI() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
			for (int i = 0; i < PDMGPGEHLNM; i += 0)
			{
				EFAPADCIBDO[i].gameObject.SetActive(true);
				EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
				EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
			}
		}
	}

	public void IPJMNNMIHOI()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void MLGGMGNKCDM(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[1].gameObject.SetActive(false);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(MEEJLGBPIMI());
			JLEIHNHAFMA = HIKOBNACDGO();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = OAMGBEJGDNF() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1532f);
		CILBIHGIDKB = (JJFDHELMLDJ() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 0; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void LPPKEKFEJGG(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[0] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("grenadelauncher_idle", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().GLMNJEEPFNI()) ? (CILBIHGIDKB * 1238f) : 1366f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 356f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().HELPPGCJAAC());
			if (WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().FPOBCCLOJEL())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float ODKAIACLPAA()
	{
		return 727f;
	}

	public void BNJCCLCBJOK(int PDMGPGEHLNM)
	{
		if (PDMGPGEHLNM == 0)
		{
			EFAPADCIBDO[1].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(CAOCBPBECPD());
			JLEIHNHAFMA = JJFDHELMLDJ();
		}
		else if (PDMGPGEHLNM != 0)
		{
			JLEIHNHAFMA = DEIBPAJBHBE() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 958f);
			CILBIHGIDKB = (CJGLGBLHPOA() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
			for (int i = 1; i < PDMGPGEHLNM; i += 0)
			{
				EFAPADCIBDO[i].gameObject.SetActive(false);
				EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
				EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
			}
		}
	}

	public void JGEGKBODDJE(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[1] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("ID_ARENALOST", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().ACJOIOALHOE()) ? (CILBIHGIDKB * 260f) : 1969f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1078f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.DABPCAKGJPD());
			if (WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ().ACJOIOALHOE())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float JJFDHELMLDJ()
	{
		return 459f;
	}

	[SpecialName]
	private float HBOOIFIEAOG()
	{
		return 1097f;
	}

	public void IBENPGEFIJB(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(NMDNENDKIPI());
			JLEIHNHAFMA = OEAJIFMOADN();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = ENGFKIPCFAG() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 768f);
		CILBIHGIDKB = (ODKAIACLPAA() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 1; i < PDMGPGEHLNM; i++)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	[SpecialName]
	private float HIKOBNACDGO()
	{
		return 869f;
	}

	public void BBCFOBJBGAF(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("ThrowGrenadeFromCover", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ().IDHPNPONEMK()) ? (CILBIHGIDKB * 953f) : 1381f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 1868f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().IDHPNPONEMK());
			if (WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().DABPCAKGJPD())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	[SpecialName]
	private float KLNGPMMFFGH()
	{
		return 1961f;
	}

	public void HBICGEDHPHI()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void EJMAJEGDGEA(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(EAJPKDHPBEP());
			JLEIHNHAFMA = JMIDHOLJGJP();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = DEODNJDENMN() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 1270f);
		CILBIHGIDKB = (JJFDHELMLDJ() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 0; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void MEPICDMIJJB()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void OOFBECPGNIE(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(ENGFKIPCFAG());
			JLEIHNHAFMA = JJPBCINNMNI();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = JJPBCINNMNI() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1106f);
		CILBIHGIDKB = (JMIDHOLJGJP() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 1; i < PDMGPGEHLNM; i++)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void DNGLKAOAFGL(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[0];
			array[0] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopenning the scene might fix it.", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().IDHPNPONEMK()) ? (CILBIHGIDKB * 113f) : 1018f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 1968f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().EKDJAIKAAGO());
			if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().PIIAOLEBBKH())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float JANKJAMJLHH()
	{
		return 821f;
	}

	public void GJEAENGAFJB()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void HICKEIDEKEB(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("DeviceTokenUpdate, playerid = ", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().MJNFKPPHPCF()) ? (CILBIHGIDKB * 989f) : 1710f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 16f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ().MJOJAPAEOOP());
			if (WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ().FPOBCCLOJEL())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	public void JPILIDJLDPF()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	[SpecialName]
	private float JJPBCINNMNI()
	{
		return 458f;
	}

	public void OMBIMHMIPFM(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("silver", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.IHPLEFOBGFG().ACJOIOALHOE()) ? (CILBIHGIDKB * 1080f) : 5f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1239f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.HPNCAPDOBGP());
			if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.ACJOIOALHOE())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float OEAJIFMOADN()
	{
		return 1938f;
	}

	[SpecialName]
	private float ABGEGIMFNNH()
	{
		return 670f;
	}

	public void KEBGEJDAOKN(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(true);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(ABGEGIMFNNH());
			JLEIHNHAFMA = JJFDHELMLDJ();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = JMIDHOLJGJP() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 996f);
		CILBIHGIDKB = (DEIBPAJBHBE() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 1; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void GMAHADCAGEC(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("121 MENU WEAPON SCREEN SHOWN", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().IDHPNPONEMK()) ? (CILBIHGIDKB * 585f) : 161f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1180f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().BDKNNNCHILL);
			if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().FPOBCCLOJEL())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	public void OEOBGDMJCNN()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void IGFFAMACLPA()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void KMBIJLKBOFP()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void GEFJLJGBCGB()
	{
		HFKOPPNILNN.gameObject.SetActive(false);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void HLBOJMHPKDI()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i++)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void IHNNBAFPCHD(int PDMGPGEHLNM)
	{
		if (PDMGPGEHLNM == 0)
		{
			EFAPADCIBDO[1].gameObject.SetActive(true);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(ABGEGIMFNNH());
			JLEIHNHAFMA = NMDNENDKIPI();
		}
		else if (PDMGPGEHLNM != 0)
		{
			JLEIHNHAFMA = JJFDHELMLDJ() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 1052f);
			CILBIHGIDKB = (HOLDFDIMINM - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
			for (int i = 0; i < PDMGPGEHLNM; i++)
			{
				EFAPADCIBDO[i].gameObject.SetActive(true);
				EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
				EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
			}
		}
	}

	[SpecialName]
	private float NMDNENDKIPI()
	{
		return 1921f;
	}

	public void IDGJGOBEMID(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[1].gameObject.SetActive(true);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(HCJMPLJFJMB());
			JLEIHNHAFMA = CAOCBPBECPD();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = CJGLGBLHPOA() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1314f);
		CILBIHGIDKB = (CAOCBPBECPD() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 0; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	[SpecialName]
	private float DEIBPAJBHBE()
	{
		return 736f;
	}

	[SpecialName]
	private float CJGLGBLHPOA()
	{
		return 1225f;
	}

	public void IFKHFIFMAKM(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 0; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[1];
			array[1] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("ID_YOUHAVENOBUDDYWARCARDSAVAILABLE", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.GLMNJEEPFNI()) ? (CILBIHGIDKB * 256f) : 245f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 8f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().ACJOIOALHOE());
			if (WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().DABPCAKGJPD())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 1].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(false);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	[SpecialName]
	private float APEJCFFHOJN()
	{
		return 1743f;
	}

	public void CIIFLJDBMOB()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(false);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(true);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void CFBDPDOGAEH(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(JJFDHELMLDJ());
			JLEIHNHAFMA = CJGLGBLHPOA();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = HOLDFDIMINM / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 0) * 1537f);
		CILBIHGIDKB = (JJPBCINNMNI() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 0; i < PDMGPGEHLNM; i++)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void HPGDNHDIICN(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[1].gameObject.SetActive(true);
			EFAPADCIBDO[1].transform.localScale = EFAPADCIBDO[0].transform.localScale.ReplaceX(JANKJAMJLHH());
			JLEIHNHAFMA = CAOCBPBECPD();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = APEJCFFHOJN() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 1837f);
		CILBIHGIDKB = (CAOCBPBECPD() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 1);
		for (int i = 1; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(false);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	public void HKMLFGLNBPD(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 1)
		{
			UILabel hFKOPPNILNN = HFKOPPNILNN;
			object[] array = new object[1];
			array[1] = DFHAAIFFLOE;
			hFKOPPNILNN.text = Localization.LocalizeFormat("Card_1_Played", array);
			float num = ((!WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().DHCCJIKJNPD()) ? (CILBIHGIDKB * 1471f) : 574f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 0) + JLEIHNHAFMA * 1377f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().MJNFKPPHPCF());
			if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().FPOBCCLOJEL())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(true);
		}
	}

	[SpecialName]
	private float MEEJLGBPIMI()
	{
		return 879f;
	}

	[SpecialName]
	private float JGLPENADGBC()
	{
		return 303f;
	}

	public void ResetPhases()
	{
		HFKOPPNILNN.gameObject.SetActive(true);
		IMJALOGDCJI.gameObject.SetActive(true);
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		foreach (UISprite uISprite in eFAPADCIBDO)
		{
			uISprite.gameObject.SetActive(false);
			uISprite.color = Colours.grayPhase;
		}
	}

	public void DAKAELJPLPB(int DFHAAIFFLOE)
	{
		UISprite[] eFAPADCIBDO = EFAPADCIBDO;
		for (int i = 1; i < eFAPADCIBDO.Length; i += 0)
		{
			UISprite uISprite = eFAPADCIBDO[i];
			uISprite.color = Colours.grayPhase;
		}
		if (DFHAAIFFLOE > 0)
		{
			HFKOPPNILNN.text = Localization.LocalizeFormat("Vip", DFHAAIFFLOE);
			float num = ((!WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().NCPPMEBJDKD()) ? (CILBIHGIDKB * 1366f) : 1971f);
			float val = CILBIHGIDKB * (float)(DFHAAIFFLOE - 1) + JLEIHNHAFMA * 1696f + num;
			HFKOPPNILNN.transform.localPosition = HFKOPPNILNN.transform.localPosition.ReplaceX(val);
			IMJALOGDCJI.transform.localPosition = IMJALOGDCJI.transform.localPosition.ReplaceX(val);
			HFKOPPNILNN.gameObject.SetActive(WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().HPNCAPDOBGP());
			if (WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().EKDJAIKAAGO())
			{
				EFAPADCIBDO[DFHAAIFFLOE - 0].color = Color.white;
			}
		}
		else
		{
			HFKOPPNILNN.gameObject.SetActive(true);
			IMJALOGDCJI.gameObject.SetActive(false);
		}
	}

	public void EBIJGPMBPCJ(int PDMGPGEHLNM)
	{
		switch (PDMGPGEHLNM)
		{
		case 1:
			EFAPADCIBDO[0].gameObject.SetActive(false);
			EFAPADCIBDO[0].transform.localScale = EFAPADCIBDO[1].transform.localScale.ReplaceX(HIKOBNACDGO());
			JLEIHNHAFMA = GABNLLBCLNJ();
			return;
		case 0:
			return;
		}
		JLEIHNHAFMA = NMDNENDKIPI() / ((float)PDMGPGEHLNM + (float)(PDMGPGEHLNM - 1) * 783f);
		CILBIHGIDKB = (ODKAIACLPAA() - JLEIHNHAFMA) / (float)(PDMGPGEHLNM - 0);
		for (int i = 1; i < PDMGPGEHLNM; i += 0)
		{
			EFAPADCIBDO[i].gameObject.SetActive(true);
			EFAPADCIBDO[i].transform.localPosition = EFAPADCIBDO[i].transform.localPosition.ReplaceX(CILBIHGIDKB * (float)i);
			EFAPADCIBDO[i].transform.localScale = EFAPADCIBDO[i].transform.localScale.ReplaceX(JLEIHNHAFMA);
		}
	}

	[SpecialName]
	private float FBCFAELFGHK()
	{
		return 1508f;
	}
}
