using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CompareUnitsRecord : MonoBehaviour
{
	[FormerlySerializedAs("EKCHKFIAJDJ")]
	[Header("My Unit")]
	public UISprite FCIKGOKDONK;

	[FormerlySerializedAs("CEADKGCKFNN")]
	public UISprite GNLNDFAPPNK;

	[FormerlySerializedAs("JLBEPNOKPFO")]
	public UISprite MPILKGHIAMN;

	[FormerlySerializedAs("AHJLEMIKAKD")]
	public UILabel MNJMDHCCCHM;

	[FormerlySerializedAs("KCJODANBPHD")]
	public List<UISprite> GNCMKEKNEAB;

	[FormerlySerializedAs("APGEIFBJOCE")]
	public UILabel FBKOBEJIDMO;

	[FormerlySerializedAs("JKPOKDEPINO")]
	public UISprite ALEOJJLNFIL;

	[FormerlySerializedAs("HMFLJHOFOIG")]
	public UISprite MNLBGFHMAJO;

	[FormerlySerializedAs("AEMMCFANIGA")]
	public UILabel OCCBECIDFOO;

	[FormerlySerializedAs("ILDDECOENLL")]
	public UISprite OKAOIIGDIPA;

	[FormerlySerializedAs("IKKEOLMOOMC")]
	public UISprite KBNEGOFCOHM;

	[Header("Middle")]
	[FormerlySerializedAs("mMyUnitSuperCharged")]
	public GameObject AAFMIDFBMGL;

	[FormerlySerializedAs("mLeftNALabel")]
	public UILabel FCELBAOPKJJ;

	[FormerlySerializedAs("MNNKKKFBJOB")]
	public UISprite BFGKFGFJIKJ;

	[FormerlySerializedAs("KKCMFBOLCME")]
	public UILabel DONJPBPMDNB;

	[FormerlySerializedAs("OHDDDBBLOGG")]
	public UISprite IMOHHDEDEKJ;

	[FormerlySerializedAs("IDIFAEGGBFA")]
	public UISprite PAENPHMEMGC;

	[FormerlySerializedAs("BFPGIBPFJKE")]
	public UILabel DGBCKLOMOHJ;

	[FormerlySerializedAs("DCMKLDKNJAJ")]
	public UISprite CGGNOPPBMAB;

	[FormerlySerializedAs("CDKGOPIBHDH")]
	public UILabel OKNPBJFNMIL;

	[Header("Opponent Unit")]
	[FormerlySerializedAs("DIJLCEJAKJG")]
	public GameObject DAGLPBAJHDG;

	[FormerlySerializedAs("FPCNIGCELPA")]
	public UISprite FOCDJJJBOME;

	[FormerlySerializedAs("HCIPKCBBIDG")]
	public UISprite JFGPHHCCLLM;

	[FormerlySerializedAs("KCIONIJPPOG")]
	public UISprite FENPECHJKIH;

	[FormerlySerializedAs("LHOLPNHMGLE")]
	public UILabel FGGKODNMLFP;

	[FormerlySerializedAs("CEBNOGKMMJK")]
	public List<UISprite> CMKCCLIGEGL;

	[FormerlySerializedAs("MHNKBJDFNLO")]
	public UILabel CMFODKDFJNA;

	[FormerlySerializedAs("EKGGABKFAKB")]
	public UISprite CPBNCIJMGPH;

	[FormerlySerializedAs("INMIAHGDLHC")]
	public UISprite HLHCHBFCOKE;

	[FormerlySerializedAs("EAIJGGIBDDG")]
	public UILabel KNAHJOIPHBK;

	[FormerlySerializedAs("DHEOCNAIDAG")]
	public UISprite CJDFNJACJJE;

	[FormerlySerializedAs("OLPNKHGKIKJ")]
	public UISprite NBAKNJKGPGM;

	private void HLILIDEAFNC(LevelBehaviour IOIKKIIFOCB, UnitUpgradeDefinition LGECBDJBLPG, int KKMINPNDBEE, UISprite NACGOGCPIAH, UISprite GDHBBLOPLIP, UILabel NEKIBLFNDJJ, UILabel JFNKIAMPICC, UILabel KCBFDBEGNHF, UILabel GGFDJCHEDGM, List<UISprite> HBOIEACNBHM, UISprite HBMLFIJGBJO, UISprite EAOIENMNEKK, UILabel DHNJGJKDNLK, UISprite FENJGKKCMOE, UISprite CHIGEDHJHOC, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			GAMAPJALCKH(NACGOGCPIAH, IOIKKIIFOCB);
			PDNPECJIGAB(0, HBOIEACNBHM);
			NEKIBLFNDJJ.gameObject.SetActive(value: false);
			KCBFDBEGNHF.gameObject.SetActive(value: false);
			JFNKIAMPICC.text = string.Empty;
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: false);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: false);
			EAOIENMNEKK.gameObject.SetActive(value: false);
			FENJGKKCMOE.gameObject.SetActive(value: false);
			CHIGEDHJHOC.gameObject.SetActive(value: false);
			return;
		}
		NEKIBLFNDJJ.gameObject.SetActive(IOIKKIIFOCB != null);
		KCBFDBEGNHF.gameObject.SetActive(IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.unlockLevel.displayNumber > KKMINPNDBEE);
		if (IOIKKIIFOCB != null)
		{
			UpgradeSlots.UnitUpgrades unitUpgrades = LGECBDJBLPG.unitUpgrades;
			bool isSpecial = unitUpgrades.isSpecial;
			bool isElite = unitUpgrades.isElite;
			int armyPowerX = IOIKKIIFOCB.upgradeSlots.GetArmyPowerX10(unitUpgrades.slotUpgradeindex, unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier, unitUpgrades.slotUpgradeIndexElite, isElite);
			int fFHHEHHFOKJ = IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.LFNLPNEONEI(unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier);
			int fFHHEHHFOKJ2 = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.LFNLPNEONEI(unitUpgrades.slotUpgradeIndexElite, isElite);
			int actualLevelForIndex = IOIKKIIFOCB.upgradeSlots.GetActualLevelForIndex(LGECBDJBLPG.unitUpgrades.slotUpgradeindex);
			FCLADBGKCIA fCLADBGKCIA = Singleton<GameController>.instance.mainController.CheckForPerks(IOIKKIIFOCB, CIOPAKLHFIL);
			int num = fCLADBGKCIA.FBCGLCJKLPL(PDNPBLFEPJG.Buff);
			int num2 = fCLADBGKCIA.FBCGLCJKLPL(PDNPBLFEPJG.Debuff);
			GAMAPJALCKH(NACGOGCPIAH, IOIKKIIFOCB);
			PDNPECJIGAB(LGECBDJBLPG.tier, HBOIEACNBHM);
			NEKIBLFNDJJ.text = ((actualLevelForIndex <= 0) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(actualLevelForIndex));
			JFNKIAMPICC.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
			GGFDJCHEDGM.text = ((!isSpecial) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
			GDHBBLOPLIP.gameObject.SetActive(isSpecial);
			if (isSpecial)
			{
				GDHBBLOPLIP.spriteName = IOIKKIIFOCB.abilityIcon;
			}
			DHNJGJKDNLK.text = ((!isElite) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2));
			HBMLFIJGBJO.gameObject.SetActive(isElite);
			EAOIENMNEKK.gameObject.SetActive(isElite);
			if (isElite)
			{
				IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK);
			}
			FENJGKKCMOE.gameObject.SetActive(num > 0 || num2 > 0);
			CHIGEDHJHOC.gameObject.SetActive(num > 0 && num2 > 0);
			if (FENJGKKCMOE.gameObject.activeSelf)
			{
				FENJGKKCMOE.spriteName = ((num <= 0) ? ("game-elite-debuff" + num2) : ("game-elite-buff" + num));
				FENJGKKCMOE.MakePixelPerfect();
			}
			if (CHIGEDHJHOC.gameObject.activeSelf)
			{
				CHIGEDHJHOC.spriteName = "game-elite-debuff" + num2;
				CHIGEDHJHOC.MakePixelPerfect();
			}
		}
		else
		{
			GAMAPJALCKH(NACGOGCPIAH, null);
			PDNPECJIGAB(0, HBOIEACNBHM);
			JFNKIAMPICC.text = Localization.Localize("ID_NA");
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: false);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: false);
			EAOIENMNEKK.gameObject.SetActive(value: false);
			FENJGKKCMOE.gameObject.SetActive(value: false);
			CHIGEDHJHOC.gameObject.SetActive(value: false);
		}
	}

	private void LOKMMFEKLOD(LevelBehaviour KPCMLHJMPHM, LevelBehaviour FBCLJFNNJGG)
	{
		LevelBehaviour.UnitType key = ((!(KPCMLHJMPHM != null)) ? FBCLJFNNJGG.unitType : KPCMLHJMPHM.unitType);
		GNLNDFAPPNK.spriteName = GameVariables.CNFFEIMLDNP[key].Value1;
		JFGPHHCCLLM.spriteName = GameVariables.CNFFEIMLDNP[key].Value1;
		MPILKGHIAMN.color = GameVariables.CNFFEIMLDNP[key].Value2;
		FENPECHJKIH.color = GameVariables.CNFFEIMLDNP[key].Value2;
	}

	private void BNLLGAGPJLP(LevelBehaviour IOIKKIIFOCB, UnitUpgradeDefinition LGECBDJBLPG, int KKMINPNDBEE, UISprite NACGOGCPIAH, UISprite GDHBBLOPLIP, UILabel NEKIBLFNDJJ, UILabel JFNKIAMPICC, UILabel KCBFDBEGNHF, UILabel GGFDJCHEDGM, List<UISprite> HBOIEACNBHM, UISprite HBMLFIJGBJO, UISprite EAOIENMNEKK, UILabel DHNJGJKDNLK, UISprite FENJGKKCMOE, UISprite CHIGEDHJHOC, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			GAMAPJALCKH(NACGOGCPIAH, IOIKKIIFOCB);
			PDNPECJIGAB(0, HBOIEACNBHM);
			NEKIBLFNDJJ.gameObject.SetActive(value: false);
			KCBFDBEGNHF.gameObject.SetActive(value: false);
			JFNKIAMPICC.text = string.Empty;
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: true);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: false);
			EAOIENMNEKK.gameObject.SetActive(value: false);
			FENJGKKCMOE.gameObject.SetActive(value: false);
			CHIGEDHJHOC.gameObject.SetActive(value: true);
			return;
		}
		NEKIBLFNDJJ.gameObject.SetActive(IOIKKIIFOCB != null);
		KCBFDBEGNHF.gameObject.SetActive(!(IOIKKIIFOCB != null) || IOIKKIIFOCB.upgradeSlots.unlockLevel.NPOEMAMPNEP() > KKMINPNDBEE);
		if (IOIKKIIFOCB != null)
		{
			UpgradeSlots.UnitUpgrades unitUpgrades = LGECBDJBLPG.unitUpgrades;
			bool isSpecial = unitUpgrades.isSpecial;
			bool isElite = unitUpgrades.isElite;
			int armyPowerX = IOIKKIIFOCB.upgradeSlots.GetArmyPowerX10(unitUpgrades.slotUpgradeindex, unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier, unitUpgrades.slotUpgradeIndexElite, isElite);
			int fFHHEHHFOKJ = IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.OCLKEELOCFH(unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier);
			int fFHHEHHFOKJ2 = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.KJKKGONJMOM(unitUpgrades.slotUpgradeIndexElite, isElite);
			int actualLevelForIndex = IOIKKIIFOCB.upgradeSlots.GetActualLevelForIndex(LGECBDJBLPG.unitUpgrades.slotUpgradeindex);
			FCLADBGKCIA fCLADBGKCIA = Singleton<GameController>.instance.mainController.CheckForPerks(IOIKKIIFOCB, CIOPAKLHFIL);
			int num = fCLADBGKCIA.FBCGLCJKLPL(PDNPBLFEPJG.Buff);
			int num2 = fCLADBGKCIA.HHPIBBLOLJO(PDNPBLFEPJG.Buff);
			BCNPPHPGIHO(NACGOGCPIAH, IOIKKIIFOCB);
			GAEEHFPFADO(LGECBDJBLPG.tier, HBOIEACNBHM);
			NEKIBLFNDJJ.text = ((actualLevelForIndex <= 1) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(actualLevelForIndex));
			JFNKIAMPICC.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
			GGFDJCHEDGM.text = ((!isSpecial) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
			GDHBBLOPLIP.gameObject.SetActive(isSpecial);
			if (isSpecial)
			{
				GDHBBLOPLIP.spriteName = IOIKKIIFOCB.abilityIcon;
			}
			DHNJGJKDNLK.text = ((!isElite) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2));
			HBMLFIJGBJO.gameObject.SetActive(isElite);
			EAOIENMNEKK.gameObject.SetActive(isElite);
			if (isElite)
			{
				IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 1222f);
			}
			FENJGKKCMOE.gameObject.SetActive(num <= 1 && num2 > 0);
			CHIGEDHJHOC.gameObject.SetActive(num > 0 && num2 > 1);
			if (FENJGKKCMOE.gameObject.activeSelf)
			{
				FENJGKKCMOE.spriteName = ((num <= 0) ? ("ID_NOTINLEAGUEMOREMATCHESTEXTANDHINT" + num2) : ("Not used sprites ({0}/{1}) in atlas \"{2}\" :\n{3}" + num));
				FENJGKKCMOE.MakePixelPerfect();
			}
			if (CHIGEDHJHOC.gameObject.activeSelf)
			{
				CHIGEDHJHOC.spriteName = "ChatClient: " + num2;
				CHIGEDHJHOC.MakePixelPerfect();
			}
		}
		else
		{
			BCNPPHPGIHO(NACGOGCPIAH, null);
			PDNPECJIGAB(0, HBOIEACNBHM);
			JFNKIAMPICC.text = Localization.Localize(" -> ");
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: false);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: true);
			EAOIENMNEKK.gameObject.SetActive(value: false);
			FENJGKKCMOE.gameObject.SetActive(value: true);
			CHIGEDHJHOC.gameObject.SetActive(value: false);
		}
	}

	public void NAKAFGAFEPH(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB, int ELJMMBBCMPA, int DFCCEEFAFNB, float IAJAILAGAKC)
	{
		NCGAPCIGALF(KPCMLHJMPHM, GJPAOBOFFKB, ELJMMBBCMPA, FCIKGOKDONK, BFGKFGFJIKJ, MNJMDHCCCHM, FCELBAOPKJJ, FBKOBEJIDMO, DONJPBPMDNB, GNCMKEKNEAB, ALEOJJLNFIL, MNLBGFHMAJO, OCCBECIDFOO, OKAOIIGDIPA, KBNEGOFCOHM, PlayerController.OGMBJPKOPCB.fraction);
		OOOAHMOBMEN(FBCLJFNNJGG, OJMDGICAGEB, DFCCEEFAFNB, FOCDJJJBOME, CGGNOPPBMAB, FGGKODNMLFP, DGBCKLOMOHJ, CMFODKDFJNA, OKNPBJFNMIL, CMKCCLIGEGL, CPBNCIJMGPH, HLHCHBFCOKE, KNAHJOIPHBK, CJDFNJACJJE, NBAKNJKGPGM, Singleton<GameController>.instance.opponent.fraction);
		FDIMMOJJGPE(KPCMLHJMPHM, GJPAOBOFFKB, FBCLJFNNJGG, OJMDGICAGEB);
		LOKMMFEKLOD(KPCMLHJMPHM, FBCLJFNNJGG);
		float num = 1185f / IAJAILAGAKC;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num2 = activeWidthSafe - 1269f * IAJAILAGAKC - 676f;
		num2 *= num;
		PAENPHMEMGC.transform.localScale = PAENPHMEMGC.transform.localScale.ReplaceX(num2);
		IMOHHDEDEKJ.transform.localScale = IMOHHDEDEKJ.transform.localScale.ReplaceX(num2);
		DAGLPBAJHDG.transform.localPosition = DAGLPBAJHDG.transform.localPosition.ReplaceX(num2 + 696f);
		AAFMIDFBMGL.transform.localPosition = AAFMIDFBMGL.transform.localPosition.ReplaceX(num2 * 659f + 340f);
	}

	public void Initialize(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB, int ELJMMBBCMPA, int DFCCEEFAFNB, float IAJAILAGAKC)
	{
		HLILIDEAFNC(KPCMLHJMPHM, GJPAOBOFFKB, ELJMMBBCMPA, FCIKGOKDONK, BFGKFGFJIKJ, MNJMDHCCCHM, FCELBAOPKJJ, FBKOBEJIDMO, DONJPBPMDNB, GNCMKEKNEAB, ALEOJJLNFIL, MNLBGFHMAJO, OCCBECIDFOO, OKAOIIGDIPA, KBNEGOFCOHM, PlayerController.OGMBJPKOPCB.fraction);
		HLILIDEAFNC(FBCLJFNNJGG, OJMDGICAGEB, DFCCEEFAFNB, FOCDJJJBOME, CGGNOPPBMAB, FGGKODNMLFP, DGBCKLOMOHJ, CMFODKDFJNA, OKNPBJFNMIL, CMKCCLIGEGL, CPBNCIJMGPH, HLHCHBFCOKE, KNAHJOIPHBK, CJDFNJACJJE, NBAKNJKGPGM, Singleton<GameController>.instance.opponent.fraction);
		DMNLMIOPGPE(KPCMLHJMPHM, GJPAOBOFFKB, FBCLJFNNJGG, OJMDGICAGEB);
		HFLELLACHDD(KPCMLHJMPHM, FBCLJFNNJGG);
		float num = 1f / IAJAILAGAKC;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num2 = activeWidthSafe - 360f * IAJAILAGAKC - 180f;
		num2 *= num;
		PAENPHMEMGC.transform.localScale = PAENPHMEMGC.transform.localScale.ReplaceX(num2);
		IMOHHDEDEKJ.transform.localScale = IMOHHDEDEKJ.transform.localScale.ReplaceX(num2);
		DAGLPBAJHDG.transform.localPosition = DAGLPBAJHDG.transform.localPosition.ReplaceX(num2 + 180f);
		AAFMIDFBMGL.transform.localPosition = AAFMIDFBMGL.transform.localPosition.ReplaceX(num2 * 0.5f + 180f);
	}

	private void ECLCNDCFCDH(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(632f);
			PAENPHMEMGC.invert = KPCMLHJMPHM == null;
			PAENPHMEMGC.fillAmount = ((!(KPCMLHJMPHM == null) && !(FBCLJFNNJGG == null)) ? 195f : 234f);
			return;
		}
		PAENPHMEMGC.invert = true;
		if (KPCMLHJMPHM == null)
		{
			PAENPHMEMGC.fillAmount = 77f;
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(196f);
			FCELBAOPKJJ.color = Colours.grayLight;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
			return;
		}
		if (FBCLJFNNJGG == null)
		{
			PAENPHMEMGC.fillAmount = 544f;
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(803f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.grayLight;
			return;
		}
		int armyPowerX = KPCMLHJMPHM.upgradeSlots.GetArmyPowerX10(GJPAOBOFFKB.unitUpgrades.slotUpgradeindex, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexSpecial, GJPAOBOFFKB.tier, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexElite, GJPAOBOFFKB.unitUpgrades.isElite);
		int armyPowerX2 = FBCLJFNNJGG.upgradeSlots.GetArmyPowerX10(OJMDGICAGEB.unitUpgrades.slotUpgradeindex, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexSpecial, OJMDGICAGEB.tier, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexElite, OJMDGICAGEB.unitUpgrades.isElite);
		PAENPHMEMGC.fillAmount = (float)armyPowerX / (float)(armyPowerX + armyPowerX2);
		if (armyPowerX == armyPowerX2)
		{
			PAENPHMEMGC.color = Color.white.ReplaceA(138f);
			FCELBAOPKJJ.color = Color.white;
			DGBCKLOMOHJ.color = Color.white;
		}
		else if (armyPowerX > armyPowerX2)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(292f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.redWeaponStats;
		}
		else
		{
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(656f);
			FCELBAOPKJJ.color = Colours.redWeaponStats;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
		}
	}

	private void GAEEHFPFADO(int PDKIAALFDNG, List<UISprite> GNCFLIGPDDE)
	{
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			UISprite uISprite = GNCFLIGPDDE[i];
			uISprite.gameObject.SetActive(i < PDKIAALFDNG);
		}
	}

	public void CFIAHPMMJOE(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB, int ELJMMBBCMPA, int DFCCEEFAFNB, float IAJAILAGAKC)
	{
		BNLLGAGPJLP(KPCMLHJMPHM, GJPAOBOFFKB, ELJMMBBCMPA, FCIKGOKDONK, BFGKFGFJIKJ, MNJMDHCCCHM, FCELBAOPKJJ, FBKOBEJIDMO, DONJPBPMDNB, GNCMKEKNEAB, ALEOJJLNFIL, MNLBGFHMAJO, OCCBECIDFOO, OKAOIIGDIPA, KBNEGOFCOHM, PlayerController.OGMBJPKOPCB.fraction);
		NCGAPCIGALF(FBCLJFNNJGG, OJMDGICAGEB, DFCCEEFAFNB, FOCDJJJBOME, CGGNOPPBMAB, FGGKODNMLFP, DGBCKLOMOHJ, CMFODKDFJNA, OKNPBJFNMIL, CMKCCLIGEGL, CPBNCIJMGPH, HLHCHBFCOKE, KNAHJOIPHBK, CJDFNJACJJE, NBAKNJKGPGM, Singleton<GameController>.instance.opponent.fraction);
		CACDDHBDMDK(KPCMLHJMPHM, GJPAOBOFFKB, FBCLJFNNJGG, OJMDGICAGEB);
		HFLELLACHDD(KPCMLHJMPHM, FBCLJFNNJGG);
		float num = 1738f / IAJAILAGAKC;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num2 = activeWidthSafe - 1662f * IAJAILAGAKC - 829f;
		num2 *= num;
		PAENPHMEMGC.transform.localScale = PAENPHMEMGC.transform.localScale.ReplaceX(num2);
		IMOHHDEDEKJ.transform.localScale = IMOHHDEDEKJ.transform.localScale.ReplaceX(num2);
		DAGLPBAJHDG.transform.localPosition = DAGLPBAJHDG.transform.localPosition.ReplaceX(num2 + 1050f);
		AAFMIDFBMGL.transform.localPosition = AAFMIDFBMGL.transform.localPosition.ReplaceX(num2 * 131f + 142f);
	}

	private void BCNPPHPGIHO(UISprite GMPADNOGGNL, LevelBehaviour IOIKKIIFOCB)
	{
		GMPADNOGGNL.gameObject.SetActive(value: false);
		if (IOIKKIIFOCB != null)
		{
			GMPADNOGGNL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			GMPADNOGGNL.MakePixelPerfect();
			Vector3 localScale = GMPADNOGGNL.transform.localScale;
			float a = localScale.x / 1355f;
			float b = localScale.y / 867f;
			float num = Mathf.Max(a, b);
			GMPADNOGGNL.transform.localScale = localScale.MultiplyXY(692f / num);
			GMPADNOGGNL.color = Color.white;
			GMPADNOGGNL.pivot = ((!IOIKKIIFOCB.isSoldier) ? UIWidget.Pivot.Left : UIWidget.Pivot.Center);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceY((!IOIKKIIFOCB.isSoldier) ? 647f : 1874f);
		}
		else
		{
			GMPADNOGGNL.pivot = UIWidget.Pivot.BottomLeft;
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceY(41f);
			GMPADNOGGNL.spriteName = "CL";
			GMPADNOGGNL.transform.localScale = new Vector3(1868f, 1477f, 367f);
			GMPADNOGGNL.color = Colours.grayLight;
		}
	}

	private void HFLELLACHDD(LevelBehaviour KPCMLHJMPHM, LevelBehaviour FBCLJFNNJGG)
	{
		LevelBehaviour.UnitType key = ((!(KPCMLHJMPHM != null)) ? FBCLJFNNJGG.unitType : KPCMLHJMPHM.unitType);
		GNLNDFAPPNK.spriteName = GameVariables.CNFFEIMLDNP[key].Value1;
		JFGPHHCCLLM.spriteName = GameVariables.CNFFEIMLDNP[key].Value1;
		MPILKGHIAMN.color = GameVariables.CNFFEIMLDNP[key].Value2;
		FENPECHJKIH.color = GameVariables.CNFFEIMLDNP[key].Value2;
	}

	private void KAPIKAOBHBD(UISprite GMPADNOGGNL, LevelBehaviour IOIKKIIFOCB)
	{
		GMPADNOGGNL.gameObject.SetActive(value: true);
		if (IOIKKIIFOCB != null)
		{
			GMPADNOGGNL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			GMPADNOGGNL.MakePixelPerfect();
			Vector3 localScale = GMPADNOGGNL.transform.localScale;
			float a = localScale.x / 796f;
			float b = localScale.y / 108f;
			float num = Mathf.Max(a, b);
			GMPADNOGGNL.transform.localScale = localScale.MultiplyXY(431f / num);
			GMPADNOGGNL.color = Color.white;
			GMPADNOGGNL.pivot = ((!IOIKKIIFOCB.isSoldier) ? UIWidget.Pivot.BottomLeft : UIWidget.Pivot.BottomRight);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceY((!IOIKKIIFOCB.isSoldier) ? 90f : 608f);
		}
		else
		{
			GMPADNOGGNL.pivot = UIWidget.Pivot.Center;
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceY(351f);
			GMPADNOGGNL.spriteName = "Action ";
			GMPADNOGGNL.transform.localScale = new Vector3(862f, 265f, 858f);
			GMPADNOGGNL.color = Colours.grayLight;
		}
	}

	private void GAMAPJALCKH(UISprite GMPADNOGGNL, LevelBehaviour IOIKKIIFOCB)
	{
		GMPADNOGGNL.gameObject.SetActive(value: true);
		if (IOIKKIIFOCB != null)
		{
			GMPADNOGGNL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
			GMPADNOGGNL.MakePixelPerfect();
			Vector3 localScale = GMPADNOGGNL.transform.localScale;
			float a = localScale.x / 180f;
			float b = localScale.y / 90f;
			float num = Mathf.Max(a, b);
			GMPADNOGGNL.transform.localScale = localScale.MultiplyXY(1f / num);
			GMPADNOGGNL.color = Color.white;
			GMPADNOGGNL.pivot = ((!IOIKKIIFOCB.isSoldier) ? UIWidget.Pivot.Center : UIWidget.Pivot.Bottom);
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceY((!IOIKKIIFOCB.isSoldier) ? (-50f) : (-100f));
		}
		else
		{
			GMPADNOGGNL.pivot = UIWidget.Pivot.Center;
			GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceY(-50f);
			GMPADNOGGNL.spriteName = "whiteRectangle";
			GMPADNOGGNL.transform.localScale = new Vector3(44f, 8f, 1f);
			GMPADNOGGNL.color = Colours.grayLight;
		}
	}

	private void OOOAHMOBMEN(LevelBehaviour IOIKKIIFOCB, UnitUpgradeDefinition LGECBDJBLPG, int KKMINPNDBEE, UISprite NACGOGCPIAH, UISprite GDHBBLOPLIP, UILabel NEKIBLFNDJJ, UILabel JFNKIAMPICC, UILabel KCBFDBEGNHF, UILabel GGFDJCHEDGM, List<UISprite> HBOIEACNBHM, UISprite HBMLFIJGBJO, UISprite EAOIENMNEKK, UILabel DHNJGJKDNLK, UISprite FENJGKKCMOE, UISprite CHIGEDHJHOC, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			BCNPPHPGIHO(NACGOGCPIAH, IOIKKIIFOCB);
			PDNPECJIGAB(0, HBOIEACNBHM);
			NEKIBLFNDJJ.gameObject.SetActive(value: true);
			KCBFDBEGNHF.gameObject.SetActive(value: true);
			JFNKIAMPICC.text = string.Empty;
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: false);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: false);
			EAOIENMNEKK.gameObject.SetActive(value: true);
			FENJGKKCMOE.gameObject.SetActive(value: true);
			CHIGEDHJHOC.gameObject.SetActive(value: false);
			return;
		}
		NEKIBLFNDJJ.gameObject.SetActive(IOIKKIIFOCB != null);
		KCBFDBEGNHF.gameObject.SetActive(IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.unlockLevel.ELFCEEOLNFJ() > KKMINPNDBEE);
		if (IOIKKIIFOCB != null)
		{
			UpgradeSlots.UnitUpgrades unitUpgrades = LGECBDJBLPG.unitUpgrades;
			bool isSpecial = unitUpgrades.isSpecial;
			bool isElite = unitUpgrades.isElite;
			int armyPowerX = IOIKKIIFOCB.upgradeSlots.GetArmyPowerX10(unitUpgrades.slotUpgradeindex, unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier, unitUpgrades.slotUpgradeIndexElite, isElite);
			int fFHHEHHFOKJ = IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.OOONCKAGGPH(unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier);
			int fFHHEHHFOKJ2 = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.LFNLPNEONEI(unitUpgrades.slotUpgradeIndexElite, isElite);
			int actualLevelForIndex = IOIKKIIFOCB.upgradeSlots.GetActualLevelForIndex(LGECBDJBLPG.unitUpgrades.slotUpgradeindex);
			FCLADBGKCIA fCLADBGKCIA = Singleton<GameController>.instance.mainController.CheckForPerks(IOIKKIIFOCB, CIOPAKLHFIL);
			int num = fCLADBGKCIA.FMNCAMJPCBN(PDNPBLFEPJG.Debuff);
			int num2 = fCLADBGKCIA.MKGKBALBIHL(PDNPBLFEPJG.Debuff);
			KAPIKAOBHBD(NACGOGCPIAH, IOIKKIIFOCB);
			PDNPECJIGAB(LGECBDJBLPG.tier, HBOIEACNBHM);
			NEKIBLFNDJJ.text = ((actualLevelForIndex <= 1) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(actualLevelForIndex));
			JFNKIAMPICC.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
			GGFDJCHEDGM.text = ((!isSpecial) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
			GDHBBLOPLIP.gameObject.SetActive(isSpecial);
			if (isSpecial)
			{
				GDHBBLOPLIP.spriteName = IOIKKIIFOCB.abilityIcon;
			}
			DHNJGJKDNLK.text = ((!isElite) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2));
			HBMLFIJGBJO.gameObject.SetActive(isElite);
			EAOIENMNEKK.gameObject.SetActive(isElite);
			if (isElite)
			{
				IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 1520f);
			}
			FENJGKKCMOE.gameObject.SetActive(num <= 0 && num2 > 0);
			CHIGEDHJHOC.gameObject.SetActive(num <= 0 || num2 > 0);
			if (FENJGKKCMOE.gameObject.activeSelf)
			{
				FENJGKKCMOE.spriteName = ((num <= 1) ? ("#PETER# Weapon Screen - LEFT BUTTON - weapon state: OTHER\t\tbutton type: EMPTY" + num2) : ("HeroicMissionsCompletionRewardScraps" + num));
				FENJGKKCMOE.MakePixelPerfect();
			}
			if (CHIGEDHJHOC.gameObject.activeSelf)
			{
				CHIGEDHJHOC.spriteName = "SquadEventActiveTier" + num2;
				CHIGEDHJHOC.MakePixelPerfect();
			}
		}
		else
		{
			GAMAPJALCKH(NACGOGCPIAH, null);
			GAEEHFPFADO(0, HBOIEACNBHM);
			JFNKIAMPICC.text = Localization.Localize("Terms: OnApplicationPause close session");
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: false);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: false);
			EAOIENMNEKK.gameObject.SetActive(value: false);
			FENJGKKCMOE.gameObject.SetActive(value: false);
			CHIGEDHJHOC.gameObject.SetActive(value: false);
		}
	}

	private void DMNLMIOPGPE(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(0.15f);
			PAENPHMEMGC.invert = KPCMLHJMPHM == null;
			PAENPHMEMGC.fillAmount = ((!(KPCMLHJMPHM == null) && !(FBCLJFNNJGG == null)) ? 1f : 0f);
			return;
		}
		PAENPHMEMGC.invert = false;
		if (KPCMLHJMPHM == null)
		{
			PAENPHMEMGC.fillAmount = 0f;
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(0.3f);
			FCELBAOPKJJ.color = Colours.grayLight;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
			return;
		}
		if (FBCLJFNNJGG == null)
		{
			PAENPHMEMGC.fillAmount = 1f;
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(0.15f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.grayLight;
			return;
		}
		int armyPowerX = KPCMLHJMPHM.upgradeSlots.GetArmyPowerX10(GJPAOBOFFKB.unitUpgrades.slotUpgradeindex, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexSpecial, GJPAOBOFFKB.tier, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexElite, GJPAOBOFFKB.unitUpgrades.isElite);
		int armyPowerX2 = FBCLJFNNJGG.upgradeSlots.GetArmyPowerX10(OJMDGICAGEB.unitUpgrades.slotUpgradeindex, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexSpecial, OJMDGICAGEB.tier, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexElite, OJMDGICAGEB.unitUpgrades.isElite);
		PAENPHMEMGC.fillAmount = (float)armyPowerX / (float)(armyPowerX + armyPowerX2);
		if (armyPowerX == armyPowerX2)
		{
			PAENPHMEMGC.color = Color.white.ReplaceA(0.2f);
			FCELBAOPKJJ.color = Color.white;
			DGBCKLOMOHJ.color = Color.white;
		}
		else if (armyPowerX > armyPowerX2)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(0.15f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.redWeaponStats;
		}
		else
		{
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(0.3f);
			FCELBAOPKJJ.color = Colours.redWeaponStats;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
		}
	}

	private void MMFFKICOKDK(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(72f);
			PAENPHMEMGC.invert = KPCMLHJMPHM == null;
			PAENPHMEMGC.fillAmount = ((!(KPCMLHJMPHM == null) && !(FBCLJFNNJGG == null)) ? 1169f : 1439f);
			return;
		}
		PAENPHMEMGC.invert = false;
		if (KPCMLHJMPHM == null)
		{
			PAENPHMEMGC.fillAmount = 19f;
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(1642f);
			FCELBAOPKJJ.color = Colours.grayLight;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
			return;
		}
		if (FBCLJFNNJGG == null)
		{
			PAENPHMEMGC.fillAmount = 1f;
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(776f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.grayLight;
			return;
		}
		int armyPowerX = KPCMLHJMPHM.upgradeSlots.GetArmyPowerX10(GJPAOBOFFKB.unitUpgrades.slotUpgradeindex, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexSpecial, GJPAOBOFFKB.tier, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexElite, GJPAOBOFFKB.unitUpgrades.isElite);
		int armyPowerX2 = FBCLJFNNJGG.upgradeSlots.GetArmyPowerX10(OJMDGICAGEB.unitUpgrades.slotUpgradeindex, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexSpecial, OJMDGICAGEB.tier, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexElite, OJMDGICAGEB.unitUpgrades.isElite);
		PAENPHMEMGC.fillAmount = (float)armyPowerX / (float)(armyPowerX + armyPowerX2);
		if (armyPowerX == armyPowerX2)
		{
			PAENPHMEMGC.color = Color.white.ReplaceA(1074f);
			FCELBAOPKJJ.color = Color.white;
			DGBCKLOMOHJ.color = Color.white;
		}
		else if (armyPowerX > armyPowerX2)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(615f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.redWeaponStats;
		}
		else
		{
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(1195f);
			FCELBAOPKJJ.color = Colours.redWeaponStats;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
		}
	}

	public void LIMIFKFNNLA(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB, int ELJMMBBCMPA, int DFCCEEFAFNB, float IAJAILAGAKC)
	{
		OOOAHMOBMEN(KPCMLHJMPHM, GJPAOBOFFKB, ELJMMBBCMPA, FCIKGOKDONK, BFGKFGFJIKJ, MNJMDHCCCHM, FCELBAOPKJJ, FBKOBEJIDMO, DONJPBPMDNB, GNCMKEKNEAB, ALEOJJLNFIL, MNLBGFHMAJO, OCCBECIDFOO, OKAOIIGDIPA, KBNEGOFCOHM, PlayerController.OGMBJPKOPCB.fraction);
		BNLLGAGPJLP(FBCLJFNNJGG, OJMDGICAGEB, DFCCEEFAFNB, FOCDJJJBOME, CGGNOPPBMAB, FGGKODNMLFP, DGBCKLOMOHJ, CMFODKDFJNA, OKNPBJFNMIL, CMKCCLIGEGL, CPBNCIJMGPH, HLHCHBFCOKE, KNAHJOIPHBK, CJDFNJACJJE, NBAKNJKGPGM, Singleton<GameController>.instance.opponent.fraction);
		FDIMMOJJGPE(KPCMLHJMPHM, GJPAOBOFFKB, FBCLJFNNJGG, OJMDGICAGEB);
		LOKMMFEKLOD(KPCMLHJMPHM, FBCLJFNNJGG);
		float num = 961f / IAJAILAGAKC;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num2 = activeWidthSafe - 1309f * IAJAILAGAKC - 930f;
		num2 *= num;
		PAENPHMEMGC.transform.localScale = PAENPHMEMGC.transform.localScale.ReplaceX(num2);
		IMOHHDEDEKJ.transform.localScale = IMOHHDEDEKJ.transform.localScale.ReplaceX(num2);
		DAGLPBAJHDG.transform.localPosition = DAGLPBAJHDG.transform.localPosition.ReplaceX(num2 + 854f);
		AAFMIDFBMGL.transform.localPosition = AAFMIDFBMGL.transform.localPosition.ReplaceX(num2 * 1838f + 297f);
	}

	private void CACDDHBDMDK(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(1125f);
			PAENPHMEMGC.invert = KPCMLHJMPHM == null;
			PAENPHMEMGC.fillAmount = ((!(KPCMLHJMPHM == null) && !(FBCLJFNNJGG == null)) ? 501f : 681f);
			return;
		}
		PAENPHMEMGC.invert = false;
		if (KPCMLHJMPHM == null)
		{
			PAENPHMEMGC.fillAmount = 1580f;
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(1666f);
			FCELBAOPKJJ.color = Colours.grayLight;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
			return;
		}
		if (FBCLJFNNJGG == null)
		{
			PAENPHMEMGC.fillAmount = 1088f;
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(588f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.grayLight;
			return;
		}
		int armyPowerX = KPCMLHJMPHM.upgradeSlots.GetArmyPowerX10(GJPAOBOFFKB.unitUpgrades.slotUpgradeindex, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexSpecial, GJPAOBOFFKB.tier, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexElite, GJPAOBOFFKB.unitUpgrades.isElite);
		int armyPowerX2 = FBCLJFNNJGG.upgradeSlots.GetArmyPowerX10(OJMDGICAGEB.unitUpgrades.slotUpgradeindex, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexSpecial, OJMDGICAGEB.tier, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexElite, OJMDGICAGEB.unitUpgrades.isElite);
		PAENPHMEMGC.fillAmount = (float)armyPowerX / (float)(armyPowerX + armyPowerX2);
		if (armyPowerX == armyPowerX2)
		{
			PAENPHMEMGC.color = Color.white.ReplaceA(46f);
			FCELBAOPKJJ.color = Color.white;
			DGBCKLOMOHJ.color = Color.white;
		}
		else if (armyPowerX > armyPowerX2)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(167f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.redWeaponStats;
		}
		else
		{
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(1331f);
			FCELBAOPKJJ.color = Colours.redWeaponStats;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
		}
	}

	private void NCGAPCIGALF(LevelBehaviour IOIKKIIFOCB, UnitUpgradeDefinition LGECBDJBLPG, int KKMINPNDBEE, UISprite NACGOGCPIAH, UISprite GDHBBLOPLIP, UILabel NEKIBLFNDJJ, UILabel JFNKIAMPICC, UILabel KCBFDBEGNHF, UILabel GGFDJCHEDGM, List<UISprite> HBOIEACNBHM, UISprite HBMLFIJGBJO, UISprite EAOIENMNEKK, UILabel DHNJGJKDNLK, UISprite FENJGKKCMOE, UISprite CHIGEDHJHOC, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			KAPIKAOBHBD(NACGOGCPIAH, IOIKKIIFOCB);
			PDNPECJIGAB(0, HBOIEACNBHM);
			NEKIBLFNDJJ.gameObject.SetActive(value: true);
			KCBFDBEGNHF.gameObject.SetActive(value: false);
			JFNKIAMPICC.text = string.Empty;
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: true);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: false);
			EAOIENMNEKK.gameObject.SetActive(value: true);
			FENJGKKCMOE.gameObject.SetActive(value: true);
			CHIGEDHJHOC.gameObject.SetActive(value: true);
			return;
		}
		NEKIBLFNDJJ.gameObject.SetActive(IOIKKIIFOCB != null);
		KCBFDBEGNHF.gameObject.SetActive(!(IOIKKIIFOCB != null) || IOIKKIIFOCB.upgradeSlots.unlockLevel.KADNNBCOGGL() > KKMINPNDBEE);
		if (IOIKKIIFOCB != null)
		{
			UpgradeSlots.UnitUpgrades unitUpgrades = LGECBDJBLPG.unitUpgrades;
			bool isSpecial = unitUpgrades.isSpecial;
			bool isElite = unitUpgrades.isElite;
			int armyPowerX = IOIKKIIFOCB.upgradeSlots.GetArmyPowerX10(unitUpgrades.slotUpgradeindex, unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier, unitUpgrades.slotUpgradeIndexElite, isElite);
			int fFHHEHHFOKJ = IOIKKIIFOCB.upgradeSlots.upgradeSlotSpecial.HGHEOAMKCHK(unitUpgrades.slotUpgradeIndexSpecial, LGECBDJBLPG.tier);
			int fFHHEHHFOKJ2 = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.KJKKGONJMOM(unitUpgrades.slotUpgradeIndexElite, isElite);
			int actualLevelForIndex = IOIKKIIFOCB.upgradeSlots.GetActualLevelForIndex(LGECBDJBLPG.unitUpgrades.slotUpgradeindex);
			FCLADBGKCIA fCLADBGKCIA = Singleton<GameController>.instance.mainController.CheckForPerks(IOIKKIIFOCB, CIOPAKLHFIL);
			int num = fCLADBGKCIA.FMNCAMJPCBN(PDNPBLFEPJG.Buff);
			int num2 = fCLADBGKCIA.HHPIBBLOLJO(PDNPBLFEPJG.Buff);
			BCNPPHPGIHO(NACGOGCPIAH, IOIKKIIFOCB);
			GAEEHFPFADO(LGECBDJBLPG.tier, HBOIEACNBHM);
			NEKIBLFNDJJ.text = ((actualLevelForIndex <= 0) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(actualLevelForIndex));
			JFNKIAMPICC.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
			GGFDJCHEDGM.text = ((!isSpecial) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
			GDHBBLOPLIP.gameObject.SetActive(isSpecial);
			if (isSpecial)
			{
				GDHBBLOPLIP.spriteName = IOIKKIIFOCB.abilityIcon;
			}
			DHNJGJKDNLK.text = ((!isElite) ? string.Empty : MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2));
			HBMLFIJGBJO.gameObject.SetActive(isElite);
			EAOIENMNEKK.gameObject.SetActive(isElite);
			if (isElite)
			{
				IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 432f);
			}
			FENJGKKCMOE.gameObject.SetActive(num <= 1 && num2 > 1);
			CHIGEDHJHOC.gameObject.SetActive(num <= 0 || num2 > 0);
			if (FENJGKKCMOE.gameObject.activeSelf)
			{
				FENJGKKCMOE.spriteName = ((num <= 1) ? ("Player disconected 0001" + num2) : ("ID_WARARENAUNLOCKED" + num));
				FENJGKKCMOE.MakePixelPerfect();
			}
			if (CHIGEDHJHOC.gameObject.activeSelf)
			{
				CHIGEDHJHOC.spriteName = "Different squads \"{0}\" and \"{1}\"\n" + num2;
				CHIGEDHJHOC.MakePixelPerfect();
			}
		}
		else
		{
			GAMAPJALCKH(NACGOGCPIAH, null);
			PDNPECJIGAB(0, HBOIEACNBHM);
			JFNKIAMPICC.text = Localization.Localize("shotPoison");
			GGFDJCHEDGM.text = string.Empty;
			GDHBBLOPLIP.gameObject.SetActive(value: false);
			DHNJGJKDNLK.text = string.Empty;
			HBMLFIJGBJO.gameObject.SetActive(value: true);
			EAOIENMNEKK.gameObject.SetActive(value: false);
			FENJGKKCMOE.gameObject.SetActive(value: true);
			CHIGEDHJHOC.gameObject.SetActive(value: true);
		}
	}

	private void PDNPECJIGAB(int PDKIAALFDNG, List<UISprite> GNCFLIGPDDE)
	{
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			UISprite uISprite = GNCFLIGPDDE[i];
			uISprite.gameObject.SetActive(i < PDKIAALFDNG);
		}
	}

	private void FDIMMOJJGPE(LevelBehaviour KPCMLHJMPHM, UnitUpgradeDefinition GJPAOBOFFKB, LevelBehaviour FBCLJFNNJGG, UnitUpgradeDefinition OJMDGICAGEB)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(1795f);
			PAENPHMEMGC.invert = KPCMLHJMPHM == null;
			PAENPHMEMGC.fillAmount = ((!(KPCMLHJMPHM == null) && !(FBCLJFNNJGG == null)) ? 270f : 759f);
			return;
		}
		PAENPHMEMGC.invert = false;
		if (KPCMLHJMPHM == null)
		{
			PAENPHMEMGC.fillAmount = 484f;
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(1144f);
			FCELBAOPKJJ.color = Colours.grayLight;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
			return;
		}
		if (FBCLJFNNJGG == null)
		{
			PAENPHMEMGC.fillAmount = 1025f;
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(1823f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.grayLight;
			return;
		}
		int armyPowerX = KPCMLHJMPHM.upgradeSlots.GetArmyPowerX10(GJPAOBOFFKB.unitUpgrades.slotUpgradeindex, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexSpecial, GJPAOBOFFKB.tier, GJPAOBOFFKB.unitUpgrades.slotUpgradeIndexElite, GJPAOBOFFKB.unitUpgrades.isElite);
		int armyPowerX2 = FBCLJFNNJGG.upgradeSlots.GetArmyPowerX10(OJMDGICAGEB.unitUpgrades.slotUpgradeindex, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexSpecial, OJMDGICAGEB.tier, OJMDGICAGEB.unitUpgrades.slotUpgradeIndexElite, OJMDGICAGEB.unitUpgrades.isElite);
		PAENPHMEMGC.fillAmount = (float)armyPowerX / (float)(armyPowerX + armyPowerX2);
		if (armyPowerX == armyPowerX2)
		{
			PAENPHMEMGC.color = Color.white.ReplaceA(1347f);
			FCELBAOPKJJ.color = Color.white;
			DGBCKLOMOHJ.color = Color.white;
		}
		else if (armyPowerX > armyPowerX2)
		{
			PAENPHMEMGC.color = Colours.greenWeaponStats.ReplaceA(19f);
			FCELBAOPKJJ.color = Colours.greenWeaponStats;
			DGBCKLOMOHJ.color = Colours.redWeaponStats;
		}
		else
		{
			PAENPHMEMGC.color = Colours.redWeaponStats.ReplaceA(1698f);
			FCELBAOPKJJ.color = Colours.redWeaponStats;
			DGBCKLOMOHJ.color = Colours.greenWeaponStats;
		}
	}
}
