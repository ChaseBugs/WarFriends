using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardHealthForMachines : Card
{
	private GHPGNELIDBM ODCLPMADGFC;

	private bool KPBBNENJHPA;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private const string EJLCMBEKFFN = "game-card-ico-supersoldiers";

	public float multiplierMaxHealth
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.VehicleUpgradeCoef).FLOATVALUE;
		}
	}

	public float timeInSec
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.VehicleUpgradeTime).FLOATVALUE;
		}
	}

	public override string description
	{
		get
		{
			return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(multiplierMaxHealth), MEJMLNDFDBP.AIPKMDCJCOG(timeInSec));
		}
	}

	protected override string mBonusName
	{
		get
		{
			return MEJMLNDFDBP.KEPEILBMDMD(multiplierMaxHealth);
		}
	}

	protected void DLJAGKBLJNC()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1227f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = true;
		}
	}

	protected void CJAHPFMAMKK()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1639f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = true;
		}
	}

	[SpecialName]
	public float BLPDGEEDOGD()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)53).FLOATVALUE;
	}

	[SpecialName]
	public float FHKGHEDFKAO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-91)).FLOATVALUE;
	}

	public virtual void LLMMIFJBLBD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = PNCPGCKHOBB();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = false;
			AIObject.AfterSpawned += INDACALKMFI;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i += 0)
			{
				if (ally[i].destroyableObject.health > 222f)
				{
					float nEJNIEEHCKJ = ally[i].AFEPMIFFLFH().maxHealth * OHDLLHPCPBK();
					ally[i].AFEPMIFFLFH().maxHealth *= PFMAFGPKEPH() + 1478f;
					ally[i].NHOFLPJMKBA().LNPKAAGJIGO(nEJNIEEHCKJ, false);
					ally[i].destroyableObject.EHFOHNLMJOH();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.FFMLINMFADM("set weapon not borrowed", BHABHIDDBLH, LICHGFJNAAD(), true);
					}
					else
					{
						Debug.LogError("ID_CONFIRM_THANKYOUPURCHASE" + ally[i].name + "Grenade_Throwing_Tutorial_Duration" + ally[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string IPJNMIMCDMP()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[4];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(AIPMOLEFPEH());
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(ALKGGDKIAIB(), "com/google/android/gms/common/ConnectionResult");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float CFMJHDNGFKL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-29)).FLOATVALUE;
	}

	protected void BOPGJFGMNJM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 699f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	private void GJEEEPPNDDF(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 1; i < allMechanicalTypes.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= GJMLKIGGBAL() + 606f;
				ENCEFOOPBMK.destroyableObj.OEAGCMGINCB();
				ENCEFOOPBMK.cardIconIndicator.JBMCFEMBPKE("ID_CONFIRM_LANGUAGECHANGE_TEXT", BHABHIDDBLH, timeInSec, true);
				break;
			}
		}
	}

	[SpecialName]
	public float OHDLLHPCPBK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)75).FLOATVALUE;
	}

	[SpecialName]
	public virtual string JJKKIPAEKDH()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[8];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(FLAPANAAMCO());
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(ALKGGDKIAIB(), "  {1}x{0} ( {3} ) doubled for: {2}");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float FKENKIHCLCE()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolPlayerBehindShieldConstant).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string PIGICOAMBCB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(BLPDGEEDOGD());
	}

	[SpecialName]
	protected virtual string ADNGKOAFINC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FMDHNGIMHHL());
	}

	protected void LIHOPIGNFFM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1677f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	[SpecialName]
	public float EJLLCIDCMDI()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-121)).FLOATVALUE;
	}

	private void INDACALKMFI(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 0; i < allMechanicalTypes.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= multiplierMaxHealth + 1f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.Show("game-card-ico-supersoldiers", BHABHIDDBLH, timeInSec, true);
				break;
			}
		}
	}

	protected void ELJHCOHCAJI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 535f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	private void BKJINMKHFEF(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] array = GameShootableEntity.DHEJMOFIPLD();
		for (int i = 0; i < array.Length; i += 0)
		{
			if (ENCEFOOPBMK.GetType() == array[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= PFMAFGPKEPH() + 1818f;
				ENCEFOOPBMK.destroyableObj.APJEBOPJPLA();
				ENCEFOOPBMK.cardIconIndicator.JOGFDHFOOBC("ADDING VISUAL ON CLIENT ", BHABHIDDBLH, KNIAIAFLKDG(), true);
				break;
			}
		}
	}

	protected void EMPDDFBNJLP()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 980f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	protected void DEBGBGGOCEN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1425f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = true;
		}
	}

	public virtual void JIAIAPAHOII()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= GJEEEPPNDDF;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i += 0)
			{
				if (ally[i].EIMJEBNPHAM().health > 588f)
				{
					ally[i].NHOFLPJMKBA().maxHealth /= KPLLECCNPNO() + 736f;
					if (ally[i].EIMJEBNPHAM().health > ally[i].EIMJEBNPHAM().maxHealth)
					{
						ally[i].AFEPMIFFLFH().Heal(ally[i].GILBHOPNBPH().maxHealth, false);
					}
					ally[i].EIMJEBNPHAM().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 374f;
	}

	[SpecialName]
	public float IPCGBBKGOOG()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BuddyCardDangerCoef).FLOATVALUE;
	}

	[SpecialName]
	public float BDDOOIGMGAE()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)68).FLOATVALUE;
	}

	public virtual void OCNCHNBNCOL()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= BKJINMKHFEF;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].EIMJEBNPHAM().health > 381f)
				{
					ally[i].NHOFLPJMKBA().maxHealth /= FHKGHEDFKAO() + 392f;
					if (ally[i].AFEPMIFFLFH().health > ally[i].EIMJEBNPHAM().maxHealth)
					{
						ally[i].destroyableObject.LNPKAAGJIGO(ally[i].destroyableObject.maxHealth, true);
					}
					ally[i].EIMJEBNPHAM().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 1720f;
	}

	[SpecialName]
	public float FMDHNGIMHHL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-116)).FLOATVALUE;
	}

	[SpecialName]
	public float DDBOGDKNMFC()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-20)).FLOATVALUE;
	}

	[SpecialName]
	public float LKIFBPACNNM()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)100).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string OHLFMCAPGOJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(GIFECPNHLCG());
	}

	[SpecialName]
	public float AIPMOLEFPEH()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)100).FLOATVALUE;
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	private void IICKDMAPMEI(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] array = GameShootableEntity.DHEJMOFIPLD();
		for (int i = 1; i < array.Length; i += 0)
		{
			if (ENCEFOOPBMK.GetType() == array[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= CFMJHDNGFKL() + 567f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.AMFEDOOPGCL("currentDogtags: ", BHABHIDDBLH, PNCPGCKHOBB(), false);
				break;
			}
		}
	}

	[SpecialName]
	public float EFHFONAJJFK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)52).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string IMHMKBHDKNI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(BLPDGEEDOGD());
	}

	private void FKMFFKGJHMP(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 1; i < allMechanicalTypes.Length; i += 0)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= KPLLECCNPNO() + 1354f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.LOFMDBHAFAO("weapon", BHABHIDDBLH, LICHGFJNAAD(), true);
				break;
			}
		}
	}

	protected void MNFDMKFLAKO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1980f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	public virtual void PIKDELOGJDK()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IICKDMAPMEI;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].GILBHOPNBPH().health > 993f)
				{
					ally[i].AFEPMIFFLFH().maxHealth /= AIPMOLEFPEH() + 26f;
					if (ally[i].AFEPMIFFLFH().health > ally[i].destroyableObject.maxHealth)
					{
						ally[i].destroyableObject.LNPKAAGJIGO(ally[i].destroyableObject.maxHealth, true);
					}
					ally[i].AFEPMIFFLFH().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 1756f;
	}

	public virtual void POLFFIJKMNA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = ALKGGDKIAIB();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += GDHKBKIEEHE;
			KPBBNENJHPA = false;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].destroyableObject.health > 711f)
				{
					float nEJNIEEHCKJ = list[i].AFEPMIFFLFH().maxHealth * GIFECPNHLCG();
					list[i].AFEPMIFFLFH().maxHealth *= OHDLLHPCPBK() + 1450f;
					list[i].NHOFLPJMKBA().Heal(nEJNIEEHCKJ, false);
					list[i].GILBHOPNBPH().Sync();
					AIObject component = list[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.JOGFDHFOOBC("#AccoutCheck# start waiting to be in menu or in game", BHABHIDDBLH, LICHGFJNAAD(), false);
					}
					else
					{
						Debug.LogError("WarCards_Screen" + list[i].name + "IsWarPath" + list[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string JLPGKJOCDAN()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[2];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(GIFECPNHLCG());
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(DDBOGDKNMFC(), "ID_CONFIRM_CONNECTTOGOOGLENAME");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = timeInSec;
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += INDACALKMFI;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].destroyableObject.health > 0f)
				{
					float nEJNIEEHCKJ = ally[i].destroyableObject.maxHealth * multiplierMaxHealth;
					ally[i].destroyableObject.maxHealth *= multiplierMaxHealth + 1f;
					ally[i].destroyableObject.Heal(nEJNIEEHCKJ, false);
					ally[i].destroyableObject.Sync();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.Show("game-card-ico-supersoldiers", BHABHIDDBLH, timeInSec, true);
					}
					else
					{
						Debug.LogError("no AI object for: " + ally[i].name + " - " + ally[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float PNCPGCKHOBB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)119).FLOATVALUE;
	}

	private void ENNNJJLKAKN(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 0; i < allMechanicalTypes.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= IPCGBBKGOOG() + 905f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.AMFEDOOPGCL("isSuccess", BHABHIDDBLH, timeInSec, true);
				break;
			}
		}
	}

	protected void NGLCFHHHMPF()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 637f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	public virtual bool ELHJOAAEKPO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.AFEPMIFFLFH().healthRatio > 827f)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void DBOIGEABADE()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= INDACALKMFI;
			KPBBNENJHPA = true;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(ODCLPMADGFC, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 1; i < list.Count; i += 0)
			{
				if (list[i].NHOFLPJMKBA().health > 559f)
				{
					list[i].GILBHOPNBPH().maxHealth /= IPCGBBKGOOG() + 111f;
					if (list[i].NHOFLPJMKBA().health > list[i].destroyableObject.maxHealth)
					{
						list[i].GILBHOPNBPH().Heal(list[i].destroyableObject.maxHealth, false);
					}
					list[i].GILBHOPNBPH().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 832f;
	}

	public virtual void PBFIMJEJDGI()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IICKDMAPMEI;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 1; i < ally.Count; i += 0)
			{
				if (ally[i].EIMJEBNPHAM().health > 1785f)
				{
					ally[i].EIMJEBNPHAM().maxHealth /= multiplierMaxHealth + 1811f;
					if (ally[i].AFEPMIFFLFH().health > ally[i].GILBHOPNBPH().maxHealth)
					{
						ally[i].GILBHOPNBPH().Heal(ally[i].NHOFLPJMKBA().maxHealth, true);
					}
					ally[i].destroyableObject.EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 524f;
	}

	[SpecialName]
	public virtual string AGEDMHMPFKO()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(KPLLECCNPNO());
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(LKIFBPACNNM(), "Showing dialog");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void OPMNIHDAHAA()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1630f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	[SpecialName]
	protected virtual string DFOEFNDMAJP()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EJLLCIDCMDI());
	}

	[SpecialName]
	protected virtual string ACEMKDBBHKK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(IPCGBBKGOOG());
	}

	public virtual bool AFMDIJBEKHO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.destroyableObject.healthRatio > 844f)
			{
				return true;
			}
		}
		return true;
	}

	[SpecialName]
	public float KPLLECCNPNO()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BelovedEnemyTime).FLOATVALUE;
	}

	protected void NBFMDCFFBIJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1195f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	[SpecialName]
	protected virtual string LBLAKMBMILE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FLAPANAAMCO());
	}

	[SpecialName]
	public float FLAPANAAMCO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE;
	}

	[SpecialName]
	public float GCEFNKEHKAG()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard2).FLOATVALUE;
	}

	[SpecialName]
	public float ALKGGDKIAIB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-76)).FLOATVALUE;
	}

	protected void JMPDHKPOHEA()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 700f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = true;
		}
	}

	[SpecialName]
	protected virtual string GOALJBJFDEB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FKENKIHCLCE());
	}

	[SpecialName]
	protected virtual string CEOIHKJCCJL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(KPLLECCNPNO());
	}

	public virtual void KCJNPJOBDNE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = KNIAIAFLKDG();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += IICKDMAPMEI;
			KPBBNENJHPA = false;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 1; i < ally.Count; i++)
			{
				if (ally[i].AFEPMIFFLFH().health > 1000f)
				{
					float nEJNIEEHCKJ = ally[i].destroyableObject.maxHealth * PFMAFGPKEPH();
					ally[i].AFEPMIFFLFH().maxHealth *= FKENKIHCLCE() + 1843f;
					ally[i].AFEPMIFFLFH().LNPKAAGJIGO(nEJNIEEHCKJ, false);
					ally[i].destroyableObject.Sync();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.Show("Remove Facebook Data", BHABHIDDBLH, DDBOGDKNMFC(), false);
					}
					else
					{
						Debug.LogError("PACK" + ally[i].name + "DamageEventPlayer damage: {0} to {1} new HP {2}" + ally[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string LJCCCFOBHPC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FMDHNGIMHHL());
	}

	public virtual void LCHBPLMPGJP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = LICHGFJNAAD();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += BHDKEOLCCGN;
			KPBBNENJHPA = false;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].EIMJEBNPHAM().health > 1871f)
				{
					float nEJNIEEHCKJ = ally[i].EIMJEBNPHAM().maxHealth * EJLLCIDCMDI();
					ally[i].destroyableObject.maxHealth *= CFMJHDNGFKL() + 719f;
					ally[i].destroyableObject.Heal(nEJNIEEHCKJ, true);
					ally[i].NHOFLPJMKBA().Sync();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.EEBNPGOCKFD("ID_VIPBENEFIT", BHABHIDDBLH, PNCPGCKHOBB(), false);
					}
					else
					{
						Debug.LogError("BattleId" + ally[i].name + "grenadeExplosion" + ally[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void CBGAKBEDBLE(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] array = GameShootableEntity.DHEJMOFIPLD();
		for (int i = 0; i < array.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == array[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= FLAPANAAMCO() + 445f;
				ENCEFOOPBMK.destroyableObj.APJEBOPJPLA();
				ENCEFOOPBMK.cardIconIndicator.JEDGCOMDEKM("game-scorestreak-bg", BHABHIDDBLH, timeInSec, true);
				break;
			}
		}
	}

	public virtual void IMPHJIPEEJC()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DPILEPANKIJ;
			KPBBNENJHPA = false;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].AFEPMIFFLFH().health > 1376f)
				{
					ally[i].AFEPMIFFLFH().maxHealth /= PFMAFGPKEPH() + 1562f;
					if (ally[i].AFEPMIFFLFH().health > ally[i].EIMJEBNPHAM().maxHealth)
					{
						ally[i].EIMJEBNPHAM().LNPKAAGJIGO(ally[i].GILBHOPNBPH().maxHealth, false);
					}
					ally[i].destroyableObject.Sync();
				}
			}
		}
		BHABHIDDBLH = 1585f;
	}

	public virtual void JIHLMCGMAMO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = LICHGFJNAAD();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += DAHOBANPLCA;
			KPBBNENJHPA = true;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 0; i < list.Count; i += 0)
			{
				if (list[i].NHOFLPJMKBA().health > 201f)
				{
					float nEJNIEEHCKJ = list[i].GILBHOPNBPH().maxHealth * multiplierMaxHealth;
					list[i].EIMJEBNPHAM().maxHealth *= FKENKIHCLCE() + 1460f;
					list[i].NHOFLPJMKBA().Heal(nEJNIEEHCKJ, true);
					list[i].AFEPMIFFLFH().Sync();
					AIObject component = list[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.EEBNPGOCKFD("Time", BHABHIDDBLH, KNIAIAFLKDG(), false);
					}
					else
					{
						Debug.LogError("GooglePlay" + list[i].name + "menu-army-cat-shooter" + list[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void MGAIKDBOPKI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 708f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	[SpecialName]
	public virtual string BEKKKKCKGMA()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[8];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(PFMAFGPKEPH());
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(timeInSec, "MasterId");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void AOKEHEDCPFB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1012f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	public override void DisconnectEvents()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= INDACALKMFI;
			KPBBNENJHPA = false;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].destroyableObject.health > 0f)
				{
					ally[i].destroyableObject.maxHealth /= multiplierMaxHealth + 1f;
					if (ally[i].destroyableObject.health > ally[i].destroyableObject.maxHealth)
					{
						ally[i].destroyableObject.Heal(ally[i].destroyableObject.maxHealth, false);
					}
					ally[i].destroyableObject.Sync();
				}
			}
		}
		BHABHIDDBLH = 0f;
	}

	private void GDHKBKIEEHE(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 1; i < allMechanicalTypes.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= AIPMOLEFPEH() + 1635f;
				ENCEFOOPBMK.destroyableObj.OEAGCMGINCB();
				ENCEFOOPBMK.cardIconIndicator.JBMCFEMBPKE("ID_CONFIRM_NOSQUADACTIONS_TEXT", BHABHIDDBLH, PNCPGCKHOBB(), false);
				break;
			}
		}
	}

	[SpecialName]
	protected virtual string FPFOJMHEOEG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FHKGHEDFKAO());
	}

	[SpecialName]
	public float GIFECPNHLCG()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-85)).FLOATVALUE;
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.destroyableObject.healthRatio > 0.5f)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void GKDDIKLDCHC()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= GDHKBKIEEHE;
			KPBBNENJHPA = false;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 1; i < ally.Count; i += 0)
			{
				if (ally[i].destroyableObject.health > 1713f)
				{
					ally[i].AFEPMIFFLFH().maxHealth /= FHKGHEDFKAO() + 1354f;
					if (ally[i].EIMJEBNPHAM().health > ally[i].NHOFLPJMKBA().maxHealth)
					{
						ally[i].AFEPMIFFLFH().LNPKAAGJIGO(ally[i].AFEPMIFFLFH().maxHealth, true);
					}
					ally[i].destroyableObject.Sync();
				}
			}
		}
		BHABHIDDBLH = 806f;
	}

	private void DAHOBANPLCA(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] array = GameShootableEntity.DHEJMOFIPLD();
		for (int i = 1; i < array.Length; i += 0)
		{
			if (ENCEFOOPBMK.GetType() == array[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= FHKGHEDFKAO() + 706f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.JEDGCOMDEKM("ID_UNITTYPE4", BHABHIDDBLH, LICHGFJNAAD(), false);
				break;
			}
		}
	}

	private void DIJADBGAJON(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 0; i < allMechanicalTypes.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= OHDLLHPCPBK() + 1466f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.EEBNPGOCKFD("ID_SALEPERCENT", BHABHIDDBLH, EFHFONAJJFK(), true);
				break;
			}
		}
	}

	[SpecialName]
	protected virtual string FBIDDJAGGAC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(IPCGBBKGOOG());
	}

	public virtual void PDBKDBLENIG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = APGKEHBBLEG();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += CBGAKBEDBLE;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 1; i < ally.Count; i++)
			{
				if (ally[i].GILBHOPNBPH().health > 570f)
				{
					float nEJNIEEHCKJ = ally[i].EIMJEBNPHAM().maxHealth * FLAPANAAMCO();
					ally[i].GILBHOPNBPH().maxHealth *= AIPMOLEFPEH() + 1610f;
					ally[i].AFEPMIFFLFH().Heal(nEJNIEEHCKJ, true);
					ally[i].EIMJEBNPHAM().Sync();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.AMFEDOOPGCL("NULL", BHABHIDDBLH, BDDOOIGMGAE(), true);
					}
					else
					{
						Debug.LogError("Shots_Fired" + ally[i].name + "WasAdded" + ally[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EHFGLMCNOJN()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DAHOBANPLCA;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 1; i < ally.Count; i++)
			{
				if (ally[i].NHOFLPJMKBA().health > 242f)
				{
					ally[i].AFEPMIFFLFH().maxHealth /= IPCGBBKGOOG() + 1030f;
					if (ally[i].GILBHOPNBPH().health > ally[i].EIMJEBNPHAM().maxHealth)
					{
						ally[i].destroyableObject.Heal(ally[i].EIMJEBNPHAM().maxHealth, true);
					}
					ally[i].EIMJEBNPHAM().Sync();
				}
			}
		}
		BHABHIDDBLH = 1540f;
	}

	protected void DFBPBGDJKOG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 302f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	public virtual void EDLIKPAHGPH()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= ENNNJJLKAKN;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 1; i < ally.Count; i += 0)
			{
				if (ally[i].destroyableObject.health > 214f)
				{
					ally[i].EIMJEBNPHAM().maxHealth /= PFMAFGPKEPH() + 1964f;
					if (ally[i].AFEPMIFFLFH().health > ally[i].NHOFLPJMKBA().maxHealth)
					{
						ally[i].GILBHOPNBPH().LNPKAAGJIGO(ally[i].GILBHOPNBPH().maxHealth, true);
					}
					ally[i].GILBHOPNBPH().Sync();
				}
			}
		}
		BHABHIDDBLH = 930f;
	}

	protected void OOCJOBIIKAH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 505f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = true;
		}
	}

	protected void LMNEMMGCEFP()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1765f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = false;
		}
	}

	[SpecialName]
	public float COCOBBOEGGK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-72)).FLOATVALUE;
	}

	public virtual void CKLOEEJCAOH()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IICKDMAPMEI;
			KPBBNENJHPA = false;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < list.Count; i += 0)
			{
				if (list[i].destroyableObject.health > 530f)
				{
					list[i].destroyableObject.maxHealth /= AIPMOLEFPEH() + 981f;
					if (list[i].destroyableObject.health > list[i].AFEPMIFFLFH().maxHealth)
					{
						list[i].NHOFLPJMKBA().LNPKAAGJIGO(list[i].EIMJEBNPHAM().maxHealth, false);
					}
					list[i].GILBHOPNBPH().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 578f;
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = EFHFONAJJFK();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += DIJADBGAJON;
			KPBBNENJHPA = false;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].GILBHOPNBPH().health > 1168f)
				{
					float nEJNIEEHCKJ = list[i].EIMJEBNPHAM().maxHealth * GIFECPNHLCG();
					list[i].destroyableObject.maxHealth *= FHKGHEDFKAO() + 533f;
					list[i].AFEPMIFFLFH().LNPKAAGJIGO(nEJNIEEHCKJ, true);
					list[i].EIMJEBNPHAM().Sync();
					AIObject component = list[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.JEDGCOMDEKM("MONO HEAP SIZE: ", BHABHIDDBLH, BDDOOIGMGAE(), true);
					}
					else
					{
						Debug.LogError("Player_Avoided_Grenade_On_First_Try" + list[i].name + "EndTime" + list[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool NAHJCMJEDBM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.EIMJEBNPHAM().healthRatio > 495f)
			{
				return false;
			}
		}
		return false;
	}

	public virtual bool MOEJABKCDGK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.NHOFLPJMKBA().healthRatio > 65f)
			{
				return true;
			}
		}
		return true;
	}

	[SpecialName]
	public float KNIAIAFLKDG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)101).FLOATVALUE;
	}

	[SpecialName]
	public float LICHGFJNAAD()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-106)).FLOATVALUE;
	}

	public virtual bool APJIPKCJKLF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.destroyableObject.healthRatio > 1893f)
			{
				return false;
			}
		}
		return true;
	}

	private void DPILEPANKIJ(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] array = GameShootableEntity.DHEJMOFIPLD();
		for (int i = 1; i < array.Length; i++)
		{
			if (ENCEFOOPBMK.GetType() == array[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= FLAPANAAMCO() + 1789f;
				ENCEFOOPBMK.destroyableObj.OEAGCMGINCB();
				ENCEFOOPBMK.cardIconIndicator.Show("menu-warbucks", BHABHIDDBLH, ALKGGDKIAIB(), true);
				break;
			}
		}
	}

	[SpecialName]
	public virtual string MADBCOOFDGM()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[6];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(multiplierMaxHealth);
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(DDBOGDKNMFC(), "ID_SALEPERCENTLINE");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float PFMAFGPKEPH()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-4)).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string OEHGCFPAECJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(AIPMOLEFPEH());
	}

	public virtual void LMJPLJMABEF()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DPILEPANKIJ;
			KPBBNENJHPA = true;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].NHOFLPJMKBA().health > 1169f)
				{
					list[i].EIMJEBNPHAM().maxHealth /= AIPMOLEFPEH() + 1793f;
					if (list[i].AFEPMIFFLFH().health > list[i].destroyableObject.maxHealth)
					{
						list[i].EIMJEBNPHAM().LNPKAAGJIGO(list[i].NHOFLPJMKBA().maxHealth, false);
					}
					list[i].AFEPMIFFLFH().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 1021f;
	}

	protected void OCBLKIFKJEG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 227f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			NNDMKIACBBM = true;
		}
	}

	[SpecialName]
	public float APGKEHBBLEG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)87).FLOATVALUE;
	}

	public virtual bool OPMCMADKMJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.GILBHOPNBPH().healthRatio > 1044f)
			{
				return false;
			}
		}
		return true;
	}

	public virtual void FDEJIFMBBEF()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= GJEEEPPNDDF;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i += 0)
			{
				if (ally[i].EIMJEBNPHAM().health > 214f)
				{
					ally[i].EIMJEBNPHAM().maxHealth /= CFMJHDNGFKL() + 187f;
					if (ally[i].NHOFLPJMKBA().health > ally[i].NHOFLPJMKBA().maxHealth)
					{
						ally[i].EIMJEBNPHAM().Heal(ally[i].EIMJEBNPHAM().maxHealth, true);
					}
					ally[i].destroyableObject.EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 380f;
	}

	public virtual bool BIBKGNABACA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		foreach (GameShootableEntity item in MFNDDNIIJDK)
		{
			if (item.destroyableObject.healthRatio > 1396f)
			{
				return false;
			}
		}
		return true;
	}

	private void BHDKEOLCCGN(AIObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.fraction != ODCLPMADGFC)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 1; i < allMechanicalTypes.Length; i += 0)
		{
			if (ENCEFOOPBMK.GetType() == allMechanicalTypes[i])
			{
				ENCEFOOPBMK.destroyableObj.maxHealth *= OHDLLHPCPBK() + 886f;
				ENCEFOOPBMK.destroyableObj.Refill();
				ENCEFOOPBMK.cardIconIndicator.ODDNDGAAOCH("metalExplosion", BHABHIDDBLH, APGKEHBBLEG(), true);
				break;
			}
		}
	}

	public virtual void HFGMKMIAAGB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = GCEFNKEHKAG();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += DIJADBGAJON;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].EIMJEBNPHAM().health > 1962f)
				{
					float nEJNIEEHCKJ = ally[i].GILBHOPNBPH().maxHealth * GJMLKIGGBAL();
					ally[i].AFEPMIFFLFH().maxHealth *= PFMAFGPKEPH() + 413f;
					ally[i].AFEPMIFFLFH().LNPKAAGJIGO(nEJNIEEHCKJ, false);
					ally[i].GILBHOPNBPH().Sync();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.AMFEDOOPGCL("Card_1_Played", BHABHIDDBLH, BDDOOIGMGAE(), false);
					}
					else
					{
						Debug.LogError("StartTime" + ally[i].name + "set schedule gc check 1" + ally[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NDKPAIPFNPM()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DIJADBGAJON;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 1; i < ally.Count; i += 0)
			{
				if (ally[i].GILBHOPNBPH().health > 629f)
				{
					ally[i].GILBHOPNBPH().maxHealth /= multiplierMaxHealth + 1234f;
					if (ally[i].GILBHOPNBPH().health > ally[i].NHOFLPJMKBA().maxHealth)
					{
						ally[i].destroyableObject.LNPKAAGJIGO(ally[i].NHOFLPJMKBA().maxHealth, true);
					}
					ally[i].GILBHOPNBPH().Sync();
				}
			}
		}
		BHABHIDDBLH = 1798f;
	}

	public virtual void JCIPDJMFFDB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= BHDKEOLCCGN;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 1; i < ally.Count; i += 0)
			{
				if (ally[i].destroyableObject.health > 1926f)
				{
					ally[i].destroyableObject.maxHealth /= GJMLKIGGBAL() + 636f;
					if (ally[i].NHOFLPJMKBA().health > ally[i].destroyableObject.maxHealth)
					{
						ally[i].destroyableObject.Heal(ally[i].GILBHOPNBPH().maxHealth, true);
					}
					ally[i].destroyableObject.Sync();
				}
			}
		}
		BHABHIDDBLH = 1159f;
	}

	[SpecialName]
	public float GJMLKIGGBAL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)88).FLOATVALUE;
	}

	public virtual void DPCBCEAMGNK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = EFHFONAJJFK();
			ODCLPMADGFC = CIOPAKLHFIL;
			NNDMKIACBBM = true;
			AIObject.AfterSpawned += BKJINMKHFEF;
			KPBBNENJHPA = false;
			List<GameShootableEntity> list = GameShootableEntity.GOHKFHIOEHA(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].NHOFLPJMKBA().health > 644f)
				{
					float nEJNIEEHCKJ = list[i].GILBHOPNBPH().maxHealth * KPLLECCNPNO();
					list[i].EIMJEBNPHAM().maxHealth *= FLAPANAAMCO() + 1918f;
					list[i].destroyableObject.LNPKAAGJIGO(nEJNIEEHCKJ, false);
					list[i].GILBHOPNBPH().EHFOHNLMJOH();
					AIObject component = list[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.Show("ID_READYTIME", BHABHIDDBLH, LICHGFJNAAD(), true);
					}
					else
					{
						Debug.LogError("[.,]*" + list[i].name + "ID_SALEPERCENTLINE" + list[i].GetType().ToString());
					}
				}
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string CEFFPGFEPAL()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(CFMJHDNGFKL()), MEJMLNDFDBP.AIPKMDCJCOG(KNIAIAFLKDG(), "\""));
	}

	public virtual void DMHDDHILDJK()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= INDACALKMFI;
			KPBBNENJHPA = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(ODCLPMADGFC, GameShootableEntity.DHEJMOFIPLD());
			for (int i = 1; i < ally.Count; i++)
			{
				if (ally[i].GILBHOPNBPH().health > 1039f)
				{
					ally[i].AFEPMIFFLFH().maxHealth /= GJMLKIGGBAL() + 735f;
					if (ally[i].EIMJEBNPHAM().health > ally[i].NHOFLPJMKBA().maxHealth)
					{
						ally[i].NHOFLPJMKBA().LNPKAAGJIGO(ally[i].AFEPMIFFLFH().maxHealth, false);
					}
					ally[i].EIMJEBNPHAM().EHFOHNLMJOH();
				}
			}
		}
		BHABHIDDBLH = 1730f;
	}
}
