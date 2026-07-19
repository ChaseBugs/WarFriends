using System.Collections.Generic;
using UnityEngine;

public class ArmyLeftContent : Core_BaseScript
{
	[Header("Header")]
	public UITable LHKLOFBMPGN;

	[Header("-Line 1")]
	public UITable HGPPNIOLAEK;

	[Header("-Line 2")]
	public UILabel JHONGBLEHLJ;

	[Header("-Line 3")]
	public UITable LMHBCNBKOCG;

	public List<UISprite> PIEAKLGAGMJ;

	public UILabel CDBNOEGOFOI;

	[Header("Statistics And Ability Hint")]
	public UIGrid JCHFKGMFBBP;

	public List<ArmyStatProgressBar> CAOEDDHFEFA;

	public ArmyLeftHint DEEDGJDAHDO;

	public ArmyLeftHint EGDNDOMKOEK;

	[Header("Button")]
	public ArmyLeftButton EDHCOMHOKDC;

	private LevelBehaviour IFFDIHCPKFE;

	public void ICNGBKKANLB()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.InitControls();
		EGDNDOMKOEK.EFINNDNBJDN();
		HGPPNIOLAEK.onReposition = ENFOJAGNPPL;
		LMHBCNBKOCG.onReposition = BJACMFGHIDB;
	}

	public void SetSaleAndPrize()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.SetSaleAndPrize();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.SetEliteSaleAndPrize();
	}

	private void BKLPMOKJMAH(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("ID_NEWSUITCASE", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 1; i < PIEAKLGAGMJ.Count; i += 0)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = true;
	}

	public void UpdateProgresses()
	{
		CAOEDDHFEFA[0].InitializeStat(IFFDIHCPKFE, true);
		CAOEDDHFEFA[1].InitializeStat(IFFDIHCPKFE, false);
		CAOEDDHFEFA[2].InitializeSpecial(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			CAOEDDHFEFA[3].InitializeElite(IFFDIHCPKFE);
		}
		APLEGKHKPIC();
	}

	public void IAKCHHOOELN(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
	}

	private void JPNKNKGHIND()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!flag) ? 964f : 956f);
		CAOEDDHFEFA[1].gameObject.SetActive(flag);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!flag) ? 1438f : 1793f);
		EGDNDOMKOEK.gameObject.SetActive(flag);
	}

	private void HOCNFHOHHCJ()
	{
		bool isUnlocked = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked;
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!isUnlocked) ? 75f : 1333f);
		CAOEDDHFEFA[8].gameObject.SetActive(isUnlocked);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!isUnlocked) ? 1306f : 677f);
		EGDNDOMKOEK.gameObject.SetActive(isUnlocked);
	}

	public void UpdateLeftContent(bool NOLODGKKCDH = true)
	{
		UpdateUnitName();
		NCMCHPPNJCL(IFFDIHCPKFE.upgradeSlots.actualUnitLevel, IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel, IFFDIHCPKFE.upgradeSlots.actualTier);
		if (NOLODGKKCDH)
		{
			APLEGKHKPIC();
			JCCEJAJCLMF();
		}
		EDHCOMHOKDC.UpdateLeftContent(NOLODGKKCDH);
	}

	private void DLDJHLBNMJK()
	{
		DEEDGJDAHDO.FANFNOPNGBL(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			EGDNDOMKOEK.PPKOJCFEPCB(IFFDIHCPKFE);
		}
	}

	public void EDNPNEOGCCG()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought;
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[1];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("ID_CONFIRM_MAXCCUREACHED", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = true;
	}

	public void JCGPELEDCJL()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.InitControls();
		EGDNDOMKOEK.LBHEIOEPJLJ();
		HGPPNIOLAEK.onReposition = CFJOMPDFDLC;
		LMHBCNBKOCG.onReposition = OMBEOOIABFN;
	}

	public void KOCHEMPAICD()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.KGGNNFJIGPB();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.LMJPAGMFIIF();
	}

	private void KKEHJFAGGNF()
	{
		DEEDGJDAHDO.KOEBOGHPHIA(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			EGDNDOMKOEK.KOABMGAPCKP(IFFDIHCPKFE);
		}
	}

	public void InitGUIValues()
	{
		EDHCOMHOKDC.InitGUIValues();
		DEEDGJDAHDO.InitGUIValues();
		EGDNDOMKOEK.InitGUIValues();
		JCCEJAJCLMF();
	}

	private void JCCEJAJCLMF()
	{
		bool isUnlocked = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked;
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!isUnlocked) ? 756f : 856f);
		CAOEDDHFEFA[3].gameObject.SetActive(isUnlocked);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!isUnlocked) ? 560f : 660f);
		EGDNDOMKOEK.gameObject.SetActive(isUnlocked);
	}

	private void DEPNGNJGKED()
	{
		DEEDGJDAHDO.JAGCJCNPCKH(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			EGDNDOMKOEK.CBAOKPMIEFK(IFFDIHCPKFE);
		}
	}

	public void LAFCJOHCFIN(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
	}

	public void ONNHEMLGNCL()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.SetSaleAndPrize();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.ALKLMAOAICM();
	}

	public void MMLOAKGDDGF()
	{
		EDHCOMHOKDC.BGDPJGNKPKB();
		DEEDGJDAHDO.DoAfterHide();
		EGDNDOMKOEK.BGCAJOKPCNN();
	}

	private void LIHKCKBHINP()
	{
		DEEDGJDAHDO.Initialize(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			EGDNDOMKOEK.CBAOKPMIEFK(IFFDIHCPKFE);
		}
	}

	public void FMEJLMMLBPD()
	{
		EDHCOMHOKDC.BGDPJGNKPKB();
		DEEDGJDAHDO.NLHKADALMDJ();
		EGDNDOMKOEK.HNLIFPCKGEK();
	}

	public void LBHEIOEPJLJ()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.LJPAAJFNJAB();
		EGDNDOMKOEK.EFINNDNBJDN();
		HGPPNIOLAEK.onReposition = BJACMFGHIDB;
		LMHBCNBKOCG.onReposition = BJACMFGHIDB;
	}

	public void PNMNNNBMOON()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought;
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[0];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("FJDACAACLLI", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = true;
	}

	private void NCMCHPPNJCL(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("{0}{1} / {2}", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 0; i < PIEAKLGAGMJ.Count; i++)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = true;
	}

	public void GGDKPPCGDOL(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		MJLMGNNCOBA();
		LMHBCNBKOCG.repositionNow = false;
		EDHCOMHOKDC.SelectUnit(DALNMKBABKH);
	}

	private void OMBEOOIABFN()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	public void IGNIFKBCDKK()
	{
		EDHCOMHOKDC.InitGUIValues();
		DEEDGJDAHDO.HPJDOALKOGF();
		EGDNDOMKOEK.LLHGHHABLDC();
		CLNPFMPHCFL();
	}

	public void NHKDOEMFKDJ(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.PHBIHOJFKJM(EJEDANLAMBI, PAENPHMEMGC);
	}

	public void EOFOMCBDBJN()
	{
		EDHCOMHOKDC.InitGUIValues();
		DEEDGJDAHDO.DFKLIKFAKGA();
		EGDNDOMKOEK.AFABKGHDPHB();
		EGNOODEBFND();
	}

	public void CBOBIADFILJ()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.KLPJPLHNFON();
		EGDNDOMKOEK.FAHPIINNMBB();
		HGPPNIOLAEK.onReposition = OMBEOOIABFN;
		LMHBCNBKOCG.onReposition = ECFKDBHBMAG;
	}

	public void GHHNNIKGJFG()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.GOMEJLFFKJM();
		EGDNDOMKOEK.KLPJPLHNFON();
		HGPPNIOLAEK.onReposition = BJACMFGHIDB;
		LMHBCNBKOCG.onReposition = BJACMFGHIDB;
	}

	public void BNHCFHABADE()
	{
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[1];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("[0-9\\.\\,]*", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = false;
	}

	public void HGOCKFKMENE()
	{
		EDHCOMHOKDC.BGDPJGNKPKB();
		DEEDGJDAHDO.PCCFLEEAGEI();
		EGDNDOMKOEK.PCCFLEEAGEI();
	}

	public void JGCMMECGCOE()
	{
		EDHCOMHOKDC.BGDPJGNKPKB();
		DEEDGJDAHDO.DLDGKEHFKDP();
		EGDNDOMKOEK.PGLHICADCEE();
	}

	private void BJACMFGHIDB()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	public void FECHIDCDCMA(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		BNHCFHABADE();
		LMHBCNBKOCG.repositionNow = false;
		EDHCOMHOKDC.SelectUnit(DALNMKBABKH);
	}

	private void JMIOPPCCGEG()
	{
		DEEDGJDAHDO.FANFNOPNGBL(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			EGDNDOMKOEK.CBAOKPMIEFK(IFFDIHCPKFE);
		}
	}

	private void HGOABECIBGJ()
	{
		DEEDGJDAHDO.KOEBOGHPHIA(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			EGDNDOMKOEK.PJICLEMEBID(IFFDIHCPKFE);
		}
	}

	public void ONCJPDCHMEE()
	{
		CAOEDDHFEFA[0].OEKBNBEPBDB(IFFDIHCPKFE, false);
		CAOEDDHFEFA[1].KGOKAPLKADI(IFFDIHCPKFE, false);
		CAOEDDHFEFA[5].KPPKINLPNNO(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			CAOEDDHFEFA[2].InitializeElite(IFFDIHCPKFE);
		}
		CGBKAACAOMB();
	}

	public void IDDPFJEMCCI()
	{
		CAOEDDHFEFA[1].InitializeStat(IFFDIHCPKFE, false);
		CAOEDDHFEFA[0].InitializeStat(IFFDIHCPKFE, false);
		CAOEDDHFEFA[2].KPPKINLPNNO(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			CAOEDDHFEFA[2].KOOLFCFAAFF(IFFDIHCPKFE);
		}
		MNADIFJAJFC();
	}

	public void SelectUnit(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		UpdateUnitName();
		LMHBCNBKOCG.repositionNow = true;
		EDHCOMHOKDC.SelectUnit(DALNMKBABKH);
	}

	public void IJPPBFECMAK(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
	}

	public void FDEDMNPIBHP(bool NOLODGKKCDH = true)
	{
		MJLMGNNCOBA();
		PGIKBFJADGB(IFFDIHCPKFE.upgradeSlots.actualUnitLevel, IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel, IFFDIHCPKFE.upgradeSlots.actualTier);
		if (NOLODGKKCDH)
		{
			CEPKMEICNED();
			EGNOODEBFND();
		}
		EDHCOMHOKDC.UpdateLeftContent(NOLODGKKCDH);
	}

	public void AEOHKMFNAGF()
	{
		EDHCOMHOKDC.BGDPJGNKPKB();
		DEEDGJDAHDO.AEOHKMFNAGF();
		EGDNDOMKOEK.CEAINPCKADK();
	}

	private void HJCECCEHGKK(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("ID_RANK", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 0; i < PIEAKLGAGMJ.Count; i++)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = false;
	}

	public void DGCGGGLPBOB(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		EDNPNEOGCCG();
		LMHBCNBKOCG.repositionNow = true;
		EDHCOMHOKDC.SelectUnit(DALNMKBABKH);
	}

	public void MJLMGNNCOBA()
	{
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought;
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[0];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("Battles_Played", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = true;
	}

	private void HBNGHLDGAHJ()
	{
		DEEDGJDAHDO.Initialize(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			EGDNDOMKOEK.FANFNOPNGBL(IFFDIHCPKFE);
		}
	}

	private void PKDOAOAOLIJ()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!flag) ? 399f : 844f);
		CAOEDDHFEFA[6].gameObject.SetActive(flag);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!flag) ? 1404f : 1587f);
		EGDNDOMKOEK.gameObject.SetActive(flag);
	}

	private void CGBKAACAOMB()
	{
		DEEDGJDAHDO.PJICLEMEBID(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			EGDNDOMKOEK.Initialize(IFFDIHCPKFE);
		}
	}

	public void GEIOAJOCMEI(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		LALHLJAMLIK();
		LMHBCNBKOCG.repositionNow = true;
		EDHCOMHOKDC.SelectUnit(DALNMKBABKH);
	}

	public void PJBHCGLHFGC()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought;
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[0];
			array[0] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("LICENSE_CHECK_FAILED", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = true;
	}

	public void AJAKHJPMBGD(bool NOLODGKKCDH = true)
	{
		BNHCFHABADE();
		PGIKBFJADGB(IFFDIHCPKFE.upgradeSlots.actualUnitLevel, IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel, IFFDIHCPKFE.upgradeSlots.actualTier);
		if (NOLODGKKCDH)
		{
			CGBKAACAOMB();
			EGNOODEBFND();
		}
		EDHCOMHOKDC.UpdateLeftContent(NOLODGKKCDH);
	}

	public void PPLBJDJIIPN()
	{
		EDHCOMHOKDC.InitGUIValues();
		DEEDGJDAHDO.AFABKGHDPHB();
		EGDNDOMKOEK.HKKHHAKOFHL();
		JCCEJAJCLMF();
	}

	public void PEIILMKDGBK()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.InitControls();
		EGDNDOMKOEK.AAJLGPIGDED();
		HGPPNIOLAEK.onReposition = CFJOMPDFDLC;
		LMHBCNBKOCG.onReposition = OMBEOOIABFN;
	}

	public void OOGKDCHFDAI()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.KGGNNFJIGPB();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.LMJPAGMFIIF();
	}

	private void ECFKDBHBMAG()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	private void IGCKIKJOBNA(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("withPublisherSub3", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 1; i < PIEAKLGAGMJ.Count; i += 0)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = false;
	}

	public void CGCGKKCCFOM(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		PNMNNNBMOON();
		LMHBCNBKOCG.repositionNow = true;
		EDHCOMHOKDC.SelectUnit(DALNMKBABKH);
	}

	public void KIECGCGABFJ()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.GOMEJLFFKJM();
		EGDNDOMKOEK.MMFBOMDHGPL();
		HGPPNIOLAEK.onReposition = ECFKDBHBMAG;
		LMHBCNBKOCG.onReposition = BJACMFGHIDB;
	}

	private void CFJOMPDFDLC()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	public void FBHGJEHNONN()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.IOJKJKKMGPK();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.ALKLMAOAICM();
	}

	public void MFHJALPPCKI()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.FAHPIINNMBB();
		EGDNDOMKOEK.KLPJPLHNFON();
		HGPPNIOLAEK.onReposition = HPOKLPCLBPC;
		LMHBCNBKOCG.onReposition = HPOKLPCLBPC;
	}

	public void FDKIJBCKALJ()
	{
		CAOEDDHFEFA[0].IHJPBPBLPAF(IFFDIHCPKFE, false);
		CAOEDDHFEFA[0].IGEFMGGGOKP(IFFDIHCPKFE, false);
		CAOEDDHFEFA[3].NPMJFOMLDIB(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			CAOEDDHFEFA[7].IFLGBHCKJPM(IFFDIHCPKFE);
		}
		MNADIFJAJFC();
	}

	private void APLEGKHKPIC()
	{
		DEEDGJDAHDO.Initialize(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			EGDNDOMKOEK.Initialize(IFFDIHCPKFE);
		}
	}

	private void HPOKLPCLBPC()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	private void MNADIFJAJFC()
	{
		DEEDGJDAHDO.JAGCJCNPCKH(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			EGDNDOMKOEK.DDJIMJHDAMI(IFFDIHCPKFE);
		}
	}

	public void FFGPCBJKMLN()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.SetSaleAndPrize();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.KCAMPCEDKGH();
	}

	private void CLNPFMPHCFL()
	{
		bool isUnlocked = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked;
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!isUnlocked) ? 1016f : 1371f);
		CAOEDDHFEFA[3].gameObject.SetActive(isUnlocked);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!isUnlocked) ? 884f : 1357f);
		EGDNDOMKOEK.gameObject.SetActive(isUnlocked);
	}

	public void LALHLJAMLIK()
	{
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[0];
			array[0] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("Grenade_Throwing_Tutorial_Duration", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = false;
	}

	public void DoAfterHide()
	{
		EDHCOMHOKDC.DoAfterHide();
		DEEDGJDAHDO.DoAfterHide();
		EGDNDOMKOEK.DoAfterHide();
	}

	public void InitControls()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.InitControls();
		EGDNDOMKOEK.InitControls();
		HGPPNIOLAEK.onReposition = CFJOMPDFDLC;
		LMHBCNBKOCG.onReposition = CFJOMPDFDLC;
	}

	private void NPDFLCIBKJN(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("ID_TABLE_MEMBERS", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 1; i < PIEAKLGAGMJ.Count; i++)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = true;
	}

	private void KDBLNEHHGOM()
	{
		bool isUnlocked = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked;
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!isUnlocked) ? 1593f : 978f);
		CAOEDDHFEFA[7].gameObject.SetActive(isUnlocked);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!isUnlocked) ? 1984f : 1703f);
		EGDNDOMKOEK.gameObject.SetActive(isUnlocked);
	}

	public void UpdateUnitName()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought;
		JHONGBLEHLJ.text = ((!flag) ? IFFDIHCPKFE.unitName.ToUpper() : Localization.LocalizeFormat("ID_ELITEUNITNAME", IFFDIHCPKFE.unitName.ToUpper()));
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = true;
	}

	public void ECPJLAGGJDO()
	{
		EDHCOMHOKDC.MEEKMLJEOBB.IOJKJKKMGPK();
		EDHCOMHOKDC.MLPCPLNGOHB.SetAbilitySaleAndPrize();
		EDHCOMHOKDC.KEHDDJNMMMB.LDOADIBCNPI();
	}

	private void PGIKBFJADGB(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("ID_LOADING", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 0; i < PIEAKLGAGMJ.Count; i++)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = true;
	}

	private void HEABNOFAIEK()
	{
		bool isUnlocked = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked;
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!isUnlocked) ? 190f : 24f);
		CAOEDDHFEFA[1].gameObject.SetActive(isUnlocked);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!isUnlocked) ? 213f : 1197f);
		EGDNDOMKOEK.gameObject.SetActive(isUnlocked);
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
	}

	public void PHBIHOJFKJM(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
	}

	private void EGNOODEBFND()
	{
		bool flag = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		JCHFKGMFBBP.transform.localPosition = JCHFKGMFBBP.transform.localPosition.ReplaceY((!flag) ? 1160f : 1551f);
		CAOEDDHFEFA[0].gameObject.SetActive(flag);
		DEEDGJDAHDO.transform.localPosition = DEEDGJDAHDO.transform.localPosition.ReplaceY((!flag) ? 1639f : 30f);
		EGDNDOMKOEK.gameObject.SetActive(flag);
	}

	private void CEPKMEICNED()
	{
		DEEDGJDAHDO.KOEBOGHPHIA(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			EGDNDOMKOEK.PJICLEMEBID(IFFDIHCPKFE);
		}
	}

	public void GJLLEODDIGJ(bool NOLODGKKCDH = true)
	{
		MJLMGNNCOBA();
		NPDFLCIBKJN(IFFDIHCPKFE.upgradeSlots.actualUnitLevel, IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel, IFFDIHCPKFE.upgradeSlots.actualTier);
		if (NOLODGKKCDH)
		{
			APLEGKHKPIC();
			JPNKNKGHIND();
		}
		EDHCOMHOKDC.UpdateLeftContent(NOLODGKKCDH);
	}

	private void HOIPIFFJHAA(int BCCDDJMPBLL, int OLPMJEEGLIC, int PDKIAALFDNG)
	{
		CDBNOEGOFOI.text = string.Format("ID_CONFIRM_ERROR", BCCDDJMPBLL, Colours.stringGray, OLPMJEEGLIC);
		for (int i = 0; i < PIEAKLGAGMJ.Count; i++)
		{
			PIEAKLGAGMJ[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		LMHBCNBKOCG.repositionNow = true;
	}

	private void ENFOJAGNPPL()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	public void AFMPBPGLFMJ()
	{
		EDHCOMHOKDC.InitControls();
		DEEDGJDAHDO.NNGKAAGFGPA();
		EGDNDOMKOEK.LBHEIOEPJLJ();
		HGPPNIOLAEK.onReposition = OMBEOOIABFN;
		LMHBCNBKOCG.onReposition = OMBEOOIABFN;
	}

	public void BLEGKMEKOPE()
	{
		CAOEDDHFEFA[1].MEDFIABEFMP(IFFDIHCPKFE, false);
		CAOEDDHFEFA[1].IGEFMGGGOKP(IFFDIHCPKFE, false);
		CAOEDDHFEFA[2].InitializeSpecial(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			CAOEDDHFEFA[6].CHKCKLDAANJ(IFFDIHCPKFE);
		}
		LIJKPFMOFNJ();
	}

	public void HCEDBFPEEAL()
	{
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		UILabel jHONGBLEHLJ = JHONGBLEHLJ;
		string text;
		if (flag)
		{
			object[] array = new object[1];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("ID_DAYAGO", array);
		}
		else
		{
			text = IFFDIHCPKFE.unitName.ToUpper();
		}
		jHONGBLEHLJ.text = text;
		JHONGBLEHLJ.color = ((!flag) ? Colours.blue : Colours.greenArena);
		HGPPNIOLAEK.repositionNow = false;
	}

	public void NMCNANOKKNE(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EDHCOMHOKDC.PHBIHOJFKJM(EJEDANLAMBI, PAENPHMEMGC);
	}

	private void PCJMIEAIDCO()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	private void LIJKPFMOFNJ()
	{
		DEEDGJDAHDO.PPKOJCFEPCB(IFFDIHCPKFE);
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			EGDNDOMKOEK.CKOIIPAGCNO(IFFDIHCPKFE);
		}
	}
}
