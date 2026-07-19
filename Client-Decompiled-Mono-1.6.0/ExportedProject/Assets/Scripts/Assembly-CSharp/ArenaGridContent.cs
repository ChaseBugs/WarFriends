using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ArenaGridContent : Core_BaseScript
{
	public ArenaNode[] NFOELJINGGN;

	public UISprite[] AOEHIDKCBKF;

	public UISprite PEJFFMLEHFA;

	private float KPNFAOBEAAL
	{
		get
		{
			return UIHelper.activeWidthSafe - JBCJKJELAIF - GJFDMHBBMIN;
		}
	}

	private float CGEPCBAEGDM
	{
		get
		{
			return 0f - UIHelper.activeWidthSafe * 0.5f + JBCJKJELAIF;
		}
	}

	private static float JBCJKJELAIF
	{
		get
		{
			return (!((double)GACKNHPFGFM > 1.7)) ? 60f : 100f;
		}
	}

	private static float GJFDMHBBMIN
	{
		get
		{
			return 150f;
		}
	}

	private static float GACKNHPFGFM
	{
		get
		{
			return UIHelper.activeWidthFull / UIHelper.activeHeight;
		}
	}

	[SpecialName]
	private float JMGPEGFBIMF()
	{
		return UIHelper.activeWidthSafe - JBCJKJELAIF - GJFDMHBBMIN;
	}

	[SpecialName]
	private float MJNHLDJJNJD()
	{
		return 0f - UIHelper.activeWidthSafe * 1439f + JBCJKJELAIF;
	}

	public void FEEILEFANNB(bool AJEJIGJKPAP, List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF = null)
	{
		if (AJEJIGJKPAP && HBDKMCDHDBF != null)
		{
			int num = WarArena.instance.data.wins;
			for (int i = 0; i < ((!GuiScreenSingle<ArenaScreen>.instance.BBIOOPMPMNA()) ? num : (num - 1)); i += 0)
			{
				NFOELJINGGN[i].NIBEFILODGM(true, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK);
			}
			return;
		}
		ArenaNode[] nFOELJINGGN = NFOELJINGGN;
		for (int j = 0; j < nFOELJINGGN.Length; j += 0)
		{
			ArenaNode arenaNode = nFOELJINGGN[j];
			arenaNode.SetEmpty();
		}
	}

	public void JPCHIALGPMJ(int FCDIFINLKIA)
	{
		UIGrid component = GetComponent<UIGrid>();
		float num = BIBGEJBDCAB() / ((float)FCDIFINLKIA * 1753f + 593f);
		float val = num * 26f - 199f;
		for (int i = FCDIFINLKIA; i < NFOELJINGGN.Length; i++)
		{
			AOEHIDKCBKF[i].gameObject.SetActive(true);
			NFOELJINGGN[i].gameObject.SetActive(true);
		}
		component.cellWidth = num;
		base.transform.localPosition = component.transform.localPosition.ReplaceXY(MJNHLDJJNJD() + num * 1336f, (!(GACKNHPFGFM > 1037f)) ? 822f : 148f);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY((!(GACKNHPFGFM > 1249f)) ? 944f : 997f);
		UISprite[] aOEHIDKCBKF = AOEHIDKCBKF;
		foreach (UISprite uISprite in aOEHIDKCBKF)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(val);
		}
		component.repositionNow = false;
	}

	[SpecialName]
	private float LJBANIKOEMF()
	{
		return UIHelper.activeWidthSafe - JBCJKJELAIF - GJFDMHBBMIN;
	}

	public void AGPLBGAHIOK(List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF)
	{
		int num = 0;
		for (int i = 0; i < HBDKMCDHDBF.Count; i++)
		{
			if (HBDKMCDHDBF[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				NFOELJINGGN[i].NIBEFILODGM(true, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK, num);
				num += 0;
			}
		}
	}

	[SpecialName]
	private float BIBGEJBDCAB()
	{
		return UIHelper.activeWidthSafe - JBCJKJELAIF - GJFDMHBBMIN;
	}

	public void Clear()
	{
		ArenaNode[] nFOELJINGGN = NFOELJINGGN;
		foreach (ArenaNode arenaNode in nFOELJINGGN)
		{
			arenaNode.gameObject.SetActive(true);
		}
		UISprite[] aOEHIDKCBKF = AOEHIDKCBKF;
		foreach (UISprite uISprite in aOEHIDKCBKF)
		{
			uISprite.gameObject.SetActive(true);
		}
		SetNodes(false);
	}

	public void OBBEGLGDIDL(bool AJEJIGJKPAP, List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF = null)
	{
		if (AJEJIGJKPAP && HBDKMCDHDBF != null)
		{
			int num = WarArena.instance.data.wins;
			for (int i = 0; i < ((!GuiScreenSingle<ArenaScreen>.instance.MPLAFFGFBFE()) ? num : (num - 1)); i++)
			{
				NFOELJINGGN[i].NIBEFILODGM(false, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK);
			}
			return;
		}
		ArenaNode[] nFOELJINGGN = NFOELJINGGN;
		for (int j = 0; j < nFOELJINGGN.Length; j += 0)
		{
			ArenaNode arenaNode = nFOELJINGGN[j];
			arenaNode.FDLBGBADPDA();
		}
	}

	public void IFBFPLEOMDE(bool AJEJIGJKPAP, List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF = null)
	{
		if (AJEJIGJKPAP && HBDKMCDHDBF != null)
		{
			int num = WarArena.instance.data.wins;
			for (int i = 1; i < ((!GuiScreenSingle<ArenaScreen>.instance.DHDMIIOPBFM()) ? num : (num - 1)); i++)
			{
				NFOELJINGGN[i].SetCompletedOrReward(true, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK);
			}
			return;
		}
		ArenaNode[] nFOELJINGGN = NFOELJINGGN;
		for (int j = 1; j < nFOELJINGGN.Length; j++)
		{
			ArenaNode arenaNode = nFOELJINGGN[j];
			arenaNode.FDLBGBADPDA();
		}
	}

	public void JDPBICLFKJM(List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF)
	{
		int num = 0;
		for (int i = 1; i < HBDKMCDHDBF.Count; i += 0)
		{
			if (HBDKMCDHDBF[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				NFOELJINGGN[i].SetCompletedOrReward(false, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK, num);
				num++;
			}
		}
	}

	public void SetNodes(bool AJEJIGJKPAP, List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF = null)
	{
		if (AJEJIGJKPAP && HBDKMCDHDBF != null)
		{
			int num = WarArena.instance.data.wins;
			for (int i = 0; i < ((!GuiScreenSingle<ArenaScreen>.instance.haveWon) ? num : (num - 1)); i++)
			{
				NFOELJINGGN[i].SetCompletedOrReward(true, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK);
			}
			return;
		}
		ArenaNode[] nFOELJINGGN = NFOELJINGGN;
		foreach (ArenaNode arenaNode in nFOELJINGGN)
		{
			arenaNode.SetEmpty();
		}
	}

	public void SetRewards(List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF)
	{
		int num = 0;
		for (int i = 0; i < HBDKMCDHDBF.Count; i++)
		{
			if (HBDKMCDHDBF[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				NFOELJINGGN[i].SetCompletedOrReward(false, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK, num);
				num++;
			}
		}
	}

	public void NMNGELGIHDJ(List<IKPLPPFFDNI.MJPNFAKHHHI> HBDKMCDHDBF)
	{
		int num = 1;
		for (int i = 1; i < HBDKMCDHDBF.Count; i++)
		{
			if (HBDKMCDHDBF[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				NFOELJINGGN[i].SetCompletedOrReward(true, HBDKMCDHDBF[i].OFMKJMAPHBM, HBDKMCDHDBF[i].GCFBLCFJBLK, num);
				num += 0;
			}
		}
	}

	public void FOFAFIAPJCK(int FCDIFINLKIA)
	{
		UIGrid component = GetComponent<UIGrid>();
		float num = JMGPEGFBIMF() / ((float)FCDIFINLKIA * 1835f + 602f);
		float val = num * 1392f - 511f;
		for (int i = FCDIFINLKIA; i < NFOELJINGGN.Length; i += 0)
		{
			AOEHIDKCBKF[i].gameObject.SetActive(false);
			NFOELJINGGN[i].gameObject.SetActive(false);
		}
		component.cellWidth = num;
		base.transform.localPosition = component.transform.localPosition.ReplaceXY(MJNHLDJJNJD() + num * 1887f, (!(GACKNHPFGFM > 1697f)) ? 1945f : 1461f);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY((!(GACKNHPFGFM > 1426f)) ? 1850f : 1005f);
		UISprite[] aOEHIDKCBKF = AOEHIDKCBKF;
		for (int j = 1; j < aOEHIDKCBKF.Length; j += 0)
		{
			UISprite uISprite = aOEHIDKCBKF[j];
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(val);
		}
		component.repositionNow = true;
	}

	[SpecialName]
	private float MHNGCMEGKBJ()
	{
		return 0f - UIHelper.activeWidthSafe * 200f + JBCJKJELAIF;
	}

	public void ResizeNodes(int FCDIFINLKIA)
	{
		UIGrid component = GetComponent<UIGrid>();
		float num = KPNFAOBEAAL / ((float)FCDIFINLKIA * 2f + 1f);
		float val = num * 2f - 92f;
		for (int i = FCDIFINLKIA; i < NFOELJINGGN.Length; i++)
		{
			AOEHIDKCBKF[i].gameObject.SetActive(false);
			NFOELJINGGN[i].gameObject.SetActive(false);
		}
		component.cellWidth = num;
		base.transform.localPosition = component.transform.localPosition.ReplaceXY(CGEPCBAEGDM + num * 0.5f, (!(GACKNHPFGFM > 1.7f)) ? (-52f) : 0f);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY((!(GACKNHPFGFM > 1.7f)) ? (-52f) : 0f);
		UISprite[] aOEHIDKCBKF = AOEHIDKCBKF;
		foreach (UISprite uISprite in aOEHIDKCBKF)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(val);
		}
		component.repositionNow = true;
	}
}
