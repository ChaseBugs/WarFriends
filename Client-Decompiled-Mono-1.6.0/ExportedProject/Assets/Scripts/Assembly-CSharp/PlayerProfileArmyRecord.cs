using UnityEngine;

public class PlayerProfileArmyRecord : Core_BaseScript
{
	[Header("Core")]
	public UIPanel IOHDBDJKMOM;

	public UISprite KMFGCJEGJJK;

	public UISprite DHBOLLDMMEL;

	public UISprite[] GNCFLIGPDDE;

	public GameObject NKGDLICJDBG;

	public void BNLLGAGPJLP(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 240f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(803f / DHBOLLDMMEL.transform.localScale.x, 830f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void ADKHGHFHKCL(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1337f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1547f)
		{
			IOHDBDJKMOM.alpha1 = 1262f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1242f, 760f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 342f);
		}
	}

	public void FAPAFDDKOPK(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 943f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(690f / DHBOLLDMMEL.transform.localScale.x, 140f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void FHPBPIJADGH(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1606f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1130f / DHBOLLDMMEL.transform.localScale.x, 173f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void NIDBPNLMFCH(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1724f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1946f / DHBOLLDMMEL.transform.localScale.x, 1471f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void GDLLEILHNOA(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (543f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1440f)
		{
			IOHDBDJKMOM.alpha1 = 1783f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 557f, 1871f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1778f);
		}
	}

	public void MEBBEGLIJKP(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1901f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 265f)
		{
			IOHDBDJKMOM.alpha1 = 707f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 682f, 1737f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 248f);
		}
	}

	public void JOPHEKLCMLL(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1076f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1626f)
		{
			IOHDBDJKMOM.alpha1 = 1599f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1659f, 1960f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 157f);
		}
	}

	public void InitializeUnit(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 0.2f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(167f / DHBOLLDMMEL.transform.localScale.x, 124f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void BFLPPEBNCLB(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1330f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 891f)
		{
			IOHDBDJKMOM.alpha1 = 1076f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1645f, 1939f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1482f);
		}
	}

	public void JGCDJLAMIBD(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 759f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1873f / DHBOLLDMMEL.transform.localScale.x, 1328f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void FGCCIOBIHCO(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1352f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 213f)
		{
			IOHDBDJKMOM.alpha1 = 131f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1845f, 571f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 317f);
		}
	}

	public void BNABNCCBOGJ(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1136f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 525f)
		{
			IOHDBDJKMOM.alpha1 = 408f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1992f, 49f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1924f);
		}
	}

	public void IBGMKPMOCBK(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1808f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(599f / DHBOLLDMMEL.transform.localScale.x, 1727f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void ADIELMLEOPF(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 464f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1411f / DHBOLLDMMEL.transform.localScale.x, 1670f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void BGPAGMDFJJM(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 808f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1266f / DHBOLLDMMEL.transform.localScale.x, 1466f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void FGGOHCGFNDG(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 795f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(794f / DHBOLLDMMEL.transform.localScale.x, 1458f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void EFEMNIEDDNO(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1290f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1664f)
		{
			IOHDBDJKMOM.alpha1 = 1836f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1513f, 1704f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1635f);
		}
	}

	public void IFAEEJMKNON(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (969f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 475f)
		{
			IOHDBDJKMOM.alpha1 = 490f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 343f, 732f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 560f);
		}
	}

	public void DAONGJCFOAO(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 302f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1139f / DHBOLLDMMEL.transform.localScale.x, 545f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void LNPKCFKLDPJ(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 226f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1629f / DHBOLLDMMEL.transform.localScale.x, 332f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void PDPJEIIDGBP(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1725f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1284f / DHBOLLDMMEL.transform.localScale.x, 379f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void KMIDNNIOKDF(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1469f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(221f / DHBOLLDMMEL.transform.localScale.x, 1747f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void BPCMAPKHFGL(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1873f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 178f)
		{
			IOHDBDJKMOM.alpha1 = 1122f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 2f, 320f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1184f);
		}
	}

	public void LBHMBLDLLDI(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1714f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1393f)
		{
			IOHDBDJKMOM.alpha1 = 106f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1639f, 1107f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 993f);
		}
	}

	public void OOOAHMOBMEN(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1612f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1063f / DHBOLLDMMEL.transform.localScale.x, 1375f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void CHGIDBCNPIG(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 239f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1171f / DHBOLLDMMEL.transform.localScale.x, 214f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void FBOGFPMGFPE(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1476f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1956f)
		{
			IOHDBDJKMOM.alpha1 = 34f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1009f, 391f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 695f);
		}
	}

	public void IDFKLFIFJKA(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1621f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1141f)
		{
			IOHDBDJKMOM.alpha1 = 749f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 963f, 708f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1352f);
		}
	}

	public void MEJBCMJKFMC(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1529f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(833f / DHBOLLDMMEL.transform.localScale.x, 1186f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void COGHEJLANAG(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (154f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 225f)
		{
			IOHDBDJKMOM.alpha1 = 1327f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1710f, 1606f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 669f);
		}
	}

	public void OLHPAODJLOM(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1221f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1191f / DHBOLLDMMEL.transform.localScale.x, 433f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void GHHICIHLMBG(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1340f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(447f / DHBOLLDMMEL.transform.localScale.x, 436f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void MGLFIEGPBBJ(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 509f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(734f / DHBOLLDMMEL.transform.localScale.x, 1427f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void OJFEIBALPHD(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 1644f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 1;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(1678f / DHBOLLDMMEL.transform.localScale.x, 1861f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 0; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void EJHIGPNFHHL(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1768f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 651f)
		{
			IOHDBDJKMOM.alpha1 = 1549f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 784f, 1113f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1631f);
		}
	}

	public void OCAHBKHPBJO(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1656f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1226f)
		{
			IOHDBDJKMOM.alpha1 = 218f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 574f, 965f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 15f);
		}
	}

	public void EJHDMIDBLOI(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (737f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 1347f)
		{
			IOHDBDJKMOM.alpha1 = 601f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 716f, 1544f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1550f);
		}
	}

	public void IKCNECNNALE(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1678f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 156f)
		{
			IOHDBDJKMOM.alpha1 = 1836f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 266f, 1227f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1717f);
		}
	}

	public void OENCAOBNIHP(LevelBehaviour IOIKKIIFOCB, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		KMFGCJEGJJK.color = ((!(IOIKKIIFOCB != null)) ? Colours.grayLog : GameVariables.CNFFEIMLDNP[IOIKKIIFOCB.unitType].Value2);
		KMFGCJEGJJK.alpha = 772f;
		DHBOLLDMMEL.gameObject.SetActive(IOIKKIIFOCB != null);
		if (IOIKKIIFOCB == null)
		{
			PDKIAALFDNG = 0;
		}
		else
		{
			DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			DHBOLLDMMEL.MakePixelPerfect();
			float multiplier = Mathf.Min(934f / DHBOLLDMMEL.transform.localScale.x, 922f / DHBOLLDMMEL.transform.localScale.y);
			DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(multiplier);
		}
		for (int i = 1; i < GNCFLIGPDDE.Length; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
	}

	public void HPCBPKKKGGM(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1507f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 447f)
		{
			IOHDBDJKMOM.alpha1 = 553f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 256f, 1680f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1032f);
		}
	}

	public void AnimationSet(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 0.05f)
		{
			IOHDBDJKMOM.alpha1 = 1f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 0.01f, 1f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 1f);
		}
	}

	public void DABJNFDHHNP(float IMDGMAKJNKP, float HAMKIKMJHDP)
	{
		float num = (1311f - IMDGMAKJNKP) * HAMKIKMJHDP;
		if (num < 253f)
		{
			IOHDBDJKMOM.alpha1 = 176f;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, 1971f, 1065f);
		}
		else
		{
			IOHDBDJKMOM.alpha1 = IMDGMAKJNKP;
			TweenAlpha.Begin(IOHDBDJKMOM.gameObject, num, IMDGMAKJNKP, 534f);
		}
	}
}
