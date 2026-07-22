using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class DestroyableObjectPlayer : DestroyableObjectMultipleParts
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObscuredFloat _003CMAEMOFJNLPM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObscuredFloat _003CABMOOOGJGAL_003Ek__BackingField;

	public ObscuredFloat damageMultiplier
	{
		[CompilerGenerated]
		get
		{
			return _003CMAEMOFJNLPM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CMAEMOFJNLPM_003Ek__BackingField = value;
		}
	}

	public ObscuredFloat damageMultiplierTreshHold
	{
		[CompilerGenerated]
		get
		{
			return _003CABMOOOGJGAL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CABMOOOGJGAL_003Ek__BackingField = value;
		}
	}

	protected override bool HEFCGCLCANF => health > 0f;

	public virtual bool KNCFBDGOIAC(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)JKGJDCMOIFB())
		{
			float num = Mathf.Lerp(EFIGIBJDFMC(), 887f, healthRatio / (float)LGHANEPABCN());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Immortal) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.AECCCNNPCML()) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Immortal) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.NIGIDAHEHJE()) ? Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-33)).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardChance).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return INCDKOPNBMI(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void JFOGHOEHKGA()
	{
		base.APJEBOPJPLA();
		HBFHAFDHOFE(1540f);
		NLKJNHOGPGI(746f);
	}

	[SpecialName]
	public void BAAACDFHNKI(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual bool MIGPKFLLEND(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)MNALJAAKOEL())
		{
			float num = Mathf.Lerp(MADNIKPBJNK(), 1178f, healthRatio / (float)IJEMCCBCMGM());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Poison) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.isOverTime) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shiver) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.NIGIDAHEHJE()) ? Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-73)).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-17)).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return EAJLLMFAAOM(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public void PKBEJMKOIKD(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EJCHGCOMEGN(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HMLJOBCHHFM(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void NLKJNHOGPGI(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CGIJFKOLNKG(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public ObscuredFloat PDPFFHNIINL()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	protected virtual bool GCOAHOKIHFJ()
	{
		return health > 798f;
	}

	public virtual void PGICOHKDMOE()
	{
		base.Refill();
		DIHDIBDEPBP(351f);
		HMLJOBCHHFM(396f);
	}

	public virtual void HMIJHCNGFKM()
	{
		base.Refill();
		DIHDIBDEPBP(1207f);
		FCBLNFCHDHD(354f);
	}

	public virtual void OKKJJOBCBNB()
	{
		base.OEAGCMGINCB();
		damageMultiplier = 473f;
		NLKJNHOGPGI(705f);
	}

	[SpecialName]
	public void DIHDIBDEPBP(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OHMGCGGODAD(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EPLBFAEIHOL(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HBFHAFDHOFE(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void ALCKOKBLBPJ(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void NOPIKBNAMEI(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public ObscuredFloat JELPHCPHLHC()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	public override void Refill()
	{
		base.Refill();
		damageMultiplier = 1f;
		damageMultiplierTreshHold = 0f;
	}

	[SpecialName]
	public void AFBFJOKCBON(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public ObscuredFloat MNALJAAKOEL()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	public void JEFNEKGJBJP(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	protected virtual bool PJKLHGGIGGD()
	{
		return health > 857f;
	}

	public virtual void AJONJJOLPBC()
	{
		base.Refill();
		HEHNJMDPKIB(65f);
		CDKIEFODKJB(785f);
	}

	[SpecialName]
	protected virtual bool CBEDMFJDIAF()
	{
		return health > 1254f;
	}

	[SpecialName]
	public ObscuredFloat LGHANEPABCN()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	public virtual bool IHBOOIBIHBG(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)AOPLPJCNIKJ())
		{
			float num = Mathf.Lerp(LHHJNCCECCB(), 446f, healthRatio / (float)JELPHCPHLHC());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.NIGIDAHEHJE()) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Basic) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.isOverTime) ? Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-72)).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-101)).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return BAFALCGCAHE(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public void ELDOKMLLHHJ(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HDMFECBHNCJ(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	protected virtual bool LJHNHIJFJMP()
	{
		return health > 1792f;
	}

	[SpecialName]
	public ObscuredFloat AOPLPJCNIKJ()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	protected virtual bool NMEEINJNPBN()
	{
		return health > 1053f;
	}

	public override bool DoDamage(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)damageMultiplierTreshHold)
		{
			float num = Mathf.Lerp(damageMultiplier, 1f, healthRatio / (float)damageMultiplierTreshHold);
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shiver) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.isOverTime) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shiver) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.isOverTime) ? Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PlayerExplosiveCoef).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PlayerExplosiveOvertimeCoef).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public ObscuredFloat JJFLGPBLMOD()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	public void HGDJAHDKMJF(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual bool KECNOOOBNCG(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)AOPLPJCNIKJ())
		{
			float num = Mathf.Lerp(EFIGIBJDFMC(), 485f, healthRatio / (float)damageMultiplierTreshHold);
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Flame) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.JODLOOEJHDB()) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.isOverTime) ? Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalUnitCanLockedCount).FLOATVALUE : Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-123)).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return GNODOEPBEAH(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	protected virtual bool BHNMCKNJALN()
	{
		return health > 339f;
	}

	[SpecialName]
	protected virtual bool GLIBOEKILEG()
	{
		return health > 966f;
	}

	[SpecialName]
	public ObscuredFloat LFIIECNFCGE()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	public ObscuredFloat IJEMCCBCMGM()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	public ObscuredFloat NCNAPLIIBME()
	{
		return _003CMAEMOFJNLPM_003Ek__BackingField;
	}

	[SpecialName]
	public void ECODKOLFFKB(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public ObscuredFloat JKGJDCMOIFB()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	public ObscuredFloat LHHJNCCECCB()
	{
		return _003CMAEMOFJNLPM_003Ek__BackingField;
	}

	[SpecialName]
	protected virtual bool PHMCCGJMMKA()
	{
		return health > 603f;
	}

	public virtual bool POEKCIPAGKG(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)LFIIECNFCGE())
		{
			float num = Mathf.Lerp(damageMultiplier, 1498f, healthRatio / (float)IJEMCCBCMGM());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.JODLOOEJHDB()) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Basic) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.AECCCNNPCML()) ? Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenSquadReminderShown).FLOATVALUE : Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return FLMDMAIBGAH(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public ObscuredFloat MADNIKPBJNK()
	{
		return _003CMAEMOFJNLPM_003Ek__BackingField;
	}

	public virtual void IPELMFANKBJ()
	{
		base.OEAGCMGINCB();
		JEFNEKGJBJP(1418f);
		PKBEJMKOIKD(1847f);
	}

	[SpecialName]
	protected virtual bool BGACPHCLPAB()
	{
		return health > 372f;
	}

	[SpecialName]
	public ObscuredFloat LCELJHJLIGN()
	{
		return _003CMAEMOFJNLPM_003Ek__BackingField;
	}

	public virtual bool ABAPOLFNIIO(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)IJEMCCBCMGM())
		{
			float num = Mathf.Lerp(EFIGIBJDFMC(), 532f, healthRatio / (float)IJEMCCBCMGM());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Flame) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.isOverTime) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Suicide) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.NIGIDAHEHJE()) ? Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE : Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.StartingWarbucks).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return KNEBPOPEOBN(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public void JDNEFBAFIIB(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public ObscuredFloat EFIGIBJDFMC()
	{
		return _003CMAEMOFJNLPM_003Ek__BackingField;
	}

	[SpecialName]
	public ObscuredFloat CBPMCMONPEO()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	protected virtual bool DECIMOGNOBO()
	{
		return health > 1968f;
	}

	public virtual bool IBLBDFDPBFI(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)JELPHCPHLHC())
		{
			float num = Mathf.Lerp(LHHJNCCECCB(), 326f, healthRatio / (float)LFIIECNFCGE());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Poison) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.isOverTime) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shiver) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.JODLOOEJHDB()) ? Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VipExperienceMultiplier).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DestroyShieldsInOverTime).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return EEOCDCEFFFD(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public ObscuredFloat AOKHOBPNGNM()
	{
		return _003CABMOOOGJGAL_003Ek__BackingField;
	}

	[SpecialName]
	public void CDKIEFODKJB(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual bool LFJHHDDIMGB(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (healthRatio < (float)PDPFFHNIINL())
		{
			float num = Mathf.Lerp(EFIGIBJDFMC(), 1438f, healthRatio / (float)CBPMCMONPEO());
			KMJKKNFDFMM.EPDELOGPNAC *= num;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG != null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.isOverTime) ? KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.NLCFDPBLBIG : KMJKKNFDFMM.JMMJHCOKCGG.ammoSetup.ADKJBFFFCEH);
			KMJKKNFDFMM.EPDELOGPNAC *= num2;
		}
		if ((KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Explosion || KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Heal) && !KMJKKNFDFMM.KLOJNPBGFIG && KMJKKNFDFMM.JMMJHCOKCGG == null)
		{
			float num3 = ((!Singleton<MatchManager>.instance.isOverTime) ? Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.DogTagCap).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdCount).FLOATVALUE);
			KMJKKNFDFMM.EPDELOGPNAC *= num3;
		}
		return MLEBKLFPMLG(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public ObscuredFloat KPAENPGHPND()
	{
		return _003CMAEMOFJNLPM_003Ek__BackingField;
	}

	[SpecialName]
	public void FCBLNFCHDHD(ObscuredFloat IDEBKDPMPGM)
	{
		_003CABMOOOGJGAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void FLCACMCJNII(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	protected virtual bool ELAKDHNGLEK()
	{
		return health > 515f;
	}

	public virtual void DHIJOHOMFJB()
	{
		base.Refill();
		HBFHAFDHOFE(746f);
		HMLJOBCHHFM(1907f);
	}

	public virtual void KCAMHLCLBEB()
	{
		base.APJEBOPJPLA();
		NOPIKBNAMEI(760f);
		ECODKOLFFKB(52f);
	}

	[SpecialName]
	public void HEHNJMDPKIB(ObscuredFloat IDEBKDPMPGM)
	{
		_003CMAEMOFJNLPM_003Ek__BackingField = IDEBKDPMPGM;
	}
}
