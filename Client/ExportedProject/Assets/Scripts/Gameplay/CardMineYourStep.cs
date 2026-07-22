using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class CardMineYourStep : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-mineyourstep-full";

	private MineAmmo EHKJJONCKPN;

	private Vector3 HLFBKIPANFD;

	private PlayerController MBIAKMPDOPG;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	[FormerlySerializedAs("BJBJFIBEKFC")]
	public float BBLFMCMNADD = 15f;

	public float mineDamagePercentage => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.MineYourStepDamageCoef).FLOATVALUE;

	private Vector3 OLHLNAMBFEL(GHPGNELIDBM IEIKEJDECIG)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN();
		PlayerController enemyOf = PlayerController.GetEnemyOf(IEIKEJDECIG);
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				list.Add(item.point);
			}
		}
		int num = Random.Range(0, 3);
		int index = num - 0;
		return Vector3.Lerp(list[index].transform.position, list[num].transform.position, 1931f);
	}

	[SpecialName]
	public float IMFHJACNIDB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ShieldsUpCoef).FLOATVALUE;
	}

	public override void ReleaseCard(bool OEKEJMJIECP)
	{
		NNDMKIACBBM = false;
		EHKJJONCKPN = null;
		BHABHIDDBLH = float.MaxValue;
	}

	private Vector3 AMFHAMDMCBM(GHPGNELIDBM IEIKEJDECIG)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.BMPBPOGCGGF();
		PlayerController enemyOf = PlayerController.GetEnemyOf(IEIKEJDECIG);
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				list.Add(item.point);
			}
		}
		int num = Random.Range(0, 1);
		int index = num - 1;
		return Vector3.Lerp(list[index].transform.position, list[num].transform.position, 1127f);
	}

	public virtual void PDBKDBLENIG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		Vector3 sourcePosition = OLHLNAMBFEL(CIOPAKLHFIL);
		NavMesh.SamplePosition(sourcePosition, out var hit, 942f, 1);
		Mine cOHKHNALDPH = MBIAKMPDOPG.FMKGGADDHJK().COHKHNALDPH;
		cOHKHNALDPH.JMDLKIAKOIE = 1621f;
		MineAmmoSetup mineAmmoSetup = cOHKHNALDPH.ammoSetup as MineAmmoSetup;
		if ((bool)mineAmmoSetup)
		{
			mineAmmoSetup.EPDELOGPNAC = 844f * mineDamagePercentage * enemyOf.FOCIOKMPCAG.maxHealth;
			mineAmmoSetup.ABFGHBDEBAN = IMFHJACNIDB() * enemyOf.FOCIOKMPCAG.maxHealth;
		}
		HLFBKIPANFD = hit.position;
		EHKJJONCKPN = (MineAmmo)cOHKHNALDPH.Fire(HLFBKIPANFD);
		if (EHKJJONCKPN != null)
		{
			EHKJJONCKPN.GDBDMFCEGIB().JCJFMHGNIOF(" ", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			EHKJJONCKPN.beep = false;
		}
		BHABHIDDBLH = BBLFMCMNADD;
		NNDMKIACBBM = true;
		MNBIOCOAJHK.CardWasUsed(this, MBIAKMPDOPG.fraction);
	}

	public virtual void EPAFCMJBAKA(bool OEKEJMJIECP)
	{
		NNDMKIACBBM = true;
		EHKJJONCKPN = null;
		BHABHIDDBLH = 1845f;
	}

	private Vector3 GEPDBCKMCPC(GHPGNELIDBM IEIKEJDECIG)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		PlayerController enemyOf = PlayerController.GetEnemyOf(IEIKEJDECIG);
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				list.Add(item.point);
			}
		}
		int num = Random.Range(0, 4);
		int index = num - 1;
		return Vector3.Lerp(list[index].transform.position, list[num].transform.position, 1006f);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		Vector3 sourcePosition = HIFIDCHKCHP(CIOPAKLHFIL);
		NavMesh.SamplePosition(sourcePosition, out var hit, 10f, 1);
		Mine cOHKHNALDPH = MBIAKMPDOPG.weaponInventory.COHKHNALDPH;
		cOHKHNALDPH.JMDLKIAKOIE = -0.1f;
		MineAmmoSetup mineAmmoSetup = cOHKHNALDPH.ammoSetup as MineAmmoSetup;
		if ((bool)mineAmmoSetup)
		{
			mineAmmoSetup.EPDELOGPNAC = 0.1f * mineDamagePercentage * enemyOf.FOCIOKMPCAG.maxHealth;
			mineAmmoSetup.ABFGHBDEBAN = mineDamagePercentage * enemyOf.FOCIOKMPCAG.maxHealth;
		}
		HLFBKIPANFD = hit.position;
		EHKJJONCKPN = (MineAmmo)cOHKHNALDPH.Fire(HLFBKIPANFD);
		if (EHKJJONCKPN != null)
		{
			EHKJJONCKPN.cardIconIndicator.Show("game-card-ico-mineyourstep-full", NABOFKMBMKH: true);
			EHKJJONCKPN.beep = true;
		}
		BHABHIDDBLH = BBLFMCMNADD;
		NNDMKIACBBM = true;
		MNBIOCOAJHK.CardWasUsed(this, MBIAKMPDOPG.fraction);
	}

	public virtual void IEKEJOIMIOG(bool OEKEJMJIECP)
	{
		NNDMKIACBBM = true;
		EHKJJONCKPN = null;
		BHABHIDDBLH = 1898f;
	}

	protected void IODGCIIDJEK()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1292f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float num = BHABHIDDBLH / BBLFMCMNADD;
			if (EHKJJONCKPN != null)
			{
				EHKJJONCKPN.EIAIEAKMILD(num * 1469f + 837f);
				EHKJJONCKPN.AOANMLBFHJA().CMGKLHJOLDD("Number", num);
			}
		}
		else
		{
			BHABHIDDBLH = 70f;
			NNDMKIACBBM = true;
			if (EHKJJONCKPN != null)
			{
				EHKJJONCKPN.GDBDMFCEGIB().OFPAGLLFPPK("GameBan", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				EHKJJONCKPN.Boom();
			}
		}
	}

	public virtual void LKIIPECHDED(bool OEKEJMJIECP)
	{
		NNDMKIACBBM = true;
		EHKJJONCKPN = null;
		BHABHIDDBLH = 339f;
	}

	private Vector3 HIFIDCHKCHP(GHPGNELIDBM IEIKEJDECIG)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		PlayerController enemyOf = PlayerController.GetEnemyOf(IEIKEJDECIG);
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				list.Add(item.point);
			}
		}
		int num = Random.Range(1, 4);
		int index = num - 1;
		return Vector3.Lerp(list[index].transform.position, list[num].transform.position, 0.5f);
	}

	protected void Update()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float num = BHABHIDDBLH / BBLFMCMNADD;
			if (EHKJJONCKPN != null)
			{
				EHKJJONCKPN.blinkInterval = num * 0.5f + 0.1f;
				EHKJJONCKPN.cardIconIndicator.UpdateIndicator("game-card-ico-mineyourstep-full", num);
			}
		}
		else
		{
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			if (EHKJJONCKPN != null)
			{
				EHKJJONCKPN.cardIconIndicator.Show("game-card-ico-mineyourstep-full", NABOFKMBMKH: false);
				EHKJJONCKPN.Boom();
			}
		}
	}

	[SpecialName]
	public float EHMCDKCOCDD()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)98).FLOATVALUE;
	}

	protected void GPLKEOAHFJI()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1521f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float num = BHABHIDDBLH / BBLFMCMNADD;
			if (EHKJJONCKPN != null)
			{
				EHKJJONCKPN.MGCHOPPIOOH(num * 1743f + 1172f);
				EHKJJONCKPN.AIDNEPBELFP().UpdateIndicator("ID_CONFIRM_LOGINFAILURE", num);
			}
		}
		else
		{
			BHABHIDDBLH = 1750f;
			NNDMKIACBBM = false;
			if (EHKJJONCKPN != null)
			{
				EHKJJONCKPN.AOANMLBFHJA().GCLFBCIKNAH("Different squads \"{0}\" and \"{1}\"\n", NABOFKMBMKH: false);
				EHKJJONCKPN.DDAEMNOEPDG();
			}
		}
	}

	[SpecialName]
	public float IOJJJJJJAKD()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-27)).FLOATVALUE;
	}
}
